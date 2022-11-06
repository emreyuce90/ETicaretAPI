namespace ETicaretAPI.Application.Exceptions
{
    public class LoginErrorException : Exception
    {
        public LoginErrorException():base("Kullanıcı doğrulanamadı!")
        {
        }

        public LoginErrorException(string? message) : base(message)
        {
        }

        public LoginErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
