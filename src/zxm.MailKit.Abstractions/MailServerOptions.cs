namespace zxm.MailKit.Abstractions
{
    /// <summary>
    /// Mail Server Options
    /// </summary>
    public class MailServerOptions
    {
        /// <summary>
        /// Mail server host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Mail server port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Mail server account name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Mail server password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Mail server from address
        /// </summary>
        public MailAddress From { get; set; }
    }
}
