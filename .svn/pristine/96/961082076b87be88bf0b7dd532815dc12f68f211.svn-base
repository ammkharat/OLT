using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ReferencedLogForm : BaseForm, IReferencedLogFormView
    {
        private readonly IMainForm mainForm;
        private readonly DomainSummaryGrid<LogDTO> grid;
        private readonly ReferencedLogFormPresenter presenter;

        public ReferencedLogForm(List<LogDTO> dtos, IMainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
           
            grid = new DomainSummaryGrid<LogDTO>(new LogGridRenderer(true, LogType.Standard, false),
                                                 OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, "LogGrid")
                       {Dock = DockStyle.Fill};
            logsPanel.Controls.Add(grid);

            logDetails.HideActionStrip();
            logDetails.Clear();

            presenter = new ReferencedLogFormPresenter(this, dtos);
            InitializePresenter();
        }

        private void InitializePresenter()
        {            
            Load += presenter.Load;
       
            grid.AfterRowActivate += HandleAfterRowActivate;
            okButton.Click += presenter.OkButton_Click;
            goToLogButton.Click += presenter.GoToLogButton_Click;
            logDetails.DetailsMarkedAsReadByExpand += presenter.DetailsMarkedAsReadByExpand;
        }

        private void HandleAfterRowActivate(object sender, EventArgs e)
        {
            UltraGridRow ultraGridRow = grid.ActiveRow;      
            presenter.SelectedLogChanged(ultraGridRow.ListObject);
        }

        public void SetTitle(string title)
        {
            Text = title;
        }

        public void SelectFirstLog()
        {
            grid.SelectFirstRow();
        }

        public void DisplayLogDoesNotFallWithinSelectedVisibilityGroupsError()
        {
            OltMessageBox.Show(this, StringResources.LogDoesNotFallWithinSelectedVisibilityGroups, StringResources.LogDoesNotFallWithinSelectedVisibilityGroupsTitle);
        }

        public IList<LogDTO> LogList
        {
            set { grid.Items = value; }
        }

        public void SetDetails(Log item, List<CustomField> customFields)
        {
            logDetails.SetDetails(item, customFields);
        }

        public void HighlightSelectedLogInLogTab()
        {
            LogDTO selectedLogDto = grid.SelectedItem;
            mainForm.SelectSectionAndItem(SectionKey.LogSection, selectedLogDto);
        }

        public LogDTO SelectedItem
        {
            get { return grid.SelectedItem; }
        }

        public List<ItemReadBy> MarkedAsReadByList
        {
            set { logDetails.MarkedAsReadBy = value; }
        }

        public bool GoToLogButtonEnabled
        {
            set { goToLogButton.Enabled = value; }
        }
    }   
}
