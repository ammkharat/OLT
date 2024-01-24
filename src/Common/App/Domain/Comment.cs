using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Comment : DomainObject, IComparable
    {
        private readonly User createdBy;
        private readonly DateTime createdDate;
        private readonly string text;

        public Comment(User createdBy, DateTime createdDate, string text)
        {
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.text = text;
        }


        public User CreatedBy
        {
            get { return createdBy; }
        }

        public string CreatedByUserName
        {
            get { return createdBy.Username; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
        }

        public string Text
        {
            get { return text; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            var that = (Comment) obj;
            return CreatedDate.CompareTo(that.CreatedDate);
        }

        #endregion
    }
}