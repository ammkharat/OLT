using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.Data.PLinq.Helpers;
using Infragistics.Win.UltraWinExplorerBar;

namespace Com.Suncor.Olt.Client.Forms
{
    // This class can not be marked abstract because VS is unable to render such classes in the Designer. 
    //   As a result, these classes can't be marked abstract - instead they are virtual expecting to be overriden.
    public class WorkPermitForm : BaseForm
    {
        private static readonly string SPECIAL_PRECAUTIONS_CONSIDERATIONS_GROUPHEADERKEY =
            WorkPermitSection.SpecialPrecautionsOrConsiderations.GroupKey;

        internal readonly ErrorProviderHandler errorHandler;
        // keeps track of errors already put on controls. Helpful for upgrading an error from Warning to a higher level.
        private readonly List<ControlError> errors = new List<ControlError>();


        protected WorkPermitForm()
        {
            Name = StringResources.WorkPermitForm_FormTitle;
            errorHandler = new ErrorProviderHandler(this);
        }

        // This class can not be marked abstract because VS is unable to render such classes in the Designer. 
        //   As a result, these classes can't be marked abstract - instead they are virtual expecting to be overriden.
        public virtual List<IGasTestElementDetails> GasTestElementDetailsList
        {
            get { return new List<IGasTestElementDetails>(); }
        }

        internal virtual OltExplorerBar ExplorerBar
        {
            get { return null; }
        }

        public void ClearErrorProviders()
        {
            errors.Clear();
            errorHandler.Clear();

            foreach (var details in GasTestElementDetailsList)
            {
                details.ClearWarningMessages();
            }

            foreach (var grp in ExplorerBar.Groups)
            {
                grp.Settings.AppearancesSmall.HeaderAppearance.ResetForeColor();
            }
        }

        public void SetError(string controlName, ProblemLevel level, string message)
        {
            if (errors.Exists(error => error.ControlName.Equals(controlName) && error.ProblemLevel >= level))
                return;

            var lowerLevelError =
                errors.Find(error => error.ControlName.Equals(controlName) && error.ProblemLevel < level);
            if (lowerLevelError != null)
            {
                errors.Remove(lowerLevelError);
            }

            switch (level)
            {
                case ProblemLevel.Warning:
                    errorHandler.SetWarning(controlName, message);
                    break;
                case ProblemLevel.RequiredForApproval:
                    errorHandler.SetRequiredForApproval(controlName, message);
                    break;
                case ProblemLevel.RequiredForSave:
                    errorHandler.SetError(controlName, message);
                    break;
                default:
                    return;
            }

            errors.Add(new ControlError {ControlName = controlName, ProblemLevel = level});

            var parentGroup = FindParentGroup(controlName);
            if (parentGroup != null)
            {
                var currentColour =
                    GroupColour.GetByColor(parentGroup.Settings.AppearancesSmall.HeaderAppearance.ForeColor);
                if (currentColour == null || currentColour.ProblemLevel < level)
                {
                    var color = GroupColour.GetByProblemLevel(level);
                    parentGroup.Settings.AppearancesSmall.HeaderAppearance.ResetForeColor();
                    parentGroup.Settings.AppearancesSmall.HeaderAppearance.ForeColor = color.DrawingColor;
                }
            }
        }

        private UltraExplorerBarGroup FindParentGroup(string controlName)
        {
            var control = FindControlByName(controlName);
            if (control == null)
            {
                return null;
            }

            var infragisticsGroupControlName = RecursivelyFindInfragisticsParentGroup(control);

            return ExplorerBar.Groups.Find<UltraExplorerBarGroup>(
                group => string.Equals(group.Container.Name, infragisticsGroupControlName));
        }

        private static string RecursivelyFindInfragisticsParentGroup(Control control)
        {
            var parentControl = control.Parent;

            if (parentControl == null) return string.Empty;

            return parentControl.GetType() == typeof (UltraExplorerBarContainerControl)
                ? parentControl.Name
                : RecursivelyFindInfragisticsParentGroup(parentControl);
        }

        public void IndicateProblemOnSection(WorkPermitSection section, ProblemLevel level)
        {
            var currentColor = GetExplorerBarGroupHeaderForeColor(section.GroupKey);
            if (currentColor.IsEmpty || currentColor == Color.Black)
            {
                SetExplorerBarGroupHeaderForeColor(section.GroupKey, GroupColour.GetByProblemLevel(level));
                return;
            }

            var currentGroupColor = GroupColour.GetByColor(currentColor);

            // already red, so nothing more to do.
            if (currentGroupColor == null || currentGroupColor.ProblemLevel == ProblemLevel.RequiredForSave)
                return;

            var currentSectionLevel = currentGroupColor.ProblemLevel;

            // automatically set to red for required to save.
            if (level == ProblemLevel.RequiredForSave)
            {
                SetExplorerBarGroupHeaderForeColor(section.GroupKey, GroupColour.Error);
            }
                // If we are less than Orange, then set to orange
            else if (level == ProblemLevel.RequiredForApproval && currentSectionLevel < ProblemLevel.RequiredForApproval)
            {
                SetExplorerBarGroupHeaderForeColor(section.GroupKey, GroupColour.ErrorOnApproval);
            }

                // want to set to yellow, but only if we aren't already Orange or Yellow.
            else if (level == ProblemLevel.Warning && currentSectionLevel < ProblemLevel.RequiredForApproval)
            {
                SetExplorerBarGroupHeaderForeColor(section.GroupKey, GroupColour.Warning);
            }
        }

        private Color GetExplorerBarGroupHeaderForeColor(string groupKey)
        {
            return ExplorerBar.Groups[groupKey].Settings.AppearancesSmall.HeaderAppearance.ForeColor;
        }

        private void SetExplorerBarGroupHeaderForeColor(string groupKey, GroupColour color)
        {
            ExplorerBar.Groups[groupKey].Settings.AppearancesSmall.HeaderAppearance.ForeColor = color.DrawingColor;
        }

        public void ValidateFullySucceededMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.PermitIsValidMessageBoxText,
                StringResources.PermitIsValidMessageBoxCaption);
        }

        public void ValidatePassedButCannotApproveMessage()
        {
            var message = string.Format(StringResources.PermitCanBeSavedButNotApprovedMessage,
                GroupColour.ErrorOnApproval,
                GroupColour.Warning);
            OltMessageBox.Show(ActiveForm,
                message,
                StringResources.PermitValidateFailedButBasicPassedTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        public void ValidateFullyFailedMessage()
        {
            var message = string.Format(StringResources.PermitValidateFullyFailedMessage,
                GroupColour.Error);
            OltMessageBox.Show(ActiveForm,
                message,
                StringResources.PermitValidateFullyFailedTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        public FunctionalLocation ShowFunctionalLocationSelector()
        {
            ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectionForm =
                new SingleSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3));

            var result = functionalLocationSelectionForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                return functionalLocationSelectionForm.SelectedFunctionalLocation;
            }
            return null;
        }

        protected IGasTestElementDetails FindGasTestElement(GasTestElementInfo gasTestElementInfo)
        {
            return GasTestElementDetailsList.Find(d => d.ElementName == gasTestElementInfo.Name);
        }

        public void ShowImmediateAreaGasTestResultOutOfRangeWarning(GasTestElementInfo gasTestElementInfo)
        {
            var element = FindGasTestElement(gasTestElementInfo);
            if (element != null && !element.ImmediateAreaTestResult.HasValue)        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            {
                element.SetImmediateAreaResultAlertMessage(StringResources.FieldCannotBeEmpty);
                IndicateProblemOnSection(WorkPermitSection.GasTests, ProblemLevel.RequiredForSave);
            }

            if (element != null && element.ImmediateAreaTestResult.HasValue)
            {
                element.SetImmediateAreaResultWarningMessage(StringResources.GasTestElementImmediateAreaResultOutOfRange);
                IndicateProblemOnSection(WorkPermitSection.GasTests, ProblemLevel.Warning);
            }
            
        }
        public void ShowConfinedSpaceGasTestResultOutOfRangeWarning(GasTestElementInfo gasTestElementInfo)
        {
            var element = FindGasTestElement(gasTestElementInfo);

            if (element != null && !element.ConfinedSpaceTestResult.HasValue)    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            {
                element.SetConfinedSpaceTestResultAlertMessage(StringResources.FieldCannotBeEmpty);
                IndicateProblemOnSection(WorkPermitSection.GasTests, ProblemLevel.RequiredForSave);
            }
            if (element != null && element.ConfinedSpaceTestResult.HasValue)
            {
                element.SetConfinedSpaceTestResultWarningMessage(
                    StringResources.GasTestElementConfinedSpaceResultOutOfRange);
                IndicateProblemOnSection(WorkPermitSection.GasTests, ProblemLevel.Warning);
            }
        }

        public void ShowSystemEntryGasTestResultOutOfRangeWarning(GasTestElementInfo gasTestElementInfo)
        {
            var element = FindGasTestElement(gasTestElementInfo);
            if (element != null)
            {
                element.SetSystemEntryTestResultWarningMessage(StringResources.GasTestElementSystemEntryResultOutOfRange);
                IndicateProblemOnSection(WorkPermitSection.GasTests, ProblemLevel.Warning);
            }
        }

        /// <summary>
        /// Disables All items in the groupbox except for the selected checkbox
        /// </summary>
        /// <param name="currentCheckBox"></param>
        public void SetGroupBoxItems(CheckBox currentCheckBox)
        {
            var oltGroupBox = currentCheckBox.Parent as OltGroupBox;
            var isEnabled = !currentCheckBox.Checked;

            if (oltGroupBox != null)
            {
                oltGroupBox.Controls
                    .FindAll((Control control) => control.DoesNotEqual(currentCheckBox))
                    .ForEach(control => control.Enabled = isEnabled);

                DisableLabelsThatShouldBeDisabled(oltGroupBox.Controls, !isEnabled);

                //disable the special boxes that should stay disabled due to
                // their associated checkbox
                if (isEnabled)
                    DisableItemsThatShouldBeDisabled();
            }
        }

        /// <summary>
        /// Forces all disabled Label controls to be displayed with the same text
        /// color as other disabled controls (e.g. checkboxes and radio buttons etc).
        /// </summary>
        private static void DisableLabelsThatShouldBeDisabled(ICollection controls, bool isEnabled)
        {
            var disabledColor = SystemColors.GrayText;

            controls.FindAll((Control control) => control is Label && control.Enabled == isEnabled)
                .ForEach(control => control.ForeColor = disabledColor);
        }

        protected virtual void DisableItemsThatShouldBeDisabled()
        {
            // TODO: what was supposed to happen here?
        }

        public void ExpandOrCollapseGroups(bool isExpanded)
        {
            ExplorerBar.Groups.ForEach((UltraExplorerBarGroup group) => group.Expanded = isExpanded);
        }

        protected void collapseAllGroupsButton_Click(object sender, EventArgs e)
        {
            ExpandOrCollapseGroups(false);
        }

        protected void expandAllGroupsButton_Click(object sender, EventArgs e)
        {
            ExpandOrCollapseGroups(true);
        }

        /// <summary>
        ///     Set foc the incoming textbox in the special precautions area making sure group is expanded and visible to user
        /// </summary>
        /// <param name="textbox">Textbox to set focus to in the special precautions area</param>
        protected void SetFocusToTextboxInSpecialPrecautionsArea(Control textbox)
        {
            ExplorerBar.Groups[SPECIAL_PRECAUTIONS_CONSIDERATIONS_GROUPHEADERKEY].Expanded = true;
            ExplorerBar.Groups[SPECIAL_PRECAUTIONS_CONSIDERATIONS_GROUPHEADERKEY].EnsureGroupInView();

            textbox.Focus();
        }

        protected static void AssignRadioButtonsFromNullableBoolean(RadioButton affirmativeRadioButton,
            RadioButton negativeRadioButton, bool? value)
        {
            if (value == null)
            {
                affirmativeRadioButton.Checked = false;
                negativeRadioButton.Checked = false;
                return;
            }

            affirmativeRadioButton.Checked = value.Value;
            negativeRadioButton.Checked = !value.Value;
        }

        protected static bool? GetNullableBooleanFromRadioButtons(RadioButton affirmativeRadioButton,
            RadioButton negativeRadioButton)
        {
            if (affirmativeRadioButton.Checked ||
                negativeRadioButton.Checked)
            {
                return affirmativeRadioButton.Checked;
            }
            return null;
        }

        private void SetEnableOnExplorerBarGroupControls(string groupKey, bool isEnabled)
        {
            if (ExplorerBar.Groups.Exists(groupKey))
            {
                var controls = ExplorerBar.Groups[groupKey].Container.Controls;
                controls.SetEnableOnAllChildControls(isEnabled);
            }
        }

        public void SetEnableOnWorkPermitSection(WorkPermitSection section, bool isEnabled)
        {
            SetEnableOnExplorerBarGroupControls(section.GroupKey, isEnabled);
        }

        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof (WorkPermitForm));
            SuspendLayout();
            // 
            // WorkPermitForm
            // 
            resources.ApplyResources(this, "$this");
            Name = "WorkPermitForm";
            ResumeLayout(false);
        }

        private class ControlError
        {
            public string ControlName { get; set; }
            public ProblemLevel ProblemLevel { get; set; }
        }
    }
}