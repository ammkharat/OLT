using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormOilsandsTrainingItem : DomainObject
    {
        public FormOilsandsTrainingItem(long? id, long? formOilsandsTrainingId, TrainingBlock trainingBlock,            //ayman training form add column
            string comments, string supervisor, bool blockCompleted, decimal hours)
        {
            this.id = id;
            FormOilsandsTrainingId = formOilsandsTrainingId;
            TrainingBlock = trainingBlock;
            Comments = comments;
            Supervisor = supervisor;                           //ayman training form add column
            BlockCompleted = blockCompleted;
            Hours = hours;
        }

        public long? FormOilsandsTrainingId { get; set; }

        public TrainingBlock TrainingBlock { get; set; }

        public string Comments { get; set; }

        public string Supervisor { get; set; }                      //ayman training form add column

        public bool BlockCompleted { get; set; }

        public decimal? Hours { get; set; }
    }
}