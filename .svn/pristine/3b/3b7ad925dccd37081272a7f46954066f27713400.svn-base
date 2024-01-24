using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class UserInformation
    {
        private readonly string sapId;
        private readonly string firstName;
        private readonly string lastName;

        public UserInformation(string firstName, string lastName, string sapId)
        {
            this.sapId = sapId;
            this.firstName = firstName.CapitalizeFully();
            this.lastName = lastName.CapitalizeFully();
        }

        public string SapId
        {
            get { return sapId; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public string FirstName
        {
            get { return firstName; }
        }
    }
}
