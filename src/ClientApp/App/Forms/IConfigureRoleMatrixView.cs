using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureRoleMatrixView : IBaseForm
    {
        event Action<InitializeLayoutEventArgs> InitializeGridLayout;
        event Action PreviewChanges;
        event Action GenerateSql;

        List<RoleMatrixDisplayAdapter> RoleMatrixDisplayAdapters { set; get; }

        void ShowNoChangesMessage();
        void ShowSuccessMessageAndCloseForm();
        void AddCheckColumn(Role role, InitializeLayoutEventArgs e);
    }
}
