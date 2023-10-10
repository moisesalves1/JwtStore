using JwtStore.Core.AccountContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.UseCases
{
    public interface IService
    {
        Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken);

        Task SendResetPasswordCodeAsync(User user, CancellationToken cancellationToken);
    }
}
