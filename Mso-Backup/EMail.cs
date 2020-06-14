using Mso_Backup.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup
{
    class EMail
    {
        SmtpClient _client = new SmtpClient();
        MailMessage _mailMessage = new MailMessage();
        FileManagement _fileManagement = new FileManagement();
        Smtp _Smtp;

        public EMail()
        {
            _client.Credentials = new NetworkCredential("lrewar37@gmail.com", "654333Lr");
            _client.Port = 587;
            _client.Host = "smtp.gmail.com";
            _client.EnableSsl = true;

            _mailMessage.To.Add("m.sabri.oguz@gmail.com");
            _mailMessage.From = new MailAddress("lrewar37@gmail.com", "Lord Rewar");
            _mailMessage.IsBodyHtml = true;
            _mailMessage.Subject = "Deneme maili...";
            _mailMessage.Body = "<html><body><b>Bu bir deneme yazısıdır.<b><br/>Merhabalar bugün nasılsınız?<br />" +
                "<img src='https://media.giphy.com/media/28GHfhGFWpFgsQB4wR/source.gif' /></body></html>";

            _mailMessage.Attachments.Add(new Attachment("C:\\Users\\msabr\\OneDrive\\Resimler\\IMG_20200428_155754.jpg"));

            
        }
        public EMail(Smtp smtp)
        {
            _Smtp = smtp;
            _client.Credentials = new NetworkCredential(_Smtp.Username, _Smtp.Password);
            _client.Port = _Smtp.Port;
            _client.Host = _Smtp.Server;
            _client.EnableSsl = _Smtp.SSLSupport;
            _mailMessage.From = new MailAddress(_Smtp.Username, _Smtp.Name);
            _mailMessage.IsBodyHtml = true;
        }
        public void TestMail()
        {
            _mailMessage.To.Add(_Smtp.TestEmail);
            _mailMessage.Subject = "MsoBackup Test Maili";
            string content = _fileManagement.GetFileAllText(Application.StartupPath + "\\Html\\mail-template.htm");
            _mailMessage.Body = string.Format(content, "Mustafa Oğuz", 5, "E:", "123 GB");
            Send();
        }
        public void Send()
        {
            _client.Send(_mailMessage);
        }
    }
}
