
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditConfiguredDocumentLinksFormPresenter : BaseFormPresenter<IEditConfiguredDocumentLinksView>
    {
        private readonly ConfiguredDocumentLinkLocation location;
        private List<ConfiguredDocumentLink> originalDocumentLinks;
        private readonly IConfiguredDocumentLinkService service;
        private List<ConfiguredDocumentLink> documentLinks;

        public EditConfiguredDocumentLinksFormPresenter(ConfiguredDocumentLinkLocation location) : base(new EditConfiguredDocumentLinksForm())
        {
            this.location = location;
            this.originalDocumentLinks = documentLinks ?? new List<ConfiguredDocumentLink>();
            service = ClientServiceRegistry.Instance.GetService<IConfiguredDocumentLinkService>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            view.Load += ViewOnLoad;
            view.AddButtonClick += ViewOnAddButtonClick;
            view.EditButtonClick += ViewOnEditButtonClick;
            view.DeleteButtonClick += ViewOnDeleteButtonClick;
            view.MoveUpButtonClick += ViewOnMoveUpButtonClick;
            view.MoveDownButtonClick += ViewOnMoveDownButtonClick;
            view.SaveAndCloseButtonClick += ViewOnSaveAndCloseButtonClick;
        }

        private void ViewOnSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            List<ConfiguredDocumentLink> deletedLinks = new List<ConfiguredDocumentLink>();

            foreach (ConfiguredDocumentLink oldLink in originalDocumentLinks)
            {
                if (oldLink.IsInDatabase() && !documentLinks.ExistsById(oldLink))
                {
                    deletedLinks.Add(oldLink);
                }
            }

            service.UpdateLinks(documentLinks, deletedLinks);
            view.Close();
        }

        private void ViewOnMoveDownButtonClick(object sender, EventArgs eventArgs)
        {
            if (documentLinks.Count == 0)
            {
                return;
            }

            ConfiguredDocumentLink link = view.SelectedLink;

            int index = documentLinks.IndexOf(link);

            if (index == documentLinks.Count - 1)
            {
                return;
            }

            documentLinks.Remove(link);
            documentLinks.Insert(index + 1, link);

            DisplayOrderHelper.ResetDisplayValues(documentLinks);
            SortAndSetValuesOnGrid();

            view.SelectedLink = link;
        }

        private void ViewOnMoveUpButtonClick(object sender, EventArgs eventArgs)
        {
            if (documentLinks.Count == 0)
            {
                return;
            }

            ConfiguredDocumentLink link = view.SelectedLink;

            int index = documentLinks.IndexOf(link);

            if (index == 0)
            {
                return;
            }

            documentLinks.Remove(link);
            documentLinks.Insert(index - 1, link);

            DisplayOrderHelper.ResetDisplayValues(documentLinks);
            SortAndSetValuesOnGrid();

            view.SelectedLink = link;
        }

        private void ViewOnDeleteButtonClick(object sender, EventArgs eventArgs)
        {
            ConfiguredDocumentLink selectedLink = view.SelectedLink;
            if (selectedLink != null && view.UserIsSure())
            {
                documentLinks.Remove(selectedLink);
                SortAndSetValuesOnGrid();
                view.SelectFirstRow();
            }            
        }

        private void ViewOnEditButtonClick(object sender, EventArgs eventArgs)
        {
            ConfiguredDocumentLink configuredDocumentLink = view.SelectedLink;
            if (configuredDocumentLink == null)
            {
                return;
            }

            AddEditConfiguredDocumentLinkFormPresenter presenter = new AddEditConfiguredDocumentLinkFormPresenter(configuredDocumentLink, location);
            DialogResult dialogResult = presenter.Run(view);
            if (dialogResult == DialogResult.OK)
            {
                SortAndSetValuesOnGrid();
                view.SelectedLink = configuredDocumentLink;
            }
        }

        private void ViewOnAddButtonClick(object sender, EventArgs eventArgs)
        {
            AddEditConfiguredDocumentLinkFormPresenter presenter = new AddEditConfiguredDocumentLinkFormPresenter(location);
            DialogResult dialogResult = presenter.Run(view);
            if (dialogResult == DialogResult.OK)
            {
                ConfiguredDocumentLink newLink = presenter.ConfiguredDocumentLink;
                if (newLink != null)
                {
                    newLink.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(documentLinks) + 1;
                    documentLinks.Add(newLink);
                    SortAndSetValuesOnGrid();
                    view.SelectedLink = newLink;
                }
            }
        }

        private void SortAndSetValuesOnGrid()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(documentLinks);
            view.ConfiguredDocumentLinks = documentLinks;
        }

        private void ViewOnLoad(object sender, EventArgs eventArgs)
        {
            this.originalDocumentLinks = service.GetLinks(location);
            this.documentLinks = new List<ConfiguredDocumentLink>(originalDocumentLinks);

            SortAndSetValuesOnGrid();
            view.SelectFirstRow();

            view.LocationName = location.DisplayName;
        }
    }
}
