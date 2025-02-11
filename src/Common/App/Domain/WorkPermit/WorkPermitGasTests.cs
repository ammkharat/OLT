using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    [Alias("GasTests")]
    public class WorkPermitGasTests : DomainObject
    {
        private Time confinedSpaceTestTime;
        private bool constantMonitoringRequired;
        private List<GasTestElement> elements;
        private bool forkLiftNotUsed;
        private string frequencyOrDuration;
        private Time immediateAreaTestTime;

        public WorkPermitGasTests()
        {
            frequencyOrDuration = string.Empty;
            constantMonitoringRequired = false;
            elements = new List<GasTestElement>();
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]         //ayman USPipeline workpermit // mangesh uspipeline to selc
        public Time ImmediateAreaTestTime
        {
            get { return immediateAreaTestTime; }
            set { immediateAreaTestTime = value; }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public Time ConfinedSpaceTestTime
        {
            get { return confinedSpaceTestTime; }
            set { confinedSpaceTestTime = value; }
        }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public Time SystemEntryTestTime { get; set; }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string FrequencyOrDuration
        {
            set { frequencyOrDuration = value; }

            get { return frequencyOrDuration; }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool ConstantMonitoringRequired
        {
            set { constantMonitoringRequired = value; }

            get { return constantMonitoringRequired; }
        }

        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool ForkliftNotUsed
        {
            get { return forkLiftNotUsed; }
            set { forkLiftNotUsed = value; }
        }

        public List<GasTestElement> Elements
        {
            set { elements = value; }

            get { return elements; }
        }

        public void InitializeWithSensibleDefaults()
        {
            frequencyOrDuration = string.Empty;
            constantMonitoringRequired = false;
            //Edit by Gloria based on SO8000081358
            //There is event in workpermitform to reset the time to the next hour
            //We do not need it to here, change it to null and use it to test if the time
            //is copied from the origial permit or a new one.
            //testTime = new Time(Clock.NextHour);
            //confinedSpaceTestTime = new Time(Clock.NextHour);
            immediateAreaTestTime = null;
            confinedSpaceTestTime = null;
            //End of test
        }

        public WorkPermitGasTests Copy()
        {
            var newCopy = new WorkPermitGasTests
            {
                ImmediateAreaTestTime = immediateAreaTestTime,
                ConfinedSpaceTestTime = confinedSpaceTestTime,
                FrequencyOrDuration = frequencyOrDuration,
                ConstantMonitoringRequired = constantMonitoringRequired,
                ForkliftNotUsed = forkLiftNotUsed
            };

            foreach (var element in Elements)
            {
                newCopy.Elements.Add(element.Copy());
            }

            return newCopy;
        }

        /// <summary>
        ///     Tests if this section of the work permit has data (has been "filled out").
        /// </summary>
        public bool HasData()
        {
            if (FrequencyOrDuration.HasValue())
            {
                return true;
            }
            if (ConstantMonitoringRequired)
            {
                return true;
            }
            if (ImmediateAreaTestTime != null)
            {
                return true;
            }
            if (ConfinedSpaceTestTime != null) return true;

            return Elements.Exists(match => match.HasData());
        }

       //Muds Site Properties
        private Time gasTestFirstResultTime;
        public Time GasTestFirstResultTime
        {
            get { return gasTestFirstResultTime; }
            set { gasTestFirstResultTime = value; }
        }
        private Time gasTestSecondResultTime;
        public Time GasTestSecondResultTime
        {
            get { return gasTestSecondResultTime; }
            set { gasTestSecondResultTime = value; }
        }

        private Time gasTestThirdResultTime;
        public Time GasTestThirdResultTime
        {
            get { return gasTestThirdResultTime; }
            set { gasTestThirdResultTime = value; }
        }

        private Time gasTestFourthResultTime;
        public Time GasTestFourthResultTime
        {
            get { return gasTestFourthResultTime; }
            set { gasTestFourthResultTime = value; }
        }

    }
}