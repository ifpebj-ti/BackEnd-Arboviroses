using arbovirose.Domain.Exceptions;
using arbovirose.Domain.ValueObjects;

namespace arbovirose.Domain.Entities
{
    public class UserEntity
    {
        public UserEntity () { }
        public UserEntity (
            string Name,
            Email Email,
            string Password,
            Guid ProfileId
        ) 
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Email = Email;
            this.Password = Password ?? Name+"_"+Email;
            this.UniqueCode = new UniqueCode();
            this.ProfileId = ProfileId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public Email Email { get; set; } = null!;
        public string Password { get; set; } = "";
        public UniqueCode UniqueCode { get; set; } = null!;
        public bool Active { get; set; } = true;
        public bool PrimaryAccess { get; set; } = false;
        public ProfileEntity Profile { get; set; } = null!;
        public Guid ProfileId { get; set; }

        public void VerifyGenericPassword(string password)
        {
            if(this.Password != password) throw new InvalidUserGenericPassword();
        }
    }
}
