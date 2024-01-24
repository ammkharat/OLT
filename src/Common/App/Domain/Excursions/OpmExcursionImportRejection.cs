using System;
using System.Text;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionImportRejection
    {
        private readonly string average;
        private readonly string duration;
        private readonly string endDate;
        private readonly string engineerComments;
        private readonly string exceptionMessage;
        private readonly string excursionStatus;
        private readonly string functionalLocation;
        private readonly string historianTag;
        private readonly string ilpNumber;
        private readonly string oltOperatorResponse;
        private readonly string opmTrendUrl;
        private readonly string peak;
        private readonly string reason;
        private readonly string reasonCode;
        private readonly RejectionType rejectionType;
        private readonly string startDate;
        private readonly string toeLimitValue;
        private readonly string toeName;
        private readonly string toeType;
        private readonly string toeVersion;
        private readonly string unitOfMeasure;

        public OpmExcursionImportRejection(string reason, string functionalLocation, string toeName,
            string toeType, string toeVersion, string excursionStatus, string startDate, string endDate,
            string unitOfMeasure, string peak,
            string average, string duration, string ilpNumber, string engineerComments, string oltOperatorResponse,
            string reasonCode, string toeLimitValue, string opmTrendUrl, string historianTag)
        {
            this.reason = reason;
            this.functionalLocation = functionalLocation;
            this.toeName = toeName;
            this.toeType = toeType;
            this.toeVersion = toeVersion;
            this.excursionStatus = excursionStatus;
            this.startDate = startDate;
            this.endDate = endDate;
            this.unitOfMeasure = unitOfMeasure;
            this.peak = peak;
            this.average = average;
            this.duration = duration;
            this.ilpNumber = ilpNumber;
            this.engineerComments = engineerComments;
            this.oltOperatorResponse = oltOperatorResponse;
            this.reasonCode = reasonCode;
            this.toeLimitValue = toeLimitValue;
            this.opmTrendUrl = opmTrendUrl;
            this.historianTag = historianTag;
            rejectionType = RejectionType.Validation;
        }

        public OpmExcursionImportRejection(string reason, Exception exception)
        {
            this.reason = reason;
            exceptionMessage = exception.Message;
            rejectionType = RejectionType.Exception;
        }

        public OpmExcursionImportRejection(string reason)
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

        public string Average
        {
            get { return average; }
        }

        public string EngineerComments
        {
            get { return engineerComments; }
        }

        public string Duration
        {
            get { return duration; }
        }

        public string ExcursionStatus
        {
            get { return excursionStatus; }
        }

        public string IlpNumber
        {
            get { return ilpNumber; }
        }

        public string OltOperatorResponse
        {
            get { return oltOperatorResponse; }
        }

        public string Peak
        {
            get { return peak; }
        }

        public string ReasonCode
        {
            get { return reasonCode; }
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

        public string StartDate
        {
            get { return startDate; }
        }

        public string EndDate
        {
            get { return endDate; }
        }

        public string OpmTrendUrl
        {
            get { return opmTrendUrl; }
        }

        public string HistorianTag
        {
            get { return historianTag; }
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
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_Reason, reason);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_FunctionalLocation,
                FunctionalLocation);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_Average,
                Average);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_EngineerComments,
                EngineerComments);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_Duration, Duration);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ExcursionStatus,
                ExcursionStatus);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_IlpNumber, IlpNumber);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_OltOperatorResponse,
                OltOperatorResponse);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_Peak, Peak);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ReasonCode, ReasonCode);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ToeLimitValue,
                ToeLimitValue);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ToeName, ToeName);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ToeType, ToeType);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_ToeVersion, ToeVersion);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_HistorianTag, HistorianTag);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_UnitOfMeasure,
                UnitOfMeasure);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_OpmTrendUrl, OpmTrendUrl);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_StartDate, StartDate);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.OpmExcursionImportRejectionStringDescriptionLabel_EndDate, EndDate);

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