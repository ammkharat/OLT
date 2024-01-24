using System;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client
{
    public class ClientSession
    {
        public event EventHandler CurrentShiftHasEnded;
        public event EventHandler CurrentShiftGracePeriodHasEnded;
        public event EventHandler ShiftHandoverAlertEvent; //RITM0387753-Shift Handover creation alert

        private static ClientSession clientSession;
        private readonly UserContext userContext;
        private readonly SessionStore sessionStore;

        private readonly IStopWatch shiftStopwatch;
        private readonly IStopWatch shiftGracePeriodStopwatch;
        private readonly IStopWatch shiftAlertPeroidStopwatch; ////RITM0387753-Shift Handover creation alert:Aarti
        private Guid guid;

        private ClientSession()
        {
            shiftStopwatch = new StopWatch(OnShiftStopWatchBlastOff);
            shiftGracePeriodStopwatch = new StopWatch(OnShiftGracePeriodStopWatchBlastOff);
            shiftAlertPeroidStopwatch = new StopWatch(OnShiftAlertStopWatchBlastOff);////RITM0387753-Shift Handover creation alert:Aarti
            guid = Guid.NewGuid();
            userContext = new UserContext(this);
            sessionStore = new SessionStore();
        }

        public bool ForceLogoff { get; set; }

        private void OnShiftGracePeriodStopWatchBlastOff(DateTime? intendedExecutionDateTime)
        {
            if (CurrentShiftGracePeriodHasEnded != null)
            {
                CurrentShiftGracePeriodHasEnded(this, null);
            }
        }

        private void OnShiftStopWatchBlastOff(DateTime? intendedExecutionDateTime)
        {
            if (CurrentShiftHasEnded != null)
            {
                CurrentShiftHasEnded(this, null);
            }
        }

        //RITM0387753-Shift Handover creation alert:Aarti
        private void OnShiftAlertStopWatchBlastOff(DateTime? intendedExecutionDateTime)
        {
            if (ShiftHandoverAlertEvent != null)
            {
                ShiftHandoverAlertEvent(this, null);
            }

        }

        public static ClientSession GetInstance()
        {
            return clientSession ?? (clientSession = new ClientSession());
        }

        public static UserContext GetUserContext()
        {
            ClientSession instance = GetInstance();
            return instance.userContext;
        }

        public SessionStore GetSessionStore()
        {
            return sessionStore;
        }

        public FunctionalLocationMode SiteConfiguredFunctionalLocationMode
        {
            get
            {
                if (GetUserContext().SiteConfiguration.AllowLoginFlocSelectionUpToSeventhLevel)
                {
                    return FunctionalLocationMode.LevelSevenAndAbove;
                }

                if (GetUserContext().SiteConfiguration.AllowLoginFlocSelectionUpToFifthLevel)
                {
                    return FunctionalLocationMode.LevelFiveAndAbove;
                }

                return FunctionalLocationMode.LevelThreeAndAbove;
            }
        }

        public bool UserHasMultipleSites
        {
            get
            {
                return userContext.User.AvailableSites.Count > 1; 
            }
        }

        public void CleanUpOldInstance()
        {
            // Remove All Event Handlers for the timer delegates
            CurrentShiftHasEnded = (EventHandler)Delegate.RemoveAll(CurrentShiftHasEnded, CurrentShiftHasEnded);
            CurrentShiftGracePeriodHasEnded = (EventHandler)Delegate.RemoveAll(CurrentShiftGracePeriodHasEnded, CurrentShiftGracePeriodHasEnded);

            shiftStopwatch.Stop();
            shiftGracePeriodStopwatch.Stop();
            shiftAlertPeroidStopwatch.Stop();////RITM0387753-Shift Handover creation alert:Aarti
            sessionStore.Clear();
        }

        public static ClientSession GetNewInstance()
        {
            if (clientSession != null)
            {
                clientSession.CleanUpOldInstance();
            }

            clientSession = new ClientSession();
            return clientSession;
        }

        public string GuidAsString
        {
            get { return guid.ToString(); }
        }

        internal void StartShiftEndStopWatch()
        {
            TimeSpan ts = userContext.UserShift.EndDateTime.Subtract(Clock.Now);
            if (ts > TimeSpan.Zero)
            {
                var countDownInMilliseconds = (long) ts.TotalMilliseconds;
                shiftStopwatch.CountDown(countDownInMilliseconds, userContext.UserShift.EndDateTime);
            }
        }


        //RITM0387753-Shift Handover creation alert(Aarti)
        internal void ShiftHandoverAlertStopWatch()
        {
            int alertTime = userContext.SiteConfiguration.ShiftHandoverAlert.GetValueOrDefault();

            TimeSpan ts = userContext.UserShift.EndDateTime.AddMinutes(-alertTime).Subtract(Clock.Now);
            if (ts > TimeSpan.Zero)
            {
                var countDownInMilliseconds = (long)ts.TotalMilliseconds;
                shiftAlertPeroidStopwatch.CountDown(countDownInMilliseconds, userContext.UserShift.EndDateTime.AddMinutes(-alertTime));
            }

        }

        public bool UserIsInGracePeriod()
        {
            DateTime endOfShift = userContext.UserShift.EndDateTime;
            DateTime endOfShiftWithPadding = userContext.UserShift.EndDateTimeWithPadding;

            DateTime now = Clock.Now;
            return now >= endOfShift && now <= endOfShiftWithPadding;
        }

        public TimeSpan GetTimeRemainingInShiftWithPostShiftPadding()
        {
            return userContext.UserShift.EndDateTimeWithPadding.Subtract(Clock.Now);
        }
        
        //RITM0387753-Shift Handover creation alert(Aarti)
        public bool ShiftHandoverAlertCreated()
        {
            int alertTime = userContext.SiteConfiguration.ShiftHandoverAlert.GetValueOrDefault();
            DateTime endOfShift = userContext.UserShift.EndDateTime;
            DateTime t1 = Convert.ToDateTime(userContext.UserShift.EndDateTime).AddMinutes(-alertTime);
            // //TimeSpan ts = endOfShift.Subtract(alertTime);
            DateTime now = Clock.Now;
            return now <= endOfShift && now >= t1;


        }
        //RITM0387753-Shift Handover creation alert(Aarti)
        public TimeSpan GetShiftHandoverAlertTime()
        {
            int alertTime = userContext.SiteConfiguration.ShiftHandoverAlert.GetValueOrDefault();
            return userContext.UserShift.EndDateTime.AddMinutes(-alertTime).Subtract(Clock.Now);

            // return userContext.UserShift.EndDateTime.Subtract(Clock.Now);

        }
        internal void StartShiftGracePeriodStopWatch()
        {
            TimeSpan ts = GetTimeRemainingInShiftWithPostShiftPadding();
            if (ts > TimeSpan.Zero)
            {
                var countDownInMillis = (long) ts.TotalMilliseconds;
                shiftGracePeriodStopwatch.CountDown(countDownInMillis, userContext.UserShift.EndDateTimeWithPadding);
            }
        }
    }
}