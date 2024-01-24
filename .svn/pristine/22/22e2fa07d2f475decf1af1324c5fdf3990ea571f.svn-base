using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class MultiGridFormPage : AbstractMultiGridPage, IMultiGridFormPage
    {
        public override PageKey PageKey
        {
            get { return PageKey.MULTIGRID_FORM_PAGE; }
        }

        public void CloseSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.CloseSuccessfulMessage,
                               StringResources.CloseSuccessfulTitle, MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
        }

        public override string TabText
        {
            get { return PageKey.TabText; }
        }

        public override Type PageDtoType
        {
            get { return null; }
        }

        public override bool CanSelectItemFromAnotherPage
        {
            get { return true; }
        }

        public override void SelectSingleItemById(long? id)
        {
            Grid.SelectItemById(id);
        }

        public override void ClearSelectionsAndSelectItemsById(List<long> ids)
        {
            ;
        }

        public override void SelectSingleItemByIndex(int index)
        {
            Grid.SelectSingleItemByIndex(index);
        }

        public override bool ContainsItemById(long? id)
        {
            return false;
        }
    }
}
