namespace arbovirose.Domain.Dtos.Auth
{
    public class UpdatePasswordDTO
    {
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string UniqueCode { get; set; } = "";
    }
}
