using System;
using System.Text;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmToeDefinitionImportRejection
    {
        private readonly string causesDescription;
        private readonly string consequencesDescription;
        private readonly string correctiveActionDescription;
        private readonly string exceptionMessage;
        private readonly string functionalLocation;
        private readonly string historianTag;
        private readonly string opmToeHistoryUrl;
        private readonly string publishDate;

        private readonly string reason;
        private readonly string referencesDocuments;
        private readonly RejectionType rejectionType;
        private readonly string toeLimitValue;
        private readonly string toeName;
        private readonly string toeType;
        private readonly string toeVersion;
        private readonly string unitOfMeasure;

        public OpmToeDefinitionImportRejection(string reason, string functionalLocation, string toeName,
            string toeType, string toeVersion, string publishDate, string unitOfMeasure, string toeLimitValue,
            string opmToeHistoryUrl, string historianTag, string causesDescription, string consequencesDescription,
            string correctiveActionDescription, string referencesDocuments)
        {
            this.reason = reason;
            this.functionalLocation = functionalLocation;
            this.toeName = toeName;
            this.toeType = toeType;
            this.toeVersion = toeVersion;
            this.unitOfMeasure = unitOfMeasure;
            this.toeLimitValue = toeLimitValue;
            this.historianTag = historianTag;
            this.publishDate = publishDate;
            this.opmToeHistoryUrl = opmToeHistoryUrl;
            this.causesDescription = causesDescription;
            this.consequencesDescription = consequencesDescription;
            this.correctiveActionDescription = correctiveActionDescription;
            this.referencesDocuments = referencesDocuments;
            rejectionType = RejectionType.Validation;
        }

        public OpmToeDefinitionImportRejection(string reason, Exception exception)
        {
            this.reason = reason;
            exceptionMessage = exception.Message;
            rejectionType = RejectionType.Exception;
        }

        public OpmToeDefinitionImportRejection(string reason)
        {
            this.reason = reason;
            rejectionType = RejectionType.Other;
        }

        public string Reason
        {
            get { return reason; }
        }

        public string FunctionalLocation
        {
            get { return functionalLocation; }
        }

        public string ToeLimitValue
        {
            get { return toeLimitValue; }
        }

        public string ToeName
        {
            get { return toeName; }
        }

        public string ToeType
        {
            get { return toeType; }
        }

        public string ToeVersion
        {
            get { return toeVersion; }
        }

        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
        }

        public string ToeVersionPublishDate
        {
            get { return publishDate; }
        }

        public string OpmToeHistoryUrl
        {
            get { return opmToeHistoryUrl; }
        }

        public string HistorianTag
        {
            get { return historianTag; }
        }

        public string CausesDescription
        {
            get { return causesDescription; }
        }

        public string ConsequencesDescription
        {
            get { return consequencesDescription; }
        }

        public string CorrectiveActionDescription
        {
            get { return correctiveActionDescription; }
        }

        public string ReferencesDocuments
        {
            get { return referencesDocuments; }
        }

        public string BuildRejectedExcursionDescription()
        {
            string description;

            if (rejectionType == RejectionType.Exception)
            {
                description = BuildDescriptionForException();
            }
            else if (rejectionType == RejectionType.Validation)
            {
                description = BuildDescriptionForValidationFailure();
            }
            else
            {
                description = BuildDescription();
            }

            return description;
        }

        private string BuildDescriptionForException()
        {
            var sb = new StringBuilder();

            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_Reason, reason);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ErrorMessage,
                exceptionMessage);

            return sb.ToString();
        }

        private string BuildDescriptionForValidationFailure()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_Reason, reason);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_FunctionalLocation,
                FunctionalLocation);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ToeLimitValue,
                ToeLimitValue);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ToeName, ToeName);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ToeType, ToeType);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ToeVersion, ToeVersion);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_HistorianTag, HistorianTag);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_UnitOfMeasure,
                UnitOfMeasure);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_OpmToeHistoryUrl,
                OpmToeHistoryUrl);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ToeVersionPublishDate,
                ToeVersionPublishDate);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_CausesDescription,
                CausesDescription);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ConsequencesDescription,
                ConsequencesDescription);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_CorrectiveActionDescription,
                CorrectiveActionDescription);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmToeDefinitionImportRejectionStringDescriptionLabel_ReferencesDocuments,
                ReferencesDocuments);

            return sb.ToString();
        }

        private string BuildDescription()
        {
            return reason;
        }

        private enum RejectionType
        {
            Validation,
            Exception,
            Other
        };
    }
}