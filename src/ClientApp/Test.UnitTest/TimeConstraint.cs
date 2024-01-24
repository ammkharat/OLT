using System;
using NUnit.Framework.Constraints;

namespace Com.Suncor.Olt.Client
{
    public class TimeConstraint : Constraint
    {
        private readonly long millisecondThreshold;
        private readonly DateTime actualDateTime;

        public TimeConstraint(DateTime actualDateTime, long millisecondThreshold)
        {
            this.actualDateTime = actualDateTime;
            this.millisecondThreshold = millisecondThreshold;
        }

        public override bool Matches(object result)
        {
            DateTime resultDateTime = (DateTime)result;
            return Math.Abs((resultDateTime - actualDateTime).Milliseconds) <= millisecondThreshold;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.Write("Comparing times with millisecond threshold of " + millisecondThreshold);
        }
    }

    
}
