using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class SAPHandlerValidationException : OLTException
    {
        private string subject = String.Empty;

        public SAPHandlerValidationException()
        {
        }

        public SAPHandlerValidationException(string message)
            : base(message)
        {
        }

        public SAPHandlerValidationException(string message, string subject)
            : base(message)
        {
            this.subject = subject;
        }

        public SAPHandlerValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public SAPHandlerValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}