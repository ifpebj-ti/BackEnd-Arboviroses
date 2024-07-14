using arbovirose.Domain.ValueObjects;

namespace arbovirose.Domain.Entities
{
    public class InfoHomeEntity
    {
        public InfoHomeEntity() { }
        public InfoHomeEntity(
            string? Topic,
            string Title,
            string? TitleLink,
            string Link,
            TypeInfo TypeInfo
        )
        {
            this.Id = Guid.NewGuid();
            this.Topic = Topic;
            this.Title = Title;
            this.TitleLink = TitleLink;
            this.Link = Link;
            this.TypeInfo = TypeInfo;
        }
        public Guid Id { get; set; }
        public string? Topic { get; set; }
        public string Title { get; set; } = "";
        public string? TitleLink { get; set; }
        public string Link { get; set; } = "";
        public TypeInfo TypeInfo { get; set; } = null!;
    }
}
