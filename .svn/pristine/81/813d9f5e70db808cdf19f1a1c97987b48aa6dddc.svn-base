using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditDocumentLinkRootFormPresenter : AbstractFormPresenter<IAddEditDocmentLinkRootView, DocumentRootUncPath>
    {
        private readonly IDocumentLinkService service;

        public AddEditDocumentLinkRootFormPresenter(IAddEditDocmentLinkRootView view, DocumentRootUncPath editObject) : base(view, editObject)
        {
            service = ClientServiceRegistry.Instance.GetService<IDocumentLinkService>();
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            SaveOrUpdate(true);           
        }

        protected override void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
        {
            if(saveOrUpdateSucceeded)
            {
                view.SetDialogResultOK();
            }
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            if (editObject != null)
            {
                UpdateViewFromEditObject();
            }
            else
            {
                UpdateViewWithDefaults();
            }
        }

        public override bool ValidateViewHasError()
        {
            UpdateEditObjectFromView();

            DocumentRootUncPathValidator validator = new DocumentRootUncPathValidator(view);
            validator.ValidateAndSetErrors(editObject);
            return validator.HasErrors;
        }

        protected override SaveUpdateDomainObjectContainer<DocumentRootUncPath> GetNewObjectToInsert()
        {
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<DocumentRootUncPath>(editObject);
        }

        public override void Insert(SaveUpdateDomainObjectContainer<DocumentRootUncPath> path)
        {            
            service.Insert(path.Item);
        }

        protected override SaveUpdateDomainObjectContainer<DocumentRootUncPath> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<DocumentRootUncPath>(editObject);
        }

        public override void Update(SaveUpdateDomainObjectContainer<DocumentRootUncPath> path)
        {            
            service.Update(path.Item);
        }

        private void UpdateEditObjectFromView()
        {
            long? id = editObject != null ? editObject.Id : null;
            editObject = new DocumentRootUncPath(view.PathName, view.UncPath, view.FunctionalLocations.ToList()) { Id = id };
        }

        private void UpdateViewFromEditObject()
        {
            view.PathName = editObject.PathName;
            view.UncPath = editObject.Path;
            view.FunctionalLocations = editObject.FirstLevelFunctionalLocations;
        }

        protected void UpdateViewWithDefaults()
        {
            view.PathName = string.Empty;
            view.UncPath = string.Empty;
            view.FunctionalLocations = new List<FunctionalLocation>(0);
        }
    }

}