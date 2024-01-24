using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RestrictionLocationListConfigurationFormPresenter
    {
        private readonly IRestrictionLocationListConfigurationView view;
        private readonly IRestrictionLocationService service;
        private List<RestrictionLocation> allRestrictionLocations;

        public RestrictionLocationListConfigurationFormPresenter(IRestrictionLocationListConfigurationView view)
        {
            this.view = view;
            service = ClientServiceRegistry.Instance.GetService<IRestrictionLocationService>();
        }

        public void AddList()
        {
            AddRenameRestrictionLocationForm form = new AddRenameRestrictionLocationForm(allRestrictionLocations);
            form.ShowDialog();

            if (!form.ShouldAddOrUpdate)
            {
                return;
            }

            string nameOfNewRestrictionLocation = form.NameOfNewRestrictionLocation;
            RestrictionLocation restrictionLocation = new RestrictionLocation(nameOfNewRestrictionLocation, new List<WorkAssignment>(0), ClientSession.GetUserContext().User, Clock.Now,ClientSession.GetUserContext().SiteId);    //ayman restriction location

            service.Insert(restrictionLocation);

            RefreshList();
            view.SelectedRestrictionLocation = restrictionLocation;
        }

        public void RemoveList()
        {
            DialogResult result = OltMessageBox.ShowCustomYesNo("Are you sure you want to delete the entire Location List?");
            if (result == DialogResult.Yes)
            {
                RestrictionLocation selectedRestrictionLocation = view.SelectedRestrictionLocation;
                selectedRestrictionLocation.LastModifiedBy = ClientSession.GetUserContext().User;
                selectedRestrictionLocation.LastModifiedDateTime = Clock.Now;

                service.Remove(selectedRestrictionLocation);

                RefreshList();
            }
        }

        public void RenameList()
        {
            RestrictionLocation selectedRestrictionLocation = view.SelectedRestrictionLocation;

            AddRenameRestrictionLocationForm form = new AddRenameRestrictionLocationForm(allRestrictionLocations, selectedRestrictionLocation);
            form.ShowDialog();

            if (!form.ShouldAddOrUpdate)
            {
                return;
            }

            string nameOfNewRestrictionLocation = form.NameOfNewRestrictionLocation;
            selectedRestrictionLocation.Name = nameOfNewRestrictionLocation;
            selectedRestrictionLocation.LastModifiedBy = ClientSession.GetUserContext().User;
            selectedRestrictionLocation.LastModifiedDateTime = Clock.Now;

            service.Update(selectedRestrictionLocation);

            RefreshList();
        }

        public void EditList()
        {
            RestrictionLocation selectedRestrictionLocation = view.SelectedRestrictionLocation;
            if (selectedRestrictionLocation != null)
            {
                RestrictionLocationConfigurationForm form = new RestrictionLocationConfigurationForm(selectedRestrictionLocation.IdValue);
                form.ShowDialog();
            }
        }

        public static string CreateLockIdentifier()
        {
            return "Restriction Location Form";
        }

        public void HandleLoad()
        {
            RefreshList();
        }

        private void RefreshList()
        {

            allRestrictionLocations = service.QueryAll(ClientSession.GetUserContext().SiteId);   //ayman restriction
            view.RestrictionLocationList = allRestrictionLocations;
        }

        
    }
}