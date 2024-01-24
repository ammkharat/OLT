using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmToeDefinitionComment : DomainObject
    {
        public OpmToeDefinitionComment(long id, long toeVersion, string toeName, string historianTag, User lastModifiedBy, string comment, DateTime lastModifiedDateTime, long oltToeDefinitionId)
            : base(id)
        {
            ToeVersion = toeVersion;
            ToeName = toeName;
            HistorianTag = historianTag;
            LastModifiedBy = lastModifiedBy;
            Comment = comment;
            LastModifiedDateTime = lastModifiedDateTime;
            OltToeDefinitionId = oltToeDefinitionId;
        }

        public OpmToeDefinitionComment(OpmToeDefinition opmToeDefinition)
        {
            ToeVersion = opmToeDefinition.ToeVersion;
            ToeName = opmToeDefinition.ToeName;
            HistorianTag = opmToeDefinition.HistorianTag;
            OltToeDefinitionId = opmToeDefinition.IdValue;
        }

        public long ToeVersion { get; set; }
        public string ToeName { get; set; }
        public string HistorianTag { get; set; }
        public User LastModifiedBy { get; set; }
        public string Comment { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public long OltToeDefinitionId { get; set; }

        public OpmToeDefinitionCommentHistory TakeSnapshot()
        {
            return new OpmToeDefinitionCommentHistory(IdValue,ToeName,LastModifiedBy,LastModifiedDateTime,Comment);
        }
    }
}