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
    public class AddEditAdministratorFormPresenter : AbstractFormPresenter<IAddEditAdministratorView, AdministratorList>
    {
        private readonly IAdministratorListService service;

        public AddEditAdministratorFormPresenter(IAddEditAdministratorView view, AdministratorList editObject)
            : base(view, editObject)
        {
            service = ClientServiceRegistry.Instance.GetService<IAdministratorListService>();
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

            AdministratorFormValidator validator = new AdministratorFormValidator(view);
            validator.ValidateAndSetErrors(editObject);
            return validator.HasErrors;
        }

        protected override SaveUpdateDomainObjectContainer<AdministratorList> GetNewObjectToInsert()
        {
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<AdministratorList>(editObject);
        }

        public override void Insert(SaveUpdateDomainObjectContainer<AdministratorList> path)
        {            
            service.Insert(path.Item);
        }

        protected override SaveUpdateDomainObjectContainer<AdministratorList> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditObjectFromView();
            return new SaveUpdateDomainObjectContainer<AdministratorList>(editObject);
        }

        public override void Update(SaveUpdateDomainObjectContainer<AdministratorList> path)
        {            
            service.Update(path.Item);
        }

        private void UpdateEditObjectFromView()
        {
            long? id = editObject != null ? editObject.Id : null;
            editObject = new AdministratorList(view.SiteName, view.Group, view.SiteRepresentative,view.SiteAdmin, view.BEA) { Id = id };
        }

        private void UpdateViewFromEditObject()
        {   
            view.SiteName = editObject.SiteName;
            view.Group = editObject.Group;
            view.SiteAdmin = editObject.SiteAdmin;
            view.SiteRepresentative = editObject.SiteRepresentative;
            view.BEA = editObject.BEA;
        }

        protected void UpdateViewWithDefaults()
        {
            view.SiteName = string.Empty;
            view.Group = string.Empty;
            view.SiteAdmin = string.Empty;
            view.SiteRepresentative = string.Empty;
            view.BEA = string.Empty;
        }
    }

}