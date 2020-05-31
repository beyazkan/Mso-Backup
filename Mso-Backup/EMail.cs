using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Mso_Backup
{
    class EMail
    {
        SmtpClient _client = new SmtpClient();
        MailMessage _mailMessage = new MailMessage();


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

            _client.Send(_mailMessage);
        }


    }
}
