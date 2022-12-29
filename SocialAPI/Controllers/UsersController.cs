using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.DTOs;
using SocialAPI.Interfaces;

namespace SocialAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // var users = await _userRepository.GetUsersAsync();
            // var usersDto = _mapper.Map<IEnumerable<MemberDto>>(users);
            // return Ok(usersDto);

            return Ok(await _userRepository.GetMembersAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userDto = _mapper.Map<MemberDto>(user);
            return Ok(userDto);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto?>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }
    }
}
