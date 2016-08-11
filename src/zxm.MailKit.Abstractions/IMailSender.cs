using System.Collections.Generic;
using System.Threading.Tasks;

namespace zxm.MailKit.Abstractions
{
    /// <summary>
    /// Mail sender interface
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        void SendEmail(string to, string subject, string message);

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="tos"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        void SendEmail(IEnumerable<MailAddress> tos, string subject, string message);

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="tos"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        void SendEmail(IEnumerable<MailAddress> tos, IEnumerable<MailAddress> bcc, string subject, string message);

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(string to, string subject, string message);

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="tos"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(IEnumerable<MailAddress> tos, string subject, string message);

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="tos"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(IEnumerable<MailAddress> tos, IEnumerable<MailAddress> bcc, string subject, string message);
    }
}
