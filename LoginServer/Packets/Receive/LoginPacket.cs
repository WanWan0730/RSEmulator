using LoginServer.Packets;
using LoginServer.Packets.Send;
using Org.BouncyCastle.Crypto.Generators;
using RSLIB;
using RSLIB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class LoginPacket : IPacketHandler
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
        private Client? client;

        public void Run()
        {
            this.ExtractData();

            LoginPacketResult loginResult = new LoginPacketResult();
            loginResult.SetPacketAndClient(packet, client);
            
            UserModel user = new UserModel(this.username, this.password);
            if (user.Exists())
            {
                LoginModel usersLogin = new LoginModel(this.username, this.macAddress, this.serverName, this.client.clientID);
                if (!usersLogin.IsLoggedIn())
                {
                    usersLogin.RegisterUserLogin();
                    loginResult.SuccessfullyLoggedIn();
                    this.client.username = this.username;
                } else
                {
                    loginResult.AlreadyLoggedIn();
                }

                CharacterListPacket characterListPacket = new();
                characterListPacket.SetPacketAndClient(packet, client);
                characterListPacket.Run();
            }
            else
            {
                loginResult.InvalidCredentials();
            }

        }

        public void SetPacketAndClient(byte[] packet, Client client)
        {
            this.packet = packet;
            this.client = client;
        }

        private void ExtractData()
        {
            NetworkPacket packetWorker = new NetworkPacket(packet);
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
