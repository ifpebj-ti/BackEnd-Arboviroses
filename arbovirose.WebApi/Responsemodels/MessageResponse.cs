namespace arbovirose.WebApi.Responsemodels
{
    public class MessageResponse
    {
        public MessageResponse(string message)
        {
            this.message = message;
        }
        public string message { get; set; } = "";
    }
}
