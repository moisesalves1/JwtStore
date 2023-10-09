using JwtStore.Core.AccountContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail.Contracts
{
    public interface IService
    {
        Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken);

    }
}
