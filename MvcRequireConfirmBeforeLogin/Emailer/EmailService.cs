using Engine.Emailer;
using Entities.Email;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MvcRequireConfirmBeforeLogin.Emailer
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await EmaileServiceProvider.ConfigMailAsync(new Email { Destination = message.Destination, Subject = message.Subject, Body = message.Body });
        }
    }
}