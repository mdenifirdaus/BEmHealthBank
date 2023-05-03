using BE_mHealthBank.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_mHealthBank.Controllers
{
    [Route("api/credential/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserCredentialsController : ControllerBase
    {
        public readonly UserDbContext _dbcontext;

        public UserCredentialsController(UserDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertUserCredential([FromBody] TblUserCredential itemUser)
        {
            if (itemUser is not null)
            {
                _dbcontext.TblUserCredential.Add(itemUser);
                _dbcontext.SaveChanges();
            }
            return Ok(itemUser);
        }
    }
}
