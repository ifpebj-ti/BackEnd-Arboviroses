using arbovirose.Domain.Dtos.InfoHome;
using arbovirose.Domain.Entities;

namespace arbovirose.Domain.Factories
{
    public class InfoHomeEntityFactory
    {
        public static InfoHomeEntity CreateInfoHomeEntity(AddInfoHomeDTO data)
        {

            return new InfoHomeEntity(
                data.Topic,
                data.Title,
                data.TitleLink,
                data.Link
            );
        }

        public static UploadDTO CreateUploadDTO(InfoHomeEntity infoHome, AddInfoHomeDTO data)
        {
            return new UploadDTO()
            {
                File = data.File,
                TypeFile = data.TypeFile,
                FileName = $"{infoHome.Id}_{data.OriginalFileName}.{data.TypeFile}",
                Size = data.Size,
            };
        }

        public static UploadDTO CreateUploadDTO(InfoHomeEntity infoHome, EditInfoHomeDTO data)
        {
            if (data.File == null || data.TypeFile == null || data.OriginalFileName == null || data.Size == null)
            {
                throw new ArgumentException("File, TypeFile, OriginalFileName, and Size não devem ser null.");
            }

            return new UploadDTO()
            {
                File = data.File,
                TypeFile = data.TypeFile,
                FileName = $"{infoHome.Id}_{data.OriginalFileName}.{data.TypeFile}",
                Size = data.Size.Value,
            };
        }
    }
}
