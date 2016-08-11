using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zxm.MailKit.Abstractions;

namespace zxm.MailKit.Outlook365
{
    public class Outlook365MailSender : MailSender
    {
        public Outlook365MailSender(string userName, string password)
            : base(
                new MailServerOptions
                {
                    UserName = userName,
                    Password = password,
                    Host = "smtp.office365.com",
                    Port = 587
                })
        {
        }
    }
}
