using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using Xunit;
using zxm.MailKit;
using zxm.MailKit.Outlook365;

namespace zxm.MailKit.Tests
{
    public class EmailSenderTest
    {
        [Fact]
        public async Task TestSendEmailForOutlook365()
        {
            var mailSender = new Outlook365MailSender("asdfasdf", "asdfasdf");

            mailSender.SendEmail("asdf", "test", "test sync is ok");

            await mailSender.SendEmailAsync("asdf", "test", "test async is ok");
        }
    }
}
