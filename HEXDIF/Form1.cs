namespace HEXDIF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string field1Text = input_1.Text;
            string field2Text = input_2.Text;

            byte[] field1 = Convert.FromHexString(field1Text.Replace(" ", ""));
            byte[] field2 = Convert.FromHexString(field2Text.Replace(" ", ""));


            int counter = 0;
            string result = "";
            

            try
            {
                
                int len = int.Parse(len_field.Text);
                int offset_count = 0;
                List<string> list = new List<string>();
                for (int index = 0; index < field1.Length; index++)
                {
                    counter++;
                    if (field1[index].ToString("X") != field2[index].ToString("X"))
                    {
                        result += $"offset {index}, V1 = {field1[index].ToString("X")} | V2 = {field2[index].ToString("X")} \r\n";
                    }

                    if ( offset_field.Text != "" && len > 0 && field1.Length > 0 && offset_count <= len)
                    {
                        offset_count++;
                        list.Add(field1[index].ToString("X"));
                    }
                }

                field_result.Text = result;
            } catch(Exception ex) {
                Console.WriteLine($"{ex.Message}\n {ex.StackTrace}");
            }



        }
    }
}