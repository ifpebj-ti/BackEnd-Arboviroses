namespace arbovirose.WebApi.Requestmodels.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public Guid ProfileId { get; set; }
    }
}
