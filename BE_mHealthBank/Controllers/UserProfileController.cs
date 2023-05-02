using BE_mHealthBank.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_mHealthBank.Controllers
{
    [Route("api/user/")]
    [ApiController]
    [Authorize]
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
                            .FirstOrDefaultAsync(m => m.FullName == incomingItem.FullName).Result;

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

    }
}
