using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentElectionAPI.Models;
using StudentElectionAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace StudentElectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        private readonly IConfiguration config;
        private readonly ElectionDbContext context;
        public AuthenticationController(IConfiguration configuration, ElectionDbContext _context)
        {
            config = configuration;
            context = _context;
        }


        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { code = "EMPTY_FIELDS", message = "Please fill in all required fields." });
            }

            if (request.Password.Length < 6)
            {
                return BadRequest(new { code = "WEAK_PASSWORD", message = "Password must be at least 6 characters long." });
            }

            var newUser = new User
            {
                Username = request.Username,
                PasswordHashed = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };



            context.Users.Add(newUser);
            context.SaveChanges();
            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {

            var user = context.Users.FirstOrDefault(u => u.Username == request.Username);

            if (user == null)
            {
                return NotFound("User not Foud!");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHashed))
            {
                return NotFound("Incorrect Password!");
            }
            var token = CreateToken(user);
            return Ok(new { Token = token, User = user });
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username!),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWTsettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                config["JWTsettings:Issuer"],
                config["JWTsettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        [Authorize]
        [HttpGet("GetUsers")]
        public ActionResult<User> GetUsers()
        {
            return Ok(context.Users);
        }

    }
}
