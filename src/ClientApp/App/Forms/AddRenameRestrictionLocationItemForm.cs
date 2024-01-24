using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddRenameRestrictionLocationItemForm : BaseForm
    {
        private readonly RestrictionLocationItem editObject;
        private readonly List<RestrictionLocationItem> siblingRestrictionLocationItems;
        private readonly string nameOfParentLocationItem;

        public AddRenameRestrictionLocationItemForm(List<RestrictionLocationItem> siblingRestrictionLocationItems, string nameOfParentLocationItem)
            : this(siblingRestrictionLocationItems, nameOfParentLocationItem, null)
        {
        }

        public AddRenameRestrictionLocationItemForm(List<RestrictionLocationItem> siblingRestrictionLocationItems, string nameOfParentLocationItem, RestrictionLocationItem editObject)
        {
            this.nameOfParentLocationItem = nameOfParentLocationItem;
            this.editObject = editObject;
            InitializeComponent();

            this.siblingRestrictionLocationItems = siblingRestrictionLocationItems;

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;

            if (editObject != null)
            {
                nameTextBox.Text = editObject.Name;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = editObject != null ? "Rename Location Item" : "Add Location Item";
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

        public string NameOfNewRestrictionLocationItem
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

            if (NameOfNewRestrictionLocationItem.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
                hasError = true;
            }
            else if (editObject == null && siblingRestrictionLocationItems.Exists(vg => vg.Name.EqualsIgnoreCase(NameOfNewRestrictionLocationItem)))
            {
                errorProvider.SetError(nameTextBox, string.Format(StringResources.RestrictionLocationItemDuplicateName, nameOfParentLocationItem));
                hasError = true;
            }
            else if (editObject != null && siblingRestrictionLocationItems.Exists(vg => !editObject.IsSame(vg) && vg.Name.EqualsIgnoreCase(NameOfNewRestrictionLocationItem)))
            {
                errorProvider.SetError(nameTextBox, string.Format(StringResources.RestrictionLocationItemDuplicateName, nameOfParentLocationItem));
                hasError = true;
            }
            return !hasError;
        }

    }
}
