using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class UserDTO : DomainObject
    {
        public UserDTO(long id, string userName, string firstName, string lastName) : base(id)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName
        {
            get { return User.ToFullName(FirstName, LastName); }
        }
    }
}