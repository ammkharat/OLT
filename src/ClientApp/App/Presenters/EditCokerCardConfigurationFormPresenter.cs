using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditCokerCardConfigurationFormPresenter
    {
        private readonly IEditCokerCardConfigurationFormView view;
        private readonly CokerCardConfiguration editObject;
        private readonly ICokerCardService cokerCardService;

        private readonly List<CokerCardConfigurationDrum> drums = new List<CokerCardConfigurationDrum>();
        private readonly List<CokerCardConfigurationCycleStep> steps = new List<CokerCardConfigurationCycleStep>();

        private bool configurationStructureChanged;

        readonly Dictionary<long, int> stepIdToDisplayOrderMap = new Dictionary<long, int>();

        public EditCokerCardConfigurationFormPresenter(
            IEditCokerCardConfigurationFormView view, CokerCardConfiguration editObject)
        {
            cokerCardService = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
            
            this.view = view;
            this.editObject = editObject;            
        }

        public void Load(object sender, EventArgs e)
        {
            if (editObject != null)
            {                                
                LoadViewFromEditObject();
            }
            else
            {
                LoadViewWithDefaults();
            }

            view.SelectFirstDrum();
            view.SelectFirstStep();
        }

        private static void LoadDisplayOrderMapFromCycleSteps(Dictionary<long, int> map, List<CokerCardConfigurationCycleStep> steps)
        {
            foreach (CokerCardConfigurationCycleStep currentStep in steps)
            {
                map.Add(currentStep.IdValue, currentStep.DisplayOrder);
            }
        }

        private void LoadViewFromEditObject()
        {
            view.ConfigurationName = editObject.Name;
            view.FunctionalLocation = editObject.FunctionalLocation;

            view.WorkAssignments = editObject.WorkAssignments;

            drums.Clear();
            drums.AddRange(editObject.Drums);
            SortAndSetDrumsOnGrid();
            LoadDisplayOrderMapFromCycleSteps(stepIdToDisplayOrderMap, editObject.Steps); // It's important that this method is called after resetting the display order above

            steps.Clear();
            steps.AddRange(editObject.Steps);
            SortAndSetStepsOnGrid();            
        }

        private void LoadViewWithDefaults()
        {
            drums.Clear();
            view.Drums = drums;

            steps.Clear();
            view.Steps = steps;

            view.WorkAssignments = new List<WorkAssignment>();
        }

        public void FunctionalLocationButton_Click(object sender, EventArgs e)
        {
            DialogResultAndOutput<FunctionalLocation> result = view.ShowFunctionalLocationSelector();
            if (result.Result == DialogResult.OK)
            {
                view.FunctionalLocation = result.Output;
            }
        }

        public void SelectWorkAssignments_Click(object sender, EventArgs e)
        {
            List<WorkAssignment> selectedAssignments = view.WorkAssignments;
            DialogResultAndOutput<IList<WorkAssignment>> result = view.ShowWorkAssignmentSelector(selectedAssignments);

            if (result.Result == DialogResult.OK)
            {
                IList<WorkAssignment> assignments = result.Output;
                view.WorkAssignments = assignments == null ? new List<WorkAssignment>() : new List<WorkAssignment>(assignments);
            }
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void SaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            if (ValidateViewSuccessful())
            {
                if (editObject != null)
                {
                    LoadEditObjectFromViewAndSave();
                }
                else
                {
                    CreateNewObjectFromViewAndSave();
                }

                view.Close();
            }
        }

        private void LoadEditObjectFromViewAndSave()
        {
            configurationStructureChanged = configurationStructureChanged || CycleStepDisplayOrderChanged();

            if (configurationStructureChanged)
            {
                CokerCardConfiguration newObjectFromView = CreateNewObjectFromView();
                cokerCardService.ReplaceCokerCardConfiguration(editObject, newObjectFromView);
            }
            else
            {
                editObject.Name = view.ConfigurationName;
                editObject.FunctionalLocation = view.FunctionalLocation;
                editObject.WorkAssignments.Clear();
                editObject.WorkAssignments.AddRange(view.WorkAssignments);

                editObject.Drums.Clear();
                editObject.Drums.AddRange(drums);

                editObject.Steps.Clear();
                editObject.Steps.AddRange(steps);

                cokerCardService.UpdateCokerCardConfiguration(editObject);     
            }           
        }

        private bool CycleStepDisplayOrderChanged()
        {
            Dictionary<long, int> latestMap = new Dictionary<long, int>();

            LoadDisplayOrderMapFromCycleSteps(latestMap, editObject.Steps);

            return !latestMap.ValueEquals(stepIdToDisplayOrderMap);
        }

        private CokerCardConfiguration CreateNewObjectFromView()
        {
            CokerCardConfiguration configuration = new CokerCardConfiguration(null, view.ConfigurationName, view.FunctionalLocation);

            configuration.WorkAssignments.Clear();
            configuration.WorkAssignments.AddRange(view.WorkAssignments);

            configuration.Drums.Clear();
            configuration.Drums.AddRange(drums);

            configuration.Steps.Clear();
            configuration.Steps.AddRange(steps);

            return configuration;
        }

        private void CreateNewObjectFromViewAndSave()
        {
            CokerCardConfiguration configuration = CreateNewObjectFromView();
            cokerCardService.InsertCokerCardConfiguration(configuration);
        }

        private bool ValidateViewSuccessful()
        {
            view.ClearErrors();
            bool hasErrors = false;

            if (view.ConfigurationName.IsNullOrEmptyOrWhitespace())
            {
                view.SetConfigurationNameMissingError();
                hasErrors = true;
            }

            if (view.FunctionalLocation == null)
            {
                view.SetFunctionalLocationMissingError();
                hasErrors = true;
            }

            if (view.Drums.Count == 0)
            {
                view.SetAtLeastOneDrumRequiredError();
                hasErrors = true;
            }

            if (view.Steps.Count == 0)
            {
                view.SetAtLeastOneStepRequiredError();
                hasErrors = true;
            }

            return !hasErrors;
        }

        public void AddDrumButton_Click(object sender, EventArgs e)
        {
            string newDrumName = view.ShowAddItemForm(StringResources.AddDrumTitle, null);

            if (newDrumName != null)
            {
                int displayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(drums) + 1;

                CokerCardConfigurationDrum newDrum = new CokerCardConfigurationDrum(null, newDrumName, displayOrder);
              
                drums.Add(newDrum);
                SortAndSetDrumsOnGrid();
                view.SelectedDrum = newDrum;

                configurationStructureChanged = true;
            }
        }

        public void AddStepButton_Click(object sender, EventArgs e)
        {
            string newStepName = view.ShowAddItemForm(StringResources.AddCycleStepTitle, null);

            if (newStepName != null)
            {                
                int displayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(steps) + 1;

                CokerCardConfigurationCycleStep newStep = new CokerCardConfigurationCycleStep(null, newStepName, displayOrder);
              
                steps.Add(newStep);
                SortAndSetStepsOnGrid();
                view.SelectedStep = newStep;

                configurationStructureChanged = true;
            }
        }

        public void EditDrumButton_Click(object sender, EventArgs e)
        {
            CokerCardConfigurationDrum selectedDrum = view.SelectedDrum;
            if (selectedDrum != null)
            {
                string newName = view.ShowAddItemForm(StringResources.EditDrumTitle, selectedDrum.Name);

                if (newName != null)
                {
                    selectedDrum.Name = newName;
                    SortAndSetDrumsOnGrid();
                    view.SelectedDrum = selectedDrum;
                }              
            }
        }

        public void EditStepButton_Click(object sender, EventArgs e)
        {
            CokerCardConfigurationCycleStep selectedStep = view.SelectedStep;
            if (selectedStep != null)
            {                
                string newName = view.ShowAddItemForm(StringResources.EditCycleStepTitle, selectedStep.Name);

                if (newName != null)
                {
                    selectedStep.Name = newName;
                    SortAndSetStepsOnGrid();
                    view.SelectedStep = selectedStep;
                }
            }
        }

        public void DeleteDrumButton_Click(object sender, EventArgs e)
        {
            CokerCardConfigurationDrum selectedDrum = view.SelectedDrum;
            if (selectedDrum != null)
            {
                if (view.UserIsSure())
                {
                    drums.Remove(selectedDrum);
                    SortAndSetDrumsOnGrid();
                    view.SelectFirstDrum();
                    configurationStructureChanged = true;
                }
            }
        }

        public void DeleteStepButton_Click(object sender, EventArgs e)
        {
            CokerCardConfigurationCycleStep selectedStep = view.SelectedStep;
            if (selectedStep != null)
            {
                if (view.UserIsSure())
                {
                    steps.Remove(selectedStep);
                    SortAndSetStepsOnGrid();
                    view.SelectFirstStep();
                    configurationStructureChanged = true;
                }
            }
        }

        public void DrumUpButton_Click(object sender, EventArgs e)
        {
            HandleUpButton(drums, SortAndSetDrumsOnGrid, () => view.SelectedDrum, SetSelectedDrum);
        }

        public void StepUpButton_Click(object sender, EventArgs e)
        {
            HandleUpButton(steps, SortAndSetStepsOnGrid, () => view.SelectedStep, SetSelectedStep);
        }       

        private static void HandleUpButton<T>(
            IList<T> items, Action sortAndSetItemsOnGrid, Func<T> getSelected, Action<T> setSelected) where T : IHasDisplayOrder
        {
            if (items.Count == 0)
            {
                return;
            }

            T selectedDrum = getSelected();

            int index = items.IndexOf(selectedDrum);

            if (index == 0)
            {
                return;
            }

            items.Remove(selectedDrum);
            items.Insert(index - 1, selectedDrum);

            DisplayOrderHelper.ResetDisplayValues(items);
            sortAndSetItemsOnGrid();

            setSelected(selectedDrum);
        }

        public void DrumDownButton_Click(object sender, EventArgs e)
        {
            HandleDownButton(drums, SortAndSetDrumsOnGrid, () => view.SelectedDrum, SetSelectedDrum);
        }

        public void StepDownButton_Click(object sender, EventArgs e)
        {
            HandleDownButton(steps, SortAndSetStepsOnGrid, () => view.SelectedStep, SetSelectedStep);
        }

        private static void HandleDownButton<T>(
            IList<T> items, Action sortAndSetItemsOnGrid, Func<T> getSelected, Action<T> setSelected) where T : IHasDisplayOrder
        {
            if (items.Count == 0)
            {
                return;
            }

            T item = getSelected();

            int index = items.IndexOf(item);

            if (index == items.Count - 1)
            {
                return;
            }

            items.Remove(item);
            items.Insert(index + 1, item);

            DisplayOrderHelper.ResetDisplayValues(items);
            sortAndSetItemsOnGrid();

            setSelected(item);
        }

        private void SetSelectedDrum(CokerCardConfigurationDrum drum)
        {
            view.SelectedDrum = drum;
        }

        private void SetSelectedStep(CokerCardConfigurationCycleStep step)
        {
            view.SelectedStep = step;
        }

        private void SortAndSetDrumsOnGrid()
        {            
            DisplayOrderHelper.SortAndResetDisplayOrder(drums);            
            view.Drums = drums;
        }

        private void SortAndSetStepsOnGrid()
        {            
            DisplayOrderHelper.SortAndResetDisplayOrder(steps);            
            view.Steps = steps;
        }
    }
}
