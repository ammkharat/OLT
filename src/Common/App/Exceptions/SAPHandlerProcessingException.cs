using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class SAPHandlerProcessingException : OLTException
    {
        private string subject = String.Empty;

        public SAPHandlerProcessingException()
        {
        }

        public SAPHandlerProcessingException(string message)
            : base(message)
        {
        }

        public SAPHandlerProcessingException(string message, string subject)
            : base(message)
        {
            this.subject = subject;
        }

        public SAPHandlerProcessingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public SAPHandlerProcessingException(string message, Exception innerException)
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