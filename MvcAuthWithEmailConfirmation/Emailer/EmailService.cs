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
using Engine.Emailer;
using Entities.Email;

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
            await EmaileServiceProvider.ConfigMailAsync(new Email { Destination = message.Destination, Subject = message.Subject, Body = message.Body });
        }
    }
}