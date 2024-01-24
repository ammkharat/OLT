using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    // runs a set of jobs synchronously so that they don't conflict with one another
    public class SynchronousJob : AbstractScheduledJob
    {
        private readonly string jobName;
        private readonly List<AbstractScheduledJob> jobs;

        public SynchronousJob(ISchedule scheduleForJob, String jobName) : base(scheduleForJob)
        {
            this.jobName = jobName;
            jobs = new List<AbstractScheduledJob>();
        }

        public override string Name
        {
            get { return jobName; }
        }

        public override void Execute()
        {
            foreach (var job in jobs)
            {
                job.Execute();
            }
        }

        public void AddJob(AbstractScheduledJob job)
        {
            jobs.Add(job);
        }
    }
}