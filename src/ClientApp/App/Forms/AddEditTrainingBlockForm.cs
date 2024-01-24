using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditTrainingBlockForm : BaseForm, IAddEditTrainingBlockView
    {
        public event Action FormLoad;
        public event Action SaveButtonClick;

        public AddEditTrainingBlockForm()
        {
            InitializeComponent();

            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);

            saveButton.Click += HandleSaveButtonClick;
            clearFlocsButton.Click += HandleClearFlocsButtonClick;
        }

        private void HandleClearFlocsButtonClick(object sender, EventArgs e)
        {
            flocSelectionControl.UserCheckedFunctionalLocations = new List<FunctionalLocation>();
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (SaveButtonClick != null)
            {
                SaveButtonClick();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public string FormTitle
        {
            set { Text = value; }
        }

        public string TrainingBlockName
        {
            get { return trainingBlockNameTextBox.Text.TrimOrNull(); }
            set { trainingBlockNameTextBox.Text = value; }
        }

        public string TrainingCode
        {
            get { return trainingCodeTextBox.Text.TrimOrNull(); }
            set { trainingCodeTextBox.Text = value; }
        }

        public IList<FunctionalLocation> FunctionalLocations
        {
            set { flocSelectionControl.UserCheckedFunctionalLocations = value; }
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
        }

        public void ShowNameMustBeUniqueError()
        {
            errorProvider.SetError(trainingBlockNameTextBox, StringResources.TrainingBlockNameMustBeUnique);
        }

        public void ShowAtLeastOneFunctionalLocationIsNecessaryError()
        {
            errorProvider.SetError(functionalLocationsGroupBox, StringResources.FlocForTrainingBlockNeeded);
        }

        public void ShowNameMustNotBeEmptyError()
        {
            errorProvider.SetError(trainingBlockNameTextBox, StringResources.NameEmptyError);
        }
    }
}
