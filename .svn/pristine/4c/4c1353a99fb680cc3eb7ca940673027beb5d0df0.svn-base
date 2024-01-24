using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Common.Utility
{
    /// <summary>
    ///     Clock provides access to the system time in a manner that allows code to become
    ///     more testable. By freezing and unfreezing the clock tests can manipulate the current
    ///     system time without having to use Thread.Sleep(). All code that needs to know the
    ///     current system time should use Clock.Now.
    /// </summary>
    public class Clock
    {
        private static Clock instance;
        private bool frozen;
        private DateTime frozenTime = new DateTime(2006, 1, 1);
        private bool isDisabled;
        private ITimeService timeService;
        private OltTimeZoneInfo timezone;

        private Clock()
        {
        }

        private static Clock Instance
        {
            get { return instance ?? (instance = new Clock()); }
        }

        public static DateTime Now
        {
            get
            {
                DateTime returnValue;

                if (Instance.isDisabled)
                {
                    throw new Exception("Clock is disabled.");
                }

                if (Instance.frozen)
                {
                    returnValue = Instance.frozenTime;
                }
                else if (Instance.timeService != null)
                {
                    returnValue = Instance.timeService.GetTime(TimeZone);
                }
                else
                {
                    returnValue = DateTime.Now;
                }

                return returnValue.GetNetworkPortable();
            }
            set
            {
                if (!Instance.frozen)
                {
                    throw new ApplicationException("You cannot set when not frozen.");
                }
                Instance.frozenTime = value;
            }
        }

        public static Date DateNow
        {
            get { return new Date(Now); }
        }

        public static Time TimeNow
        {
            get { return new Time(Now); }
        }

        public static DateTime NextHour
        {
            get
            {
                var now = Now;
                var result = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
                return result.AddHours(1);
            }
        }

        public static OltTimeZoneInfo TimeZone
        {
            set { Instance.timezone = value; }
            get { return Instance.timezone; }
        }

        public static void Disable()
        {
            Instance.isDisabled = true;
        }

        public static void Enable()
        {
            Instance.isDisabled = false;
        }


        public static void UseTimeService(ITimeService service)
        {
            Instance.timeService = service;
        }

        public static void Freeze()
        {
            if (!Instance.frozen)
            {
                Instance.frozenTime = DateTime.Now.GetNetworkPortable();
                Instance.frozenTime =
                    new DateTime(Instance.frozenTime.Year, Instance.frozenTime.Month, Instance.frozenTime.Day,
                        Instance.frozenTime.Hour, Instance.frozenTime.Minute,
                        Instance.frozenTime.Second);
                Instance.frozen = true;
            }
        }

        public static void UnFreeze()
        {
            Instance.frozen = false;
        }
    }
}