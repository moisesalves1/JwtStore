using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword.Contracts;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Contexts.AccountContext.UseCases.ResetPassword
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context) 
            => _context = context;
        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().AnyAsync(x => x.Email.Address == email, cancellationToken: cancellationToken);
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Address == email, cancellationToken);
        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
