using arbovirose.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace arbovirose.Domain.ValueObjects
{
    public class Email
    {
        public string value { get; set; } = "";
        public Email() { }
        public Email(string email)
        {
            if (!IsValid(email)) throw new InvalidEmailException();
            this.value = email;
        }
        public bool IsValidEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (Regex.IsMatch(email, pattern)) return true;

            return false;
        }
        public bool IsValid(string email)
        {
            if (IsValidEmail(email)) return true;

            return false;
        }
    }
}
