namespace arbovirose.Domain.Dtos.Auth
{
    public class PrimaryAccessDTO
    {
        public string Email { get; set; } = "";
        public string NewPassword { get; set; } = "";
        public string DefaultPassword { get; set; } = "";
    }
}
