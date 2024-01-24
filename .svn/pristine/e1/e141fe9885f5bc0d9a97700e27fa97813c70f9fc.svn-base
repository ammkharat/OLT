using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmToeDefinition : DomainObject
    {
        public OpmToeDefinition(long id, long toeVersion, string historianTag, DateTime toeVersionPublishDate,
            string toeName, string functionalLocation, long functionalLocationId, ToeType toeType, decimal limitValue, string causesDescription,
            string consequencesDescription, string correctiveActionDescription, string referencesDocuments, string unitOfMeasure, string opmToeHistoryUrl)
            : base(id)
        {
            ToeVersion = toeVersion;
            HistorianTag = historianTag;
            ToeVersionPublishDate = toeVersionPublishDate;
            ToeName = toeName;
            FunctionalLocation = functionalLocation;
            FunctionalLocationId = functionalLocationId;
            ToeType = toeType;
            LimitValue = limitValue;
            CausesDescription = causesDescription;
            ConsequencesDescription = consequencesDescription;
            CorrectiveActionDescription = correctiveActionDescription;
            ReferencesDocuments = referencesDocuments;
            UnitOfMeasure = unitOfMeasure;
            OpmToeHistoryUrl = opmToeHistoryUrl;
        }

        public OpmToeDefinitionComment OpmToeDefinitionComment { get; set; }

        public long ToeVersion { get; set; }
        public string HistorianTag { get; set; }
        public DateTime ToeVersionPublishDate { get; set; }
        public string ToeName { get; set; }
        public string FunctionalLocation { get; set; }
        public long FunctionalLocationId { get; set; }
        public ToeType ToeType { get; set; }
        public decimal LimitValue { get; set; }
        public string CausesDescription { get; set; }
        public string ConsequencesDescription { get; set; }
        public string CorrectiveActionDescription { get; set; }
        public string ReferencesDocuments { get; set; }
        public string UnitOfMeasure { get; set; }
        public string OpmToeHistoryUrl { get; set; }
    }
}