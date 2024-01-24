using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureSiteCommunicationsPresenter : BaseFormPresenter<IConfigureSiteCommunicationsView>
    {
        private readonly ISiteCommunicationService siteCommunicationService;
        private List<SiteCommunication> siteCommunications;

        public ConfigureSiteCommunicationsPresenter(IConfigureSiteCommunicationsView view)
            : base(view)
        {
            siteCommunicationService = ClientServiceRegistry.Instance.GetService<ISiteCommunicationService>();

            view.Load += HandleViewLoad;
            view.AddSiteCommunication += HandleAddSiteCommunication;
            view.EditSiteCommunication += HandleEditSiteCommunication;
            view.DeleteSiteCommunication += HandleDeleteSiteCommunication;
            view.SelectedSiteCommunicationChanged += HandleSelectedSiteCommunicationChanged;
        }

        private void HandleSelectedSiteCommunicationChanged()
        {
            if (view.SelectedSiteCommunication == null)
            {
                view.EditButtonEnabled = false;
                view.DeleteButtonEnabled = false;
            }
            else
            {
                view.EditButtonEnabled = true;
                view.DeleteButtonEnabled = true;
            }
        }

        private void HandleViewLoad(object sender, EventArgs e)
        {
            if (ClientSession.GetUserContext().UserRoleElements.Role.Name == "Technical Administrator")     //ayman site communication
            {
               
                this.siteCommunications = siteCommunicationService.QueryAll();
                SortAndSetValuesOnGrid();
                view.SelectFirstValue();
            }
            else
            {
                this.siteCommunications = siteCommunicationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);    
            }

            SortAndSetValuesOnGrid();
            view.SelectFirstValue();

            HandleSelectedSiteCommunicationChanged();
        }

        private void HandleAddSiteCommunication()
        {
            AddEditSiteCommunicationForm addEditForm = new AddEditSiteCommunicationForm();
            
            DialogResult dialogResult = addEditForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                
                siteCommunications = addEditForm.SiteCommunication;         //ayman site communication
                SortAndSetValuesOnGrid();
                view.SelectedSiteCommunication = addEditForm.SiteCommunication[0];          //ayman site communication
            }

            addEditForm.Dispose();
        }

        private void HandleEditSiteCommunication()
        {
            SiteCommunication selectedSiteCommunication = view.SelectedSiteCommunication;

            if (selectedSiteCommunication != null)
            {
                //ayman site communication
                List<SiteCommunication> siteCommunications = new List<SiteCommunication>();
                siteCommunications.Add(selectedSiteCommunication);

                AddEditSiteCommunicationForm addEditForm = new AddEditSiteCommunicationForm(siteCommunications);
                addEditForm.ShowDialog();
                addEditForm.Dispose();

                SortAndSetValuesOnGrid();
                view.SelectedSiteCommunication = selectedSiteCommunication;
            }
        }

        private void SortAndSetValuesOnGrid()
        {
            siteCommunications.Sort((sc1, sc2) => sc2.StartDateTime.CompareTo(sc1.StartDateTime));
            view.SiteCommunications = siteCommunications;
        }

        private void HandleDeleteSiteCommunication()
        {

            //ayman site communication
            if (view.DeleteAllChecked)
            {
                foreach (SiteCommunication sitecomm in siteCommunications)
                {
                    if (sitecomm != null)
                    {
                        siteCommunicationService.Remove(sitecomm);
                    }
                }
                siteCommunications.RemoveAll(sitecomm => sitecomm.SiteId > 0);
                SortAndSetValuesOnGrid();
                view.SelectFirstValue();
            }
            else
            {

                SiteCommunication selectedSiteCommunication = view.SelectedSiteCommunication;

                if (selectedSiteCommunication != null && view.UserIsSureTheyWantToDelete())
                {
                    siteCommunicationService.Remove(selectedSiteCommunication);
                    siteCommunications.Remove(selectedSiteCommunication);
                    SortAndSetValuesOnGrid();
                    view.SelectFirstValue();
                }
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return String.Format("Configure Site Communications - {0}", site.IdValue);
        }
    }
}
