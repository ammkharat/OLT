using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogTemplateView
    {
        void SetLogTemplates(List<LogTemplateDTO> logTemplates);
        void ShowLogTemplateComponent();
        void HideLogTemplateComponent();
        void ApplyLogTemplateText(string text);
        event Action HandleLogTemplateButtonClick;
        LogTemplateDTO SelectedLogTemplate { get; set; }
    }
}