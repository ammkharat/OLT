using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class TrainingBlockReportAdapter
    {
        private readonly FormOilsandsTrainingItem item;
        private readonly long parentId;

        public TrainingBlockReportAdapter(long parentId, FormOilsandsTrainingItem item)
        {
            this.parentId = parentId;
            this.item = item;
        }

        public long ParentId
        {
            get { return parentId; }
        }

        public string Name
        {
            get { return item.TrainingBlock.Name; }
        }

        public string Comments
        {
            get { return item.Comments; }
        }

        //ayman training form add column
        public string Supervisor
        {
            get { return item.Supervisor; }
        }

        public bool IsComplete
        {
            get { return item.BlockCompleted; }
        }

        public bool IsNotComplete
        {
            get { return !item.BlockCompleted; }
        }

        public decimal Hours
        {
            get { return item.Hours.GetValueOrDefault(0); }
        }
    }
}