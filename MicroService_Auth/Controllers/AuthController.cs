using MicroService_Auth.Data;
using MicroService_Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroService_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthTokenService _authTokenService;

        public AuthController(AppDbContext context, AuthTokenService authTokenService)
        {
            _context = context;
            _authTokenService = authTokenService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthUser authUser)
        {
            var dbUser = await _context
                .AuthUsers
                .SingleOrDefaultAsync(u => u.Username == authUser.Username);

            if (dbUser == null)
            {
                return NotFound("User not found.");
            }


            var isValid = dbUser.Password == authUser.Password;

            if (!isValid)
            {
                return BadRequest("Could not authenticate user.");
            }

            var token = _authTokenService.GenerateToken(authUser);

            return Ok(token);
        }

    }
}
