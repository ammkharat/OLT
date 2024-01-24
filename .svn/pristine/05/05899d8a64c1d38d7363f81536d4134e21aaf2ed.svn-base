using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class ConfinedSpaceDetails : AbstractDetails, IConfinedSpaceDetails
    {
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Clone;
        public event EventHandler Print;
        public event EventHandler PrintPreview;
        public event EventHandler ExportAll;

        public ConfinedSpaceDetails()
        {
            InitializeComponent();

            deleteButton.Click += DeleteButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            editButton.Click += EditButton_Click;
            cloneButton.Click += CloneButton_Click;
            printButton.Click += PrintButton_Click;
            printPreviewButton.Click += PrintPreviewButton_Click;
            exportallButton.Click += ExportAllButton_Click;
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return rangeButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(this, e);
            }
        }

        private void PrintPreviewButton_Click(object sender, EventArgs e)
        {
            if (PrintPreview != null)
            {
                PrintPreview(this, e);
            }
        }


        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Visible = false;
            }
        }

        public bool RangeVisible
        {
            set { rangeButton.Visible = value; }
        }

        public bool HistoryVisible
        {
            set { editHistoryButton.Visible = value; }
        }

        public void SetDetails(ConfinedSpace confinedSpace)
        {
            permitStartDate.Text = confinedSpace.StartDateTime.ToLongDateAndTimeString();
            permitEndDate.Text = confinedSpace.EndDateTime.ToLongDateAndTimeString();
            permitNumberData.Text = confinedSpace.ConfinedSpaceNumber.Value.ToString();
            flocData.Text = confinedSpace.FunctionalLocation.FullHierarchyWithDescription;

            h2sCheckBox.Checked = confinedSpace.H2S;
            hydrocarbureCheckBox.Checked = confinedSpace.Hydrocarbure;
            ammoniaqueCheckBox.Checked = confinedSpace.Ammoniaque;
            corrosifCheckBox.Checked = confinedSpace.Corrosif.StateAsBool;
            corrosifData.Text = confinedSpace.Corrosif.Text;
            aromatiqueCheckBox.Checked = confinedSpace.Aromatique.StateAsBool;
            aromatiqueData.Text = confinedSpace.Aromatique.Text;
            autresCheckBox.Checked = confinedSpace.AutresSubstances.StateAsBool;
            autresData.Text = confinedSpace.AutresSubstances.Text;

            obtureCheckBox.Checked = confinedSpace.ObtureOuDebranche;
            depressuriseCheckBox.Checked = confinedSpace.DepressuriseEtVidange;
            enPresenceCheckBox.Checked = confinedSpace.EnPresenceDeGazInerte;
            purgeCheckBox.Checked = confinedSpace.PurgeALaVapeur;
            dessinsRequisCheckBox.Checked = confinedSpace.DessinsRequis.StateAsBool;
            dessinsRequisData.Text = confinedSpace.DessinsRequis.Text;
            planDeSAuvetageCheckBox.Checked = confinedSpace.PlanDeSauvetage;

            cablesChauffantsMisHorsTnsionCheckBox.Checked = confinedSpace.CablesChauffantsMisHorsTension;
            interrupteursElectriquesVerrouillesCheckBox.Checked = confinedSpace.InterrupteursElectriquesVerrouilles;
            purgeGazInerteCheckBox.Checked = confinedSpace.PurgeParUnGazInerte;
            rinceAlEauCheckBox.Checked = confinedSpace.RinceAlEau;
            ventilationMecaniqueCheckBox.Checked = confinedSpace.VentilationMecanique;

            bouchesDegoutProtegeesCheckBox.Checked = confinedSpace.BouchesDegoutProtegees;
            possibiliteDeSulfureDeFerCheckBox.Checked = confinedSpace.PossibiliteDeSulfureDeFer;
            aereCheckBox.Checked = confinedSpace.AereVentile;
            autresConditionsCheckBox.Checked = confinedSpace.AutreConditions.StateAsBool;
            autresConditionsData.Text = confinedSpace.AutreConditions.Text;
            ventilationNaturelleCheckBox.Checked = confinedSpace.VentilationNaturelle;

            specialPrecautionsOrConsiderationsDescriptionTextBox.Text = confinedSpace.InstructionsSpeciales;

        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }
        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void flowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }

    }
}
