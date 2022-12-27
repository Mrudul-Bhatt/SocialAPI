
using Microsoft.EntityFrameworkCore;
using SocialAPI.Interfaces;
using SocialAPI.Models;

namespace SocialAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.AppUsers
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<AppUser?> GetUserByIdAsync(int id)
        {
            return await _context.AppUsers
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AppUser?> GetUserByUsernameAsync(string username)
        {
            return await _context.AppUsers
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username.ToLower());
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}