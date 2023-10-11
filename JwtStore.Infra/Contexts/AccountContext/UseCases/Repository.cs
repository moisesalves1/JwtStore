using JwtStore.Core.AccountContext.Entities;
using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.AccountContext.UseCases;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Contexts.AccountContext.UseCases
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context) 
            => _context = context;
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.Include(x=>x.Roles).FirstOrDefaultAsync(x => x.Email.Address == email, cancellationToken);
        public async Task<List<User>?> GetAllUsersAsync(CancellationToken cancellationToken)
            => await _context.Users.Include(x => x.Roles).ToListAsync(cancellationToken);
        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().AnyAsync(x => x.Email.Address == email, cancellationToken: cancellationToken);
        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveAsync(User user, CancellationToken cancellationToken)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Name == "Usuario");
            if (role != null)
                user.Roles.Add(role);
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken)
            => await _context.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id.ToString() == id, cancellationToken);

        public async Task DeleteUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
