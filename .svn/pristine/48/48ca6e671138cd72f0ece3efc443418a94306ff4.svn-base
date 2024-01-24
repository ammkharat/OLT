using System;
using System.IO;
using Com.Suncor.Olt.Integration.Handlers.Adapters;
using Com.Suncor.Olt.Integration.Handlers.Validators;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class FunctionalLocationMessageHandler
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (FunctionalLocationMessageHandler));

        /// <summary>
        ///     Processes the XML data (supplied by SAP-IDD0307) and either add, change
        ///     or delete the functional location record.
        /// </summary>
        /// <param name="flocStream">Memory stream containing the decoded XML data</param>
        public void ProcessFunctionalLocation(Stream flocStream)
        {
            var flocProcessor = new FLOCValidator();

            var functionalLocationXmlMessageObj = flocProcessor.Parse(flocStream);

            var valid = flocProcessor.Validate(functionalLocationXmlMessageObj);

            if (!valid)
                throw new ApplicationException(
                    "Invalid data was sent from SAP in the FLOC message. This message will not be processsed.");

            var adapter =
                new FlocAdapter(
                    functionalLocationXmlMessageObj.FunctionalLocationXmlRecord.FunctionalLocationDetails[0], logger);
            adapter.IntegrateFlocObjectToOperatorLogTool();
        }
    }
}