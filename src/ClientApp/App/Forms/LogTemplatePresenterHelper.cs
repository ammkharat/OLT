using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Forms
{
    public class LogTemplatePresenterHelper
    {
        private readonly ILogTemplateView view;
        private readonly ILogTemplateService logTemplateService;
        private readonly WorkAssignment workAssignment;
        private readonly LogTemplate.LogType logTemplateType;
        private List<LogTemplateDTO> logTemplates = new List<LogTemplateDTO>(); 

        public LogTemplatePresenterHelper(ILogTemplateView view, ILogTemplateService logTemplateService, WorkAssignment workAssignment, LogTemplate.LogType logTemplateType)
        {
            this.view = view;
            this.logTemplateService = logTemplateService;
            this.workAssignment = workAssignment;
            this.logTemplateType = logTemplateType;
        }

        public void HandleInsertTemplateButtonClick()
        {
            LogTemplateDTO selectedLogTemplate = view.SelectedLogTemplate;

            if (selectedLogTemplate == null)
            {
                return;
            }
            LogTemplate logTemplate = logTemplateService.QueryById(selectedLogTemplate.IdValue);
            view.ApplyLogTemplateText(logTemplate.Text);
        }

        public void LoadLogTemplates(bool isEdit)
        {
            if (logTemplates.Count > 0)
            {
                view.SetLogTemplates(logTemplates);
                view.ShowLogTemplateComponent();

                if (!isEdit && workAssignment != null && workAssignment.AutoInsertLogTemplateId.HasValue)
                {
                    LogTemplateDTO logTemplate = logTemplates.FindById(workAssignment.AutoInsertLogTemplateId);
                    view.SelectedLogTemplate = logTemplate;
                    HandleInsertTemplateButtonClick();
                }
            }
            else
            {
                view.HideLogTemplateComponent();
            }

        }

        public void QueryLogTemplates()
        {
            logTemplates = logTemplateService.QueryByWorkAssignmentReturnOnlyUniqueLogTemplates(workAssignment, logTemplateType);
        }
    }
}