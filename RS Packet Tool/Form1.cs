using RSLIB;
using System.Text;

namespace RS_Packet_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void decrypt_button_Click(object sender, EventArgs e)
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
     
    }
}