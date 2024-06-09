namespace arbovirose.Application.Exceptions
{
    public class TokenNotGeneratedException : Exception
    {
        public TokenNotGeneratedException() : base("Não foi possível gerar o token")
        {

        }
    }
}
