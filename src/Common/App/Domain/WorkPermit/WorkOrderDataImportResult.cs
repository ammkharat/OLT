using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkOrderDataImportResult
    {
        private readonly Error error;

        public WorkOrderDataImportResult()
        {
            error = Error.HasNoError;
        }

        public WorkOrderDataImportResult(string errorMessage)
        {
            error = new Error(errorMessage);
        }

        public Error Error
        {
            get { return error; }
        }

        public bool HasError
        {
            get { return error.HasError; }
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

        public static string BuildDisplayText(PermitRequestPostFinalizeResult finalizeResult,
            List<WorkOrderDataImportResult> importResults)
        {
            var errorMessages = new List<string>();

            var rejectionList = finalizeResult.RejectList;
            var successfulImportCount = finalizeResult.ImportCount - rejectionList.Count;

            foreach (var importResult in importResults)
            {
                if (importResult.HasError)
                {
                    errorMessages.Add(importResult.Error.Message);
                }
            }

            var sb = new StringBuilder();

            if (successfulImportCount > 0)
            {
                sb.AppendFormat(StringResources.PermitRequestImportResultSuccess, successfulImportCount);
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