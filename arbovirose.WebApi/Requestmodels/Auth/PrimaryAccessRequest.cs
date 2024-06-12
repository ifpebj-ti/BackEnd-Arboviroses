namespace arbovirose.WebApi.Requestmodels.Auth
{
    public class PrimaryAccessRequest
    {
        public string Email { get; set; } = "";
        public string NewPassword { get; set; } = "";
        public string DefaultPassword { get; set; } = "";
    }
}
