using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGamer.Domain.Resources;

namespace XGamer.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string endEmail)
        {
            EndEmail = endEmail;

            new AddNotifications<Email>(this).IfNotEmail(x => x.EndEmail, Message.EMAIL_ERROR_01.ToFormat("E-mail error!! "));
        }

        public string EndEmail { get; private set; }


    }
}
