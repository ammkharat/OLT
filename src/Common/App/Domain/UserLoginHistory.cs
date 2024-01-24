using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class UserLoginHistory : DomainObject
    {
        public UserLoginHistory(
            long? id,
            User user,
            DateTime loginDateTime,
            ShiftPattern shift,
            DateTime shiftStartDateTime,
            DateTime shiftEndDateTme,
            WorkAssignment assignment,
            List<FunctionalLocation> selectedFunctionalLocations,
            string clientUri,
            string clientUpdatePath,
            string machineName,
            string windowsVersion,
            string dotNetVersion,
            bool isClickOnce)
        {
            this.id = id;
            User = user;
            LoginDateTime = loginDateTime;
            Shift = shift;
            ShiftStartDateTime = shiftStartDateTime;
            ShiftEndDateTme = shiftEndDateTme;
            Assignment = assignment;
            SelectedFunctionalLocations = selectedFunctionalLocations;
            ClientUri = clientUri;
            ClientUpdatePath = clientUpdatePath;
            WindowsVersion = windowsVersion;
            DotNetVersion = dotNetVersion;
            MachineName = machineName ?? "";
            IsClickOnce = isClickOnce;
        }

        public User User { get; private set; }
        public DateTime LoginDateTime { get; private set; }
        public ShiftPattern Shift { get; private set; }
        public DateTime ShiftStartDateTime { get; private set; }
        public DateTime ShiftEndDateTme { get; private set; }
        public WorkAssignment Assignment { get; private set; }
        public List<FunctionalLocation> SelectedFunctionalLocations { get; set; }
        public string ClientUri { get; private set; }
        public string ClientUpdatePath { get; private set; }
        public string MachineName { get; private set; }
        public string WindowsVersion { get; private set; }
        public string DotNetVersion { get; private set; }
        public bool IsClickOnce { get; private set; }
    }
}