using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Domain
{
    public class SiteCommunicationDisplayAdapter : DomainObject
    {
        private readonly SiteCommunication siteCommunication;

       
        public SiteCommunicationDisplayAdapter(SiteCommunication siteCommunication)
        {
            this.id = siteCommunication.Id;
            this.siteCommunication = siteCommunication;
           
           
        }

        public SiteCommunication GetSiteCommunication()
        {
            return siteCommunication;
        }

        public string Message
        {
            get { return siteCommunication.Message; }
        }

        public DateTime StartDateTime
        {
            get { return siteCommunication.StartDateTime; }
        }

        public DateTime EndDateTime
        {
            get { return siteCommunication.EndDateTime; }
        }

        public string TimeUntilActive
        {
            get
            {
                DateTime now = Clock.Now;
                if (now >= StartDateTime && now <= EndDateTime)
                {
                    return GetActiveText() + "  (" + siteCommunication.SiteName + ")";   //ayman site communication
                }

                if (now >= EndDateTime)
                {
                    return GetExpiredText() + "  (" + siteCommunication.SiteName + ")";     //ayman site communication
                }

                TimeSpan timeSpan = StartDateTime - now;
                return String.Format(StringResources.DaysHoursMinutes, timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
            }
        }

        public static string GetActiveText()
        {
            return StringResources.SiteCommunicationActive;
        }

        public static string GetExpiredText()
        {
            return StringResources.SiteCommunicationExpired;
        }
    }
}
