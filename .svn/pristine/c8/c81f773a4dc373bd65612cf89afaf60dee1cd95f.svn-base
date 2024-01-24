using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EmailToRecipientsPresenter
    {
        private readonly IShiftHandoverConfigurationForm view;
        private readonly IShiftHandoverService shiftHandoverService;        

        public EmailToRecipientsPresenter(IShiftHandoverConfigurationForm view)
        {
            this.view = view;           
            shiftHandoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();            
        }

        public void Load(object sender, EventArgs e)
        {      
            ReloadGrid();
            view.SelectFirstRow();
        }

        private void ReloadGrid()
        {
            List<ShiftHandoverConfigurationDTO> configurations =
                shiftHandoverService.QueryShiftHandoverConfigurationDTOsBySite(ClientSession.GetUserContext().SiteId);

            view.ShiftHandoverConfigurationDTOs = configurations;            
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Shift Handover Configuration Form, Site Id: " + site.Id.Value);
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            view.LaunchEditShiftHandoverConfigurationForm(null);
            ReloadGrid();
            view.SelectFirstRow();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            ShiftHandoverConfigurationDTO selected = view.SelectedItem;

            if (selected != null)
            {
                ShiftHandoverConfiguration configuration = shiftHandoverService.QueryShiftHandoverConfigurationsById(selected.Id.Value);
                view.LaunchEditShiftHandoverConfigurationForm(configuration);
                ReloadGrid();
                view.SelectFirstRow();
            }
        }

        public void RemoveButton_Click(object sender, EventArgs e)
        {
            ShiftHandoverConfigurationDTO configurationDTO = view.SelectedItem;
            if (configurationDTO != null)
            {
                if(view.UserIsSure())
                {
                    shiftHandoverService.DeleteShiftHandoverConfiguration(configurationDTO.Id.Value);
                    ReloadGrid();
                    view.SelectFirstRow();                    
                }
            }            
        }

        public void CloseButton_Clicked(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}
