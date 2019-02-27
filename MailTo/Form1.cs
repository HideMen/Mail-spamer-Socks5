using System;
using System.Windows.Forms;

namespace MailTo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            //считаем количество почт и добавляем в массив
            string[] lines = richTextBox2.Text.Split(new char[] { '_', '\r', '\n', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] mailTOarray = new string[lines.Length];
            for (int i = 0; i < mailTOarray.Length; i++)
            {
                mailTOarray[i] = lines[i].ToString();
            }
            //считаем количество прокси и добавляем в массив
            string[] ProxyLines = richTextBox3.Text.Split(new char[] { '_', '\r', '\n', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ProxyArray = new string[lines.Length];
            for (int i = 0; i < ProxyArray.Length; i++)
            {
                ProxyArray[i] = lines[i].ToString();
            }
            //считаем количество почт с которых отправляем и добавляем в массив
            string[] MailFromLines = richTextBox4.Text.Split(new char[] { '_', '\r', '\n', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] MailFromArray = new string[lines.Length];
            for (int i = 0; i < MailFromArray.Length; i++)
            {
                MailFromArray[i] = lines[i].ToString();
            }

            label1.Text = "Количество почт:";
            label2.Text = lines.Length.ToString();
            label3.Text = "Отправлено:";
            label5.Text = "Ошибок";

            string mailto = richTextBox2.Text;
            Random rnd = new Random();

            string[] arraySinonim = Sinonim.Text.Split(',');
            string[] arraySinonim2 = Sinonim2.Text.Split(',');


            int ok = 0;
            int no = 0;
            for(int io=0; io< mailTOarray.Length; io++ )
            {
                string message = richTextBox1.Text.Replace(textBox1.Text, arraySinonim[rnd.Next(arraySinonim.Length)]);
                message.Replace(textBox3.Text, arraySinonim2[rnd.Next(arraySinonim2.Length)]);
                string[] proxyPort = ProxyLines[rnd.Next(ProxyArray.Length)].Split(':');
                string proxy = proxyPort[0];
                int port = Convert.ToInt32(proxyPort[1]);

                string[] MailFrom = MailFromLines[rnd.Next(MailFromArray.Length)].Split(';');
                //string From = MailFrom[0];
                //string pass = MailFrom[1];
                try
                {
                    Send.SendMail(mailTOarray[io], message, proxy, port, MailFrom[0], MailFrom[1], textBox2.Text);
                    label4.Text = ok++.ToString();
                }
                catch { label6.Text = no++.ToString(); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
