namespace arbovirose.WebApi.Responsemodels.User
{
    public class GetAllUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string UniqueCode { get; set; } = "";
        public bool Active { get; set; }
        public ProfileResponse Profile { get; set; } = null!;
    }
}
