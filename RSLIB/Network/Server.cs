using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Network
{
    public class Server
    {
        private Socket socket;
        private Boolean running = false;
        private Dictionary<string, Client> clients = new Dictionary<string, Client>();
        private string prefix;
        private string IP;
        private int PORT;
        private int LIMIT_OF_CONNECTIONS;
        private Dictionary<uint, INetworkPacketAdapter> packets = new Dictionary<uint, INetworkPacketAdapter>();

        public Server(string IP, int PORT, string prefix = "", int limitOfConnections = 1000)
        {
            this.IP = IP;
            this.PORT = PORT;
            this.prefix = prefix;
            this.LIMIT_OF_CONNECTIONS = limitOfConnections;
            this.SetWindowTitle();
        }

        public void InitializeInterceptor(Dictionary<uint, INetworkPacketAdapter> NetworkPacketAdapter)
        {
            this.packets = NetworkPacketAdapter;
            try
            {
                if (IPAddress.TryParse(this.IP, out IPAddress? IP))
                { 
                    IPEndPoint endpoint = new IPEndPoint(IP, this.PORT);
                    this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.socket.Bind(endpoint);
                    this.socket.Listen(0);
                    this.running = true;
                    Log.Info($"[{this.prefix} Server] running at port {this.PORT}");
                    this.socket.BeginAccept(this.Handler, null);
                }
            } catch(Exception ex)
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }

        public void RemoveClient(string id)
        {
            if ( this.clients.TryGetValue(id, out Client _) )
            {
                this.clients.Remove(id);
            }
        }

        private void Handler(IAsyncResult data)
        {
            try
            {
                if (this.running) 
                {
                    if ( this.clients.Count <= this.LIMIT_OF_CONNECTIONS )
                    {
                        Socket newClientSocket = this.socket.EndAccept(data);
                        string newClientID = Nanoid.Nanoid.Generate();
                        this.clients.Add(newClientID, new Client(newClientSocket, newClientID, this.packets, this));
                    } else
                    {
                        Log.Warning($"New connection refused, server is full at moment.");
                    }
                }
            } 
            catch (Exception ex) 
            {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                if(this.running)
                {
                    this.socket.BeginAccept(this.Handler, null);
                }
            }
        }

        private void SetWindowTitle()
        {
            Console.Title = prefix;
        }

    }
}
