using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface ILogCopyStrategy
    {
        void Copy(ILogCopyFormView view, List<CustomField> customFields, WorkAssignment assignment);
        bool IsCopying { get; }
        Log LogToCopy { get; }
    }
}
