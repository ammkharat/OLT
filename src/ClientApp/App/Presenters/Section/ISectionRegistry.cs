using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public interface ISectionRegistry
    {
        void Clear();
        ISection GetSection(SectionKey key);
        bool IsPageVisible(SectionKey key, PageKey pageKey);
    }
}