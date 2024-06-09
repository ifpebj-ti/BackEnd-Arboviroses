namespace arbovirose.Domain.Dtos.User
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public Guid ProfileId { get; set; }
    }
}
