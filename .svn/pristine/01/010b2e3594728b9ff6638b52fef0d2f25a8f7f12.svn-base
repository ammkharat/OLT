using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Integration.Handlers
{
    /// <summary>
    ///     The class provides helper methods used during the validation of SAP messages.
    /// </summary>
    public abstract class Validator
    {
        /// <summary>
        ///     Check that the supplied object is not null or empty, and not greater than the maximum size.
        /// </summary>
        /// <param name="stringToCheck">object to check</param>
        /// <param name="maxSize">Maximum size of object.</param>
        /// <returns>Returns false if the object is non null or empty and does not exceed the max size; true otherwise.</returns>
        protected static bool FailsIsRequiredAndSizeCheck(string stringToCheck, int maxSize)
        {
            if (maxSize <= 0)
            {
                throw new ArgumentException("Max size must be greater than 0.", "maxSize");
            }
            if (FailsIsRequired(stringToCheck))
            {
                return true;
            }
            if (stringToCheck.Length > maxSize)
            {
                return true;
            }

            return false;
        }

        protected static bool FailsIsRequired(string stringToCheck)
        {
            return stringToCheck.IsNullOrEmptyOrWhitespace();
        }

        /// <summary>
        ///     Validation helper routine
        ///     Checked that the supplied object is not greater
        ///     than the maximum size.
        /// </summary>
        /// <param name="stringToCheck">Object to check</param>
        /// <param name="maxSize">Maximum size of object.</param>
        /// <returns>Returns true if the object does not exceed the max size, or is null</returns>
        protected static bool FailsNotRequiredAndSizeCheck(string stringToCheck, int maxSize)
        {
            return !stringToCheck.IsNullOrEmptyOrWhitespace() && stringToCheck.Length > maxSize;
        }
    }
}