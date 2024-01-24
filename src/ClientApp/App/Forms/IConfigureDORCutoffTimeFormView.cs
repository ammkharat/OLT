using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureDORCutoffTimeFormView
    {
        string SiteName { set; }
        Time CutoffTime { set; get; }
        void CloseForm();
        void SetTimeLmitError(string errorMessage);
        void ClearErrors();
    }
}