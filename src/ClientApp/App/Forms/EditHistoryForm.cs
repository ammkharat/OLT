using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditHistoryForm : BaseForm, IEditHistoryFormView
    {
        public event Action CloseButtonClicked;
        public event Action<DomainObject> SelectedItemChanged;

        private readonly DomainSummaryGrid<DomainObjectChangeSet> changeSetGrid;
        private readonly DomainSummaryGrid<PropertyChange> fieldChangeGrid;

        public EditHistoryForm()
        {
            InitializeComponent();

            changeSetGrid = new DomainSummaryGrid<DomainObjectChangeSet>(new DomainObjectChangeSetGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty);
            changeSetGrid.DisplayLayout.GroupByBox.Hidden = true;
            changeSetGrid.TabIndex = 0;
            changeSetGrid.MaximumBands = 1;
            changeSetGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            historicalChangesGroupBox.Controls.Add(changeSetGrid);
            changeSetGrid.Dock = DockStyle.Fill;

            fieldChangeGrid = new DomainSummaryGrid<PropertyChange>(new FieldChangeGridRenderer(), OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, string.Empty);
            fieldChangeGrid.DisplayLayout.GroupByBox.Hidden = true;
            fieldChangeGrid.TabIndex = 0;
            fieldChangeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            historicalChangeDetailsGroupBox.Controls.Add(fieldChangeGrid);
            fieldChangeGrid.Dock = DockStyle.Fill;

            closeButton.Click += CloseButton_Click;
            changeSetGrid.SelectedItemChanged += ChangeSetGrid_SelectedItemChanged;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (CloseButtonClicked != null)
            {
                CloseButtonClicked();
            }
        }

        private void ChangeSetGrid_SelectedItemChanged(object sender, DomainEventArgs<DomainObjectChangeSet> e)
        {
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged(e.SelectedItem);
            }
        }

        public List<DomainObjectChangeSet> DomainObjectChangeSets
        {
            set
            {
                changeSetGrid.Items = value;
                if (value.Count > 0)
                {
                    changeSetGrid.Rows[0].Selected = true;
                }
            }
        }

        public List<PropertyChange> PropertyChanges
        {
            set { fieldChangeGrid.Items = value; }
        }

        public string TypeGroupBoxText
        {
            set { typeGroupBox.Text = value; }
        }

        public string Name
        {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value; }
        }
    }
}