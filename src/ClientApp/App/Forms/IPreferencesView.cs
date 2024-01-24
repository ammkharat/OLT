using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPreferencesView: IBaseForm
    {
        string Title { set; }
        List<IPreferenceTabPage> Tabs { get; }
    }
}