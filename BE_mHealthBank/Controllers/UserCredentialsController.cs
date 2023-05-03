using BE_mHealthBank.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_mHealthBank.Controllers
{
    [Route("api/user/credential/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserCredentialsController : ControllerBase
    {
        public readonly UserDbContext _dbcontext;

        public UserCredentialsController(UserDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("registered-list")]
        public async Task<IActionResult> GetUserCredential()
        {
            var data =_dbcontext.TblUserCredential.ToList();
            if (data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                return Ok("Data not available");
            }
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserCredential([FromBody] TblUserCredential itemUser)
        {
            var existingData = _dbcontext.TblUserCredential.FirstOrDefaultAsync(m=>m.Id.Equals(itemUser.Id)).Result;
            if (existingData is not null)
            {
                existingData.UserName = itemUser.UserName;
                existingData.UserPhone = itemUser.UserPhone;
                existingData.UserEmail = itemUser.UserEmail;
                existingData.UserPassword = itemUser.UserPassword;

                _dbcontext.SaveChanges();
            }
            return Ok(itemUser);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> DeleteUserCredential(string userId)
        {
            var existingData = _dbcontext.TblUserCredential.FirstOrDefaultAsync(m => m.Id.Equals(userId)).Result;
            if (existingData is not null)
            {
                _dbcontext.Remove(existingData);
                _dbcontext.SaveChanges();
            }
            return Ok(existingData);
        }

    }
}
