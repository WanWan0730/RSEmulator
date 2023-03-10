using LoginServer.Packets;
using LoginServer.Packets.Send;
using Org.BouncyCastle.Crypto.Generators;
using RSLIB;
using RSLIB.Database;
using RSLIB.Database.Models;
using RSLIB.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class LoginPacket : INetworkPacketAdapter
    {
        const int CREDENTIAL_SIZE = 20;
        const int SERVER_NAME_SIZE = 18;
        const int MAC_ADDRESS_SIZE = 20;
        const int TRASH_JUMP_SIZE = 58;
        const int CLIENT_VERSION_SIZE = 2;
        const int SECURE_CODE_SIZE = 2;

        public uint? clientVersion;
        public string? serverName;
        public string? macAddress;
        public string? username;
        public string? password;

        private byte[] packet = new byte[0];
        private RSLIB.Network.Client client;
        private RSLIB.Network.Server server;

        public void SetParams(RSLIB.Network.Client client, Server server, byte[] buffer)
        {
            this.client = client;
            this.server = server;
            this.packet = buffer;

            this.Run();
        }

        private void Run()
        {
            this.ExtractData();

            LoginPacketResult loginResult = new LoginPacketResult();
            loginResult.SetPacketAndClient(client);

            using var db = new RedStoneContext();
            
            var user = db?.Users?.Where(context => context.Username == this.username).FirstOrDefault();
            
            if (user != null)
            {
                var session = db?.Sessions?.Where(context => context.Username!= this.username).FirstOrDefault();

                this.client.info.TryAdd("username", this.username);
                if (session == null)
                {
                    db?.Sessions?.Add(new Session { Username = this.username, ClientId = this.client.id, ServerName = this.serverName, MacAddress = this.macAddress });
                    db.SaveChanges();
                    loginResult.SuccessfullyLoggedIn();
                } else
                {
                    loginResult.AlreadyLoggedIn();
                }

                CharacterListPacket characterListPacket = new();
                characterListPacket.SetPacketAndClient(packet, this.client);
                characterListPacket.Run();
            }
            else
            {
                loginResult.InvalidCredentials();
            }

        }
        
       

        private void ExtractData()
        {
            NetworkSecurity packetWorker = new NetworkSecurity(packet);
            byte[] decrypted = packetWorker.Decrypt();

            this.clientVersion = Helper.GetReadUint16(decrypted);
            decrypted = Helper.JumpBytesFromBebin(decrypted, CLIENT_VERSION_SIZE);

            byte[] encryptedUsername = Helper.GetBytesFromBegin(decrypted, CREDENTIAL_SIZE);
            decrypted = Helper.JumpBytesFromBebin(decrypted, CREDENTIAL_SIZE);

            byte[] encryptedPassword = Helper.GetBytesFromBegin(decrypted, CREDENTIAL_SIZE);
            decrypted = Helper.JumpBytesFromBebin(decrypted, CREDENTIAL_SIZE);

            this.serverName = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, SERVER_NAME_SIZE)));
            decrypted = Helper.JumpBytesFromBebin(decrypted, SERVER_NAME_SIZE);

            this.macAddress = Encoding.UTF8.GetString(Helper.GetBytesUntilNull(Helper.GetBytesFromBegin(decrypted, MAC_ADDRESS_SIZE)));
            decrypted = Helper.JumpBytesFromBebin(decrypted, MAC_ADDRESS_SIZE);

            decrypted = Helper.JumpBytesFromBebin(decrypted, TRASH_JUMP_SIZE);

            ushort usernameSecureCode = Helper.GetReadUint16(decrypted);
            decrypted = Helper.JumpBytesFromBebin(decrypted, SECURE_CODE_SIZE);
            ushort passwordSecureCode = Helper.GetReadUint16(decrypted);

            this.username = Encoding.UTF8.GetString(this.DecodeLoginString(usernameSecureCode, encryptedUsername));
            this.password = Encoding.UTF8.GetString(this.DecodeLoginString(passwordSecureCode, encryptedPassword));
        }

        private byte[] DecodeLoginString(ushort securityCode, byte[] str)
        {
            const uint EncryptionSeed = 0x64;
            var rand = new CryptRandom(securityCode);
            uint range = securityCode % EncryptionSeed + EncryptionSeed;
            uint sum = 0;
            List<byte> decoded = new List<byte>();
            foreach (byte b in str)
            {
                sum += b;
                decoded.Add((byte)(b - (byte)rand.Next(range)));
            }
            return Helper.GetBytesUntilNull(decoded.ToArray());
        }

        
    }
}
