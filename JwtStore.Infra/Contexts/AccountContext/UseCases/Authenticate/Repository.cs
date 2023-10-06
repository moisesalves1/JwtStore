using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Threading;

namespace JwtStore.Infra.Contexts.AccountContext.UseCases.Authenticate
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
            => _context = context;
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Email.Address == email, cancellationToken);
    }
}
