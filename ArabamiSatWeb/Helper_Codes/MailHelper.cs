using System.Net;
using System.Net.Mail;
using System.Text;

namespace ArabamiSatWeb.Helper_Codes
{
    public class MailHelper
    {
        public static void SendMail(string baslik, string icerik, string aliciEposta)
        {  
            string mailDisplayName = "Arabamı Sat";
            string mailAdres = "user21351@outlook.com";
            string mailUserName = "user21351@outlook.com";
            string mailPassword = "123456mail";
            string mailHost = "smtp.office365.com";
            int mailPortNumber = 587;

            MailAddress fromAddress = new MailAddress(mailAdres, mailDisplayName, Encoding.UTF8);
            MailAddress toAddress = new MailAddress(aliciEposta);
            MailMessage myMailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = baslik,
                Body = icerik,
                IsBodyHtml = true
            };

            NetworkCredential mailAuthentication = new NetworkCredential(mailUserName, mailPassword);
            SmtpClient mailClient = new SmtpClient(mailHost, mailPortNumber)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = mailAuthentication
            };

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            mailClient.Send(myMailMessage);
        }
    }
}
