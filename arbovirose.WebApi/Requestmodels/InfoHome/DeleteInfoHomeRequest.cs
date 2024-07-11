namespace arbovirose.WebApi.Requestmodels.InfoHome
{
    public class DeleteInfoHomeRequest
    {
        public Guid Id { get; set; }
        public string? TypeFile { get; set; }
        public string? OriginalFileName { get; set; }
    }
}
