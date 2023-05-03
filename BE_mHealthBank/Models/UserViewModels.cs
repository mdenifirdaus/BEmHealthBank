namespace BE_mHealthBank.Models
{
    public class UserViewModels
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string AddressName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public IFormFile ImageProfile { get; set; }
    }
}
