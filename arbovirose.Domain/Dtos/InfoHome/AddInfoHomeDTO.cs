
namespace arbovirose.Domain.Dtos.InfoHome
{
    public class AddInfoHomeDTO
    {
        public string? Topic { get; set; }
        public string Title { get; set; } = "";
        public string? TitleLink { get; set; }
        public string Link { get; set; } = "";
        public Byte[] File { get; set; } = new Byte[0];
        public string TypeFile { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public double Size { get; set; } = 0;
    }
}
