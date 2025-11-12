namespace _42_API.Models
{
    public class FileUpload
    {
        public string Description { get; set; }
        public IFormFile File { get; set; } //Formlardan gelen dosyayı tutar
    }
}
