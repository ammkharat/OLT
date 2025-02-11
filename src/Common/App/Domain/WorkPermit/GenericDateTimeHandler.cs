using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public class SiteSpecificHandlerFactory
    {
        public static ISiteSpecificDateTimeHandler GetDateTimeHandler(Site site)
        {
            if (site.Id == Site.DENVER_ID)
            {
                return new DenverDateTimeHandler();
            }
            else if (site.Id == Site.USPipeline_ID)
            {
                return new USPipelineDateTimeHandler();
            }
            else if (site.Id == Site.SELC_ID)  //mangesh uspipeline to selc
            {
                return new USPipelineDateTimeHandler();
            }
            else
            return new GenericDateTimeHandler();
        }
    }

    //ayman USPipeline workpermit
    [Serializable]
    internal class USPipelineDateTimeHandler : ComparableObject, ISiteSpecificDateTimeHandler
    {
        public void InitializeDateTimes(WorkPermitSpecifics specifics, UserWorkPermitDefaultTimePreferences prefs,
            UserShift currentShift, DateTime now)
        {
            if (currentShift != null)
            {
                var dateTimeRange = prefs.DefaultDateTimeRange(currentShift);
                specifics.StartDateTime = dateTimeRange.LowerBound;
            }

            specifics.StartTimeNotApplicable = true;
            specifics.StartAndOrEndTimesFinalized = false;

            InitializeEndDateTime(specifics, prefs, currentShift);
        }

        public void ReinitializeStartAndOrEndDateTimes(WorkPermitSpecifics specifics,
            UserWorkPermitDefaultTimePreferences prefs, UserShift currentShift, DateTime now)
        {
            InitializeEndDateTime(specifics, prefs, currentShift);
        }

        public void Initialize(WorkPermitEquipmentPreparationCondition equipmentCondition)
        {
            equipmentCondition.IsTestBump = true;
        }

        private void InitializeEndDateTime(WorkPermitSpecifics specifics, UserWorkPermitDefaultTimePreferences prefs,
            UserShift currentShift)
        {
            if (currentShift != null)
            {
                var dateTimeRange = prefs.DefaultDateTimeRange(currentShift);
                specifics.EndDateTime = dateTimeRange.UpperBound;
            }
        }

        public override string ToString()
        {
            return "USPipelineHandler";
        }
    }




    [Serializable]
    internal class DenverDateTimeHandler : ComparableObject, ISiteSpecificDateTimeHandler
    {
        public void InitializeDateTimes(WorkPermitSpecifics specifics, UserWorkPermitDefaultTimePreferences prefs,
            UserShift currentShift, DateTime now)
        {
            if (currentShift != null)
            {
                var dateTimeRange = prefs.DefaultDateTimeRange(currentShift);
                specifics.StartDateTime = dateTimeRange.LowerBound;
            }

            specifics.StartTimeNotApplicable = true;
            specifics.StartAndOrEndTimesFinalized = false;

            InitializeEndDateTime(specifics, prefs, currentShift);
        }

        public void ReinitializeStartAndOrEndDateTimes(WorkPermitSpecifics specifics,
            UserWorkPermitDefaultTimePreferences prefs, UserShift currentShift, DateTime now)
        {
            InitializeEndDateTime(specifics, prefs, currentShift);
        }

        public void Initialize(WorkPermitEquipmentPreparationCondition equipmentCondition)
        {
            equipmentCondition.IsTestBump = true;
        }

        private void InitializeEndDateTime(WorkPermitSpecifics specifics, UserWorkPermitDefaultTimePreferences prefs,
            UserShift currentShift)
        {
            if (currentShift != null)
            {
                var dateTimeRange = prefs.DefaultDateTimeRange(currentShift);
                specifics.EndDateTime = dateTimeRange.UpperBound;
            }
        }

        public override string ToString()
        {
            return "DenverHandler";
        }
    }

    [Serializable]
    internal class GenericDateTimeHandler : ComparableObject, ISiteSpecificDateTimeHandler
    {
        public void InitializeDateTimes(WorkPermitSpecifics specifics, UserWorkPermitDefaultTimePreferences prefs,
            UserShift currentShift, DateTime now)
        {
            if (currentShift != null)
            {
                var dateTimeRange = prefs.DefaultDateTimeRange(currentShift);
                specifics.StartDateTime = now.BuildDateTimeWithNoSecondsOrMilliseconds();
                specifics.EndDateTime = dateTimeRange.UpperBound;
            }

            specifics.StartAndOrEndTimesFinalized = true;
        }

        public void ReinitializeStartAndOrEndDateTimes(WorkPermitSpecifics specifics,
            UserWorkPermitDefaultTimePreferences prefs, UserShift currentShift, DateTime now)
        {
            InitializeDateTimes(specifics, prefs, currentShift, now);
        }

        public void Initialize(WorkPermitEquipmentPreparationCondition equipmentCondition)
        {
            equipmentCondition.IsTestBump = false;
        }
    }
}