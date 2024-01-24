using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormOilsandsTrainingForm : BaseForm, IFormOilsandsTrainingView
    {
        private const string TrainingBlockColumnKey = "TrainingBlock";
        private const string BlockCompletedColumnKey = "BlockCompleted";
        private const string HoursColumnKey = "Hours";

        private const string TrainingBlockValueListKey = "TrainingBlockValueList";
        
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action FormLoad;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action SaveAndEmailButtonClicked;
        public event Action AddTrainingBlockClicked;
        public event Action RemoveTrainingBlockClicked;
        public event Action HistoryClicked;

        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        public FormOilsandsTrainingForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            addTrainingBlockButton.Click += HandleAddTrainingBlockClicked;
            removeTrainingBlockButton.Click += HandleRemoveTrainingBlockClicked;
            historyButton.Click += HandleHistoryButtonClicked;

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootsForSelectedFunctionalLocations;

            flocSelector = new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetAll(userContext.SiteConfiguration),
                                                              new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1, rootFlocsForActiveSelection),
                                                              true, rootFlocsForActiveSelection);

            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocatnButton.Click += HandleRemoveFunctionalLocationButtonClicked;

            trainingGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            trainingGrid.CreationFilter = new OptionSetCenteredCreationFilter();

            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;
        }

        public IFunctionalLocationValidator FlocValidator
        {
            set { flocSelector.FlocValidator = value; }
        }

        private void HandleHistoryButtonClicked(object sender, EventArgs e)
        {
            if (HistoryClicked != null)
            {
                HistoryClicked();
            }
        }

        private void HandleRemoveTrainingBlockClicked(object sender, EventArgs e)
        {
            if (RemoveTrainingBlockClicked != null)
            {
                RemoveTrainingBlockClicked();
            }
        }

        private void HandleAddTrainingBlockClicked(object sender, EventArgs e)
        {
            if (AddTrainingBlockClicked != null)
            {
                AddTrainingBlockClicked();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            trainingGrid.DataSource = new List<OilsandsTrainingItemDisplayAdapter>();

            SetupRadioButtonColumn();
            SetupGrandTotal();

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void SetupGrandTotal()
        {
            SummarySettings summarySettings = trainingGrid.DisplayLayout.Bands[0].Summaries.Add("SummaryKey", SummaryType.Sum, trainingGrid.DisplayLayout.Bands[0].Columns[HoursColumnKey]);
            summarySettings.DisplayFormat = StringResources.GrandTotal;

            trainingGrid.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void SetupRadioButtonColumn()
        {
            UltraOptionSet optionSet = new UltraOptionSet();

            ValueListItem yesValueListItem = new ValueListItem();
            ValueListItem noValueListItem = new ValueListItem();

            yesValueListItem.DataValue = true;
            noValueListItem.DataValue = false;

            yesValueListItem.DisplayText = StringResources.Yes;
            noValueListItem.DisplayText = StringResources.No;

            optionSet.Items.AddRange(new[] { yesValueListItem, noValueListItem });

            trainingGrid.DisplayLayout.Bands[0].Columns[BlockCompletedColumnKey].EditorComponent = optionSet;
        }

        public bool RemoveButtonEnabled
        {
            set { removeTrainingBlockButton.Enabled = value; }
        }

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }
        
        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            TrainingItems.ForEach(item => item.ClearErrors());
            MakeTrainingGridValidationIconsShowOrDisappear();
        }

        public void MakeTrainingGridValidationIconsShowOrDisappear()
        {
            trainingGrid.Rows.Refresh(RefreshRow.FireInitializeRow);
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public List<FormApproval> Approvals
        {
            set
            {
                approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval));
            }
            get
            {
                List<FormApprovalGridDisplayAdapter> list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public List<OilsandsTrainingItemDisplayAdapter> TrainingItems
        {
            get
            {
                return (List<OilsandsTrainingItemDisplayAdapter>)trainingGrid.DataSource;
            }

            set
            {
                trainingGrid.DataSource = value;
                trainingGrid.ResetBindings();
            }
        }

        public bool ApprovalsEnabled
        {
            set
            {
                approvalsGridControl.Enabled = value;
            }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public User CreatedByUser
        {
            set { createdByUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime CreatedDateTime
        {
            set { createdDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public List<ShiftPattern> ShiftPatterns
        {
            set
            {
                shiftComboBox.DataSource = value;
            }
        }

        public ShiftPattern Shift
        {
            get { return (ShiftPattern) shiftComboBox.SelectedItem; }
            set { shiftComboBox.SelectedItem = value; }
        }

        public Date TrainingDate
        {
            get { return trainingDatePicker.Value; }
            set { trainingDatePicker.Value = value; }
        }

        public string GeneralComments
        {
            get { return generalCommentsTextBox.Text.TrimOrNull(); }
            set { generalCommentsTextBox.Text = value; }
        }

        public void SetErrorForTrainingDateCannotBeInTheFuture()
        {
            errorProvider.SetError(trainingDatePicker, StringResources.FormOilsandsTrainingValidation_TrainingDateCannotBeInTheFuture);
        }

        public void SetErrorForDuplicateTrainingDateAndShift(string message)
        {
            errorProvider.SetError(shiftComboBox, message);
        }

        public void SetErrorForNoGeneralComments()
        {
            errorProvider.SetError(generalCommentsTextBox, StringResources.FormOilsandsTraining_GeneralCommentsRequired);
        }

        public List<TrainingBlock> TrainingBlocks
        {
            set
            {
                ValueList valueList = (ValueList)trainingGrid.DisplayLayout.Bands[0].Columns[TrainingBlockColumnKey].ValueList;
                if (valueList == null)
                {
                    valueList = trainingGrid.DisplayLayout.ValueLists.Add(TrainingBlockValueListKey);
                }

                valueList.ValueListItems.Clear();
                foreach (TrainingBlock trainingBlock in value)
                {
                    valueList.ValueListItems.Add(trainingBlock, trainingBlock.Name);
                }

                trainingGrid.DisplayLayout.Bands[0].Columns[TrainingBlockColumnKey].ValueList = valueList;
            }
        }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this, initialUserFLOCSelections);

            IList<FunctionalLocation> selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult, new List<FunctionalLocation>(selectedFunctionalLocations));
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowWarnings(List<string> warnings)
        {
            string messageOne = StringResources.WarningsListBox_MessageOne;
            string messageTwo = StringResources.WarningsListBox_MessageTwo;

            return OltListMessageBox.Show(this, messageOne, messageTwo, warnings, StringResources.WarningsListBox_Title,
                                          MessageBoxIcon.Warning, false);
        }

        public void AddTrainingItem(OilsandsTrainingItemDisplayAdapter trainingItem)
        {
            List<OilsandsTrainingItemDisplayAdapter> items = new List<OilsandsTrainingItemDisplayAdapter>((List<OilsandsTrainingItemDisplayAdapter>) trainingGrid.DataSource);
            items.Add(trainingItem);
            trainingGrid.DataSource = items;
            trainingGrid.ResetBindings();
            trainingGrid.ActiveItemByReference = trainingItem;
        }

        public void RemoveSelectedTrainingItem()
        {
            List<OilsandsTrainingItemDisplayAdapter> items = new List<OilsandsTrainingItemDisplayAdapter>((List<OilsandsTrainingItemDisplayAdapter>)trainingGrid.DataSource);

            OilsandsTrainingItemDisplayAdapter activeItem = (OilsandsTrainingItemDisplayAdapter) trainingGrid.ActiveItem;

            if (activeItem != null)
            {
                items.Remove(activeItem);
                trainingGrid.DataSource = items;
                trainingGrid.ResetBindings();
            }
        }

        public void ShowUnableToRemoveFunctionalLocationMessage(List<string> trainingBlockNames)
        {
            OltListMessageBox.Show(this, StringResources.FormOilsandsTraining_UnableToRemoveFlocMessage, null, trainingBlockNames, StringResources.FormOilsandsTraining_UnableToRemoveFlocHeader, MessageBoxIcon.Error, true);
        }

        private void HandleAddFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (AddFunctionalLocationButtonClicked != null)
            {
                AddFunctionalLocationButtonClicked();
            }
        }

        private void HandleRemoveFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (RemoveFunctionalLocationButtonClicked != null)
            {
                RemoveFunctionalLocationButtonClicked();
            }
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
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

        // This code centers the two radio buttons horizontally within the cell. It was taken from http://www.infragistics.com/community/forums/p/72723/408520.aspx#408520
        private class OptionSetCenteredCreationFilter : IUIElementCreationFilter
        {
            private const int numberOfPixelsToPushRadioButtonDownBy = 2;

            void IUIElementCreationFilter.AfterCreateChildElements(UIElement parent)
            {
                if (parent is OptionSetEmbeddableUIElement)
                {
                    int totalItemWidth = 0;

                    List<OptionSetOptionButtonUIElement> optionSetOptionButtonUIElements = new List<OptionSetOptionButtonUIElement>();
                    foreach (UIElement childElement in parent.ChildElements)
                    {
                        OptionSetOptionButtonUIElement optionSetOptionButtonUIElement = childElement as OptionSetOptionButtonUIElement;
                        if (null == optionSetOptionButtonUIElement)
                        {
                            Debug.Fail("A child element of the OptionSetEmbeddableUIElement is not an OptionSetOptionButtonUIElement; unexpected.");
                            continue;
                        }

                        totalItemWidth += optionSetOptionButtonUIElement.Rect.Width;
                        optionSetOptionButtonUIElements.Add(optionSetOptionButtonUIElement);
                    }

                    int x = parent.Rect.X;
                    x += (parent.Rect.Width - totalItemWidth) / 2;

                    foreach (OptionSetOptionButtonUIElement optionSetOptionButtonUIElement in optionSetOptionButtonUIElements)
                    {
                        optionSetOptionButtonUIElement.Rect = new Rectangle(
                            x,
                            optionSetOptionButtonUIElement.Rect.Y + numberOfPixelsToPushRadioButtonDownBy,
                            optionSetOptionButtonUIElement.Rect.Width,
                            optionSetOptionButtonUIElement.Rect.Height
                            );

                        x += optionSetOptionButtonUIElement.Rect.Width;
                    }
                }
            }

            bool IUIElementCreationFilter.BeforeCreateChildElements(UIElement parent)
            {
                // do nothing. 
                return false;
            }
        }
    }
}
