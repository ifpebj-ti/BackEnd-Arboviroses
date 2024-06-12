namespace arbovirose.WebApi.Requestmodels.Auth
{
    public class PrimaryAccessRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string UniqueCode { get; set; } = "";
    }
}
