using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class MarkedAsReadReportDataByUser
    {
        private readonly string userFullNameWithUserName;
        private readonly List<MarkedAsReadReportLogEntryDto> logs = new List<MarkedAsReadReportLogEntryDto>();
        private readonly List<MarkedAsReadReportLogEntryDto> directiveLogs = new List<MarkedAsReadReportLogEntryDto>();
        private readonly List<MarkedAsReadReportLogEntryDto> summaryLogs = new List<MarkedAsReadReportLogEntryDto>();
        private readonly List<MarkedAsReadReportShiftHandoverEntryDto> shiftHandoverQuestionnaires = new List<MarkedAsReadReportShiftHandoverEntryDto>();
        private readonly List<MarkedAsReadReportDirectiveEntryDto> directives = new List<MarkedAsReadReportDirectiveEntryDto>();

        public MarkedAsReadReportDataByUser(string userFullNameWithUserName)
        {
            this.userFullNameWithUserName = userFullNameWithUserName;
        }

        public string UserFullNameWithUserName
        {
            get { return userFullNameWithUserName; }
        }

        public List<MarkedAsReadReportLogEntryDto> Logs
        {
            get { return logs; }
        }

        public List<MarkedAsReadReportLogEntryDto> DirectiveLogs
        {
            get { return directiveLogs; }
        }

        public List<MarkedAsReadReportLogEntryDto> SummaryLogs
        {
            get { return summaryLogs; }
        }

        public List<MarkedAsReadReportShiftHandoverEntryDto> ShiftHandoverQuestionnaires
        {
            get { return shiftHandoverQuestionnaires; }
        }

        public List<MarkedAsReadReportDirectiveEntryDto> Directives
        {
            get { return directives; }
        }

        public static List<MarkedAsReadReportDataByUser> GroupByUser(MarkedAsReadReportDTO reportDto)
        {
            Dictionary<string, MarkedAsReadReportDataByUser> dtosByUser = new Dictionary<string, MarkedAsReadReportDataByUser>();

            foreach (MarkedAsReadReportLogDTO dto in reportDto.Logs)
            {
                foreach (ItemReadBy itemReadBy in dto.ReadByUsers)
                {
                    string user = itemReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsReadReportDataByUser(user));
                    }
                    dtosByUser[user].Logs.Add(new MarkedAsReadReportLogEntryDto(dto, itemReadBy.DateTime));
                }
            }
            foreach (MarkedAsReadReportLogDTO dto in reportDto.DirectiveLogs)
            {
                foreach (ItemReadBy itemReadBy in dto.ReadByUsers)
                {
                    string user = itemReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsReadReportDataByUser(user));
                    }
                    dtosByUser[user].DirectiveLogs.Add(new MarkedAsReadReportLogEntryDto(dto, itemReadBy.DateTime));
                }
            }
            foreach (MarkedAsReadReportLogDTO dto in reportDto.SummaryLogs)
            {
                foreach (ItemReadBy itemReadBy in dto.ReadByUsers)
                {
                    string user = itemReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsReadReportDataByUser(user));
                    }
                    dtosByUser[user].SummaryLogs.Add(new MarkedAsReadReportLogEntryDto(dto, itemReadBy.DateTime));
                }
            }
            foreach (MarkedAsReadReportShiftHandoverQuestionnaireDTO dto in reportDto.ShiftHandoverQuestionnaires)
            {
                foreach (ItemReadBy itemReadBy in dto.ReadByUsers)
                {
                    string user = itemReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsReadReportDataByUser(user));
                    }
                    dtosByUser[user].ShiftHandoverQuestionnaires.Add(new MarkedAsReadReportShiftHandoverEntryDto(dto, itemReadBy.DateTime));
                }
            }
            foreach (MarkedAsReadReportDirectiveDTO dto in reportDto.Directives)
            {
                foreach (ItemReadBy itemReadBy in dto.ReadByUsers)
                {
                    string user = itemReadBy.UserFullNameWithUserName;
                    if (!dtosByUser.ContainsKey(user))
                    {
                        dtosByUser.Add(user, new MarkedAsReadReportDataByUser(user));
                    }
                    dtosByUser[user].Directives.Add(new MarkedAsReadReportDirectiveEntryDto(dto, itemReadBy.DateTime));
                }
            }

            List<MarkedAsReadReportDataByUser> data = new List<MarkedAsReadReportDataByUser>(dtosByUser.Values);
            data.Sort((x, y) => string.Compare(x.UserFullNameWithUserName, y.UserFullNameWithUserName, StringComparison.CurrentCulture));
            return data;
        }
    }
}