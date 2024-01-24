using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain
{
    public class OilsandsTrainingItemDisplayAdapter : IDataErrorInfo
    {
        private readonly FormOilsandsTrainingItem trainingItem;
        private readonly List<string> errors = new List<string>();

        public OilsandsTrainingItemDisplayAdapter(FormOilsandsTrainingItem trainingItem)
        {
            this.trainingItem = trainingItem;
        }

        public FormOilsandsTrainingItem GetTrainingItem()
        {
            return trainingItem;
        }

        public TrainingBlock TrainingBlock
        {
            get { return trainingItem.TrainingBlock; }
            set { trainingItem.TrainingBlock = value; }
        }

        public string Comments
        {
            get { return trainingItem.Comments; }
            set { trainingItem.Comments = value; }
        }

        //ayman training form add column
        public string Supervisor
        {
            get { return trainingItem.Supervisor; }
            set { trainingItem.Supervisor = value; }
        }


        public bool BlockCompleted
        {
            get { return trainingItem.BlockCompleted; }
            set { trainingItem.BlockCompleted = value; }
        }

        public decimal? Hours
        {
            get { return trainingItem.Hours; }
            set { trainingItem.Hours = value; }
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
