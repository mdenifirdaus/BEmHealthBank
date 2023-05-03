using AutoMapper;
using BE_mHealthBank.Helpers;
using BE_mHealthBank.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_mHealthBank.Controllers
{
    [Route("api/user/master/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserProfileController : ControllerBase
    {
        public readonly UserDbContext _dbcontext;
        public readonly IWebHostEnvironment _environment;
        private string FOLDER_IMG_PATH = "Images";
        private UploadHelper _upload = new();

        public UserProfileController(UserDbContext dbcontext, IWebHostEnvironment environment)
        {
            _dbcontext = dbcontext;
            _environment = environment;
        }

        [HttpGet("users-list")]
        public async Task<IActionResult> GetInfoUser()
        {
            var data = _dbcontext.TblUser.AsNoTracking().ToList();
            return Ok(data);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertUser([FromForm] UserViewModels itemUser)
        {            
            if (itemUser is not null)
            {
                var folders = Path.Combine(_environment.ContentRootPath, FOLDER_IMG_PATH);
                _upload.UploadFileTo(folders, itemUser.ImageProfile);

                var dto = new TblUser
                {
                    FullName = itemUser.FullName,
                    AddressName=itemUser.AddressName,
                    BirthDate = itemUser.BirthDate,
                    Gender = itemUser.Gender,
                    ImageProfile = itemUser.ImageProfile.FileName
                };
                _dbcontext.TblUser.Add(dto);
                _dbcontext.SaveChanges();
            }
            return Ok(itemUser);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromForm] UserViewModels incomingItem)
        {
            var existingData = _dbcontext.TblUser.AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == incomingItem.Id).Result;

            if (existingData is not null)
            {
                var folders = Path.Combine(_environment.ContentRootPath, FOLDER_IMG_PATH);
                _upload.UploadFileTo(folders, incomingItem.ImageProfile);

                existingData.FullName = incomingItem.FullName;
                existingData.AddressName = incomingItem.AddressName;
                existingData.BirthDate = incomingItem.BirthDate;
                existingData.Gender = incomingItem.Gender;
                existingData.ImageProfile = incomingItem.ImageProfile.FileName;

                _dbcontext.SaveChanges();
            }            
            
            return Ok(incomingItem);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var existingData = _dbcontext.TblUser.AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == userId).Result;

            _ = _dbcontext.Remove(existingData);
            _dbcontext.SaveChanges();

            return Ok(existingData);
        }

    }
}
