using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureGenericTemplateApprovalPresenter
    {
        private readonly IConfigureGenericTemplateApprovalView view;
        private readonly IGenericTemplateService contractorService;
        private bool viewCloseNeedsConfirmation;
        private readonly Site site;
        private long formTypeId;
        private readonly long plantId;
        private List<GenericTemplateApproval> eFormTypeList;

        public ConfigureGenericTemplateApprovalPresenter(IConfigureGenericTemplateApprovalView view) : 
            this(view, ClientServiceRegistry.Instance.GetService<IGenericTemplateService>())
        {
        }

        private ConfigureGenericTemplateApprovalPresenter(IConfigureGenericTemplateApprovalView view, IGenericTemplateService contractorService)
        {
            this.view = view;
            this.contractorService = contractorService;
            viewCloseNeedsConfirmation = false;
            site = ClientSession.GetUserContext().Site;
            plantId = site.Plants[0].IdValue;//INC0251500 - mangesh
        }
        
        private void LoadView()
        {
            view.ContractorSite = site;
            //This can be manged by creating seprate class instead of db as in FormGernericTemplateContext class we are getting forms name by StringResources.
            eFormTypeList = contractorService.QueryForEGenericForms(site, plantId);
            SetupEFormTypeList();
            DisableActions();
        }
        
        private void SetupEFormTypeList()
        {   
            eFormTypeList.Sort(c => c.CompanyName);
            eFormTypeList.Insert(0, GenericTemplateApproval.NULL);
            view.AllEFormType = eFormTypeList;
        }


        private void EFormTypeChanged()
        {
            if (view.eFormType != null)
            {
                formTypeId = view.eFormType.FormTypeId;
                view.Contractors = contractorService.QueryBySite(site, plantId, formTypeId);
               //DMND0009363-#950321920-Mukesh
              view.ShowneverEnd= eFormTypeList.Find(E => E.FormTypeId == formTypeId).ShowneverEnd;
               
            }
        }


        private void ContractorInformationChanged()
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

        private void AddOrUpdate()
        {
            GenericTemplateApproval selectedContractor = view.SelectedContractor;
            view.eFormType.FormTypeId = formTypeId;
            if (selectedContractor == null)
            {
                HandleAdd();
            }
            else
            {
                HandleUpdate(selectedContractor);
            }
        }

        private void Clear()
        {
            view.ContractorName = string.Empty;
            view.ClearSelectedContractor();
            DisableActions();
        }

        private void ContractorSelected()
        {
            GenericTemplateApproval selectedContractor = view.SelectedContractor;
            if (selectedContractor != null)
            {
                view.ContractorName = selectedContractor.CompanyName;

                view.AddOrUpdateEnabled = true;
                view.DeleteEnabled = true;
                view.ClearEnabled = true;

                view.AddUpdateText = StringResources.UpdateButtonLabel;

                //DMND0009363-#950321920-Mukesh
                view.ShowneverEnd = selectedContractor.ShowneverEnd;
            }
        }

        //INC0251500 - mangesh
        private void Delete()
        {
            //IList<GenericTemplateApproval> contractors = view.Contractors;
            //contractors.Remove(view.SelectedContractor);
            //view.Contractors = contractors;

            //viewCloseNeedsConfirmation = true;
            //Clear();
            //AddUpdate();

            contractorService.DeleteFormApprover(view.SelectedContractor);
            view.Contractors = contractorService.QueryBySite(site, plantId, formTypeId);
            Clear();
        }

        private void Save()
        {
            //DMND0009363-#950321920-Mukesh
            GenericTemplateApproval objTemplate = new GenericTemplateApproval("", site, formTypeId, plantId);
            objTemplate.ShowneverEnd=view.ShowneverEnd;
            contractorService.UpdateTemplateHeader(objTemplate);
            //End DMND0009363-#950321920-Mukesh
           
            viewCloseNeedsConfirmation = false;
            view.Close();
        }
        
        private void ViewClosing(FormClosingEventArgs e)
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
            if (formTypeId == 0)
            {
                view.ShowWarningMessage(StringResources.SameFormType, string.Empty);
                return;
            }

            var newContractor = new GenericTemplateApproval(view.ContractorName, site, formTypeId, plantId);
            IList<GenericTemplateApproval> contractors = view.Contractors;
            AddContractorWithDuplicateCheck(contractors, newContractor);
            viewCloseNeedsConfirmation = false;
        }

        private void AddContractorWithDuplicateCheck(IList<GenericTemplateApproval> contractors, GenericTemplateApproval newContractor)
        {
            if (contractors.Exists(
                existingContractor => existingContractor.CompanyName.TrimAndEqual(newContractor.CompanyName)))
            {
                var title = String.Format(StringResources.DuplicateEFormTitle, Convert.ToString(FormGenericTemplate.getEdmontonFormType(formTypeId)));
                view.ShowWarningMessage(StringResources.DuplicateEFormMessage, title);
            }
            else
            {
                //INC0251500 - mangesh
                contractors.Clear();
                contractors.Add(newContractor);
                view.Contractors = contractors;
                AddUpdate();
            }
            view.Contractors = contractorService.QueryBySite(site, plantId, formTypeId);
            Clear();
        }

        private void HandleUpdate(GenericTemplateApproval selectedContractor)
        {
            IList<GenericTemplateApproval> contractors = view.Contractors;
            contractors.Remove(selectedContractor);
            selectedContractor.CompanyName = view.ContractorName;
            AddContractorWithDuplicateCheck(contractors, selectedContractor);
            viewCloseNeedsConfirmation = false;
            //AddUpdate();
        }

        private void AddUpdate()
        {
            contractorService.UpdateContractors(site, view.Contractors, plantId, formTypeId);
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
            return "Configure e- Forms approval: " + site.Id;
        }

        public void RegisterToViewEvents()
        {
            view.Load += HandleLoad;
            view.ContractorInformationChanged += HandleContractorInformationChanged;
            view.AddOrUpdate += HandleAddOrUpdate;
            view.Delete += HandleDelete;
            view.Clear += HandleClear;
            view.ContractorSelected += HandleContractorSelected;
            view.EFormTypeChanged += HandleEFormChanged;
            view.Save += HandleSave;
            
            view.ViewClosing += HandleViewClosing;
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            LoadView();
        }

        private void HandleContractorInformationChanged(object sender, EventArgs e)
        {
            ContractorInformationChanged();
        }

        private void HandleAddOrUpdate(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        private void HandleDelete(object sender, EventArgs e)
        {
            Delete();
        }

        private void HandleClear(object sender, EventArgs e)
        {
            Clear();
        }

        private void HandleContractorSelected(object sender, EventArgs e)
        {
            ContractorSelected();
        }

        private void HandleSave(object sender, EventArgs e)
        {
            Save();
        }

        private void HandleViewClosing(object sender, FormClosingEventArgs e)
        {
            ViewClosing(e);
        }

        private void HandleEFormChanged(object sender, EventArgs e)
        {
            EFormTypeChanged();
        }
    }
}
