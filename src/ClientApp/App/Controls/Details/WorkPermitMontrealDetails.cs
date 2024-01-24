using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class WorkPermitMontrealDetails : AbstractDetails, IWorkPermitMontrealDetails
    {
        public event EventHandler CloseWorkPermit;        
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Clone;
        public event EventHandler Print;
        public event EventHandler PrintPreview;
        public event EventHandler ViewEditHistory;
        public event Action ViewAssociatedLogs;
        public event EventHandler ExportAll;
        public event Action OpenDocumentLink;
        public event EventHandler EditTemplate;

        public event Action<ConfiguredDocumentLink> ConfiguredDocumentLinkClicked;

        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private DomainListView<FunctionalLocation> functionalLocationListView;

        public event EventHandler ViewAttachment;

        public event EventHandler RefreshAll;
        public WorkPermitMontrealDetails()
        {
            InitializeComponent();
            base.Dock = DockStyle.Fill;
            InitializeFunctionalLocationsGrid();
            viewAssociatedLogsButton.Click += HandleViewAssociatedLogsButtonClick;
            closeButton.Click += closeWorkPermitButton_Click;
            deleteButton.Click += deleteButton_Click;
            editButton.Click += editButton_Click;
            printButton.Click += printButton_Click;
            printPreviewButton.Click += printPreviewButton_Click;
            cloneButton.Click += cloneButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            editHistoryButton.Click += editHistoryButton_Click;

            marktemplateButton.Click += marktemplateButton_Click;

            editTemplateButon.Click += editTemplate_Click;

            documentLinksControl.LinkOpened += () => OpenDocumentLink();
        }
        public bool ViewAssociatedLogsEnabled
        {
            set { viewAssociatedLogsButton.Enabled = value; }
        }

        private void HandleViewAssociatedLogsButtonClick(object sender, EventArgs e)
        {
            if (ViewAssociatedLogs != null)
            {
                ViewAssociatedLogs();
            }
        }

        public List<ConfiguredDocumentLink> ConfiguredDocumentLinks
        {
            set
            {
                configuredDocumentLinks = value;
                documentLinks.DropDownItems.Clear();
                foreach (ConfiguredDocumentLink link in configuredDocumentLinks)
                {
                    documentLinks.DropDownItems.Add(link.Title, null, OnConfiguredDocumentLinkClick);
                }
            }
        }

        public void DisableConfiguredDocumentLinks()
        {
            documentLinks.Enabled = false;
        }

        private void OnConfiguredDocumentLinkClick(object sender, EventArgs eventArgs)
        {
            ToolStripDropDownItem dropDownItem = (ToolStripDropDownItem) sender;
            string text = dropDownItem.Text;

            ConfiguredDocumentLink configuredDocumentLink = configuredDocumentLinks.Find(link => link.Title == text);
            if (ConfiguredDocumentLinkClicked != null)
            {
                ConfiguredDocumentLinkClicked(configuredDocumentLink);
            }
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return rangeButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        private void InitializeFunctionalLocationsGrid()
        {
            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            functionalLocationsPanel.Controls.Add(functionalLocationListView);
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void closeWorkPermitButton_Click(object sender, EventArgs e)
        {
            if (CloseWorkPermit != null)
            {
                CloseWorkPermit(this, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(this, e);
            }
        }
       
        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            if (PrintPreview != null)
            {
                PrintPreview(this, e);
            }
        }

        private void exportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void editHistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        public string PermitType
        {
            set { workPermitType.Text = value; }
        }

        public string PermitStartDate
        {
            set { permitStartDate.Text = value; }
        }

        public string PermitEndDate
        {
            set { permitEndDate.Text = value; }
        }

        private void ConfigureCheckBox(OltCheckBox checkbox, Visible<bool> value)
        {
            if (value.VisibleState == VisibleState.Invisible)
            {
                checkbox.Visible = false;
                checkbox.Checked = false;
            }
            else if (value.VisibleState == VisibleState.Visible)
            {
                checkbox.Visible = true;
                checkbox.Checked = value.Value;
            }
        }

        // Informations de base
        public string WorkPermitTemplate { set { permitTemplateData.Text = value; } }
        public string WorkPermitNumber { set { permitNumberData.Text = value; } }        
        public string Trade { set { tradeData.Text = value; } }
        public string RequestedByGroup { set { requestedByGroupData.Text = value; } }
        public string WorkOrderNumber { set { workOrderNumberData.Text = value; } }
        public string Description { set { permitDescriptionData.Text = value; } }
        public List<FunctionalLocation> FunctionalLocations
        {
            set
            {
                value.SortByFullHierarchy();
                functionalLocationListView.ItemList = value;
            }
        }

        // Substances normalement à l'intérieur de l'équipement
        public Visible<bool> H2S{ set { ConfigureCheckBox(h2sCheckBox,value); } }
        public Visible<bool> Hydrocarbure{ set { ConfigureCheckBox(hydrocarbureCheckBox, value); } }
        public Visible<bool> Ammoniaque{ set { ConfigureCheckBox(ammoniaqueCheckBox, value); } }
        public string CorrosifData { set { corrosifData.Text = value; } }
        public Visible<bool> Corrosif{ set { ConfigureCheckBox(corrosifCheckBox, value); } }
        public string AromatiqueData { set { aromatiqueData.Text = value; } }
        public Visible<bool> Aromatique{ set { ConfigureCheckBox(aromatiqueCheckBox, value); } }
        public string AutresData { set { autresData.Text = value; } }
        public Visible<bool> Autres{ set { ConfigureCheckBox(autresCheckBox, value); } }

        // Conditions et outils permis pour ce travail
        public Visible<bool> ObtureOuDebranche { set { ConfigureCheckBox(obtureCheckBox, value); } }
        public Visible<bool> DepressuriseEtVidange { set { ConfigureCheckBox(depressuriseCheckBox, value); } }
        public Visible<bool> EnPresenceDeGazInerte { set { ConfigureCheckBox(enPresenceCheckBox,value); } }
        public Visible<bool> PurgeALaVapeur { set { ConfigureCheckBox(purgeCheckBox,value); } }
        public Visible<bool> RinceALeau { set { ConfigureCheckBox(rinceCheckBox, value); } }
        public Visible<bool> Excavation { set { ConfigureCheckBox(excavationCheckBox, value); } }
        public string DessinsRequisData { set { dessinsRequisData.Text = value; } }
        public Visible<bool> DessinsRequis { set { ConfigureCheckBox(dessinsRequisCheckBox, value); } }
        public Visible<bool> CablesChauffantsMisHorsTension { set { ConfigureCheckBox(cablesCheckBox, value); } }
        public Visible<bool> PompeOuVerinPneumatique { set { ConfigureCheckBox(pompeCheckBox, value); } }

        public Visible<bool> ChaineEtCadenasseOuScelle { set { ConfigureCheckBox(chaineCadenasseScelleCheckBox, value); } }
        public Visible<bool> InterrupteursElectriquesVerrouilles { set { ConfigureCheckBox(interrupteursElectriquesVerrouillesCheckBox, value); } }
        public Visible<bool> PurgeParUnGazInerte { set { ConfigureCheckBox(purgeGazInerteCheckBox, value); } }
        public Visible<bool> OutilsElectriquesOuABatteries { set { ConfigureCheckBox(outilsElectriquesBatteriesCheckBox, value); } }
        public string BoiteEnergieZeroData { set { boiteEnergieZeroData.Text = value; } }
        public Visible<bool> BoiteEnergieZero { set { ConfigureCheckBox(boiteEnergieZeroCheckBox, value); } }
        public Visible<bool> OutilsPneumatiques { set { ConfigureCheckBox(outilsPneumatiquesCheckBox, value); } }
        public Visible<bool> MoteurACombustionInterne { set { ConfigureCheckBox(moteurCombustionInterneCheckBox, value); } }
        public Visible<bool> TravauxSuperPoses { set { ConfigureCheckBox(travauxSuperposesCheckBox, value); } }

        public string FormulaireDespaceClosAfficheData { set { formulaireDespaceData.Text = value; } }
        public Visible<bool> FormulaireDespaceClosAffiche { set { ConfigureCheckBox(formulaireDespaceAfficheCheckBox, value); } }
        public Visible<bool> ExisteIlUneAnalyseDeTache { set { ConfigureCheckBox(existeIlUneAnalyseDeTacheCheckBox, value); } }
        public Visible<bool> PossibiliteDeSulfureDeFer { set { ConfigureCheckBox(possibiliteDeSulfuredeFerCheckBox, value); } }
        public Visible<bool> AereVentile { set { ConfigureCheckBox(aereCheckBox, value); } }
        public Visible<bool> SoudureALelectricite { set { ConfigureCheckBox(soudureElectriciteCheckBox, value); } }
        public Visible<bool> BrulageAAcetylene { set { ConfigureCheckBox(brulageAcetyleneCheckBox, value); } }
        public Visible<bool> Nacelle { set { ConfigureCheckBox(nacelleCheckBox, value); } }
        public string AutreConditionsData { set { autresConditionsData.Text = value; } }
        public Visible<bool> AutreConditions { set { ConfigureCheckBox(autresConditionsCheckBox, value); } }

        // Equipements de protection individuelle
        public Visible<bool> LunettesMonocoques { set { ConfigureCheckBox(lunettesMonocoquesCheckBox, value); } }
        public Visible<bool> HarnaisDeSecurite { set { ConfigureCheckBox(harnaisCheckBox, value); } }
        public Visible<bool> EcranFacial { set { ConfigureCheckBox(ecranCheckBox, value); } }
        public Visible<bool> ProtectionAuditive { set { ConfigureCheckBox(protectionCheckBox, value); } }
        public Visible<bool> Trepied { set { ConfigureCheckBox(trepiedCheckBox, value); } }
        public Visible<bool> DispositifAntichute { set { ConfigureCheckBox(dispositifCheckBox, value); } }
        
        public string ProtectionRespiratoireData { set { protectionRespiratoireData.Text = value; } }
        public Visible<bool> ProtectionRespiratoire { set { ConfigureCheckBox(protectionRespiratoireCheckBox, value); } }

        public string HabitsData { set { habitsData.Text = value; } }
        public Visible<bool> Habits { set { ConfigureCheckBox(habitsCheckBox, value); } }

        public string AutreProtectionData { set { autreProtectionData.Text = value; } }
        public Visible<bool> AutreProtection { set { ConfigureCheckBox(autreProtectionCheckBox, value); } }
        
        // Protection incendie
        public Visible<bool> Extincteur { set { ConfigureCheckBox(extincteurCheckBox, value); } }
        public Visible<bool> BouchesDegoutProtegees { set { ConfigureCheckBox(bouchesDegoutProtegeesCheckBox, value); } }
        public Visible<bool> CouvertureAntiEtincelles { set { ConfigureCheckBox(couvetureAntiEtincellesCheckBox, value); } }
        public Visible<bool> SurveillantPouretincelles { set { ConfigureCheckBox(surveillantPourEtincellesCheckBox, value); } }
        public Visible<bool> PareEtincelles { set { ConfigureCheckBox(pareEtincellesCheckBox, value); } }
        public Visible<bool> MiseAlaTerrePresDuLieuDeTravail { set { ConfigureCheckBox(miseALaTerePresDuLieuDeTravailCheckBox, value); } }
        public Visible<bool> BoyauAVapeur { set { ConfigureCheckBox(boyauVapeurCheckBox, value); } }

        public string AutresEquipementDincendieData { set { autresEquipementDincendieData.Text = value; } } 
        public Visible<bool> AutresEquipementDincendie { set { ConfigureCheckBox(autresEquipementDincendieCheckBox, value); } }

        // Autres équipements de sécurité
        public Visible<bool> Ventulateur { set { ConfigureCheckBox(ventilateurCheckBox, value); } }
        public Visible<bool> Barrieres { set { ConfigureCheckBox(barrieresCheckBox, value); } }

        public string SurveillantData { set { surveillantData.Text = value; } }
        public Visible<bool> Surveillant { set { ConfigureCheckBox(surveillantCheckBox, value); } }

        public Visible<bool> RadioEmetteur { set { ConfigureCheckBox(radioEmetteurCheckBox, value); } }
        public Visible<bool> PerimetreDeSecurite { set { ConfigureCheckBox(perimetreDeSecuriteCheckBox, value); } }

        public string DetectionContinueDesGazData { set { detectionContinueDesGazData.Text = value; } }
        public Visible<bool> DetectionContinueDesGaz { set { ConfigureCheckBox(detectionContinueDesGazCheckBox, value); } }

        public Visible<bool> KlaxonSonore { set { ConfigureCheckBox(klaxonSonoreCheckBox, value); } }
        public Visible<bool> Localiser { set { ConfigureCheckBox(localiserCheckBox, value); } }
        public Visible<bool> Amiante { set { ConfigureCheckBox(amianteCheckBox, value); } }

        public string AutreEquipementsSecuriteData { set { autreSecuriteData.Text = value; } }
        public Visible<bool> AutreEquipementsSecurite { set { ConfigureCheckBox(autreSecuriteCheckBox, value); } }

        // signature section
        public string InstructionsSpeciales { set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; } }
        public Visible<bool> SignatureOperateurSurLeTerrain { set { ConfigureCheckBox(signatureOperateurCheckBox, value); } }
        public Visible<bool> DetectionDesGazs { set { ConfigureCheckBox(detectionDesGazsCheckBox, value); } }
        public Visible<bool> SignatureContremaitre { set { ConfigureCheckBox(signatureContremaitreCheckBox, value); } }
        public Visible<bool> SignatureAutorise { set { ConfigureCheckBox(signatureAutoriseCheckBox, value); } }
        public Visible<bool> NettoyageTransfertHorsSite { set { ConfigureCheckBox(nettoyageTransfertHorsSiteCheckBox, value); } }

        public List<DocumentLink> DocumentLinks { set { documentLinksControl.DataSource = value; } }

        public void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
            string company, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes)
        {
            SuspendLayout();
            
            requestDetailsControl.Visible = visible;
            if (visible)
            {
                requestDetailsControl.SetFields(requestedDateTime, requestedByUser, company, supervisor, excavationNumber, attributes);
            }

            ResumeLayout(false);
            PerformLayout();
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Visible = false;
            }
        }

        public bool EditVisible { set { editButton.Visible = value; } }
        public bool CloseVisible { set { closeButton.Visible = value; } }
        public bool PrintVisible { set { printButton.Visible = value; } }
        public bool PrintPreviewVisible { set { printPreviewButton.Visible = value; } }
        public bool EditHistoryVisible { set { editHistoryButton.Visible = value; } }

        public bool CloseEnabled
        {
            set { closeButton.Enabled = value; }
        }
        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }
        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }
        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }
        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }
        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }
        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
            }
        }
        
        public IWorkPermitMontrealDetails BindingTarget
        {
            get { return this; }
        }

        private void flowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }


        // DMND0010609-OLT - Edmonton Work permit Scan

        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(permitNumberData.Text) != "")
            {
                string permitNumber = permitNumberData.Text;
                ScanWorkPermit Scanform = new ScanWorkPermit(permitNumber);
                Scanform.ShowDialog();
            }
           
        }

        private void ViewAttachmentbutton_Click(object sender, EventArgs e)
        {
            if (ViewAttachment != null)
            {
                ViewAttachment(this, e);
            }
        }
        public bool ViewAttachEnabled
        {
            set { ViewAttachmentbutton.Enabled = value; }
        }

        public bool ViewScanEnabled
        {
            set { ScanButton.Enabled = value; }
        }

        public void MakeSeachWindowRequiredButtonsvisibleonly()
        {
            viewAssociatedLogsButton.Visible = false;
            rangeButton.Visible = false;
            exportallButton.Visible = false;
            documentLinks.Visible = false;
            saveGridLayoutButton.Visible = false;

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
        public bool closeButtonVisible
        {
            set { closeButton.Visible = value; }
        }
        public bool printButtonVisible
        {
            set { printButton.Visible = value; }
        }
        public bool printPreviewButtonVisible
        {
            set { printPreviewButton.Visible = value; }
        }
        public bool editHistoryButtonVisible
        {
            set { editHistoryButton.Visible = value; }
        }
        public bool viewAssociatedLogsButtonVisible
        {
            set { viewAssociatedLogsButton.Visible = value; }
        }
        public bool ScanButtonVisible
        {
            set { ScanButton.Visible = value; }
        }
        public bool ViewAttachmentbuttonVisible
        {
            set { ViewAttachmentbutton.Visible = value; }
        }
        
        public bool documentLinksVisible
        {
            set { documentLinks.Visible = value; }
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
