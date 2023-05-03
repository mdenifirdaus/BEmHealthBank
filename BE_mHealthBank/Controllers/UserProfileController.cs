using BE_mHealthBank.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_mHealthBank.Controllers
{
    [Route("api/user/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserProfileController : ControllerBase
    {
        public readonly UserDbContext _dbcontext;

        public UserProfileController(UserDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("users-list")]
        public async Task<IActionResult> GetInfoUser()
        {
            var data = _dbcontext.TblUser.AsNoTracking().ToList();
            return Ok(data);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertUser([FromBody] TblUser itemUser)
        {
            if (itemUser is not null)
            {
                _dbcontext.TblUser.Add(itemUser);
                _dbcontext.SaveChanges();
            }
            return Ok(itemUser);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] TblUser incomingItem)
        {
            var existingData = _dbcontext.TblUser.AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == incomingItem.Id).Result;

            if (existingData is not null)
            {
                existingData.FullName = incomingItem.FullName;
                existingData.AddressName = incomingItem.AddressName;
                existingData.BirthDate = incomingItem.BirthDate;
                existingData.Gender = incomingItem.Gender;
                existingData.ImageProfile = incomingItem.ImageProfile;
            }
            _dbcontext.SaveChanges();
            
            return Ok(incomingItem);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] int userId)
        {
            var existingData = _dbcontext.TblUser.AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == userId).Result;

            _ = _dbcontext.Remove(existingData);
            _dbcontext.SaveChanges();

            return Ok(existingData);
        }

    }
}
