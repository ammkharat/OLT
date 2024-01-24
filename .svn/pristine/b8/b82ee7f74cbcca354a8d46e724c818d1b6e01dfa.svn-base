using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CokerCardConfigurationPresenter
    {
        private readonly ICokerCardConfigurationFormView view;
        private readonly ICokerCardService cokerCardService;

        public CokerCardConfigurationPresenter(ICokerCardConfigurationFormView view)
        {
            this.view = view;

            cokerCardService = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
        }

        public void Load(object sender, EventArgs e)
        {
            ReloadGrid();
            view.SelectFirstRow();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            view.LaunchEditConfigurationForm(null);
            ReloadGrid();
            view.SelectFirstRow();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            CokerCardConfiguration selected = view.SelectedItem;

            if (selected != null)
            {                
                view.LaunchEditConfigurationForm(selected);
                ReloadGrid();
                view.SelectFirstRow();
            }
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            CokerCardConfiguration selectedItem = view.SelectedItem;
            if (selectedItem != null)
            {
                if (view.UserIsSure())
                {
                    cokerCardService.RemoveCokerCardConfiguration(selectedItem);
                    ReloadGrid();
                    view.SelectFirstRow();
                }
            }          
        }

        public void CloseButton_Clicked(object sender, EventArgs e)
        {
            view.Close();
        }

        private void ReloadGrid()
        {
            List<CokerCardConfiguration> configurations =
                cokerCardService.QueryCokerCardConfigurationsBySite(ClientSession.GetUserContext().Site); 

            view.CokerCardConfigurations = configurations;
        }
       
        public static string CreateLockIdentifier(Site site)
        {
            return "Coker Card Configuration Form, Site Id: " + site.IdValue;
        }
    }
}
