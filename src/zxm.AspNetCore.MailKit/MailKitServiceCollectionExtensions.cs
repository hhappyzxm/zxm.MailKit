using System;
using Microsoft.Extensions.DependencyInjection;
using zxm.MailKit.Abstractions;

namespace zxm.AspNetCore.MailKit
{
    public static class MailKitServiceCollectionExtensions
    {
        public static IServiceCollection AddMailKit(this IServiceCollection services, Func<IMailSender> mailSenderFunc)
        {
            if (mailSenderFunc == null)
            {
                throw new ArgumentNullException(nameof(mailSenderFunc));
            }
            
            services.AddSingleton(provider => mailSenderFunc());

            return services;
        }
    }
}
