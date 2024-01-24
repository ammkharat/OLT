
using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditConfiguredDocumentLinkFormPresenter : BaseFormPresenter<IAddEditConfiguredDocumentLinkView>
    {
        private ConfiguredDocumentLink editObject;
        private ConfiguredDocumentLinkLocation location;
        private bool isEditMode;

        public AddEditConfiguredDocumentLinkFormPresenter(ConfiguredDocumentLinkLocation location) : this(null, location)
        {
        }

        public AddEditConfiguredDocumentLinkFormPresenter(ConfiguredDocumentLink editObject, ConfiguredDocumentLinkLocation location) : base(new AddEditConfiguredDocumentLinkForm())
        {
            this.location = location;
            this.editObject = editObject;
            isEditMode = editObject != null;

            SubscribeToEvents();
        }

        public ConfiguredDocumentLink ConfiguredDocumentLink
        {
            get { return editObject; }
        }

        private void SubscribeToEvents()
        {
            view.Load += ViewOnLoad;
            view.OkButtonClicked += ViewOnOkButtonClicked;
        }

        private void ViewOnLoad(object sender, EventArgs eventArgs)
        {
            if (isEditMode)
            {
                view.Title = StringResources.EditDocumentLink;

                view.LinkTitle = editObject.Title;
                view.Link = editObject.Link;
            }
            else
            {
                view.Title = StringResources.AddDocumentLink;
            }
        }

        private void ViewOnOkButtonClicked(object sender, EventArgs eventArgs)
        {
            bool dataIsValid = Validate();
            if (!dataIsValid)
            {
                return;
            }

            if (isEditMode)
            {
                editObject.Title = view.LinkTitle;
                editObject.Link = view.Link;
            }
            else
            {
                editObject = new ConfiguredDocumentLink(null, view.LinkTitle, view.Link, location, 0);
            }

            view.DialogResult = DialogResult.OK;
            view.Close();
        }

        private bool Validate()
        {
            view.ClearErrors();

            bool dataIsValid = true;
            if (view.Link.IsNullOrEmptyOrWhitespace())
            {
                dataIsValid = false;
                view.SetErrorNoLink();
            }

            if (view.LinkTitle.IsNullOrEmptyOrWhitespace())
            {
                dataIsValid = false;
                view.SetErrorNoTitle();
            }

            return dataIsValid;
        }

    }
}
