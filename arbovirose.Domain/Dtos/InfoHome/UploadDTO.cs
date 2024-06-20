namespace arbovirose.Domain.Dtos.InfoHome
{
    public class UploadDTO
    {
        public Byte[] File { get; set; } = new Byte[0];
        public string TypeFile { get; set; } = "";
        public string FileName { get; set; } = "";
        public double Size { get; set; } = 0;
    }
}
