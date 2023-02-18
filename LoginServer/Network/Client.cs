using LoginServer.Packets.Send;
using LoginServer.Settings;
using RSLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class Client
    {

        public Boolean active = false;
        public Socket? socket = null;
        public Int16 clientID = 0;
        public Byte serverID = 0;
        public Login server;
        public PacketHandler packetHandler = null;

        public byte[]? buffer = null;

        public Client(Socket socket, Byte ServerID, Int16 ClientID, Login server)
        {
            try
            {
                this.active= true;
                this.socket = socket;
                this.serverID= ServerID;
                this.server = server;
                this.clientID = ClientID;
                Log.Success($"[Server ID: {this.serverID}][Client ID: {this.clientID}] New connected to the server!");
                this.buffer = new byte[1024];
                this.socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, this.WaitData, null);

            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }

        private void WaitData(IAsyncResult result)
        {
            try
            {
                if (this.active)
                {
                    Int32 size = this.socket.EndReceive(result);
                    if (size > 0)
                    {
                        Array.Resize(ref this.buffer, size);

                        this.packetHandler = new PacketHandler();
                        this.packetHandler.Execute(this.buffer, this);

                        //ServerListPacket serverList = new(Config.SERVER_NAME, this.socket);

                    } else
                    {
                        this.server.RemoveClientByClientID(this.clientID);
                        Log.Warning($"[Server ID: {this.serverID}][Client ID: {this.clientID}] a client disconnected");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                if (this.active)
                {
                    this.buffer = new byte[1024];
                    this.socket?.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, this.WaitData, null);
                }
                    
            } 
        }

        public void Close()
        {
            try
            {
                if (this.active) { 
                    this.active= false;
                    this.socket?.Close();
                    this.socket = null;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }
        
    }
}
