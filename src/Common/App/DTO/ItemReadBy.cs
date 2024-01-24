using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ItemReadBy : DomainObject
    {
        private readonly DateTime dateTime;
        private readonly string userFullNameWithUserName;

        public ItemReadBy(string userFullNameWithUserName, DateTime dateTime)
        {
            this.userFullNameWithUserName = userFullNameWithUserName;
            this.dateTime = dateTime;
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public string UserFullNameWithUserName
        {
            get { return userFullNameWithUserName; }
        }
    }
}