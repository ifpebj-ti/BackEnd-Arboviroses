
namespace arbovirose.Application.Exceptions
{
    public class InvalidUploadFileSizeException : Exception
    {
        public InvalidUploadFileSizeException() : base("Tamanho do arquivo excede o valor permitido")
        {

        }
    }
}
