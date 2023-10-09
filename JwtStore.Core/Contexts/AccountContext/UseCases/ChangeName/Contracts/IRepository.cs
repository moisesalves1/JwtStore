using JwtStore.Core.AccountContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName.Contracts
{
    public interface IRepository
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);
    }
}
