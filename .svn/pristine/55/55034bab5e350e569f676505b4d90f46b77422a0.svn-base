using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class LabAlertRetrySchedule : SingleSchedule
    {
        private readonly LabAlertDefinition definition;
        private readonly ISchedule originalSchedule;

        public LabAlertRetrySchedule(LabAlertDefinition definition, ISchedule originalSchedule, Date startDate,
            Time startTime, Time endTime, Site site)
            : base(startDate, startTime, endTime, site)
        {
            this.definition = definition;
            this.originalSchedule = originalSchedule;
        }

        public LabAlertDefinition Definition
        {
            get { return definition; }
        }

        public ISchedule OriginalSchedule
        {
            get { return originalSchedule; }
        }
    }
}