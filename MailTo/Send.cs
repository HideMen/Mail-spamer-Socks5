using System;
using System.Threading.Tasks;
using EASendMail;
using System.Windows.Forms;

namespace MailTo
{
    class Send
    {
        public async static void SendMail(string mailto, string text, string proxy, int port, string mailFrom, string password, string subject)
        {
            await Task.Run(() =>
            {
                try
                {

                    SmtpMail oMail = new SmtpMail("TryIt");
                    SmtpClient oSmtp = new SmtpClient();

                    oMail.From = mailFrom;
                    oMail.To = mailto;
                    oMail.Subject = subject;
                    oMail.TextBody = text;

                    SmtpServer oServer = new SmtpServer("smtp.mail.ru");
                    oServer.SocksProxyServer = proxy;
                    oServer.SocksProxyPort = port;
                    oServer.ProxyProtocol = SocksProxyProtocol.Socks5;
                    oServer.User = mailFrom;
                    oServer.Password = password;
                    oServer.Port = 465;
                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                    oSmtp.SendMail(oServer, oMail); //отправка сообщения

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace + " " + e.Message);
                }
            });
        }
    }
}
