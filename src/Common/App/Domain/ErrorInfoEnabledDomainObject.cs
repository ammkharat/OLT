using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Allows subclasses to easily set row and column errors using the IDataErrorInfo interface. This is useful
    ///     when binding objects to grids and having the error messages show up nicely on the grids.
    /// </summary>
    [Serializable]
    public abstract class ErrorInfoEnabledDomainObject : DomainObject, IDataErrorInfo
    {
        private readonly Dictionary<string, string> errorMessagesForColumns = new Dictionary<string, string>();
        private string errorMessageForRow;

        public bool IsValid
        {
            get { return string.IsNullOrEmpty(errorMessageForRow) && errorMessagesForColumns.Count == 0; }
        }

        public string this[string columnName]
        {
            get
            {
                if (errorMessagesForColumns.ContainsKey(columnName))
                {
                    return errorMessagesForColumns[columnName];
                }

                return null;
            }
        }

        public string Error
        {
            get { return errorMessageForRow; }
        }

        public void ClearErrors()
        {
            errorMessageForRow = null;
            errorMessagesForColumns.Clear();
        }

        public void SetErrorForColumn(string columnName, string errorMessage)
        {
            if (!errorMessagesForColumns.ContainsKey(columnName))
            {
                errorMessagesForColumns.Add(columnName, errorMessage);
            }
            else
            {
                errorMessagesForColumns[columnName] = errorMessage;
            }
        }

        public void RemoveErrorForColumn(string columnName)
        {
            errorMessagesForColumns.Remove(columnName);
        }

        public void SetErrorForRow(string errorMessage)
        {
            errorMessageForRow = errorMessage;
        }
    }
}