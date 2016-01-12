using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SendGrid;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Diagnostics;

namespace MvcAuthWithEmailConfirmation.Emailer
{
    /* This is a custom class. It used to be auto-defined in IdentityConfig.cs but that has been stopped now.
     * In the sample which I followed, they used SendGrid to send the mail.
     * But, in order to use SendGrid email framework, you need to buy a membership.
     * So I'm not going to use this framework to send mail (as the tutorial was doing).
     * I'm going to use gmail smtp
     */
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            //await configSendGridasync(message);
            await configGMailAsync(message);
        }


        //send confirmation mail using gmail
        private static async Task configGMailAsync(IdentityMessage message)
        {
            //provide correct details in the web.config file for mailAccount and mailPassword
            GMailer.GmailUsername = ConfigurationManager.AppSettings["mailAccount"];
            GMailer.GmailPassword = ConfigurationManager.AppSettings["mailPassword"];

            GMailer mailer = new GMailer();
            mailer.From = new MailAddress("Joe@contoso.com", "Joe G");
            mailer.ToEmail = message.Destination;
            mailer.Subject = "Confirm Your Account";
            mailer.Body = message.Body;
            mailer.IsHtml = true;
            await mailer.SendAsync();
        }


        // Use NuGet to install SendGrid (Basic C# client lib)
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress("Joe@contoso.com", "Joe S.");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["mailAccount"],
                ConfigurationManager.AppSettings["mailPassword"]
                );

            //Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            //Send the email
            if(transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}