namespace arbovirose.WebApi.Requestmodels.Auth
{
    public class UpdatePasswordRequest
    {
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string UniqueCode { get; set; } = "";
    }
}
