using BE_mHealthBank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_mHealthBank.Controllers
{
    [Route("api/auth/")]
    [ApiController]
    public class TokenAuthController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly UserDbContext _dbContext;

        public TokenAuthController(IConfiguration configuration, UserDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("user-credential")]
        public async Task<TblUserCredential> GetUserCredential(string userName, string userPassword)
        {
            var data = await _dbContext.TblUserCredential.FirstOrDefaultAsync(m => m.UserName == userName && m.UserPassword == userPassword);
            return data;
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreateToken(UserTokenCredential userCredential)
        {
            if (userCredential is not null)
            {
                var userData = await GetUserCredential(userCredential.UserName, userCredential.Password);
                if (userData is not null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration.GetValue<string>("Jwt:Subject").ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("UserName", userData.UserName),
                        new Claim("Password", userData.UserPassword),
                        new Claim("Email", userData.UserEmail),
                        new Claim("Phone", userData.UserPhone),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration.GetValue<string>("Jwt:Issuer").ToString(),
                                                     _configuration.GetValue<string>("Jwt:Audience").ToString(),
                                                     claims, DateTime.Today, expires: DateTime.Now.AddDays(2), signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("User is not valid. Please register user..");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
