namespace arbovirose.WebApi.Requestmodels.InfoHome
{
    public class EditInfoHomeRequest
    {
        public Guid Id { get; set; }
        public string? Topic { get; set; } = null!;
        public string? Title { get; set; } = null!;
        public string? TitleLink { get; set; } = null!;
        public string? Link { get; set; } = null!;
        public string TypeInfo { get; set; } = null!;
        public IFormFile File { get; set; } = null!;
    }
}
