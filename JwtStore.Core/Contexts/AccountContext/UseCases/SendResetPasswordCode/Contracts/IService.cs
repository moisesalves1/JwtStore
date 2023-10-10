using JwtStore.Core.AccountContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode.Contracts
{
    public interface IService
    {
        Task SendResetPasswordCodeAsync(User user, CancellationToken cancellationToken);

    }
}
