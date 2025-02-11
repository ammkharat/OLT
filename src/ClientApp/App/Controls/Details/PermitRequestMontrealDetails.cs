using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class PermitRequestMontrealDetails : AbstractDetails, IPermitRequestMontrealDetails
    {
        private DomainListView<FunctionalLocation> functionalLocationListView;

        public event EventHandler RefreshAll;
        public event EventHandler EditTemplate;

        public PermitRequestMontrealDetails()
        {
            InitializeComponent();
            InitializeFunctionalLocationsGrid();

            deleteButton.Click += DeleteButton_Click;
            importButton.Click += ImportButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            cloneButton.Click += cloneButton_Click;
            exportAllButton.Click += ExportAllButton_Click;

            editButton.Click += EditButton_Click;
            submitButton.Click += SubmitButton_Click;
            marktemplateButton.Click += marktemplateButton_Click;

            editTemplateButon.Click += editTemplate_Click;
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        protected bool ShowSapDescription
        {
            set
            {
                sapDescriptionLabelPanel.Visible = value;
                sapDescriptionTextBox.Visible = value;
            }
        }

        protected bool ShowLastImportData
        {
            set
            {
                lastImportedDateTimeLabelPanel.Visible = value;
                lastImportedTableLayoutPanel.Visible = value;
            }
        }

        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Clone;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;
        public event EventHandler Submit;
        public event EventHandler Import;

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool SubmitEnabled
        {
            set { submitButton.Enabled = value; }
        }

        public bool ImportEnabled
        {
            set { importButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
            }
        }

        public void SetDetails(PermitRequestMontreal request)
        {
            if (request == null)
            {
                lastModifiedByDataLabel.Text = string.Empty;
                lastModifiedDateTimeDataLabel.Text = string.Empty;

                workPermitTypeLabelData.Text = string.Empty;
                functionalLocationListView.Clear();
                startDateLabelData.Text = string.Empty;
                endDateDataLabel.Text = string.Empty;
                requestedByDataLabel.Text = string.Empty;
                tradeDataLabel.Text = string.Empty;
                workOrderNumberDataLabel.Text = string.Empty;
                operationNumberDataLabel.Text = string.Empty;
                descriptionTextBox.Text = string.Empty;

                companyDataLabel.Text = string.Empty;
                supervisorDataLabel.Text = string.Empty;
                excavationNumberDataLabel.Text = string.Empty;

                permitAttributesControl.AllAttributes = new List<PermitAttribute>();

                lastImportedByLabelData.Text = string.Empty;
                lastImportedDateTimeLabelData.Text = string.Empty;
                lastSubmittedByLabelData.Text = string.Empty;
                lastSubmittedDateTimeLabelData.Text = string.Empty;

                documentLinksControl.DataSource = new List<DocumentLink>();
                ShowLastImportData = true;
            }
            else
            {
                lastModifiedByDataLabel.Text = request.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateTimeDataLabel.Text = request.LastModifiedDateTime.ToLongDateAndTimeString();

                workPermitTypeLabelData.Text = request.WorkPermitType.Name;
                functionalLocationListView.ItemList = request.FunctionalLocations;
                startDateLabelData.Text = request.StartDate.ToString();
                endDateDataLabel.Text = request.EndDate.ToString();
                requestedByDataLabel.Text = request.RequestedByGroup == null
                    ? string.Empty
                    : request.RequestedByGroup.Name;
                tradeDataLabel.Text = request.Trade;
                workOrderNumberDataLabel.Text = request.WorkOrderNumber;
                operationNumberDataLabel.Text = request.OperationNumberAndSubOperationNumberForDisplay;
                descriptionTextBox.Text = request.Description;
                sapDescriptionTextBox.Text = request.SapDescription;

                companyDataLabel.Text = request.Company;
                supervisorDataLabel.Text = request.Supervisor;
                excavationNumberDataLabel.Text = request.ExcavationNumber;

                permitAttributesControl.AllAttributes = request.Attributes;

                lastImportedByLabelData.Text = request.LastImportedByUser == null
                    ? ""
                    : request.LastImportedByUser.FullNameWithUserName;
                lastImportedDateTimeLabelData.Text = request.LastImportedDateTime == null
                    ? ""
                    : request.LastImportedDateTime.Value.ToLongDateAndTimeString();
                lastSubmittedByLabelData.Text = request.LastSubmittedByUser == null
                    ? ""
                    : request.LastSubmittedByUser.FullNameWithUserName;
                lastSubmittedDateTimeLabelData.Text = request.LastSubmittedDateTime == null
                    ? ""
                    : request.LastSubmittedDateTime.Value.ToLongDateAndTimeString();

                documentLinksControl.DataSource = request.DocumentLinks;
                ShowLastImportData = request.DataSource.Id == DataSource.SAP.Id;
                ShowSapDescription = request.DataSource.Id == DataSource.SAP.Id &&
                                     request.Description != request.SapDescription;
            }
        }

        private void InitializeFunctionalLocationsGrid()
        {
            functionalLocationListView = new DomainListView<FunctionalLocation>(
                new DetailsFunctionalLocationRenderer(), false) {Dock = DockStyle.Fill};
            functionalLocationPanel.Controls.Add(functionalLocationListView);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Submit != null)
            {
                Submit(this, e);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (Import != null)
            {
                Import(this, e);
            }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public event EventHandler MarkAsTemplate;

        public bool MarkTemplateEnabled
        {
            set { marktemplateButton.Visible = value; }
        }
        
        private void marktemplateButton_Click(object sender, EventArgs e)
        {
            if (MarkAsTemplate != null)
            {
                MarkAsTemplate(this, e);
            }
        }

        private void editTemplate_Click(object sender, EventArgs e)
        {
            if (EditTemplate != null)
            {
                EditTemplate(this, e);
            }
        }

        public bool editTemplateVisible
        {
            set { editTemplateButon.Visible = value; }
        }


        public bool DeleteVisible
        {
            set { deleteButton.Visible = value; }
        }
        public bool editVisible
        {
            set { editButton.Visible = value; }
        }
        public bool submitButtonVisible
        {
            set { submitButton.Visible = value; }
        }

        public bool editHistoryButtonVisible
        {
            set { editHistoryButton.Visible = value; }
        }

        private void refreshAllButton_Click(object sender, EventArgs e)
        {
            if (RefreshAll != null)
            {
                RefreshAll(this, e);
            }
        }
    }
}