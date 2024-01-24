using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class TargetDefinitionReadWriteTagConfigurationForm : BaseForm, ITargetDefinitionReadWriteTagConfigurationView
    {
        private readonly TargetDefinitionReadWriteTagConfigurationPresenter presenter;

        public TargetDefinitionReadWriteTagConfigurationForm(TargetDefinition targetDefinition)
        {
            InitializeComponent();
            presenter = new TargetDefinitionReadWriteTagConfigurationPresenter(this, targetDefinition);
            Load += ((sender, e) => presenter.Load());
            acceptButton.Click += ((sender, e) => presenter.Accept());
            cancelButton.Click += ((sender, e) => presenter.Cancel());
            clearButton.Click += ((sender, e) => presenter.Clear());
            maxThresholdComboBox.SelectedIndexChanged += ((sender, e) =>
                                                          presenter.DirectionChanged(
                                                              TargetDefinitionReadWriteTagConfigurationPresenter.
                                                                  MAX_THRESHOLD));
            minThresholdComboBox.SelectedIndexChanged += ((sender, e) =>
                                                          presenter.DirectionChanged(
                                                              TargetDefinitionReadWriteTagConfigurationPresenter.
                                                                  MIN_THRESHOLD));
            targetThresholdComboBox.SelectedIndexChanged += ((sender, e) =>
                                                             presenter.DirectionChanged(
                                                                 TargetDefinitionReadWriteTagConfigurationPresenter.
                                                                     TARGET_THRESHOLD));
            gapUnitValueComboBox.SelectedIndexChanged += ((sender, e) =>
                                                          presenter.DirectionChanged(
                                                              TargetDefinitionReadWriteTagConfigurationPresenter.
                                                                  GAP_UNIT_VALUE));
            maxThresholdTagSearchButton.Click += ((sender, e) =>
                                                  presenter.TagSearch(
                                                      TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD));
            minThresholdTagSearchButton.Click += ((sender, e) =>
                                                  presenter.TagSearch(
                                                      TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD));
            targetThresholdTagSearchButton.Click += ((sender, e) =>
                                                     presenter.TagSearch(
                                                         TargetDefinitionReadWriteTagConfigurationPresenter.
                                                             TARGET_THRESHOLD));
            gapUnitValueTagSearchButton.Click += ((sender, e) =>
                                                  presenter.TagSearch(
                                                      TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE));
        }

        public TargetDefinitionReadWriteTagConfiguration ReadWriteTagsConfiguration
        {
            get { return presenter.ReadWriteTagConfigurations; }
        }

        public string TargetDefinitionName
        {
            set { targetDefinitionNameTextbox.Text = value; }
        }

        public bool TargetDefinitionNameEnabled
        {
            set { targetDefinitionNameTextbox.Enabled = value; }
        }

        public bool MaxThresholdTagEnabled
        {
            set { maxThresholdTagNameTextBox.Enabled = value; }
        }

        public bool MinThresholdTagEnabled
        {
            set { minThresholdTagNameTextBox.Enabled = value; }
        }

        public bool TargetThresholdEnabled
        {
            set { targetThresholdTagNameTextBox.Enabled = value; }
        }

        public bool GapUnitValueEnabled
        {
            set { gapUnitValueTagNameTextBox.Enabled = value; }
        }

        public IList<TagDirection> MaxThresholdDirectionList
        {
            set { maxThresholdComboBox.DataSource = value; }
        }

        public TagDirection MaxThresholdDirection
        {
            get { return maxThresholdComboBox.SelectedItem as TagDirection; }
            set { maxThresholdComboBox.SelectedItem = value; }
        }

        public IList<TagDirection> MinThresholdDirectionList
        {
            set { minThresholdComboBox.DataSource = value; }
        }

        public TagDirection MinThresholdDirection
        {
            get { return minThresholdComboBox.SelectedItem as TagDirection; }
            set { minThresholdComboBox.SelectedItem = value; }
        }

        public IList<TagDirection> TargetThresholdDirectionList
        {
            set { targetThresholdComboBox.DataSource = value; }
        }

        public TagDirection TargetThresholdDirection
        {
            get { return targetThresholdComboBox.SelectedItem as TagDirection; }
            set { targetThresholdComboBox.SelectedItem = value; }
        }

        public IList<TagDirection> GapUnitValueDirectionList
        {
            set { gapUnitValueComboBox.DataSource = value; }
        }

        public TagDirection GapUnitDirection
        {
            get { return gapUnitValueComboBox.SelectedItem as TagDirection; }
            set { gapUnitValueComboBox.SelectedItem = value; }
        }

        public TagInfo MaxThresholdTag
        {
            get { return maxThresholdTagNameTextBox.Tag as TagInfo; }
            set
            {
                maxThresholdTagNameTextBox.Text = (value == null) ? string.Empty : value.Name;
                maxThresholdTagNameTextBox.Tag = value;
            }
        }

        public TagInfo MinThresholdTag
        {
            get { return minThresholdTagNameTextBox.Tag as TagInfo; }
            set
            {
                minThresholdTagNameTextBox.Text = (value == null) ? string.Empty : value.Name;
                minThresholdTagNameTextBox.Tag = value;
            }
        }

        public TagInfo TargetThresholdTag
        {
            get { return targetThresholdTagNameTextBox.Tag as TagInfo; }
            set
            {
                targetThresholdTagNameTextBox.Text = (value == null) ? string.Empty : value.Name;
                targetThresholdTagNameTextBox.Tag = value;
            }
        }

        public TagInfo GapUnitValueTag
        {
            get { return gapUnitValueTagNameTextBox.Tag as TagInfo; }
            set
            {
                gapUnitValueTagNameTextBox.Text = (value == null) ? string.Empty : value.Name;
                gapUnitValueTagNameTextBox.Tag = value;
            }
        }

        public void ClearErrors()
        {
            directionErrorProvider.Clear();
            tagErrorProvider.Clear();
        }

        public void ShowInvalidMaxThresholdDirectionError()
        {
            directionErrorProvider.SetError(maxThresholdComboBox, StringResources.InvalidReadWriteDirection);
        }

        public void ShowInvalidMaxThresholdTagError()
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, StringResources.InvalidReadWriteTag);
        }

        public void ShowInvalidMinThresholdDirectionError()
        {
            directionErrorProvider.SetError(minThresholdComboBox, StringResources.InvalidReadWriteDirection);
        }

        public void ShowInvalidMinThresholdTagError()
        {
            tagErrorProvider.SetError(minThresholdTagNameTextBox, StringResources.InvalidReadWriteTag);
        }

        public void ShowInvalidTargetThresholdDirectionError()
        {
            directionErrorProvider.SetError(targetThresholdComboBox, StringResources.InvalidReadWriteDirection);
        }

        public void ShowInvalidTargetThresholdTagError()
        {
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, StringResources.InvalidReadWriteTag);
        }

        public void ShowInvalidGapUnitValueDirectionError()
        {
            directionErrorProvider.SetError(gapUnitValueComboBox, StringResources.InvalidReadWriteDirection);
        }

        public void ShowInvalidGapUnitValueTagError()
        {
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, StringResources.InvalidReadWriteTag);
        }

        public void ShowMaxAndMinSameTagError()
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
            tagErrorProvider.SetError(minThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
        }

        public void ShowMaxAndTargetSameTagError()
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
        }

        public void ShowMaxAndGapUnitValueSameTagError()
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
        }

        public void ShowMinAndTargetSameTagError()
        {
            tagErrorProvider.SetError(minThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
        }

        public void ShowMinAndGapUnitValueSameTagError()
        {
            tagErrorProvider.SetError(minThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
        }

        public void ShowTargetAndGapUnitValueSameTagError()
        {
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, StringResources.MultipleWriteDirectionsToSameTag);
        }

        public void ShowMaxTagAssociatedToOtherTargetDefinitionError(string errorMessage)
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, errorMessage);
        }

        public void ShowMinTagAssociatedToOtherTargetDefinitionError(string errorMessage)
        {
            tagErrorProvider.SetError(minThresholdTagNameTextBox, errorMessage);
        }

        public void ShowTargetTagAssociatedToOtherTargetDefinitionError(string errorMessage)
        {
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, errorMessage);
        }

        public void ShowGapUnitValueTagAssociatedToOtherTargetDefinitionError(string errorMessage)
        {
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, errorMessage);
        }

        public void ShowMaxTagInvalidReadError()
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, StringResources.InvalidPlantHistorianRead);
        }

        public void ShowMinTagInvalidReadError()
        {
            tagErrorProvider.SetError(minThresholdTagNameTextBox, StringResources.InvalidPlantHistorianRead);
        }

        public void ShowTargetTagInvalidReadError()
        {
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, StringResources.InvalidPlantHistorianRead);
        }

        public void ShowGapUnitValueTagInvalidReadError()
        {
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, StringResources.InvalidPlantHistorianRead);
        }

        public void ShowMaxTagInvalidWriteError()
        {
            tagErrorProvider.SetError(maxThresholdTagNameTextBox, StringResources.InvalidPlantHistorianWrite);
        }

        public void ShowMinTagInvalidWriteError()
        {
            tagErrorProvider.SetError(minThresholdTagNameTextBox, StringResources.InvalidPlantHistorianWrite);
        }

        public void ShowTargetTagInvalidWriteError()
        {
            tagErrorProvider.SetError(targetThresholdTagNameTextBox, StringResources.InvalidPlantHistorianWrite);
        }

        public void ShowGapUnitValueTagInvalidWriteError()
        {
            tagErrorProvider.SetError(gapUnitValueTagNameTextBox, StringResources.InvalidPlantHistorianWrite);
        }

        public ITagSearchFormView DisplayTagSearchForm()
        {
            var tagSearchForm = new TagSearchForm(true, false);
            return tagSearchForm;
        }

        public void CloseView()
        {
            Close();
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }
    }
}