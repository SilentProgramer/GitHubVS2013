using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace MvcAuthWithEmailConfirmation.Emailer
{
    //before running the program, set the password in the config entry
    //However, make sure to remove the password once you have finished 
    public class GMailer
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }
        
        public MailAddress From { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 25; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
            GmailSSL = true;
        }

        public async Task SendAsync()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);
            smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack); //since we are using sendAsync to send mail, this event handler will execute the function after the mail has been sent


            using (var message = new MailMessage(GmailUsername, ToEmail))
            {
                message.From = From;
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                await smtp.SendMailAsync(message);
            }
        }

        private void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            //do something once mail has been sent

        }
    }
}