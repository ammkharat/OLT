using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
   [Serializable]
   public  class MarkedAsNotReadReportLogDTO
    {
        public const string STANDARD_LOG_TYPE_TEXT = "Log";
        public const string DAILY_DIRECTIVE_LOG_TYPE_TEXT = "Daily Directive";
        public const string SUMMARY_LOG_TYPE_TEXT = "Shift Summary";
        private readonly string comments;

        private readonly string functionalLocations;
        private readonly string lastModifiedByFullNameWithUserName;
        private readonly string logType;
        private readonly DateTime loggedDateTime;
        private readonly List<ItemNotReadBy> notreadByUsers = new List<ItemNotReadBy>();
        private readonly string shift;

       public MarkedAsNotReadReportLogDTO(string logType,
           DateTime loggedDateTime,
           string shift,
           string functionalLocations,
           string lastModifiedByFullNameWithUserName,
           string comments,
           List<ItemNotReadBy> notreadByUsers)
              {
                  this.logType = logType;
                  this.loggedDateTime = loggedDateTime;
                  this.shift = shift;
                  this.lastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
                  this.comments = comments;

                  this.functionalLocations = functionalLocations;
                  this.notreadByUsers = notreadByUsers ?? new List<ItemNotReadBy>();


              }
       public string LogType
       {
           get { return logType; }
       }

       public string LogTypeDisplay
       {
           get
           {
               string logTypeDisplay = null;

               if (LogType == STANDARD_LOG_TYPE_TEXT)
               {
                   logTypeDisplay = StringResources.ReportLogTypeDisplay_Log;
               }
               else if (LogType == DAILY_DIRECTIVE_LOG_TYPE_TEXT)
               {
                   logTypeDisplay = StringResources.ReportLogTypeDisplay_DailyDirective;
               }
               else if (LogType == SUMMARY_LOG_TYPE_TEXT)
               {
                   logTypeDisplay = StringResources.ReportLogTypeDisplay_ShiftSummary;
               }

               return logTypeDisplay;
           }
       }

       public DateTime LoggedDateTime
       {
           get { return loggedDateTime; }
       }

       public string Shift
       {
           get { return shift; }
       }

       public string FunctionalLocation
       {
           get { return functionalLocations; }
       }

       public string LastModifiedByFullNameWithUserName
       {
           get { return lastModifiedByFullNameWithUserName; }
       }

       public string Comments
       {
           get { return comments; }
       }
       public List<ItemNotReadBy> NotReadByUsers
       {
           get { return notreadByUsers; }
       }

       public void AddReadByUser(ItemNotReadBy notreadByUser)
       {
           if (!notreadByUsers.Contains(notreadByUser))
           {
               notreadByUsers.Add(notreadByUser);
           }
       }

    }
}
