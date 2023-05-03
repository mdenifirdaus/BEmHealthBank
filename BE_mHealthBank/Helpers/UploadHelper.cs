namespace BE_mHealthBank.Helpers
{
    public class UploadHelper
    {
        public void UploadFileTo(string destinationPath, IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                string filePath = Path.Combine(destinationPath, formFile.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
        }
    }
}
