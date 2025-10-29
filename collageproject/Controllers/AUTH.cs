using collageproject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace collageproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly stutentdbcontext _context;
        private readonly IConfiguration _configuration;  // ✅ Inject IConfiguration

        public AuthController(stutentdbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration; // ✅ Save it for JWT use
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LOGIN user)
        {
            if (user == null || string.IsNullOrEmpty(user.EMAIL) || string.IsNullOrEmpty(user.PASSWORD))
                return BadRequest("Invalid login request");

            var existingUser = await _context.MAIN
                .FirstOrDefaultAsync(u => u.EMAIL == user.EMAIL && u.PASSWORD == user.PASSWORD);

            if (existingUser == null)
                return Unauthorized("Invalid credentials");

            // ✅ Store in Session
            HttpContext.Session.SetString("UserId", existingUser.id.ToString());
            HttpContext.Session.SetString("UserName", existingUser.USERNAME);

            // ✅ Create JWT Token
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, existingUser.USERNAME),
        new Claim(ClaimTypes.Email, existingUser.EMAIL),
        new Claim("IsAdmin", existingUser.ISADMIN.ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                Token = jwt,
                UserName = existingUser.USERNAME,
                UserId = existingUser.id
            });
        }
    }
}

