using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddNewDocumentLinkFormPresenter 
    {
        readonly IAddNewDocumentLinkFormView view;
        private readonly IDocumentLinkService service;

        private List<DocumentRootUncPath> documentRoots;

        public AddNewDocumentLinkFormPresenter(IAddNewDocumentLinkFormView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IDocumentLinkService>())
        {
        }

        public AddNewDocumentLinkFormPresenter(IAddNewDocumentLinkFormView view, IDocumentLinkService service)
        {
            this.view = view;
            this.service = service;
        }

        public AddNewDocumentLinkFormPresenter(IDocumentLinkService service)
        {
            this.service = service;
        }

        public void HandleAddClicked(object sender, EventArgs e)
        {
            if (!ValidateViewHasError())
            {
                var documentLink =
                    new DocumentLink(view.DocumentLink, view.Title);
                view.NewDocumentLink = documentLink;
                view.CloseForm();
            }
        }


        public void HandleCancelClicked(object sender, EventArgs e)
        {            
            view.NewDocumentLink = null;
            view.CloseForm();
        }


        public bool ValidateViewHasError()
        {
            view.ClearErrorProviders();

            bool hasError = false;
            string link = view.DocumentLink;
            string title = view.Title;

            if (link.IsNullOrEmptyOrWhitespace())
            {
                view.ShowLinkDocumentIsEmptyError();
                hasError = true;
            }

            if (title.IsNullOrEmptyOrWhitespace())
            {
                view.ShowTitleDocumentIsEmptyError();
                hasError = true;
            }


            if (!link.IsNullOrEmptyOrWhitespace() && !link.IsValidUri())
            {
                view.ShowLinkDocumentIsNotValidURLError();
                hasError = true;
            }
            
            return hasError;
        }

        public void BrowseClicked(object sender, EventArgs e)
        {
            if (documentRoots.Count == 1)
                DisplayFileBrowser(documentRoots[0]);
            else
            {
                DocumentRootUncPath selectedDocumentRoot = view.DisplayRootSelector();
                
                if (selectedDocumentRoot != null)
                    DisplayFileBrowser(selectedDocumentRoot);
            }
            
        }

        private void DisplayFileBrowser(DocumentRootUncPath uncPath)
        {
            view.SelectFile(uncPath);
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            List<FunctionalLocation> sectionsForSelectedFunctionalLocations = ClientSession.GetUserContext().SectionsForSelectedFunctionalLocations;
            documentRoots = service.QueryRootsBySecondLevelFunctionalLocation(new SectionOnlyFlocSet(sectionsForSelectedFunctionalLocations));

            if (documentRoots.Count == 0)
                view.DisableFileBrowser();
        }

        public List<DocumentRootUncPath> GetFlocData()
        {
            List<FunctionalLocation> sectionsForSelectedFunctionalLocations = ClientSession.GetUserContext().SectionsForSelectedFunctionalLocations;
            documentRoots = service.QueryRootsBySecondLevelFunctionalLocation(new SectionOnlyFlocSet(sectionsForSelectedFunctionalLocations));
            return documentRoots;

        }

    }
}
