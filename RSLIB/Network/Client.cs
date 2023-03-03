using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Network
{
    public class Client
    {
        public Socket socket;
        public string id;
        private Server server;
        private Boolean running;
        private byte[] buffer = new byte[1024];
        public Dictionary<string, object> info = new Dictionary<string, object>();
        private Dictionary<uint, INetworkPacketAdapter> packets;

        public Client(Socket socket, string id, Dictionary<uint, INetworkPacketAdapter> packets, Server server) 
        {
            this.packets= packets;
            this.running = true;
            this.socket = socket;
            this.id = id;
            this.server= server;

            Log.Info($"Client id {this.id} connected to the server");

            this.socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, this.HandleData, null);
        }

        private void HandleData(IAsyncResult data)
        {
            try
            {
                if (this.running)
                {
                    Int32 size = this.socket.EndReceive(data);
                    if (size > 0)
                    {
                        Array.Resize(ref this.buffer, size);
                        uint PacketID = Helper.GetCipherID(Helper.BytesToString(this.buffer));
                        if (this.packets.TryGetValue(PacketID, out INetworkPacketAdapter? adapter))
                        {
                            adapter.SetParams(this, this.server, this.buffer);
                        } else
                        {
                           Log.Warning($"[{PacketID}] Network packet not implemented.\n{Helper.BytesToString(this.buffer)}");
                        }
                    } else
                    {
                        this.server.RemoveClient(this.id);
                        Log.Info($"Client id {this.id} disconnected");
                        this.running = false;
                        this.socket.Close();
                    }
                }
            } catch (Exception ex) {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                if(this.running)
                {
                    this.buffer = new byte[1014];
                    this.socket?.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, this.HandleData, null);
                }
            }
        }
    }
}
