using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ReferencedLogFormPresenter
    {
        private readonly IReferencedLogFormView view;
        private readonly List<LogDTO> dtos;
        private readonly ILogService logService;

        public ReferencedLogFormPresenter(IReferencedLogFormView view, List<LogDTO> dtos)
        {
            this.view = view;
            this.dtos = dtos;
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
        }

        public void Load(object sender, EventArgs e)
        {
            view.GoToLogButtonEnabled = false;
            dtos.Sort(dto => dto.LogDateTime, false);
            view.LogList = dtos;
            view.SelectFirstLog();
        }

        public void SelectedLogChanged(object item)
        {
            if (item != null)
            {
                LogDTO dto = (LogDTO)item;
                Log log = logService.QueryById(dto.IdValue);
                List<CustomField> customFields = log.CustomFields;

                view.SetDetails(log, customFields);
                view.GoToLogButtonEnabled = LogCreatedInUsersCurrentShift(log);
            }
        }

        public void OkButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void GoToLogButton_Click(object sender, EventArgs e)
        {
            Log log = logService.QueryById(view.SelectedItem.IdValue);

            if (log.IsRelevantTo(ClientSession.GetUserContext().ReadableVisibilityGroupIds))
            {
                view.HighlightSelectedLogInLogTab();
                view.Close();
            }
            else
            {
                view.DisplayLogDoesNotFallWithinSelectedVisibilityGroupsError();
            }
        }

        private bool LogCreatedInUsersCurrentShift(Log log)
        {
            UserShift userShift = ClientSession.GetUserContext().UserShift;
            return userShift.IsInUserShiftIncludingPadding(log.CreatedShiftPattern.IdValue, log.CreatedDateTime);
        }

        public void DetailsMarkedAsReadByExpand(Log log)
        {
            view.MarkedAsReadByList = logService.UsersThatMarkedLogAsRead(log.IdValue);
        }
    }
}
