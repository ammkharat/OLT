using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.Adapters;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Validators
{
    /// <summary>
    ///     The class processes a memory stream containing an XML based FLOC
    ///     message and deserialises it into a object before validating its
    ///     content.
    /// </summary>
    public class FLOCValidator : Validator
    {
        private readonly ILog logger;

        public FLOCValidator() : this(LogManager.GetLogger(typeof (FLOCValidator)))
        {
        }

        public FLOCValidator(ILog logger)
        {
            this.logger = logger;
        }

        /// <summary>
        ///     Called by the message handler layer.
        /// </summary>
        /// <param name="flocStream">A memory stream containing decoded XML</param>
        /// <returns>A validated FLOC data object contained in a memory stream</returns>
        public FunctionalLocationXmlMessage Parse(Stream flocStream)
        {
            // The XML document to deserialize into the XmlSerializer object.
            using (var reader = new StreamReader(flocStream, Encoding.Default, true))
            {
                // Use the XmlSerializer object to convert the XML
                var serializer = new XmlSerializer(typeof (FunctionalLocationXmlMessage));
                return (FunctionalLocationXmlMessage) serializer.Deserialize(reader);
            }
        }

        /// <summary>
        ///     Perform field level validation on the FLOC data object.
        ///     Ideally we would use the xsd schema to perform this function,
        ///     but the supplied xsd does not validate against the generated data.
        /// </summary>
        /// <param name="checkData">Functional Location data object</param>
        /// <returns>Boolean valid indicating if the data is valid.</returns>
        public bool Validate(FunctionalLocationXmlMessage checkData)
        {
            if (checkData == null) return false;
            if (checkData.FunctionalLocationXmlRecord == null) return false;
            if (checkData.FunctionalLocationXmlRecord.FunctionalLocationDetails == null) return false;
            if (checkData.FunctionalLocationXmlRecord.FunctionalLocationDetails[0] == null) return false;

            var functionalLocationDetails = checkData.FunctionalLocationXmlRecord.FunctionalLocationDetails[0];
            return DoesPassRequirementsCheck(functionalLocationDetails);
        }

        public bool DoesPassRequirementsCheck(FunctionalLocationDetails details)
        {
            var result = true;
            var logMessage = new StringBuilder();

            var fullHierarichyIncludingSuperior = FlocAdapter.CreateFullHierarchyIncludingSuperior(
                details.FullHierarchy, details.SuperiorFullHierarchy);

            logMessage.AppendFormat("Requirements Check for FLOC Id: {0}, Action: {1}{2}",
                fullHierarichyIncludingSuperior,
                details.Action, Environment.NewLine);

            if (FailsIsRequired(details.Action))
            {
                logMessage.AppendFormat(" Action is invalid.{0}", Environment.NewLine);
                result = false;
            }
            else
            {
                var action = details.Action;

                if (action != "Add" && action != "Change" && action != "Delete")
                {
                    logMessage.AppendFormat(" Action is invalid.{0}{1}", action, Environment.NewLine);
                    result = false;
                }
            }

            if (FailsIsRequiredAndSizeCheck(details.PlantId, Constants.PLANT_ID_MAX_LENGTH))
            {
                logMessage.AppendFormat(" PlantID is invalid. Was: {0}{1}", details.PlantId, Environment.NewLine);
                result = false;
            }

            if (FailsNumberOfLevelsCheck(fullHierarichyIncludingSuperior, Constants.FLOC_LEVELS_ALLOWED))
            {
                logMessage.AppendFormat(" FLOC {0} has too many levels for OLT.  OLT supports {1} levels.{2}",
                    fullHierarichyIncludingSuperior, Constants.FLOC_LEVELS_ALLOWED, Environment.NewLine);
                result = false;
            }

            if (FailsIsRequiredAndSizeCheck(fullHierarichyIncludingSuperior, Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH))
            {
                logMessage.AppendFormat(" FLOCID is invalid. Was: {0}{1}", fullHierarichyIncludingSuperior,
                    Environment.NewLine);
                result = false;
            }

            if (result)
            {
                logMessage.Append(" successfully passed requirements check in FLOC Validator.");
                logger.Debug(logMessage.ToString());
            }
            else
            {
                logger.Error(logMessage.ToString());
            }

            return result;
        }

        private bool FailsNumberOfLevelsCheck(string fullHierarichyIncludingSuperior, int flocLevelsAllowed)
        {
            if (fullHierarichyIncludingSuperior.IsNullOrEmptyOrWhitespace())
                return false;

            return new FunctionalLocationHierarchy(fullHierarichyIncludingSuperior).Level > flocLevelsAllowed;
        }
    }
}