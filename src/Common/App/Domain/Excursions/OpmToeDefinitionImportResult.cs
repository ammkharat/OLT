using System;
using System.Text;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmToeDefinitionImportResult
    {
        private readonly Error error;
        private readonly OpmToeDefinitionDTO importedToeDefinition;
        private readonly OpmToeDefinitionImportRejection rejection;

        public OpmToeDefinitionImportResult()
        {
            error = Error.HasNoError;
        }

        public OpmToeDefinitionImportResult(OpmToeDefinitionImportRejection rejection)
        {
            this.rejection = rejection;
            error = Error.HasNoError;
        }

        public OpmToeDefinitionImportResult(OpmToeDefinitionImportRejection rejection,
            OpmToeDefinitionDTO importedToeDefinition)
        {
            this.rejection = rejection;
            this.importedToeDefinition = importedToeDefinition;
            error = Error.HasNoError;
        }

        public OpmToeDefinitionImportResult(string errorMessage)
        {
            error = new Error(errorMessage);
        }

        public OpmToeDefinitionImportRejection Rejection
        {
            get { return rejection; }
        }

        public OpmToeDefinitionDTO ImportedToeDefinition
        {
            get { return importedToeDefinition; }
        }

        public Error Error
        {
            get { return error; }
        }

        public bool HasRejection
        {
            get { return rejection != null; }
        }

        public bool HasError
        {
            get { return error.HasError; }
        }

        public bool HasResults
        {
            get { return importedToeDefinition != null; }
        }

        public string BuildDisplayText()
        {
            var sb = new StringBuilder();

            if (HasResults)
            {
                sb.AppendFormat("TOE Definition {0} version {1} was successfully imported.",
                    importedToeDefinition.ToeName, importedToeDefinition.ToeVersion);
                sb.AppendLine();
                sb.AppendLine();
            }

            if (HasRejection)
            {
                ApplyRejectionText(sb, Rejection);
            }

            if (HasError)
            {
                sb.AppendLine(error.Message);
            }

            return sb.ToString();
        }

        private void ApplyRejectionText(StringBuilder sb, OpmToeDefinitionImportRejection importRejection)
        {
            if (HasResults)
            {
                sb.AppendFormat(
                    "TOE Definition {0} version {1} was received from OPM but could not be imported. See below for details.",
                    ImportedToeDefinition.ToeName, ImportedToeDefinition.ToeVersion);
            }
            else
            {
                sb.Append("A TOE Definition was received from OPM but could not be imported. See below for details.");
            }
            sb.AppendLine();
            sb.AppendLine();

            sb.Append(importRejection.BuildRejectedExcursionDescription());
            sb.AppendLine();
            sb.AppendLine();
        }
    }
}