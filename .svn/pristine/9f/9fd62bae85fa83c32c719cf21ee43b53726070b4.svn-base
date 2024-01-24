using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddRenameRestrictionLocationForm : BaseForm
    {
        private readonly RestrictionLocation editObject;
        private readonly List<RestrictionLocation> restrictionLocationsInSite;

        public AddRenameRestrictionLocationForm(List<RestrictionLocation> restrictionLocationsInSite)
            : this(restrictionLocationsInSite, null)
        {
        }

        public AddRenameRestrictionLocationForm(List<RestrictionLocation> restrictionLocationsInSite, RestrictionLocation editObject) 
        {
            this.editObject = editObject;
            InitializeComponent();

            this.restrictionLocationsInSite = restrictionLocationsInSite;

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;

            if (editObject != null)
            {
                nameTextBox.Text = editObject.Name;
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            ShouldAddOrUpdate = false;
            Close();
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            ShouldAddOrUpdate = true;
            Close();
        }

        public bool ShouldAddOrUpdate { get; private set; }

        public string NameOfNewRestrictionLocation
        {
            get
            {
                return nameTextBox.Text.NullToEmpty().Trim();
            }
        }

        private bool DataIsValid()
        {
            errorProvider.Clear();
            
            bool hasError = false;

            if (NameOfNewRestrictionLocation.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
                hasError = true;
            }
            else if (editObject == null && restrictionLocationsInSite.Exists(vg => vg.Name.EqualsIgnoreCase(NameOfNewRestrictionLocation)))
            {
                errorProvider.SetError(nameTextBox, StringResources.RestrictionLocationDuplicateName);
                hasError = true;
            }
            else if (editObject != null && restrictionLocationsInSite.Exists(vg => !editObject.IsSame(vg) && vg.Name.EqualsIgnoreCase(NameOfNewRestrictionLocation)))
            {
                errorProvider.SetError(nameTextBox, StringResources.RestrictionLocationDuplicateName);
                hasError = true;
            }
            return !hasError;
        }

    }
}
