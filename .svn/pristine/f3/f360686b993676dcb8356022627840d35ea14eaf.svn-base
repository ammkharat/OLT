using System;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.Exceptions
{
    public class WorkOrderSAPImportException : OLTException
    {
        private readonly string helpDeskErrorCode;

        public WorkOrderSAPImportException(string helpDeskErrorCode, Exception innerException) : 
            base("There was an unexpected error importing work order data.", innerException)
        {
            this.helpDeskErrorCode = helpDeskErrorCode;
        }

        public WorkOrderSAPImportException(string helpDeskErrorCode) : base("There was an unexpected error importing work order data.")
        {
            this.helpDeskErrorCode = helpDeskErrorCode;
        }

        public string HelpDeskErrorCode
        {
            get { return helpDeskErrorCode; }
        }
    }
}