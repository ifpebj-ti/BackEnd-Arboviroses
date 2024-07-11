
using arbovirose.Domain.Dtos.InfoHome;

namespace arbovirose.Application.Services
{
    public interface IUploadService
    {
        bool Upload(UploadDTO data);
        bool Delete(string fileName);
    }
}
