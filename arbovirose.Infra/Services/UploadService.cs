using arbovirose.Application.Exceptions;
using arbovirose.Application.Services;
using arbovirose.Domain.Dtos.InfoHome;

namespace arbovirose.Infra.Services
{
    public class UploadService : IUploadService
    {
        public bool Upload(UploadDTO data)
        {
            if (data.Size > 5) throw new InvalidUploadFileSizeException();
            if (
                data.TypeFile != "jpeg"
                && data.TypeFile != "png"
                && data.TypeFile != "jpg"
            ) throw new InvalidUploadTypeFileException();

            string uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            string filePath = Path.Combine(uploadsDirectory, data.FileName);
            File.WriteAllBytes(filePath, data.File);

            return true;
        }

        public bool Delete(string fileName)
        {
            string uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            string filePath = Path.Combine(uploadsDirectory, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }
    }
}
