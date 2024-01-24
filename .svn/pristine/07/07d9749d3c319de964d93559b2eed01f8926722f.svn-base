using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public partial class OldPriorityPage : UserControl, IOldPriorityPage
    {
        private readonly OldPriorityPagePresenter presenter;
        private readonly DomainSummaryGrid <ActionItemDTO> actionItemGridView;
        private readonly DomainSummaryGrid <WorkPermitDTO> workPermitGridView;
        private readonly DomainSummaryGrid <TargetAlertDTO> targetAlertGridView;
        private readonly DomainSummaryGrid <DeviationAlertDTO> deviationAlertGridView;
        private readonly DomainSummaryGrid <LabAlertDTO> labAlertGridView;
        private readonly DomainSummaryGrid<ShiftHandoverQuestionnaireDTO> shiftHandoverQuestionnaireGridView;

        private delegate void RemoveActionItemInvoker(ActionItemDTO item);
        private delegate void RemoveTargetAlertInvoker(TargetAlertDTO item);
        private delegate void RemoveWorkPermitInvoker(WorkPermitDTO item);

        private readonly PriorityPageSplitterManager splitterManager;

        public OldPriorityPage()
        {
            string labelFormatString = "{0} : ";

            InitializeComponent();
            presenter = new OldPriorityPagePresenter(this);
            splitterManager = new PriorityPageSplitterManager(this);
            OltLabelTitle actionItemLabel = new OltLabelTitle();
            OltLabelTitle targetLabel = new OltLabelTitle();
            OltLabelTitle permitLabel = new OltLabelTitle();
            OltLabelTitle deviationAlertLabel = new OltLabelTitle();
            OltLabelTitle labAlertLabel = new OltLabelTitle();
            OltLabelTitle shiftHandoverQuestionnaireLabel = new OltLabelTitle();
            actionItemLabel.Dock = DockStyle.Top;
            actionItemLabel.Text = String.Format(labelFormatString, StringResources.PriorityPage_ActionItemsLabel);
            actionItemLabel.TextAlign = ContentAlignment.MiddleLeft;
            targetLabel.Dock = DockStyle.Top;
            targetLabel.Text = String.Format(labelFormatString, StringResources.PriorityPage_TargetAlertsLabel);
            targetLabel.TextAlign = ContentAlignment.MiddleLeft;
            permitLabel.Dock = DockStyle.Top;
            permitLabel.Text = String.Format(labelFormatString, StringResources.PriorityPage_SafeWorkPermitsLabel);
            permitLabel.TextAlign = ContentAlignment.MiddleLeft;
            deviationAlertLabel.Dock = DockStyle.Top;
            deviationAlertLabel.Text = String.Format(labelFormatString, StringResources.PriorityPage_DeviationAlertsLabel);
            deviationAlertLabel.TextAlign = ContentAlignment.MiddleLeft;
            labAlertLabel.Dock = DockStyle.Top;
            labAlertLabel.Text = String.Format(labelFormatString, StringResources.PriorityPage_LabAlertsLabel);
            labAlertLabel.TextAlign = ContentAlignment.MiddleLeft;
            shiftHandoverQuestionnaireLabel.Dock = DockStyle.Top;
            shiftHandoverQuestionnaireLabel.Text = String.Format(labelFormatString, StringResources.PriorityPage_ShiftHandoverLabel);
            shiftHandoverQuestionnaireLabel.TextAlign = ContentAlignment.MiddleLeft;
            
            actionItemGridView = new DomainSummaryGrid<ActionItemDTO>(new ActionItemGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT), string.Empty)
                                     {Dock = DockStyle.Fill};
            actionItemGridView.SetPriorityDisplaySettings();
            actionItemGridView.ContextMenuStrip = actionItemContextMenuStrip;

            targetAlertGridView = new DomainSummaryGrid<TargetAlertDTO>(new TargetAlertGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty)
                                      {Dock = DockStyle.Fill};
            targetAlertGridView.SetPriorityDisplaySettings();
            targetAlertGridView.ContextMenuStrip = targetContextMenuStrip;

            workPermitGridView = new DomainSummaryGrid<WorkPermitDTO>(new WorkPermitPriorityGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty)
                                     {Dock = DockStyle.Fill};
            workPermitGridView.SetPriorityDisplaySettings();
            workPermitGridView.ContextMenuStrip = permitContextMenuStrip;

            deviationAlertGridView = new DomainSummaryGrid<DeviationAlertDTO>(new DeviationAlertGridRenderer(false), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty) 
                                         { Dock = DockStyle.Fill };
            deviationAlertGridView.SetPriorityDisplaySettings();
            deviationAlertGridView.ContextMenuStrip = deviationAlertContextMenuStrip;

            labAlertGridView = new DomainSummaryGrid<LabAlertDTO>(new LabAlertGridRenderer(false), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT), string.Empty) { Dock = DockStyle.Fill };
            labAlertGridView.SetPriorityDisplaySettings();
            labAlertGridView.ContextMenuStrip = labAlertContextMenuStrip;

            shiftHandoverQuestionnaireGridView = new DomainSummaryGrid<ShiftHandoverQuestionnaireDTO>(new ShiftHandoverQuestionnaireGridRenderer(), OltGridAppearance.ExtendLastGridColumn(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT), string.Empty) { Dock = DockStyle.Fill };
            shiftHandoverQuestionnaireGridView.SetPriorityDisplaySettings();

            actionItemPanel.Controls.Add(actionItemGridView);
            actionItemPanel.Controls.Add(actionItemLabel);
            workPermitPanel.Controls.Add(workPermitGridView);
            workPermitPanel.Controls.Add(permitLabel);
            targetAlertPanel.Controls.Add(targetAlertGridView);
            targetAlertPanel.Controls.Add(targetLabel);
            deviationAlertPanel.Controls.Add(deviationAlertGridView);
            deviationAlertPanel.Controls.Add(deviationAlertLabel);
            labAlertPanel.Controls.Add(labAlertGridView);
            labAlertPanel.Controls.Add(labAlertLabel);
            shiftHandoverQuestionnairePanel.Controls.Add(shiftHandoverQuestionnaireGridView);            
            shiftHandoverQuestionnairePanel.Controls.Add(shiftHandoverQuestionnaireLabel);

            actionItemContextMenuStrip.Respond += presenter.ActionItemContextMenuStrip_Respond;
            actionItemGridView.SelectedItemChanged += presenter.ActionItemGridView_SelectedItemChanged;
            actionItemGridView.DoubleClickSelected += presenter.ActionItemListView_DoubleClickSelected;

            targetContextMenuStrip.Acknowledge += presenter.TargetContextMenuStrip_Acknowledge;
            targetContextMenuStrip.Respond += presenter.TargetContextMenuStrip_Respond;
            targetAlertGridView.SelectedItemChanged += presenter.TargetAlertGridView_SelectedItemChanged;
            targetAlertGridView.DoubleClickSelected += presenter.TargetListView_DoubleClickSelected;

            permitContextMenuStrip.Approve += presenter.PermitContextMenuStrip_Approve;
            permitContextMenuStrip.Reject += presenter.PermitContextMenuStrip_Reject;
            permitContextMenuStrip.CloseWorkPermit += presenter.PermitContextMenuStrip_CloseWorkPermit;
            permitContextMenuStrip.Comment += presenter.PermitContextMenuStrip_Comment;
            permitContextMenuStrip.Delete += presenter.PermitContextMenuStrip_Delete;
            permitContextMenuStrip.Edit += presenter.PermitContextMenuStrip_Edit;
            permitContextMenuStrip.Copy += presenter.PermitContextMenuStrip_Copy;
            permitContextMenuStrip.Clone += presenter.PermitContextMenuStrip_Clone;
            permitContextMenuStrip.Print += presenter.PermitContextMenuStrip_Print;
            permitContextMenuStrip.PrintPreview += presenter.PermitContextMenuStrip_PrintPreview;
            workPermitGridView.SelectedItemChanged += presenter.WorkPermitGridView_SelectedItemChanged;
            workPermitGridView.DoubleClickSelected += presenter.WorkPermitListView_DoubleClickSelected;

            deviationAlertContextMenuStrip.Respond += presenter.DeviationAlertContextMenuStrip_Respond;
            deviationAlertGridView.SelectedItemChanged += presenter.DeviationAlertGridView_SelectedItemChanged;
            deviationAlertGridView.DoubleClickSelected += presenter.DeviationAlertGridView_DoubleClickSelected;

            labAlertContextMenuStrip.Respond += presenter.LabAlertContextMenuStrip_Respond;
            labAlertGridView.SelectedItemChanged += presenter.LabAlertGridView_SelectedItemChanged;
            labAlertGridView.DoubleClickSelected += presenter.LabAlertGridView_DoubleClickSelected;

            shiftHandoverQuestionnaireGridView.DoubleClickSelected += presenter.ShiftHandoverQuestionnaireGridView_DoubleClickSelected;

            Load += presenter.PriorityPage_Load;
        }
   
        public IMainForm MainParentForm
        {
            get { return ParentForm as MainForm; }
        }
              
        public IActionItemActions ActionItemActions
        {
            get { return actionItemContextMenuStrip; }
        }

        public List <ActionItemDTO> ActionItemList
        {
            set { actionItemGridView.Items = value; }
        }

        public List<ActionItemDTO> SelectedActionItemDTOs
        {
            get { return actionItemGridView.SelectedItems; }
        }

        public ITargetAlertActions TargetAlertActions
        {
            get { return targetContextMenuStrip; }
        }
        
        public List <TargetAlertDTO> TargetList
        {
            set { targetAlertGridView.Items = value; }
        }

        public List <TargetAlertDTO> SelectedTargetAlertDTOs
        {
            get { return targetAlertGridView.SelectedItems; }
        }

        public IDeviationAlertActions DeviationAlertActions
        {
            get { return deviationAlertContextMenuStrip; }
        }

        public List<DeviationAlertDTO> DeviationAlertList
        {
            set { deviationAlertGridView.Items = value; }
        }

        public List<DeviationAlertDTO> SelectedDeviationAlertDTOs
        {
            get { return deviationAlertGridView.SelectedItems; }
        }

        public ILabAlertActions LabAlertActions
        {
            get { return labAlertContextMenuStrip; }
        }

        public List<LabAlertDTO> LabAlertList
        {
            set { labAlertGridView.Items = value; }
        }

        public List<LabAlertDTO> SelectedLabAlertDTOs
        {
            get { return labAlertGridView.SelectedItems; }
        }

        public IWorkPermitActions WorkPermitActions
        {
            get { return permitContextMenuStrip; }
        }

        public List <WorkPermitDTO> WorkPermitList
        {
            set { workPermitGridView.Items = value; }
        }

        public List<WorkPermitDTO> SelectedWorkPermitDTOs
        {
            get { return workPermitGridView.SelectedItems; }
        }

        public List<ShiftHandoverQuestionnaireDTO> ShiftHandoverQuestionnaireList
        {
            set { shiftHandoverQuestionnaireGridView.Items = value; }
        }

        public void DisableActionItemContextMenu()
        {
            actionItemContextMenuStrip.Enabled = false;
        }
        
        public void DisableActionItemListView()
        {
            splitterManager.ActionItemsEnabled = false;
        }

        public void DisableTargetContextMenu()
        {
            targetContextMenuStrip.Enabled = false;
        }

        public void DisableTargetListView()
        {
            splitterManager.TargetAlertsEnabled = false;
        }

        public void DisableDeviationAlertContextMenu()
        {
            deviationAlertContextMenuStrip.Enabled = false;
        }

        public void DisableDeviationAlertListView()
        {
            splitterManager.DeviationAlertsEnabled = false;
        }

        public void DisableLabAlertContextMenu()
        {
            labAlertContextMenuStrip.Enabled = false;
        }

        public void DisableLabAlertListView()
        {
            splitterManager.LabAlertsEnabled = false;
        }

        public void DisablePermitContextMenu()
        {
            permitContextMenuStrip.Enabled = false;
        }

        public void DisablePermitListView()
        {
            splitterManager.WorkPermitsEnabled = false;
        }

        public void DisableShiftHandoverQuestionnaireListView()
        {
            splitterManager.ShiftHandoverQuestionnairesEnabled = false;
        }

        public void AddActionItem(ActionItemDTO dto)
        { 
            actionItemGridView.AddItem(dto);  
        }

        public void RemoveActionItem(ActionItemDTO dto)
        {
            ActionItemDTO oldVersion = actionItemGridView.Items.FindById(dto);
            
            int updateIndex = actionItemGridView.Items.IndexOf(oldVersion);
            if (updateIndex != -1)
            {
                Invoke(new RemoveActionItemInvoker(actionItemGridView.RemoveItem), oldVersion);
            }
        }
        
        public void UpdateActionItem(ActionItemDTO dto)
        {
            ActionItemDTO oldVersion = actionItemGridView.Items.FindById(dto);
            int updateIndex = actionItemGridView.Items.IndexOf(oldVersion);
            if(updateIndex != -1)
            {
                actionItemGridView.UpdateItem(updateIndex, dto);
            }
            else
            {
                // This is for the case that someone is Updating an Action Item from not Current (Complete) back to Current.
                AddActionItem(dto);
            }
        }

        public void AddTargetAlert(TargetAlertDTO dto)
        {
            targetAlertGridView.AddItem(dto);
        }

        public void UpdateTargetAlert(TargetAlertDTO dto)
        {
            TargetAlertDTO oldVersion = targetAlertGridView.Items.FindById(dto);

            int updateIndex = targetAlertGridView.Items.IndexOf(oldVersion);
            if(updateIndex != -1)
            {
                targetAlertGridView.UpdateItem(updateIndex, dto);
            }
        }

        public void RemoveTargetAlert(TargetAlertDTO dto)
        {
            TargetAlertDTO oldVersion = targetAlertGridView.Items.FindById(dto);

            int updateIndex = targetAlertGridView.Items.IndexOf(oldVersion);
            if (updateIndex != -1)
            {
                Invoke(new RemoveTargetAlertInvoker(targetAlertGridView.RemoveItem), oldVersion);
            }
        }

        public void AddDeviationAlert(DeviationAlertDTO dto)
        {
            deviationAlertGridView.AddItem(dto);
        }

        public void UpdateDeviationAlert(DeviationAlertDTO dto)
        {
            DeviationAlertDTO oldVersion = deviationAlertGridView.Items.FindById(dto);

            int updateIndex = deviationAlertGridView.Items.IndexOf(oldVersion);
            if (updateIndex != -1)
            {
                deviationAlertGridView.UpdateItem(updateIndex, dto);
            }
        }

        public void AddLabAlert(LabAlertDTO dto)
        {
            labAlertGridView.AddItem(dto);
        }

        public void UpdateLabAlert(LabAlertDTO dto)
        {
            LabAlertDTO oldVersion = labAlertGridView.Items.FindById(dto);
            if (oldVersion != null)
            {
                int updateIndex = labAlertGridView.Items.IndexOf(oldVersion);
                if (updateIndex != -1)
                {
                    labAlertGridView.UpdateItem(updateIndex, dto);                        
                }
            }
            else
            {
                AddLabAlert(dto);
            }
        }

        public void RemoveLabAlert(LabAlertDTO dto)
        {
            LabAlertDTO oldVersion = labAlertGridView.Items.FindById(dto);
            if (oldVersion != null)
            {
                int updateIndex = labAlertGridView.Items.IndexOf(oldVersion);
                if (updateIndex != -1)
                {
                    labAlertGridView.RemoveItem(oldVersion);
                }
            }
        }

        public void AddShiftHandoverQuestionnaire(ShiftHandoverQuestionnaireDTO dto)
        {
            shiftHandoverQuestionnaireGridView.AddItem(dto);
        }

        public void RemoveShiftHandoverQuestionnaire(ShiftHandoverQuestionnaireDTO dto)
        {
            ShiftHandoverQuestionnaireDTO oldVersion = shiftHandoverQuestionnaireGridView.Items.FindById(dto);

            int updateIndex = shiftHandoverQuestionnaireGridView.Items.IndexOf(oldVersion);
            if (updateIndex != -1)
            {
                shiftHandoverQuestionnaireGridView.RemoveItem(oldVersion);
            }
        }

        public void UpdateShiftHandoverQuestionnaire(ShiftHandoverQuestionnaireDTO dto)
        {
            ShiftHandoverQuestionnaireDTO oldVersion = shiftHandoverQuestionnaireGridView.Items.FindById(dto);

            int updateIndex = shiftHandoverQuestionnaireGridView.Items.IndexOf(oldVersion);
            if (updateIndex != -1)
            {
                shiftHandoverQuestionnaireGridView.UpdateItem(updateIndex, dto);
            }
        }

        public void AddWorkPermit(WorkPermitDTO dto)
        {
            workPermitGridView.AddItem(dto);
        }

        public void RemoveWorkPermit(WorkPermitDTO dto)
        {
            WorkPermitDTO oldVersion = workPermitGridView.Items.FindById(dto);
            int updateIndex = workPermitGridView.Items.IndexOf(oldVersion);
            if (updateIndex != -1)
            {
                Invoke(new RemoveWorkPermitInvoker(workPermitGridView.RemoveItem), oldVersion);
            }
            
        }

        public void UpdateWorkPermit(WorkPermitDTO dto)
        {
            WorkPermitDTO oldVersion = workPermitGridView.Items.FindById(dto);
            int updateIndex = workPermitGridView.Items.IndexOf(oldVersion);
            if(updateIndex != -1)
            {
                workPermitGridView.UpdateItem(updateIndex, dto);
            }
        }

        public bool ContainsWorkPermit(WorkPermit permit)
        {
            return workPermitGridView.ContainsItem(permit.Id);
        }

        public void SetPanelVisibility()
        {
            splitterManager.ConfigureSplitters();
        }

        private class PriorityPageSplitterManager
        {
            private readonly OldPriorityPage priorityPage;

            private readonly List<Section> enabledItems;
            private readonly List<SplitContainer> splitContainers;

            private enum Section
            {
                ActionItem,
                TargetAlert,
                WorkPermit,
                DeviationAlert,
                LabAlert,
                ShiftHandover
            };

            public PriorityPageSplitterManager(OldPriorityPage priorityPage)
            {
                this.priorityPage = priorityPage;
                splitContainers = new List<SplitContainer>
                    {
                        priorityPage.mainSplitContainer,
                        priorityPage.topSplitContainer,
                        priorityPage.firstInnerSplitContainer, 
                        priorityPage.secondInnerSplitContainer,
                        priorityPage.bottomSplitContainer
                    };

                // Everything enabled by default;
                enabledItems = new List<Section>
                    {
                        Section.ActionItem, 
                        Section.TargetAlert,
                        Section.WorkPermit, 
                        Section.DeviationAlert, 
                        Section.LabAlert, 
                        Section.ShiftHandover
                    };
            }

            public bool TargetAlertsEnabled
            {
                set { SetEnabled(value, Section.TargetAlert); }
            }

            public bool DeviationAlertsEnabled
            {
                set { SetEnabled(value, Section.DeviationAlert); }
            }

            public bool LabAlertsEnabled
            {
                set { SetEnabled(value, Section.LabAlert); }
            }

            public bool WorkPermitsEnabled
            {
                set { SetEnabled(value, Section.WorkPermit); }
            }

            public bool ActionItemsEnabled
            {
                set { SetEnabled(value, Section.ActionItem); }
            }

            public bool ShiftHandoverQuestionnairesEnabled
            {
                set { SetEnabled(value, Section.ShiftHandover); }
            }

            private void SetEnabled(bool enabled, Section section)
            {
                if (enabled && !enabledItems.Contains(section))
                {
                    enabledItems.Add(section);
                }
                else
                {
                    enabledItems.Remove(section);
                }
            }

            private int NumberOfEnabledItems()
            {
                return enabledItems.Count;
            }

            private bool IsEnabled(Section section)
            {
                return enabledItems.Contains(section);
            }

            public void ConfigureSplitters()
            {
                AssociateSplitContainerPanelsWithTheSectionsTheyContain();                

                foreach (SplitContainer splitContainer in splitContainers)
                {
                    List<Section> sectionsForPanel = (List<Section>) splitContainer.Panel1.Tag;
                    bool atLeastOneSectionEnabled = sectionsForPanel.Exists(IsEnabled);
                    splitContainer.Panel1Collapsed = !atLeastOneSectionEnabled;

                    sectionsForPanel = (List<Section>) splitContainer.Panel2.Tag;
                    atLeastOneSectionEnabled = sectionsForPanel.Exists(IsEnabled);
                    splitContainer.Panel2Collapsed = !atLeastOneSectionEnabled;
                }

                SetSizeOfSplitContainers();
            }

            // configuring each panel to know what sections it contains is ugly, but turns a dozen or two crazy
            // if statements into two sweet, sweet loops
            private void AssociateSplitContainerPanelsWithTheSectionsTheyContain()
            {
                priorityPage.mainSplitContainer.Panel1.Tag = new List<Section> { Section.ActionItem, Section.TargetAlert, Section.DeviationAlert, Section.WorkPermit };
                priorityPage.mainSplitContainer.Panel2.Tag = new List<Section> { Section.LabAlert, Section.ShiftHandover };
                priorityPage.topSplitContainer.Panel1.Tag = new List<Section> {Section.ActionItem, Section.TargetAlert};
                priorityPage.topSplitContainer.Panel2.Tag = new List<Section> {Section.DeviationAlert, Section.WorkPermit};
                priorityPage.firstInnerSplitContainer.Panel1.Tag = new List<Section> {Section.ActionItem};
                priorityPage.firstInnerSplitContainer.Panel2.Tag = new List<Section> {Section.TargetAlert};
                priorityPage.secondInnerSplitContainer.Panel1.Tag = new List<Section> {Section.DeviationAlert};
                priorityPage.secondInnerSplitContainer.Panel2.Tag = new List<Section> {Section.WorkPermit};
                priorityPage.bottomSplitContainer.Panel1.Tag = new List<Section> { Section.LabAlert };
                priorityPage.bottomSplitContainer.Panel2.Tag = new List<Section> { Section.ShiftHandover };
            }

            private int NumberOfEnabledItemsInList(List<Section> sections)
            {
                return sections.FindAll(IsEnabled).Count;
            }

            private void SetSizeOfSplitContainers()
            {
                int numberOfPanelsEnabled = NumberOfEnabledItems();
                if (numberOfPanelsEnabled == 0)
                {
                    return;
                }

                int newPageHeight = priorityPage.Size.Height;                
                int percentForEachPanel = 100 / numberOfPanelsEnabled;
                int pixelsForEachPanel = (percentForEachPanel * newPageHeight) / 100;

                foreach (SplitContainer splitContainer in splitContainers)
                {
                    SetSplitterDistance(splitContainer, pixelsForEachPanel);
                }
            }

            private void SetSplitterDistance(SplitContainer splitContainer, int pixelsForEachPanel)
            {
                List<Section> sectionsInTopPanel = (List<Section>)splitContainer.Panel1.Tag;
                List<Section> sectionsInBottomPanel = (List<Section>)splitContainer.Panel2.Tag;
                int numberOfTopItemsEnabled = NumberOfEnabledItemsInList(sectionsInTopPanel);
                int numberOfBottomItemsEnabled = NumberOfEnabledItemsInList(sectionsInBottomPanel);

                if (numberOfBottomItemsEnabled > 0 && numberOfTopItemsEnabled > 0)
                {
                    int spaceNeededForTopOfSplitContainer = numberOfTopItemsEnabled * pixelsForEachPanel;
                    splitContainer.SplitterDistance = spaceNeededForTopOfSplitContainer;
                }
            }
       }
    }
}