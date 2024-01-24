using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ShiftPatternService : IShiftPatternService
    {
        private readonly IShiftPatternDao dao;

        private readonly ILog logger = GenericLogManager.GetLogger<ShiftPatternService>();

        public ShiftPatternService()
        {
            dao = DaoRegistry.GetDao<IShiftPatternDao>();
        }

        public List<ShiftPattern> QueryAll()
        {
            return dao.QueryAll();
        }

        public List<ShiftPattern> QueryBySite(Site site)
        {
            return dao.QueryBySiteId(site.IdValue);
        }
       
        public ShiftPattern GetShiftBySiteAndDateTime(Site site, DateTime dateTimeDuringShift)
        {
            return GetShiftByNonDivisionLevelFlocAndDateTimeWithOptionOfChoosingEarlierShift(site, dateTimeDuringShift, false);
        }

        public ShiftPattern GetShiftBySiteAndDateTimeFavourEarlierShift(Site site, DateTime dateTimeDuringShift)
        {
            return GetShiftByNonDivisionLevelFlocAndDateTimeWithOptionOfChoosingEarlierShift(site, dateTimeDuringShift, true);
        }

        private ShiftPattern GetShiftByNonDivisionLevelFlocAndDateTimeWithOptionOfChoosingEarlierShift(Site site, DateTime dateTimeDuringShift, bool favourEarlierShift)
        {
            var timeDuringShift = new Time(dateTimeDuringShift);

            TimeSpan preShiftPadding;
            TimeSpan postShiftPadding;
           
            if (favourEarlierShift)
            {
                preShiftPadding = new TimeSpan(0, 0, 1);
                postShiftPadding = TimeSpan.Zero;
            }
            else
            {
                preShiftPadding = TimeSpan.Zero;
                postShiftPadding = new TimeSpan(0, 0, -1);
            }

            List<ShiftPattern> masterShiftList = dao.QueryBySiteId(site.IdValue);
            List<ShiftPattern> shifts = GetInRangeShift(masterShiftList, timeDuringShift, preShiftPadding, postShiftPadding);

            if (shifts.Count == 0) // this used to check to make sure only one shift was returned.
            {
                logger.Error(
                    string.Format("Unable to determine the unique shift for {0} at {1}.",
                                  site.Name, timeDuringShift));
                throw new ShiftNotFoundException(timeDuringShift);
            }
            if (shifts.Count == 1)
            {
                return shifts[0];
            }

            return EarliestShiftPattern(dateTimeDuringShift, shifts);
        }


        public List<ShiftPattern> GetInRangeShift(List<ShiftPattern> shiftList,
                                                             Time timeDuringShift, TimeSpan preShiftPadding,
                                                             TimeSpan postShiftPadding)
        {
            List<ShiftPattern> inRangeShifts = new List<ShiftPattern>();

            foreach (ShiftPattern pattern in shiftList)
            {
                Time startTimeWithPadding = pattern.StartTime.Subtract(preShiftPadding);
                Time endTimeWithPadding = pattern.EndTime.Add(postShiftPadding);

                if (timeDuringShift.InRange(startTimeWithPadding, endTimeWithPadding))
                {
                    inRangeShifts.Add(pattern);
                }
            }

            if (inRangeShifts.Count == 0)
            {
                throw new ShiftNotFoundException(timeDuringShift);
            }
            return inRangeShifts;
        }

        /// <summary>
        /// Finds the Shift that starts the earliest from a list of Shifts based on the current DateTime.
        /// </summary>
        /// <param name="dateTimeDuringShift"></param>
        /// <param name="shifts"></param>
        /// <returns></returns>
        private static ShiftPattern EarliestShiftPattern(DateTime dateTimeDuringShift, List<ShiftPattern> shifts)
        {
            List<UserShift> userShifts = shifts.ConvertAll(shiftPattern => new UserShift(shiftPattern,
                                                                                         dateTimeDuringShift));

            userShifts.Sort((a, b) => a.StartDateTime.CompareTo(b.StartDateTime));

            return userShifts[0].ShiftPattern;
        }


        public List<ShiftPattern> GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding
                   (Site site, Time timeDuringShift)
        {
            List<ShiftPattern> shiftsInSite = QueryBySite(site);
            if (shiftsInSite == null)
                return new List<ShiftPattern>(0);

            shiftsInSite.RemoveAll(
                s => !s.IsTimeInShiftIncludingPadding(timeDuringShift));

            return shiftsInSite;
        }

    }
}
