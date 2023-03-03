using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RSLIB;
using WorldServer.Settings;
using WorldServer;

namespace WorldServer
{
    public class World
    {
        public Boolean active = false;
        public Socket socket = null;
        public byte ServerID = 0;
        public Client[] clients = null;

        public World(Byte ServerID, string IP)
        {

            try
            {
                IPAddress ipAdress = null;

                if (IPAddress.TryParse(IP, out ipAdress))
                {
                    IPEndPoint ipEndpoint = new IPEndPoint(ipAdress, Config.SERVER_PORT);
                    this.clients = new Client[Config.MAX_CONNECTIONS + 1];
                    for (Int32 i = 0; i < clients.Length; i++)
                    {
                        this.clients[i] = null;
                    }
                    this.active = true;
                    this.ServerID = ServerID;
                    this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.socket.Bind(ipEndpoint);
                    this.socket.Listen(0);

                    Log.Info($"[Server ID: {this.ServerID}] World server running at port {Config.SERVER_PORT}");

                    this.socket.BeginAccept(this.WaitConnection, null);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }


        private void WaitConnection(IAsyncResult result)
        {
            try
            {
                if (this.active)
                {
                    Socket newClient = this.socket.EndAccept(result);
                    Int16 newClientID = this.GetFreeClientID();

                    if (newClientID > 0)
                    {
                        this.clients[newClientID] = new Client(newClient, this.ServerID, newClientID, this);
                    } else
                    {
                        Log.Warning($"[{this.ServerID}] New connection refused, server full {clients.Length - 1} of {Config.MAX_CONNECTIONS} clients connected now");
                        newClient.Close();
                        newClient = null;
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
                    this.socket.BeginAccept(this.WaitConnection, null);
                }
            }
        }

        public void RemoveClientByClientID(Int16 clientID)
        {
            this.clients[clientID] = null;
        }

        private Int16 GetFreeClientID()
        {
            try
            {
                for (Int16 i = 1; i < this.clients.Length; i++)
                {
                    if (this.clients[i] == null)
                    {
                        return i;
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
            return 0;
        }
    }
}
