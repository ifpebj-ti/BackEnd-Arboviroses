namespace arbovirose.WebApi.Requestmodels.InfoHome
{
    public class AddInfoHomeRequest
    {
        public string? Topic { get; set; }
        public string Title { get; set; } = "";
        public string? TitleLink { get; set; }
        public string Link { get; set; } = "";
        public IFormFile File { get; set; } = null!;
    }
}
