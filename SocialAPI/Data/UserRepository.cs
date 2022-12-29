
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SocialAPI.DTOs;
using SocialAPI.Interfaces;
using SocialAPI.Models;

namespace SocialAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
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

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.AppUsers
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MemberDto?> GetMemberAsync(string username)
        {
            return await _context.AppUsers
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
    }
}