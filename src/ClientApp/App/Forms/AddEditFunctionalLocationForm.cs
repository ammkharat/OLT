using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditFunctionalLocationForm : BaseForm, IAddEditFunctionalLocationView
    {
        private readonly AddEditFunctionalLocationFormPresenter presenter;

        public AddEditFunctionalLocationForm(FunctionalLocation parentFunctionalLocation, List<FunctionalLocation> potentialSiblingFunctionalLocations)
            : this(parentFunctionalLocation, potentialSiblingFunctionalLocations, null)
        {
            nextLevelTextBox.ReadOnly = false;
        }

        public AddEditFunctionalLocationForm(FunctionalLocation parentFunctionalLocation, List<FunctionalLocation> potentialSiblingFunctionalLocations, FunctionalLocation editObject) 
        {
            InitializeComponent();

            presenter = new AddEditFunctionalLocationFormPresenter(this, parentFunctionalLocation, potentialSiblingFunctionalLocations, editObject);
            nextLevelTextBox.TextChanged += (sender, args) => presenter.NameTextBoxTextChanged();
            Load += (sender, args) => presenter.HandleLoadForm();
            submitButton.Click += (sender, args) => presenter.HandleSubmitButtonClicked();
            cancelButton.Click += (sender, args) => presenter.HandleCancelButtonClicked();

        }

        public bool ShouldAddOrUpdate { get; set; }

        public string SuperiorFloc
        {
            set { superiorFlocTextBox.Text = value; }
        }

        public string NextLevel
        {
            get { return nextLevelTextBox.Text.NullToEmpty().Trim(); }
            set { nextLevelTextBox.Text = value; }
        }

        public string NewFullHierarchy
        {
            get
            {
                return fullHierarchyLabel.Text.NullToEmpty().Trim();
            }
        }

        public string FullHierarchy
        {
            set { fullHierarchyLabel.Text = value; }
        }

        public void SetErrorForEmptyName()
        {
            errorProvider.SetError(nextLevelTextBox, StringResources.NameEmptyError);            
        }

        public void SetErrorForInvalidCharactersInFlocName()
        {
            errorProvider.SetError(nextLevelTextBox, StringResources.FunctionalLocationInvalidCharacters);
        }

        public void SetErrorForDuplicateFlocName()
        {
            errorProvider.SetError(nextLevelTextBox, StringResources.FunctionalLocationDuplicateName);
        }

        public void SetErrorForEmptyDescription()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.DescriptionEmptyError);
        }

        public string Description
        {
            get { return descriptionTextBox.Text.NullToEmpty().Trim(); }
            set { descriptionTextBox.Text = value; }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }
    }
}