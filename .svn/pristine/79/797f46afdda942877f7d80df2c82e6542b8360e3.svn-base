using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionImportResult
    {
        private readonly Error error;
        private readonly List<OpmExcursionDTO> importedExcursions = new List<OpmExcursionDTO>();
        private readonly List<OpmExcursionImportRejection> rejections = new List<OpmExcursionImportRejection>();

        public OpmExcursionImportResult()
        {
            error = Error.HasNoError;
        }

        public OpmExcursionImportResult(List<OpmExcursionImportRejection> rejections)
        {
            this.rejections.AddRange(rejections);
            error = Error.HasNoError;
        }

        public OpmExcursionImportResult(List<OpmExcursionImportRejection> rejections,
            List<OpmExcursionDTO> importedExcursions)
        {
            this.rejections.AddRange(rejections);
            this.importedExcursions = importedExcursions;
            error = Error.HasNoError;
        }

        public OpmExcursionImportResult(string errorMessage)
        {
            error = new Error(errorMessage);
        }

        public List<OpmExcursionImportRejection> Rejections
        {
            get { return rejections; }
        }

        public List<OpmExcursionDTO> ImportedExcursions
        {
            get { return importedExcursions; }
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
            get { return importedExcursions.Count > 0; }
        }

        public string BuildDisplayText()
        {
            var sb = new StringBuilder();

            if (HasResults)
            {
                sb.AppendFormat("{0} Excursion(s) were successfully imported.", importedExcursions.Count);
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

        private static void ApplyRejectionText(StringBuilder sb, List<OpmExcursionImportRejection> rejectionList)
        {
            sb.AppendFormat(
                "{0} Excursion(s) were received from OPM but could not be imported. See below for details.",
                rejectionList.Count);
            sb.AppendLine();
            sb.AppendLine();

            foreach (var rejection in rejectionList)
            {
                sb.Append(rejection.BuildRejectedExcursionDescription());
                sb.AppendLine();
                sb.AppendLine();
            }
        }
    }
}