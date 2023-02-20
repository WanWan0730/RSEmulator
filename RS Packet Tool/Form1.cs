using RSLIB;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RS_Packet_Tool
{
    public partial class Form1 : Form
    {

        private Socket socket;

        public Form1()
        {
            InitializeComponent();
            this.SetConnection();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.socket.Shutdown(SocketShutdown.Both);
            this.socket.Close();
        }

        private void decrypt_button_Click(object sender, EventArgs e)
        {

            if (crypted_field.Text == "")
            {
                MessageBox.Show("Insira uma string em hexadecimal");
            } else
            {
                byte[] data = RSLIB.Helper.HexStringToByte(crypted_field.Text);
                NetworkPacket packetWorker = new(data);
                byte[] decrypted = packetWorker.Decrypt();
                packet_length.Text = BitConverter.ToString(packetWorker.packetLength);
                decode_key.Text = BitConverter.ToString(packetWorker.decodeKeyBytes);
                decode_key_field.Text = packetWorker.cipherId.ToString();
                decrypted_field.Text = BitConverter.ToString(decrypted).Replace("-", "");
                utf8_view.Text = Encoding.ASCII.GetString(decrypted).Replace("\0", ".");
            }
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            byte[] data = RSLIB.Helper.HexStringToByte(crypted_field.Text);
            NetworkPacket packetWorker = new(data);
            Console.WriteLine(uint.Parse(decode_key_field.Text));
            packetWorker.cipherId = uint.Parse(decode_key_field.Text);
            byte[] decrypted = packetWorker.Encrypt();
            decrypted_field.Text = BitConverter.ToString(decrypted).Replace("-", "");
            utf8_view.Text = Encoding.ASCII.GetString(decrypted).Replace("\0", ".");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (crypted_field.Text == "")
            {
                MessageBox.Show("Insira uma string em hexadecimal");
            }
            else
            {
                byte[] data = Convert.FromHexString("05000F27" + crypted_field.Text.Replace(" ", ""));
                this.socket.Send(data);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.SetConnection();
        }

        private void SetConnection()
        {
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = IPAddress.Parse("127.0.0.1");

            this.socket.Connect(new IPEndPoint(ip, int.Parse(port_field.Text)));
        }
    }
}