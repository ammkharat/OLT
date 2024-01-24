using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISapAutoImportConfigurationView : IBaseForm
    {
        event Action Save;
        bool IsEnabled { get; set; }
        Time ImportTime { get; set; }
        bool TimePickerEnabled { set; }
    }
}
