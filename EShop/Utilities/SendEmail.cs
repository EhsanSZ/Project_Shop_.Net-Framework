using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace EShop
{
    public class SendEmail
    {
        public static void Send(string To,string Subject,string Body)
        {
            // Az 9 khordad 1401 dige tanzimate Amniatie Google Ejaze Ersal Nemide
            // Az Host Khodet Estefade Kon (#Edit")

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("EhsanWebApplication@gmail.com", "فروشگاه");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("EhsanWebApplication@gmail.com", "Server@01ASP.NET");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}