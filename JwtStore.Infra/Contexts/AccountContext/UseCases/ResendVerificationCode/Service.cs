using JwtStore.Core;
using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode.Contracts;
using SendWithBrevo;

namespace JwtStore.Infra.Contexts.AccountContext.UseCases.ResendVerificationCode
{
    public class Service : IService
    {
        //public async Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken)
        //{
        //    var client = new SendGridClient(Configuration.SendGrid.ApiKey);
        //    var from = new EmailAddress(Configuration.Email.DefaultFromEmail, Configuration.Email.DefaultFromName);
        //    var subject = "Verifique sua conta";
        //    var to = new EmailAddress(user.Email, user.Name);
        //    var content = $"Código {user.Email.Verification.Code}";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        //    await client.SendEmailAsync(msg, cancellationToken);
        //}

        public async Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken)
        {
            BrevoClient client = new BrevoClient(Configuration.Brevo.ApiKey);

            var subject = "Verifique sua conta";
            var content = $"Código {user.Email.Verification.Code}";


            await client.SendAsync(
                new Sender(Configuration.Email.DefaultFromName, Configuration.Email.DefaultFromEmail),
                new List<Recipient> { new Recipient(user.Name, user.Email) },
                subject,
                content,
                false
                );
        }
    }
}
