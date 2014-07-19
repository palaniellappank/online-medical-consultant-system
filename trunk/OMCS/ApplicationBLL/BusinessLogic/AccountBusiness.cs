using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace OMCS.BLL
{
    public class AccountBusiness : BaseBusiness
    {
        public void SendMail(string tEmail, string subject, string body)
        {
            try
            {
                string email = "omcssystem@gmail.com";
                string password = "me09051965";

                NetworkCredential logInfo = new NetworkCredential(email, password);
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                mail.From = new MailAddress(email);
                mail.To.Add(tEmail);
                mail.Subject = subject;
                string content = string.Format("<html></html>");
                mail.Body = body;
                mail.IsBodyHtml = true;

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = logInfo;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

                SendMail(tEmail, subject, body);
            }
        }

        public string GeneratePassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var password = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return password;
        }
    }
}
