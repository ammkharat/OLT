using System;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.Exceptions
{
    public class OpmXhqImportException : OLTException
    {
        private readonly string helpDeskErrorCode;

        public OpmXhqImportException(string helpDeskErrorCode, Exception innerException) :
            base("There was an unexpected error importing excursion data from OPM.", innerException)
        {
            this.helpDeskErrorCode = helpDeskErrorCode;
        }

        public OpmXhqImportException(string helpDeskErrorCode)
            : base("There was an unexpected error importing excursion data from OPM.")
        {
            this.helpDeskErrorCode = helpDeskErrorCode;
        }

        public string HelpDeskErrorCode
        {
            get { return helpDeskErrorCode; }
        }
    }
}