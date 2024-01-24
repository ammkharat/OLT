using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConvertLogBasedDirectivesIntoNewDirectivesForm : BaseForm,
        IConvertLogBasedDirectivesIntoNewDirectivesView
    {
        private IMultiSelectFunctionalLocationSelectionForm flocSelector;

        public ConvertLogBasedDirectivesIntoNewDirectivesForm()
        {
            InitializeComponent();

            addFunctionalLocationButton.Click += (sender, args) => AddFunctionalLocationButtonClicked();
            removeFunctionalLocationButton.Click += (sender, args) => RemoveFunctionalLocationButtonClicked();

            acceptCheckBox.CheckedChanged += (sender, args) => AcceptCheckboxChanged();
            continueButton.Click += (sender, args) => ContinueClicked();
        }

        public event Action FormLoad;
        public event Action AcceptCheckboxChanged;
        public event Action ContinueClicked;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;

        public IMultiSelectFunctionalLocationSelectionForm FlocSelector
        {
            set { flocSelector = value; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> flocSelections)
        {
            var dialogResult = flocSelector.ShowDialog(this, flocSelections);

            var selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult,
                new List<FunctionalLocation>(selectedFunctionalLocations));
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public string SiteName
        {
            set { explanationLabel.Text = String.Format(explanationLabel.Text, value); }
        }

        public bool ContinueButtonEnabled
        {
            set { continueButton.Enabled = value; }
        }

        public bool AcceptChecked
        {
            get { return acceptCheckBox.Checked; }
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FormLoad();
        }
    }
}