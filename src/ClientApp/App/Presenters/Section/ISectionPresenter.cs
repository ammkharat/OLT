using Com.Suncor.Olt.Client.Controls.Section;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public interface ISectionPresenter
    {
        ISection Section { get; }
        void Dispose();
    }
}
