using arbovirose.Domain.Enums;
using arbovirose.Domain.Exceptions;

namespace arbovirose.Domain.ValueObjects
{
    public class Office
    {
        public string value { get; set; } = "";
        public Office() { }
        public Office(string office)
        {
            if (!IsValid(office)) throw new InvalidOfficeException();
            this.value = office;
        }
        public bool IsValidOffice(string office)
        {
            if (office != TypeOffice.Administrator.ToString() && office != TypeOffice.Editor.ToString()) return false;

            return true;
        }
        public bool IsValid(string office)
        {
            if (IsValidOffice(office)) return true;

            return false;
        }
    }
}
