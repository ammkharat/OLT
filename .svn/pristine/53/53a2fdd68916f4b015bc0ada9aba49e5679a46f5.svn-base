using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormTemplateConfigurationView : IBaseForm
    {
        List<FormTemplate> FormTemplates { set; }
        FormTemplate SelectedTemplate { set; }
        event Action<FormTemplate> EditButtonClicked;
        void SelectFirstRow();
    }
}
