using System;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class Error
    {
        public static readonly Error HasNoError = new Error(false, string.Empty);

        private readonly bool hasError;
        private readonly string message;

        public Error(string message) : this(true, message)
        {
        }

        private Error(bool hasError, string message)
        {
            this.hasError = hasError;
            this.message = message;
        }

        public bool HasError
        {
            get { return hasError; }
        }

        public string Message
        {
            get { return message; }
        }
    }
}