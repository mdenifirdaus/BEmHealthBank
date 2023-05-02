using Microsoft.AspNetCore.Identity;

namespace BE_mHealthBank.Models
{
    public class UserTokenCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
