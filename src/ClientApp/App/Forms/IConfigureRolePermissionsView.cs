using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureRolePermissionsView : IBaseForm
    {
        event Action Add;
        event Action Delete;
        event Action Save;

        List<RolePermissionDisplayAdapter> RolePermissions { set; get; }
        RolePermissionDisplayAdapter SelectedPermission { get; set; }
        void ShowPermissionAlreadyExistsMessage();
        void ShowNothingToSaveMessage();
        void ShowSaveSuccessfulMessageAndCloseForm();
    }
}
