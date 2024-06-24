namespace arbovirose.WebApi.Responsemodels.InfoHome
{
    public class InfoHomeResponse
    {
        public Guid Id { get; set; }
        public string? Topic { get; set; }
        public string Title { get; set; } = "";
        public string? TitleLink { get; set; }
        public string Link { get; set; } = "";
    }
}
