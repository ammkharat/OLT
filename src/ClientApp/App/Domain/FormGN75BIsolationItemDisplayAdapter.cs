using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain
{
    public class FormGN75BIsolationItemDisplayAdapter : IDataErrorInfo
    {
        private readonly IsolationItem isolationItem;
        private readonly List<string> errors = new List<string>();

        public FormGN75BIsolationItemDisplayAdapter(IsolationItem isolationItem)
        {
            this.isolationItem = isolationItem;
        }

        public IsolationItem GetIsolationItem()
        {
            return isolationItem;
        }

        //ayman Sarnia eip DMND0008992
        public string DevicePosition
        {
            get { return isolationItem.DevicePosition; }
            set { isolationItem.DevicePosition = value; }
        }

        public string TypeOfIsolation
        {
            get { return isolationItem.IsolationType; }
            set { isolationItem.IsolationType = value; }
        }

        public string LocationOfIsolation
        {
            get { return isolationItem.LocationOfEnergyIsolation; }
            set { isolationItem.LocationOfEnergyIsolation = value; }
        }

        public string this[string columnName]
        {
            get { return null; }   // we do not have cell-level validation turned on, so this should never be called
        }

        [Browsable(false)]   // setting browsable to false ensures that an Error column doesn't appear in the grid
        public string Error
        {
            get { return errors.Join(" "); }
        }

        public void ClearErrors()
        {
            errors.Clear();
        }

        public void AddError(string error)
        {
            errors.AddIfNotExist(error);
        }
    }
}