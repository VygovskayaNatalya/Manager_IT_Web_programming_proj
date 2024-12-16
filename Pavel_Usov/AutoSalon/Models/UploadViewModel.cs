using Microsoft.AspNetCore.Http;

namespace AutoSalon.Models
{
    public class UploadViewModel
    {
        public IFormFile Photo { get; set; }
    }
}
