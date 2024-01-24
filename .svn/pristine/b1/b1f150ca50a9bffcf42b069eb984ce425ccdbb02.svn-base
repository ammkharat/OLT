using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmToeDefinitionCommentHistory : DomainObjectHistorySnapshot
    {
        public OpmToeDefinitionCommentHistory(long id, string toeName, User lastModifiedBy, DateTime lastModifiedDate,
            string comment)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            ToeName = toeName;
            Comment = comment;
        }

        public string ToeName { get; set; }
        public string Comment { get; set; }
    }
}