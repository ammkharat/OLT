
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using iTextSharp.text.pdf;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class GenericTemplateEmailApprovalPresenter
    {
        private readonly IGenericTemplateEmailConfigurationview view;
        private readonly IGenericTemplateService contractorService;
        private bool viewCloseNeedsConfirmation;
        private readonly Site site;
        private long formTypeId;
        private readonly long plantId;
        private string emaillist;
        private List<GenericTemplateEmailApprovalConfiguration> eFormTypeList;
        public GenericTemplateEmailApprovalPresenter(IGenericTemplateEmailConfigurationview view) :
            this(view, ClientServiceRegistry.Instance.GetService<IGenericTemplateService>())
        {

        }
        public void RegisterToViewEvents()
        {
            view.Load += HandleLoad;
            view.ContractorInformationChanged += HandleContractorInformationChanged;
            view.Add += HandleAddOrUpdate;
            view.UpdateEmail += HandleUpdate;
            view.Delete += HandleDelete;
            view.Clear += HandleClear;
            view.ContractorSelected += HandleContractorSelected;
            view.EFormTypeChanged += HandleEFormChanged;
            view.EFormRoleChanged += HandleERoleChnaged;
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
        private void ContractorInformationChanged()
        {
            string contractorName = view.ContractorName;

            if (contractorName.HasValue())
            {
                view.AddEnabled = true;
                view.ClearEnabled = true;
            }
            else
            {
                view.AddEnabled = false;
                view.ClearEnabled = false;
            }

            view.UpdateEnabled = false;
        }
        private void HandleAddOrUpdate(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        private void HandleUpdate(object sender, EventArgs e)
        {
            UpdateEmail();

        }

        private void UpdateEmail()
        {
            long? ID = long.Parse(view.ContractorID);
            GenericTemplateEmailApprovalConfiguration selectedContractor=new GenericTemplateEmailApprovalConfiguration(ID,view.ContractorName,site,formTypeId,plantId,view.EmailList);

            contractorService.UpdateEmailApprover(selectedContractor);
        }
        private void AddOrUpdate()
        
        {

          //  ContractorSelected();

            GenericTemplateEmailApprovalConfiguration selectedContractor; //;= view.SelectedContractor;
            view.eFormType.FormTypeId = formTypeId;
            if (view.AddText=="Add")
            {
                HandleAdd();
            }
            else
            {
                selectedContractor = new GenericTemplateEmailApprovalConfiguration(view.ContractorName, site, formTypeId, plantId, view.EmailList);
                HandleUpdate(selectedContractor);
            }
        }
        private void HandleUpdate(GenericTemplateEmailApprovalConfiguration selectedContractor)
        {
           //IList<GenericTemplateEmailApprovalConfiguration> contractors = view.Contractors;
           //contractors.Remove(selectedContractor);
           //selectedContractor.CompanyName = view.ContractorName;
           // AddContractorWithDuplicateCheck(contractors, selectedContractor);
           // viewCloseNeedsConfirmation = false;
            //AddUpdate();

            
        }
        
        private void HandleAdd()
        {
            if (formTypeId == 0)
            {
                view.ShowWarningMessage(StringResources.SameFormType, string.Empty);
                return;
            }

            var newContractor = new GenericTemplateEmailApprovalConfiguration(view.ContractorName, site, formTypeId, plantId,view.EmailList);
            IList<GenericTemplateEmailApprovalConfiguration> contractors = view.Contractors;
            AddContractorWithDuplicateCheck(contractors, newContractor);
            viewCloseNeedsConfirmation = false;
        }
        private void AddContractorWithDuplicateCheck(IList<GenericTemplateEmailApprovalConfiguration> contractors, GenericTemplateEmailApprovalConfiguration newContractor)
        {
            if (contractors.Exists(
                existingContractor => existingContractor.CompanyName.TrimAndEqual(newContractor.CompanyName)))
            {
                var title = String.Format(StringResources.DuplicateEFormTitle, Convert.ToString(FormGenericTemplate.getEdmontonFormType(formTypeId)));
                view.ShowWarningMessage(StringResources.DuplicateEFormMessage, title);
            }
            else
            {
               
                contractors.Clear();
                contractors.Add(newContractor);
                view.Contractors = contractors;
                AddUpdate();
            }
            view.Contractors = contractorService.QueryByEmailSite(site, formTypeId);
            Clear();
        }
        private void Clear()
        {
          //  view.ContractorName = string.Empty;
            view.ClearSelectedContractor();
            DisableActions();
        }
        private void DisableActions()
        {
            view.AddEnabled = false;
            view.UpdateEnabled = true;
            view.ClearEnabled = false;

            //view.AddUpdateText = StringResources.AddButtonLabel;
        }

        private void EnableActions()
        {
            view.AddEnabled = true;
            view.UpdateEnabled = false;
            view.ClearEnabled = true;

            //view.AddUpdateText = StringResources.AddButtonLabel;
        }
        private void AddUpdate()
        {
          
            contractorService.UpdateContractorsEmail(site, view.Contractors, plantId, formTypeId);
        }
        private void HandleDelete(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            //IList<GenericTemplateApproval> contractors = view.Contractors;
            //contractors.Remove(view.SelectedContractor);
            //view.Contractors = contractors;

            //viewCloseNeedsConfirmation = true;
            //Clear();
            //AddUpdate();

            contractorService.DeleteFormApproverEmail(view.SelectedContractor);
            view.Contractors = contractorService.QueryByEmailSite(site,formTypeId);
            Clear();
        }
        private void HandleClear(object sender, EventArgs e)
        {
            Clear();
        }
        private void HandleContractorSelected(object sender, EventArgs e)
        {
            ContractorSelected();
        }
        private void ContractorSelected()
        {
            GenericTemplateEmailApprovalConfiguration selectedContractor = view.SelectedContractor;
            if (selectedContractor != null)
            {
               // view.ContractorName = selectedContractor.CompanyName;

               
                //view.AddUpdateText = StringResources.UpdateButtonLabel;
                view.Contractors = contractorService.QueryByEmailSite(site, formTypeId);

                var approverName = view.Contractors.FirstOrDefault(x => x.CompanyName == selectedContractor.CompanyName);

                string contractorID = Convert.ToString(approverName.Id);
                string emaillist = Convert.ToString(approverName.EmailList);
                string companyName = Convert.ToString(approverName.CompanyName);


                view.EmailList = emaillist;
                view.ContractorID = contractorID;
                view.lblApprovertextvisibe = true;
                view.lblApproveText = approverName.CompanyName;
              //  view.ContractorName = companyName;
                //view.Contractors = companyName;
                if (approverName.CompanyName == view.ContractorName)
                {
                    view.AddEnabled = false;
                    view.UpdateEnabled = true;
                    view.ClearEnabled = true;


                }
                else
                {
                    view.AddEnabled = true;
                    view.UpdateEnabled = false;
                    view.ClearEnabled = true;
                   // view.lblApprovelongtext = string.Empty;
                   // view.lblApproveText = string.Empty;
                  //  view.ContractorID = string.Empty;
                }
                
         
               // view.ShowneverEnd = selectedContractor.ShowneverEnd;
              //  view.SelectedContractor = new GenericTemplateEmailApprovalConfiguration(approverName.Id,approverName.CompanyName,approverName.Site,approverName.FormTypeId,approverName.PlantId,approverName.EmailList); //(GenericTemplateEmailApprovalConfiguration)approverName;
                //string EmailList = contractorService.QueryEmailListApproverBySite(site, selectedContractor.FormTypeId,selectedContractor.CompanyName);
            }
        }

        private void HandleSave(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //DMND0009363-#950321920-Mukesh
            GenericTemplateEmailApprovalConfiguration objTemplate = new GenericTemplateEmailApprovalConfiguration("", site, formTypeId, plantId,emaillist);
            objTemplate.ShowneverEnd = view.ShowneverEnd;
            contractorService.UpdateTemplateHeaderEmail(objTemplate);
            //End DMND0009363-#950321920-Mukesh

            viewCloseNeedsConfirmation = false;
            view.Close();
        }
        private void HandleViewClosing(object sender, FormClosingEventArgs e)
        {
            ViewClosing(e);
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

        private void HandleEFormChanged(object sender, EventArgs e)
        {
            EFormTypeChanged();
        }
        private void EFormTypeChanged()
        {
            if (view.eFormType != null)
            {
                formTypeId = view.eFormType.FormTypeId;
                if (formTypeId == 3)
                {
                  view.Contractors = contractorService.QueryByEmailSite(site, formTypeId);
                    //DMND0009363-#950321920-Mukesh
                   // view.ShowneverEnd = eFormTypeList.Find(E => E.FormTypeId == formTypeId).ShowneverEnd;
                    if (string.IsNullOrEmpty(view.EmailList) || string.IsNullOrWhiteSpace(view.EmailList))
                    {
                        view.cmbApproverEnabled = true;
                        view.AddEnabled = true;
                        view.UpdateEnabled = false;
                    }
                    else
                    {
                        view.cmbApproverEnabled = true;
                        view.AddEnabled = false;
                        view.UpdateEnabled = true;
                    }

                    // view.groupBoxenabled = true;
                }
               else if (formTypeId == 11)
               {
                   
               }
                else
                {
                    view.cmbApproverEnabled = false;
                    view.AddEnabled = false;
                    view.UpdateEnabled = false;
                   // view.groupBoxenabled = false;
                }

            }
        }

        private void HandleERoleChnaged(object sender, EventArgs e)
        {
           EFormRoleChanged();

        }

        private void EFormRoleChanged()
        {
            var companyName = view.ContractorName;
             formTypeId = view.eFormType.FormTypeId;
            if (formTypeId == 3)
            {
                view.Contractors = contractorService.QueryByEmailSite(site, formTypeId);
                var itemList = view.Contractors.Find(x => x.CompanyName == companyName);
                if (itemList != null)
                {
                    view.AddEnabled = false;
                    view.UpdateEnabled = true;
                    view.EmailList = itemList.EmailList;
                    view.ContractorID = Convert.ToString(itemList.IdValue);
                }
                else
                {
                    view.EmailList = ""; 
                    view.AddEnabled = true;
                    view.UpdateEnabled = false;
                }

                
            }
            else if (formTypeId == 11)
            {
                
                List<string> strContractorname= new List<string>();
                strContractorname.Add("");
            }
            else
            {
                view.cmbApproverEnabled = false;
                view.AddEnabled = false;
                view.UpdateEnabled = false;
            }
            //new GenericTemplateEmailApprovalConfiguration(view.ContractorName, site, formTypeId, plantId,view.EmailList);
            //IList<GenericTemplateEmailApprovalConfiguration> contractors = view.Contractors;
            //bool exists =
            //    contractors.Exists(
            //        existingContractor => existingContractor.CompanyName.TrimAndEqual(companyName));
            //if (view.eRoleType != null && exists)
            //{

            //    view.AddEnabled = false;
            //    view.UpdateEnabled = true;
            //    view.ClearEnabled = true;

            //}
            //else
            //{
            //    view.EmailList = string.Empty;
            //    view.AddEnabled = true;
            //    view.UpdateEnabled = false;
            //    view.ClearEnabled = true;
            //    view.lblApproveText = string.Empty;
            //   // view.lblApprovelongtext = string.Empty;
            //    view.ContractorID = string.Empty;
            //}



            
        }

        public GenericTemplateEmailApprovalPresenter(IGenericTemplateEmailConfigurationview view, IGenericTemplateService contractorService)
        {
            this.view = view;
            this.contractorService = contractorService;
            viewCloseNeedsConfirmation = false;
            site = ClientSession.GetUserContext().Site;
            plantId = 0; //site.Plants[0].IdValue;ppanigrahi bydefault plantId=0
        }
        public static string CreateLockIdentifier(Site site)
        {
            return "Configure e- Forms approval: " + site.Id;
        }

        private void LoadView()
        {
                
            view.ContractorSite = site;
            //This can be manged by creating seprate class instead of db as in FormGernericTemplateContext class we are getting forms name by StringResources.
            eFormTypeList = contractorService.QueryFormGenericTemplateEmailEFormsBySite(site);
            SetupEFormTypeList();
            DisableActions();
        }
        private void SetupEFormTypeList()
        {
            
            eFormTypeList.Sort(c => c.CompanyName);
            eFormTypeList.Insert(0, GenericTemplateEmailApprovalConfiguration.NULL);
            view.AllEFormType = eFormTypeList;
        }

    }
}