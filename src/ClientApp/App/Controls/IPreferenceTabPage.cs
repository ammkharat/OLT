namespace Com.Suncor.Olt.Client.Controls
{
    public interface IPreferenceTabPage
    {
        void UpdatePreference();
        bool IsTabValid { get; }
    }
}