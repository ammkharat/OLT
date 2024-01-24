using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SelectConfinedSpacePresenter : ConfinedSpacePagePresenter
    {
        private readonly IGridAndDetailsView view;

        public SelectConfinedSpacePresenter() : base(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT)
        {
            view = new GridAndDetailsForm();
            view.Title = StringResources.ConfinedSpaceTabText;
            view.Height = 749;
            view.ButtonsVisible = true;
            view.AcceptButtonText = StringResources.SelectButtonLabel;
            view.GridAndDetails = (Control)page;

            page.SplitterDistance = 200;
            page.Details.MakeAllButtonsInvisible();
            page.Details.RangeVisible = true;
            page.Details.HistoryVisible = true;

            view.AcceptButtonClicked += AcceptButtonClicked;
        }

        private void AcceptButtonClicked()
        {
            if (page.Grid.Items.Count == 0)
            {
                view.DialogResult = DialogResult.Cancel;
                view.Close();                
            }
            else if (page.FirstSelectedItem == null)
            {
                view.ShowMessageBox(StringResources.ConfinedSpaceTabText, StringResources.ConfinedSpace_PleaseSelect);
            }
            else
            {
                view.DialogResult = DialogResult.OK;
                view.Close();                                
            }
        }

        protected override void Grid_DoubleClicked(object sender, DomainEventArgs<ConfinedSpaceDTO> args)
        {
            AcceptButtonClicked();
        }

        public DialogResultAndOutput<ConfinedSpaceDTO> Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            DialogResult dialogResult = view.ShowDialog(parent);
            ConfinedSpaceDTO dto = null;
            if (dialogResult == DialogResult.OK)
            {
                dto = page.FirstSelectedItem;
            }

            view.Dispose();

            return new DialogResultAndOutput<ConfinedSpaceDTO>(dialogResult, dto);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            // don't listen to events
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            // don't listen to events
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return null; }
        }
    }
}
