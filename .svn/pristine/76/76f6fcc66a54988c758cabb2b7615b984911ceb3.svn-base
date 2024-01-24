using System;
using System.Text;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestImportRejection //: IHasPermitKey
    {
        private readonly string endDate;

        private readonly string exceptionMessage;
        private readonly string functionalLocation;
        private readonly string longText;
        private readonly string operationNumber;
        private readonly string reason;
        private readonly RejectionType rejectionType;
        private readonly string shortText;
        private readonly string startDate;
        private readonly string subOperationNumber;
        private readonly string workOrderNumber;

        public PermitRequestImportRejection(string reason, string functionalLocation, string operationNumber,
            string subOperationNumber,
            string workOrderNumber, string longText, string shortText, string startDate, string endDate)
        {
            this.reason = reason;
            this.functionalLocation = functionalLocation;
            this.operationNumber = operationNumber;
            this.subOperationNumber = subOperationNumber;
            this.workOrderNumber = workOrderNumber;
            this.longText = longText;
            this.shortText = shortText;
            this.startDate = startDate;
            this.endDate = endDate;
            rejectionType = RejectionType.Validation;
        }

        public PermitRequestImportRejection(string reason, Exception exception)
        {
            this.reason = reason;
            exceptionMessage = exception.Message;
            rejectionType = RejectionType.Exception;
        }

        public PermitRequestImportRejection(string reason)
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

        public string WorkOrderNumber
        {
            get { return workOrderNumber; }
        }

        public string OperationNumber
        {
            get { return operationNumber; }
        }

        public string SubOperationNumber
        {
            get { return subOperationNumber; }
        }

        public string WorkOrderNumberListAsString
        {
            get { return WorkOrderNumber; }
        }

        public string OperationNumberListAsString
        {
            get { return OperationNumber; }
        }

        public string SubOperationNumberListAsString
        {
            get { return SubOperationNumber; }
        }

        public string LongText
        {
            get { return longText; }
        }

        public string ShortText
        {
            get { return shortText; }
        }

        public string StartDate
        {
            get { return startDate; }
        }

        public string EndDate
        {
            get { return endDate; }
        }

        public string BuildRejectedPermitRequestDescription()
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
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_Reason, reason);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_ErrorMessage, exceptionMessage);

            return sb.ToString();
        }

        private string BuildDescriptionForValidationFailure()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_Reason, reason);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_FunctionalLocation,
                FunctionalLocation);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_OperationNumber,
                OperationNumber);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_WorkOrderNumber,
                WorkOrderNumber);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_ShortText, ShortText);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_LongText, LongText);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_StartDate, StartDate);
            sb.AppendLine();
            sb.AppendFormat(
                "{0}: {1}", StringResources.PermitRequestRejectionStringDescriptionLabel_EndDate, EndDate);

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

        //public bool MatchesByPermitKey(IHasPermitKey item)
        //{
        //    return PermitKeyData.MatchesByPermitKey(this, item);
        //}
    }
}