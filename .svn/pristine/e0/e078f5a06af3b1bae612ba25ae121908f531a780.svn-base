using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraRichEdit.Model.History;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using AutoCompleteMode = Infragistics.Win.AutoCompleteMode;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormOvertimeForm : BaseForm, IFormOvertimeView
    {
        private string ContractorColumnKey = "Contractor";
        private string ContractorValueListKey = "ContractorValueList";
        private string EndDateColumnKey = "EndDate";
        private string EndTimeColumnKey = "EndTime";
        private string PersonnelColumnKey = "PersonnelName";
        private string PersonnelValueListKey = "PersonnelNameValueList";
        private string PrimaryLocationColumnKey = "PrimaryLocation";
        private string PrimaryLocationValueListKey = "PrimaryLocationValueList";
        private string StartDateColumnKey = "StartDate";
        private string StartTimeColumnKey = "StartTime";


        public FormOvertimeForm()
        {
            InitializeComponent();

            addButton.Click += HandleAddButtonClicked;
            cloneButton.Click += HandleCloneButtonClicked;
            removeButton.Click += HandleRemoveButtonClicked;

            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;

            historyButton.Click += HandleHistoryButtonClick;

            overtimeGrid.AfterCellUpdate += HandleCellUpdate;

            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;
            approvalsGridControl.MaxLines = 4;
        }

        public event Action FormLoad;
        public event EventHandler SaveButtonClicked;
        public event Action SaveAndEmailButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action AddButtonClicked;
        public event Action CloneButtonClicked;
        public event Action RemoveButtonClicked;
        public event Action StartDateChanged;
        public event Action EndDateChanged;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;

        public List<CraftOrTrade> AllCraftOrTrades
        {
            set
            {
                occupationComboBox.DataSource = value;
                occupationComboBox.DisplayMember = "ListDisplayText";
            }
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            var message = StringResources.FormReapprovalQuestion;
            var title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void DisableApprovals()
        {
            approvalsGridControl.Enabled = false;
           
        }

        //Start Minlge Story #4003, Change By : Swapnil, Changed On : 29 Mar 2016
        public void ChangeButtonText()
        {
            saveButton.Text = "Save && Approve";
            saveAndEmailButton.Visible = false;

            }
        //End Minlge Story #4003, Change By : Swapnil, Changed On : 29 Mar 2016

        public List<string> PrimaryLocations
        {
            set
            {
                var valueList = (ValueList) overtimeGrid.DisplayLayout.Bands[0].Columns[PrimaryLocationColumnKey].ValueList ??
                                overtimeGrid.DisplayLayout.ValueLists.Add(PrimaryLocationValueListKey);

                valueList.ValueListItems.Clear();
                foreach (var primaryLocation in value)
                {
                    valueList.ValueListItems.Add(primaryLocation);
                }
                overtimeGrid.DisplayLayout.Bands[0].Columns[PrimaryLocationColumnKey].ValueList = valueList;
            }
        }

        public List<EdmontonPerson> PersonnelList
        {
            set
            {
                var valueList = (ValueList) overtimeGrid.DisplayLayout.Bands[0].Columns[PersonnelColumnKey].ValueList ??
                                overtimeGrid.DisplayLayout.ValueLists.Add(PersonnelValueListKey);

                valueList.ValueListItems.Clear();
                foreach (var personnel in value)
                {
                    valueList.ValueListItems.Add(new ValueListItem(personnel.DisplayString));
                }
                overtimeGrid.DisplayLayout.Bands[0].Columns[PersonnelColumnKey].ValueList = valueList;
            }
        }

        public string Trade { get { return occupationComboBox.Text; } set { occupationComboBox.Text = value; } }

        public List<Contractor> Contractors
        {
            set
            {
                var valueList = (ValueList) overtimeGrid.DisplayLayout.Bands[0].Columns[ContractorColumnKey].ValueList ??
                                overtimeGrid.DisplayLayout.ValueLists.Add(ContractorValueListKey);

                valueList.ValueListItems.Clear();
                foreach (var contractor in value)
                {
                    valueList.ValueListItems.Add(contractor, contractor.CompanyName);
                }

                overtimeGrid.DisplayLayout.Bands[0].Columns[ContractorColumnKey].ValueList = valueList;
            }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            OnPremiseContractors.ForEach(item => item.ClearErrors());
            MakeOvertimePersonGridValidationIconsShowOrDisappear();
        }

        public void SetErrorForOvertimePersonnel()
        {
            errorProvider.SetError(overtimeGrid, StringResources.OvertimeForm_ErrorMustHaveOneRow);
        }

        public void MakeOvertimePersonGridValidationIconsShowOrDisappear()
        {
            overtimeGrid.Rows.Refresh(RefreshRow.FireInitializeRow);
        }

        public List<OvertimeContractorDisplayAdapter> OnPremiseContractors
        {
            get { return (List<OvertimeContractorDisplayAdapter>) overtimeGrid.DataSource; }
            set
            {
                overtimeGrid.DataSource = value;
                overtimeGrid.ResetBindings();
            }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public User CreatedByUser { set { createdByUserLabel.Text = value.FullNameWithUserName; } }

        public DateTime CreatedDateTime { set { createdDateLabel.Text = value.ToLongDateAndTimeString(); } }

        public User LastModifiedByUser { set { lastModifiedUserLabel.Text = value.FullNameWithUserName; } }

        public DateTime LastModifiedDateTime { set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); } }

        public DateTime OvertimeStart
        {
            set { startOvertimeDateLabel.Text = value.ToLongDateAndTimeString(); }
            get { return DateTime.Parse(startOvertimeDateLabel.Text); }
        }

        public DateTime OvertimeEnd
        {
            set { endOvertimeDateLabel.Text = value.ToLongDateAndTimeString(); }
            get { return DateTime.Parse(endOvertimeDateLabel.Text); }
        }

        public OvertimeContractorDisplayAdapter SelectedPersonnel
        {
            get
            {
                var ultraGridRow = overtimeGrid.ActiveRow;
                return ultraGridRow == null ? null : ultraGridRow.ListObject as OvertimeContractorDisplayAdapter;
            }
        }

        public void AddOnPremiseContractor(OvertimeContractorDisplayAdapter item)
        {
            var items = new List<OvertimeContractorDisplayAdapter>((List<OvertimeContractorDisplayAdapter>) overtimeGrid.DataSource)
            {
                item
            };
            overtimeGrid.DataSource = items;
            overtimeGrid.ResetBindings();
            overtimeGrid.ActiveItemByReference = item;
        }

        public void SetErrorForNoTrade()
        {
            errorProvider.SetError(occupationComboBox, StringResources.OvertimeForm_ErrorTradeRequired);
        }

        public void RemoveSelectedOnPremiseContractor()
        {
            var items = new List<OvertimeContractorDisplayAdapter>((List<OvertimeContractorDisplayAdapter>) overtimeGrid.DataSource);

            var activeItem = (OvertimeContractorDisplayAdapter) overtimeGrid.ActiveItem;

            if (activeItem != null)
            {
                items.Remove(activeItem);
                overtimeGrid.DataSource = items;
                overtimeGrid.ResetBindings();
            }
        }

        public bool RemoveButtonEnabled { set { removeButton.Enabled = value; } }

        public List<FormApproval> Approvals
        {
            set { approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval)); }
            get
            {
                var list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }
        }

        private void HandleCellUpdate(object sender, CellEventArgs e)
        {
            var ultraGridCell = e.Cell;

            ultraGridCell.Row.PerformAutoSize();

            var columnKey = ultraGridCell.Column.Key;

            if (StartDateChanged != null && (columnKey.Equals(StartDateColumnKey) ||
                                             columnKey.Equals(StartTimeColumnKey)))
            {
                StartDateChanged();
            }
            else if (EndDateChanged != null && (columnKey.Equals(EndDateColumnKey) ||
                                                columnKey.Equals(EndTimeColumnKey)))
            {
                EndDateChanged();
            }
        }

        private void SetupSummary()
        {
            var ultraGridBand = overtimeGrid.DisplayLayout.Bands[0];
            var summarySettings = ultraGridBand.Summaries.Add("SummaryKey", SummaryType.Sum, ultraGridBand.Columns["ExpectedHours"]);
            summarySettings.DisplayFormat = "Total Hours: {0}";
            summarySettings.SummaryPosition = SummaryPosition.Right;
        }

        private void HandleRemoveButtonClicked(object sender, EventArgs e)
        {
            if (RemoveButtonClicked != null)
            {
                RemoveButtonClicked();
            }
        }

        private void HandleCloneButtonClicked(object sender, EventArgs e)
        {
            if (CloneButtonClicked != null)
            {
                CloneButtonClicked();
            }
        }

        private void HandleAddButtonClicked(object sender, EventArgs e)
        {
            if (AddButtonClicked != null)
            {
                AddButtonClicked();
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (HistoryButtonClicked != null)
            {
                HistoryButtonClicked();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            overtimeGrid.DataSource = new List<OvertimeContractorDisplayAdapter>();

            SetupSummary();

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
            }
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }
    }
}