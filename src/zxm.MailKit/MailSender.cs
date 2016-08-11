using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using zxm.MailKit.Abstractions;

namespace zxm.MailKit
{
    /// <summary>
    /// Mail sender
    /// </summary>
    public class MailSender : IMailSender
    {
        /// <summary>
        /// Constructor of MailSender
        /// </summary>
        /// <param name="options"></param>
        public MailSender(MailServerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrEmpty(options.Host))
            {
                throw new ArgumentNullException(nameof(options.Host));
            }

            if (string.IsNullOrEmpty(options.UserName))
            {
                throw new ArgumentNullException(nameof(options.UserName));
            }

            if (string.IsNullOrEmpty(options.Password))
            {
                throw new ArgumentNullException(nameof(options.Password));
            }

            MailServerOptions = options;
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void SendEmail(string to, string subject, string message)
        {
            SendEmail(new List<MailAddress> {new MailAddress {Address = to}}, subject, message);
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void SendEmail(IEnumerable<MailAddress> to, string subject, string message)
        {
            SendEmail(to, null, subject, message);
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        public void SendEmail(IEnumerable<MailAddress> to, IEnumerable<MailAddress> bcc, string subject, string message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (to.Count() == 0)
            {
                throw new Exception("At least has one to mail address");
            }

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailServerOptions.From == null
                ? new MailboxAddress(MailServerOptions.UserName, MailServerOptions.UserName)
                : new MailboxAddress(string.IsNullOrEmpty(MailServerOptions.From.DisplayName) ? MailServerOptions.From.Address : MailServerOptions.From.DisplayName, MailServerOptions.From.Address));
            foreach (var t in to)
            {
                emailMessage.To.Add(new MailboxAddress(string.IsNullOrEmpty(t.Address) ? t.Address : t.DisplayName, t.Address));
            }
            if (bcc != null)
            {
                foreach (var b in bcc)
                {
                    emailMessage.To.Add(new MailboxAddress(string.IsNullOrEmpty(b.Address) ? b.Address : b.DisplayName, b.Address));
                }
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.Connect(MailServerOptions.Host, MailServerOptions.Port, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(MailServerOptions.UserName, MailServerOptions.Password);
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }

        /// <summary>
        /// Mail server options
        /// </summary>
        public MailServerOptions MailServerOptions { get; }

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendEmailAsync(string to, string subject, string message)
        {
            return SendEmailAsync(new List<MailAddress> { new MailAddress {Address = to} }, subject, message);
        }

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="tos"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendEmailAsync(IEnumerable<MailAddress> tos, string subject, string message)
        {
            return SendEmailAsync(tos, null, subject, message);
        }

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(IEnumerable<MailAddress> to, IEnumerable<MailAddress> bcc, string subject, string message)
        {
            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (to.Count() == 0)
            {
                throw new Exception("At least has one to mail address");
            }

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(MailServerOptions.From == null
                ? new MailboxAddress(MailServerOptions.UserName, MailServerOptions.UserName)
                : new MailboxAddress(string.IsNullOrEmpty(MailServerOptions.From.DisplayName) ? MailServerOptions.From.Address : MailServerOptions.From.DisplayName, MailServerOptions.From.Address));
            foreach (var t in to)
            {
                emailMessage.To.Add(new MailboxAddress(string.IsNullOrEmpty(t.Address) ? t.Address : t.DisplayName, t.Address));
            }
            if (bcc != null)
            {
                foreach (var t in bcc)
                {
                    emailMessage.To.Add(new MailboxAddress(string.IsNullOrEmpty(t.Address) ? t.Address : t.DisplayName, t.Address));
                }
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(MailServerOptions.Host, MailServerOptions.Port, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(MailServerOptions.UserName, MailServerOptions.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
