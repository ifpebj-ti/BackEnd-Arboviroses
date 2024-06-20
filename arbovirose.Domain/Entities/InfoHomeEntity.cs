namespace arbovirose.Domain.Entities
{
    public class InfoHomeEntity
    {
        public InfoHomeEntity() { }
        public InfoHomeEntity(
            string? Topic,
            string Title,
            string? TitleLink,
            string Link
        )
        {
            this.Id = Guid.NewGuid();
            this.Topic = Topic;
            this.Title = Title;
            this.TitleLink = TitleLink;
            this.Link = Link;
        }
        public Guid Id { get; set; }
        public string? Topic { get; set; }
        public string Title { get; set; } = "";
        public string? TitleLink { get; set; }
        public string Link { get; set; } = "";
    }
}
