using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddVisibilityGroupForm : BaseForm
    {
        private readonly VisibilityGroup editObject;
        private readonly List<VisibilityGroup> visibilityGroupsInSite;

        public AddVisibilityGroupForm(List<VisibilityGroup> visibilityGroupsInSite) : this(visibilityGroupsInSite, null)
        {
        }

        public AddVisibilityGroupForm(List<VisibilityGroup> visibilityGroupsInSite, VisibilityGroup editObject) 
        {
            this.editObject = editObject;
            InitializeComponent();

            this.visibilityGroupsInSite = visibilityGroupsInSite;

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

        public string NameOfNewVisibilityGroup
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

            if (NameOfNewVisibilityGroup.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
                hasError = true;
            }
            else if (editObject == null && visibilityGroupsInSite.Exists(vg => vg.Name.EqualsIgnoreCase(NameOfNewVisibilityGroup)))
            {
                errorProvider.SetError(nameTextBox, StringResources.VisibilityGroupDuplicateNameForSite);
                hasError = true;
            }
            else if (editObject != null && visibilityGroupsInSite.Exists(vg => !editObject.IsSame(vg) && vg.Name.EqualsIgnoreCase(NameOfNewVisibilityGroup)))
            {
                errorProvider.SetError(nameTextBox, StringResources.VisibilityGroupDuplicateNameForSite);
                hasError = true;
            }
            return !hasError;
        }

    }
}
