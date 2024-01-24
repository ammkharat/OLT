using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestImportResult
    {
        private readonly Error error;
        private readonly List<IHasPermitKey> importedWorkOrders = new List<IHasPermitKey>();
        private readonly List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
        private readonly List<PermitRequestImportRejection> rejections = new List<PermitRequestImportRejection>();

        public PermitRequestImportResult()
        {
            error = Error.HasNoError;
        }

        public PermitRequestImportResult(List<NotifiedEvent> notifiedEvents,
            List<PermitRequestImportRejection> rejections)
        {
            this.notifiedEvents.AddRange(notifiedEvents);
            this.rejections.AddRange(rejections);
            error = Error.HasNoError;
        }

        public PermitRequestImportResult(List<NotifiedEvent> notifiedEvents,
            List<PermitRequestImportRejection> rejections, List<IHasPermitKey> importedWorkOrders)
        {
            this.notifiedEvents.AddRange(notifiedEvents);
            this.rejections.AddRange(rejections);
            this.importedWorkOrders = importedWorkOrders;
            error = Error.HasNoError;
        }

        public PermitRequestImportResult(string errorMessage)
        {
            error = new Error(errorMessage);
        }

        public List<NotifiedEvent> NotifiedEvents
        {
            get { return notifiedEvents; }
        }

        public List<PermitRequestImportRejection> Rejections
        {
            get { return rejections; }
        }

        public List<IHasPermitKey> ImportedWorkOrders
        {
            get { return importedWorkOrders; }
        }

        public Error Error
        {
            get { return error; }
        }

        public bool HasRejections
        {
            get { return rejections.Count > 0; }
        }

        public bool HasError
        {
            get { return error.HasError; }
        }

        public bool HasResults
        {
            get { return notifiedEvents.Count > 0; }
        }

        public string BuildDisplayText()
        {
            var sb = new StringBuilder();

            if (HasResults)
            {
                sb.AppendFormat(StringResources.PermitRequestImportResultSuccess, notifiedEvents.Count);
                sb.AppendLine();
                sb.AppendLine();
            }

            if (HasRejections)
            {
                ApplyRejectionText(sb, Rejections);
            }

            if (HasError)
            {
                sb.AppendLine(error.Message);
            }

            return sb.ToString();
        }

        private static void ApplyRejectionText(StringBuilder sb, List<PermitRequestImportRejection> rejectionList)
        {
            sb.AppendFormat(StringResources.PermitRequestImportResultFailure, rejectionList.Count);
            sb.AppendLine();
            sb.AppendLine();

            foreach (var rejection in rejectionList)
            {
                sb.Append(rejection.BuildRejectedPermitRequestDescription());
                sb.AppendLine();
                sb.AppendLine();
            }
        }

        public static string BuildDisplayText(List<PermitRequestImportResult> results, int additionalSuccessCount)
        {
            var resultCount = 0;
            var rejectionList = new List<PermitRequestImportRejection>();
            var errorMessages = new List<string>();

            foreach (var result in results)
            {
                resultCount += result.notifiedEvents.Count;

                rejectionList.AddRange(result.Rejections);

                if (result.HasError)
                {
                    errorMessages.Add(result.Error.Message);
                }
            }

            var sb = new StringBuilder();

            if (resultCount > 0 || additionalSuccessCount > 0)
            {
                sb.AppendFormat(StringResources.PermitRequestImportResultSuccess, resultCount + additionalSuccessCount);
                sb.AppendLine();
                sb.AppendLine();
            }

            if (rejectionList.Count > 0)
            {
                ApplyRejectionText(sb, rejectionList);
            }

            if (errorMessages.Count > 0)
            {
                foreach (var errorMessage in errorMessages)
                {
                    sb.AppendLine(errorMessage);
                }
            }

            return sb.ToString();
        }
    }
}