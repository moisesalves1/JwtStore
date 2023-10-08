using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Verify.Contracts
{
    public interface IRepository
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);
    }
}
