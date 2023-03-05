using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ElitPatisserie.MVC.Validate
{
    public static class MyValidateImage
    {
        public static bool IsImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var allowedMimeTypes = new[] { "image/jpeg", "image/png" }; // İzin verilen MIME türleri
            var contentType = file.ContentType.ToLowerInvariant();

            return allowedMimeTypes.Contains(contentType);
        }
    }
}
