using System;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.Exceptions
{
    public class OpmXhqInvalidAuthenticationException : OLTException
    {
        private readonly string helpDeskErrorCode;

        public OpmXhqInvalidAuthenticationException(string helpDeskErrorCode, Exception innerException, string domain,
            string userName) :
                base(
                string.Format(
                    "Authorization failed for domain user {0}\\{1} while attempting to import excursion data from OPM.",
                    domain, userName), innerException)
        {
            this.helpDeskErrorCode = helpDeskErrorCode;
        }

        public OpmXhqInvalidAuthenticationException(string helpDeskErrorCode, string domain, string userName)
            : base(
                string.Format(
                    "Authorization failed for domain user {0}\\{1} while attempting to import excursion data from OPM.",
                    domain, userName))
        {
            this.helpDeskErrorCode = helpDeskErrorCode;
        }

        public string HelpDeskErrorCode
        {
            get { return helpDeskErrorCode; }
        }
    }
}