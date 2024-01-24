using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IRoleSelectionView : IBaseForm
    {
        List<Role> Roles { set; }
        Role SelectedRole { get; set; }
    }
}