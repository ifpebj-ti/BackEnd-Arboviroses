
namespace arbovirose.Domain.Dtos.InfoHome
{
    public class EditInfoHomeDTO
    {
        public Guid Id { get; set; }
        public string Topic { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TitleLink { get; set; } = null!;
        public string Link { get; set; } = null!;
        public byte[]? File { get; set; }
        public string? TypeFile { get; set; }
        public string? OriginalFileName { get; set; }
        public long? Size { get; set; }
    }
}
