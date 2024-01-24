using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    class MarkedAsNotReadReportDataByUser
    {
        private readonly string userFullNameWithUserName;
       // private readonly List<MarkedAsReadReportLogEntryDto> logs = new List<MarkedAsReadReportLogEntryDto>();
       // private readonly List<MarkedAsReadReportLogEntryDto> directiveLogs = new List<MarkedAsReadReportLogEntryDto>();
       // private readonly List<MarkedAsReadReportLogEntryDto> summaryLogs = new List<MarkedAsReadReportLogEntryDto>();
        private readonly List<MarkedAsNotReadReportShiftHandoverEntryDto> shiftHandoverQuestionnaires = new List<MarkedAsNotReadReportShiftHandoverEntryDto>();
       private readonly List<MarkedAsNotReadReportDirectiveEntryDto> directives = new List<MarkedAsNotReadReportDirectiveEntryDto>();
        public MarkedAsNotReadReportDataByUser(string userFullNameWithUserName)
        {
            this.userFullNameWithUserName = userFullNameWithUserName;
        }
        public string UserFullNameWithUserName
        {
            get { return userFullNameWithUserName; }
        }
        public List<MarkedAsNotReadReportShiftHandoverEntryDto> ShiftHandoverQuestionnaires
        {
            get { return shiftHandoverQuestionnaires; }
        }
        public List<MarkedAsNotReadReportDirectiveEntryDto> Directives
        {
            get { return directives; }
        }

        public static List<MarkedAsNotReadReportDataByUser> GroupByUser(MarkedAsNotReadReportDTO reportDto)
        {
            Dictionary<string, MarkedAsNotReadReportDataByUser> dtosByUser = new Dictionary<string, MarkedAsNotReadReportDataByUser>();
            foreach (MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto in reportDto.ShiftHandoverQuestionnaires)
            {
                foreach (ItemNotReadBy itemReadBy in dto.NotReadByUsers)
                {
                    string user = itemReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsNotReadReportDataByUser(user));
                    }
                    dtosByUser[user].ShiftHandoverQuestionnaires.Add(new MarkedAsNotReadReportShiftHandoverEntryDto(dto));

                   
                }
            }
            foreach (MarkedAsNotReadReportDirectiveDTO dto in reportDto.Directives)
            {
                foreach (ItemNotReadBy itemNotReadBy in dto.NotReadByUsers)
                {
                    string user = itemNotReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsNotReadReportDataByUser(user));
                    }
                    dtosByUser[user].Directives.Add(new MarkedAsNotReadReportDirectiveEntryDto(dto));
                }
            }
            List<MarkedAsNotReadReportDataByUser> data = new List<MarkedAsNotReadReportDataByUser>(dtosByUser.Values);
            data.Sort((x, y) => string.Compare(x.UserFullNameWithUserName, y.UserFullNameWithUserName, StringComparison.CurrentCulture));
            return data;
        }
    }
}
