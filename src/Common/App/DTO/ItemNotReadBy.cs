using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ItemNotReadBy:DomainObject
    {
       // private readonly DateTime dateTime;
        private readonly string userFullNameWithUserName;
        private readonly string userid;

        public ItemNotReadBy(string userFullNameWithUserName, string userid)
        {
            this.userFullNameWithUserName = userFullNameWithUserName;
            this.userid = userid;
        }
        //public DateTime DateTime
        //{
        //    get { return dateTime; }
        //}

        public string UserFullNameWithUserName
        {
            get { return userFullNameWithUserName; }
        }

        public string UserID { get { return userid; } }

    }
}
