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
    }
}
