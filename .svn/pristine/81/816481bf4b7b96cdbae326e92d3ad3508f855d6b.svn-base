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
    public partial class WorkPermitMudsDetails : AbstractDetails, IWorkPermitMudsDetails
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

        public event Action<ConfiguredDocumentLink> ConfiguredDocumentLinkClicked;

        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private DomainListView<FunctionalLocation> functionalLocationListView;

        public event EventHandler ViewAttachment;

        public event EventHandler GastestButtonEvent;

        public event EventHandler RefreshAll;

        public event EventHandler EditTemplate;

        public WorkPermitMudsDetails()
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
            documentLinksControl.LinkOpened += () => OpenDocumentLink();
            GasTestButton.Click += Gastestbutton_Click;
           //viewAssociatedLogsButton.Visible = false;
            marktemplateButton.Click += marktemplateButton_Click;

            editTemplateButton.Click += editTemplate_Click;
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
        public string Trade { set { value = value; } }
        public string CompanyName { set { contractorLabelData.Text = value; } }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string CompanyName_1 { set { contractorLabelData_1.Text = value; } }
        public string CompanyName_2 { set { contractorLabelData_2.Text = value; } }
        public string RequestedByGroup { set { requestedByGroupData.Text = value; } }
        public string RequestedByGroupText { set { requestedByGroupData.Text = value; } }
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

        public string NbTravail { set { nbTravailLabelData.Text = value; } }
        public bool FormationCheck { set { formationCheckBox.Checked = value; } }
        public string NomsEnt { set { nomsLabelData.Text = value; } }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string NomsEnt_1 { set { nomsLabelData_1.Text = value; } }
        public string NomsEnt_2 { set { nomsLabelData_2.Text = value; } }
        public string NomsEnt_3 { set { nomsLabelData_3.Text = value; } }
        public string Surveilant { set { survielantLabelData.Text = value; } }

        public string RemplirLeFormulaireDeConditionData { set { remplirLeFormulaireDeConditionData.Text = value; } }
        public Visible<bool> RemplirLeFormulaireDeCondition { set { ConfigureCheckBox(remplirLeFormulaireDeConditionCheckBox, value); } }

        public Visible<bool> AnalyseCritiqueDeLaTache { set { ConfigureCheckBox(analyseCritiqueDeLaTacheCheckBox, value); } }
        public Visible<bool> Depressurises { set { ConfigureCheckBox(depressurisesCheckBox, value); } }
        public Visible<bool> Vides { set { ConfigureCheckBox(videsCheckBox, value); } }
        public Visible<bool> ContournementDesGda { set { ConfigureCheckBox(procedureEntretienCheckBox, value); } }
        public Visible<bool> Rinces { set { ConfigureCheckBox(rincesCheckBox, value); } }
        public Visible<bool> NettoyesLaVapeur { set { ConfigureCheckBox(nettoyesLaVapeurCheckBox, value); } }
        public Visible<bool> Purges { set { ConfigureCheckBox(purgesCheckBox, value); } }
        public Visible<bool> Ventiles { set { ConfigureCheckBox(ventilesCheckBox, value); } }
        public Visible<bool> Aeres { set { ConfigureCheckBox(aeresCheckBox, value); } }
        public Visible<bool> Energies { set { ConfigureCheckBox(energiesCheckBox, value); } }// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        public Visible<bool> Autres { set { ConfigureCheckBox(autres1CheckBox, value); } }
        public string AutresCData { set { autresCData.Text = value; } }
        

        public string InterrupteursEtVannesCadenassesData { set { interrupteursEtVannesCadenassesData.Text = value; } }
        public Visible<bool> InterrupteursEtVannesCadenasses { set { ConfigureCheckBox(interrupteursEtVannesCadenassesCheckBox, value); } }

        public Visible<bool> VerrouillagesParTravailleurs { set { ConfigureCheckBox(verrouillagesParTravailleursCheckBox, value); } }
        public Visible<bool> SourcesDesenergisees { set { ConfigureCheckBox(sourcesDesenergiseesCheckBox, value); } }
        public Visible<bool> DepartsLocauxTestes { set { ConfigureCheckBox(departsLocauxTestesCheckBox, value); } }
        public Visible<bool> ConduitesDesaccouplees { set { ConfigureCheckBox(conduitesDesaccoupleesCheckBox, value); } }
        public Visible<bool> ObturateursInstallees { set { ConfigureCheckBox(obturateursInstalleesCheckBox, value); } }
        public Visible<bool> PvciSuncorEffectuee { set { ConfigureCheckBox(pvciSuncorEffectueeCheckBox, value); } }
        public Visible<bool> PvciEntExtEffectuee { set { ConfigureCheckBox(pvciEntExtEffectueeCheckBox, value); } }
        public Visible<bool> Amiante { set { ConfigureCheckBox(amiante1CheckBox, value); } }
        public Visible<bool> AcideSulfurique { set { ConfigureCheckBox(acideSulfuriqueCheckBox, value); } }
        public Visible<bool> Azote { set { ConfigureCheckBox(azoteCheckBox, value); } }
        public Visible<bool> Caustique { set { ConfigureCheckBox(caustiqueCheckBox, value); } }
        public Visible<bool> DioxydeDeSoufre { set { ConfigureCheckBox(dioxydeDeSoufreCheckBox, value); } }
        public Visible<bool> Sbs { set { ConfigureCheckBox(sbsCheckBox, value); } }
        public Visible<bool> Soufre { set { ConfigureCheckBox(soufreCheckBox, value); } }
        public Visible<bool> EquipementsNonRinces { set { ConfigureCheckBox(equipementsNonRincesCheckBox, value); } }
        public Visible<bool> Hydrocarbures { set { ConfigureCheckBox(hydrocarburesCheckBox, value); } }
        public Visible<bool> HydrogeneSulfure { set { ConfigureCheckBox(hydrogeneSulfureCheckBox, value); } }
        public Visible<bool> MonoxydeCarbone { set { ConfigureCheckBox(monoxydeCarboneCheckBox, value); } }
        public Visible<bool> Reflux { set { ConfigureCheckBox(refluxCheckBox, value); } }
        public Visible<bool> ProduitsVolatilsUtilises { set { ConfigureCheckBox(produitsVolatilsUtilisesCheckBox, value); } }
        public Visible<bool> Bacteries { set { ConfigureCheckBox(bacteriesCheckBox, value); } }

        public string AppareilData { set { appareilData.Text = value; } }
        public Visible<bool> Appareil { set { ConfigureCheckBox(appareilCheckBox, value); } }

        public Visible<bool> InterferencesEntreTravaux { set { ConfigureCheckBox(interferencesEntreTravauxCheckBox, value); } }
        public Visible<bool> PiecesEnRotation { set { ConfigureCheckBox(piecesEnRotationCheckBox, value); } }
        public Visible<bool> IncendieExplosion { set { ConfigureCheckBox(incendieExplosionCheckBox, value); } }
        public Visible<bool> ContrainteThermique { set { ConfigureCheckBox(contrainteThermiqueCheckBox, value); } }
        public Visible<bool> Radiations { set { ConfigureCheckBox(radiationsCheckBox, value); } }
        public Visible<bool> Silice { set { ConfigureCheckBox(siliceCheckBox, value); } }
        public Visible<bool> Vanadium { set { ConfigureCheckBox(vanadiumCheckBox, value); } }
        public Visible<bool> AsphyxieIntoxication { set { ConfigureCheckBox(asphyxieIntoxicationCheckBox, value); } }

        public string AutresRisquesData { set { autresRisquesData.Text = value; } }
        public Visible<bool> AutresRisques { set { ConfigureCheckBox(autresRisquesCheckBox, value); } }

        public string ElectriciteVoltData { set { electriciteVoltData.Text = value; } }
        public Visible<bool> ElectriciteVolt { set { ConfigureCheckBox(electriciteVoltCheckBox, value); } }

        public Visible<bool> TravailEnHauteur6EtPlus { set { ConfigureCheckBox(travailEnHauteur6EtPlusCheckBox, value); } }
        public Visible<bool> VapeurCondensat { set { ConfigureCheckBox(vapeurCondensatCheckBox, value); } } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        public Visible<bool> FeSValue { set { ConfigureCheckBox(FeSoltCheckBox, value); } }
        

        public Visible<bool> Electrisation { set { ConfigureCheckBox(electrisationCheckBox, value); } }
        public Visible<bool> LunettesMonocoques { set { ConfigureCheckBox(lunettes_MonocoquesCheckBox, value); } }
        public Visible<bool> Visiere { set { ConfigureCheckBox(visiereCheckBox, value); } }
        public Visible<bool> ProtectionAuditive { set { ConfigureCheckBox(protection_AuditiveCheckBox, value); } }
        public Visible<bool> CagouleIgnifuge { set { ConfigureCheckBox(cagouleIgnifugeCheckBox, value); } }
        public Visible<bool> Harnais2LiensDeRetenue { set { ConfigureCheckBox(harnais2LiensDeRetenueCheckBox, value); } }
        

        public string GantsData { set { gantsData.Text = value; } }
        public Visible<bool> Gants { set { ConfigureCheckBox(gantsCheckBox, value); } }

        public string MasqueACartouchesData { set { masqueACartouchesData.Text = value; } }
        public Visible<bool> MasqueACartouches { set { ConfigureCheckBox(masqueACartouchesCheckBox, value); } }

        public string EpiAntiArcCatData { set { ePI_AntiArcCATData.Text = value; } }
        public Visible<bool> EpiAntiArcCat { set { ConfigureCheckBox(ePI_AntiArcCATCheckBox, value); } }

        public string HabitCompletAntiEclaboussureData { set { habitProtecteurData.Text = value; } }
        public Visible<bool> HabitCompletAntiEclaboussure { set { ConfigureCheckBox(habitProtecteurCheckBox, value); } }

        public Visible<bool> EpiAntiChoc { set { ConfigureCheckBox(ePIAntiChocCheckBox, value); } }
        
        public Visible<bool> EcranDeflecteur { set { ConfigureCheckBox(ecranDeflecteurCheckBox, value); } }
        public Visible<bool> MaltDesEquipements { set { ConfigureCheckBox(mALTDesEquipementsCheckBox, value); } }
        public Visible<bool> Rallonges { set { ConfigureCheckBox(rallongesCheckBox, value); } }
        public Visible<bool> ApprobationPourEquipDeLevage { set { ConfigureCheckBox(approbationPourEquipDeLevageCheckBox, value); } }
        public Visible<bool> BarricadeRigide { set { ConfigureCheckBox(barricadeRigideCheckBox, value); } }

        public string AutresEData { set { autresEData.Text = value; } }
        public Visible<bool> AutresE { set { ConfigureCheckBox(autresECheckBox, value); } }

        public string AlarmeDcsData { set { alarmeDCSData.Text = value; } }
        public Visible<bool> AlarmeDcs { set { ConfigureCheckBox(alarmeDCSCheckBox, value); } }

        public Visible<bool> EchelleSecurisee { set { ConfigureCheckBox(echelleSecuriseeCheckBox, value); } }
        public Visible<bool> EchafaudageApprouve { set { ConfigureCheckBox(echafaudageApprouveCheckBox, value); } }
        public Visible<bool> OutilDeLaiton { set { ConfigureCheckBox(outilDeLaitonCheckBox, value); } }
        public Visible<bool> PerimetreSecurite { set { ConfigureCheckBox(perimetreSecuriteCheckBox, value); } }
        public string PerimetreSecuriteData { set { perimetreSecuriteCheckBoxData.Text = value; } }
        public Visible<bool> Radio { set { ConfigureCheckBox(radioCheckBox, value); } }
        public Visible<bool> Signaleur { set { ConfigureCheckBox(signaleurCheckBox, value); } }

        public Visible<bool> OutillageElectriqueCheckBox { set { ConfigureCheckBox(outillageElectriqueCheckBox, value); } }
        
        // signature section
        public string InstructionsSpeciales { set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; } }

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

        public string MudsAnswerTextBox { set { oltQuestionAnswerTextBox.Text = value; } }
        public string MudsQuestionlabel { set
        {
            oltQuestionLabel.Text = ClientSession.GetUserContext().SiteConfiguration.SetWorkPermitQuestionForMudsSite;
        } }

        

        public Visible<bool> SignatureOperateurSurLeTerrain { set { ConfigureCheckBox(signatureOperateurCheckBox, value); } }
        public Visible<bool> DetectionDesGazs { set { ConfigureCheckBox(detectionDesGazsCheckBox, value); } }
        public Visible<bool> SignatureContremaitre { set { ConfigureCheckBox(signatureContremaitreCheckBox, value); } }
        public Visible<bool> SignatureAutorise { set { ConfigureCheckBox(signatureAutoriseCheckBox, value); } }
        public Visible<bool> NettoyageTransfertHorsSite { set { ConfigureCheckBox(nettoyageTransfertHorsSiteCheckBox, value); } }

        public List<DocumentLink> DocumentLinks { set { documentLinksControl.DataSource = value; } }

        
        public string ProcedureData { set  { procedureEntretienData.Text = value; } }
        public Visible<bool> Procedure { set { ConfigureCheckBox(procedureEntretienCheckBox, value); } }

        public string HabitProtecteurData { set { habitProtecteurData.Text = value; } }
        public Visible<bool> HabitProtecteur { set { ConfigureCheckBox(habitProtecteurCheckBox, value); } }

        public string EtiquetteData { set { etiquetteData.Text = value; } }
        public Visible<bool> Etiquette { set { ConfigureCheckBox(etiquetteCheckBox, value); } }

        public Visible<bool> Masque { set { ConfigureCheckBox(masqueSoudeurCheckBox, value); } }

        public string AutresInstructionData { set { autresTData.Text = value; } }
        public Visible<bool> AutresInstruction { set { ConfigureCheckBox(autresTravauxCheckBox, value); } }  //TODO  change the checkbox id to autresInstructionCheckBox

        public Visible<bool> MhAutres { set { ConfigureCheckBox(autresColdCheckBox, value); } }

        public string AutresTravauxData { set { autresTData.Text = value; } }
        public Visible<bool> AutresTravaux { set { ConfigureCheckBox(autresTravauxCheckBox, value); } }

        //public string AutresColdData { set { autresColdData.Text = value; } }
        //public Visible<bool> AutresCold { set { ConfigureCheckBox(autresColdCheckBox, value); } }


        public Visible<bool> Soudage { set { ConfigureCheckBox(soudageCheckBox, value); } }
        public Visible<bool> Traitement { set { ConfigureCheckBox(traitementThermiqueCheckBox, value); } }
        public Visible<bool> Cuissons { set { ConfigureCheckBox(cuissonsCheckBox, value); } }
        public Visible<bool> Perçage { set { ConfigureCheckBox(percageCheckBox, value); } }
        public Visible<bool> Chaufferette { set { ConfigureCheckBox(chaufferetteCheckBox, value); } }
        public Visible<bool> Meulage { set { ConfigureCheckBox(meulageCheckBox, value); } }
        public Visible<bool> Nettoyage { set { ConfigureCheckBox(nettoyageCheckBox, value); } }
        public Visible<bool> TravauxDansZone { set { ConfigureCheckBox(travauxDansCheckBox, value); } }
        public Visible<bool> Combustibles { set { ConfigureCheckBox(combustiblesCheckBox, value); } }
        public Visible<bool> Ecran { set { ConfigureCheckBox(ecranCheckBox, value); } }
        public Visible<bool> Boyau { set { ConfigureCheckBox(boyauCheckBox, value); } }
        public Visible<bool> BoyauDe { set { ConfigureCheckBox(boyauDeCheckBox, value); } }
        public Visible<bool> Couverture { set { ConfigureCheckBox(couvertureCheckBox, value); } }
        public Visible<bool> Extincteur { set { ConfigureCheckBox(extincteurCheckBox, value); } }
        public Visible<bool> Bouche { set { ConfigureCheckBox(boucheCheckBox, value); } }
        public Visible<bool> RadioS { set { ConfigureCheckBox(radioSCheckBox, value); } }
        public Visible<bool> Surveillant { set { ConfigureCheckBox(surveillantCheckbox, value); } }
        public Visible<bool> UtilisationMoteur { set { ConfigureCheckBox(utilisationMoteurCheckBox, value); } }
        public Visible<bool> NettoyageAu { set { ConfigureCheckBox(nettoyageAUCheckBox, value); } }
        public Visible<bool> UtilisationElectronics { set { ConfigureCheckBox(utilisationOutilCheckBox, value); } }
        public Visible<bool> Radiographie { set { ConfigureCheckBox(radiographieCheckBox, value); } }
        public Visible<bool> UtilisationOutlis { set { ConfigureCheckBox(utilisationPneumCheckBox, value); } }
        public Visible<bool> UtilisationEquipments { set { ConfigureCheckBox(utilisationEquipCheckBox, value); } }
        public Visible<bool> Demolition { set { ConfigureCheckBox(demolitionCheckBox, value); } }
       


        public void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            string company, string company_1, string company_2, string supervisor, string excavationNumber,
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
        
        public IWorkPermitMudsDetails BindingTarget
        {
            get { return this; }
        }

        private void flowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }

        // DMND0010609-OLT - Edmonton Work permit Scan
      
        private void Scanbutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString((sender as System.Windows.Forms.ToolStripButton).Tag) == "Scan")
            {
                string permitNumber = permitNumberData.Text;
                ScanWorkPermit Scanform = new ScanWorkPermit(permitNumber);
                Scanform.ShowDialog();
            }
            else
            {
                ScanWorkPermit Scanform = new ScanWorkPermit();
                Scanform.ShowDialog();
            }
        }

        private void viewAttachementbutton_Click(object sender, EventArgs e)
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
            set { ScanButton.Enabled = value;  }
        }

        public bool GasTestButtonEnabled
        {
            set { GasTestButton.Enabled = value; }
        }

        public void MakeSeachWindowRequiredButtonsvisibleonly()
        {
            viewAssociatedLogsButton.Visible = false;
            rangeButton.Visible = false;
            exportallButton.Visible = false;
            documentLinks.Visible = false;
            saveGridLayoutButton.Visible = false;

        }

        private void Gastestbutton_Click(object sender, EventArgs e)
        {
            if (GastestButtonEvent != null)
            {
                GastestButtonEvent(this, e);
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

       

        public bool DeleteVisible 
        { 
           set { deleteButton.Visible = value; } 
        }
        public bool editVisible
        {
            set { editButton.Visible = value; }
        }
        public bool editTemplateVisible
        {
            set { editTemplateButton.Visible = value; }
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
        public bool GasTestButtonVisible
        {
            set { GasTestButton.Visible = value; }
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
