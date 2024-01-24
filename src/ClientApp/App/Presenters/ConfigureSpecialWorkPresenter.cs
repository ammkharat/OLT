using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureSpecialWorkPresenter
    {
        private readonly IConfigureSpecialWorkView view;
        private readonly ISpecialWorkService contractorService;
        private bool viewCloseNeedsConfirmation;
        private readonly Site site;

        public ConfigureSpecialWorkPresenter(IConfigureSpecialWorkView view) : 
            this(view, ClientServiceRegistry.Instance.GetService<ISpecialWorkService>())
        {
        }

        public ConfigureSpecialWorkPresenter(IConfigureSpecialWorkView view, ISpecialWorkService contractorService)
        {
            this.view = view;
            this.contractorService = contractorService;
            viewCloseNeedsConfirmation = false;
            site = ClientSession.GetUserContext().Site;
        }
        
        public void LoadView()
        {
            view.ContractorSite = site;
            view.Contractors = contractorService.QueryBySite(site);
            DisableActions();
        }

        public void ContractorInformationChanged()
        {
            string contractorName = view.ContractorName;

            if (contractorName.HasValue())
            {
                view.AddOrUpdateEnabled = true;
                view.ClearEnabled = true;
            }
            else
            {
                view.AddOrUpdateEnabled = false;
                view.ClearEnabled = false;
            }

            view.DeleteEnabled = false;
        }

        public void AddOrUpdate()
        {
            SpecialWork selectedContractor = view.SelectedContractor;
            
            if (selectedContractor == null)
            {
                HandleAdd();
            }
            else
            {
                HandleUpdate(selectedContractor);
            }
        }

        public void Clear()
        {
            view.ContractorName = string.Empty;
            view.ClearSelectedContractor();
            DisableActions();
        }

        public void ContractorSelected()
        {
            SpecialWork selectedContractor = view.SelectedContractor;
            if (selectedContractor != null)
            {
                view.ContractorName = selectedContractor.CompanyName;

                view.AddOrUpdateEnabled = true;
                view.DeleteEnabled = true;
                view.ClearEnabled = true;

                view.AddUpdateText = StringResources.UpdateButtonLabel;
            }
        }

        public void Delete()
        {
            IList<SpecialWork> contractors = view.Contractors;
            contractors.Remove(view.SelectedContractor);
            view.Contractors = contractors;

            viewCloseNeedsConfirmation = true;
            Clear();
        }

        public void Save()
        {
            contractorService.UpdateContractors(site, view.Contractors);

            viewCloseNeedsConfirmation = false;
            view.Close();
        }

        public void ViewClosing(FormClosingEventArgs e)
        {
            if (ViewShouldBeClosed() == false)
            {
                e.Cancel = true;
            }
        }

        private bool ViewShouldBeClosed()
        {
            return !viewCloseNeedsConfirmation ||
                   view.ConfirmCancelDialog();
        }

        private void HandleAdd()
        {
            var newContractor = new SpecialWork(view.ContractorName, site);

            IList<SpecialWork> contractors = view.Contractors;

            AddContractorWithDuplicateCheck(contractors, newContractor);

            viewCloseNeedsConfirmation = true;
        }

        private void AddContractorWithDuplicateCheck(IList<SpecialWork> contractors, SpecialWork newContractor)
        {
            if (contractors.Exists(
                existingContractor => existingContractor.CompanyName.TrimAndEqual(newContractor.CompanyName)))
            {
                view.ShowWarningMessage(StringResources.DuplicateSpecialWorkMessage, StringResources.DuplicateSpecialWorkTitle);
            }
            else
            {
                contractors.Add(newContractor);
                view.Contractors = contractors;

                Clear();
            }
        }

        private void HandleUpdate(SpecialWork selectedContractor)
        {
            IList<SpecialWork> contractors = view.Contractors;

            contractors.Remove(selectedContractor);

            selectedContractor.CompanyName = view.ContractorName;
            AddContractorWithDuplicateCheck(contractors, selectedContractor);

            viewCloseNeedsConfirmation = true;
        }

        private void DisableActions()
        {
            view.AddOrUpdateEnabled = false;
            view.DeleteEnabled = false;
            view.ClearEnabled = false;

            view.AddUpdateText = StringResources.AddButtonLabel;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Work Permit Special Work: " + site.Id;
        }

        public void RegisterToViewEvents()
        {
            view.Load += HandleLoad;
            view.ContractorInformationChanged += HandleContractorInformationChanged;
            view.AddOrUpdate += HandleAddOrUpdate;
            view.Delete += HandleDelete;
            view.Clear += HandleClear;
            view.ContractorSelected += HandleContractorSelected;
            view.Save += HandleSave;
            view.ViewClosing += HandleViewClosing;
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            LoadView();
        }

        public void HandleContractorInformationChanged(object sender, EventArgs e)
        {
            ContractorInformationChanged();
        }

        public void HandleAddOrUpdate(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        public void HandleDelete(object sender, EventArgs e)
        {
            Delete();
        }

        public void HandleClear(object sender, EventArgs e)
        {
            Clear();
        }

        public void HandleContractorSelected(object sender, EventArgs e)
        {
            ContractorSelected();
        }

        public void HandleSave(object sender, EventArgs e)
        {
            Save();
        }

        public void HandleViewClosing(object sender, FormClosingEventArgs e)
        {
            ViewClosing(e);
        }
    }
}
