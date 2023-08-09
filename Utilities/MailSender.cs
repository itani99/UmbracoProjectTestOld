using System.Net;
using System.Net.Mail;
using Umbraco.Cms.Infrastructure.Mail;
using UmbracoProject2.Models;

namespace UmbracoProject2.Utilities
{
    public class MailSender
    {

        public static void SendEmail(EmailForm mailModel)
        {
        string recipientEmail = mailModel.Receiever;

            string senderEmail = "itanimhmd99@gmail.com";
            string senderPassword = "***********";



            // Create a new MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = mailModel.Title;
            mail.Body = mailModel.Message;

            // Create a new SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; 
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true; 

            try
            {
                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
            

        }
    }
}
