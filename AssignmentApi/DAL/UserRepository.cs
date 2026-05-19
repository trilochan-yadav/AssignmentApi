using AssignmentApi.DAL.Interfaces;
using AssignmentApi.Data;
using AssignmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsers(int lastSeenId, int pageSize)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.Id > lastSeenId)
                .OrderBy(u => u.Id)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
