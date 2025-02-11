﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormOP14FormPresenter : AbstractFormEdmontonFormPresenter<FormOP14, IFormOP14View>
    {
        
        private readonly IFormEdmontonService service;
        private FormTemplate formTemplate;
        private List<FormApproval> approvals = new List<FormApproval>();      //ayman Sarnia eip DMND0008992
        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string originalPlainTextContent;
        private List<FunctionalLocation> originalFlocs;
        private FormOP14Department originalDepartment;
        private bool originalPressureSafetyValveAnswer;
        private string originalCriticalSystemDefeated;
        private static IFormGenericTemplateService service1;//Added by ppanigrahi
        private readonly IReportPrintManager<FormOP14> reportPrintManager;//Added by ppanigrahi
        private List<string> originalListOfApprovers;

        private string buttontext;

        public FormOP14FormPresenter() : this(CreateDefaultForm())
        {
        }

        public FormOP14FormPresenter(FormOP14 form) : base(new FormOP14Form(), form)
        {
            SaveOriginalFormValues();

            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.FormLoad += HandleViewLoad;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.ExpandClicked += HandleExpandClicked;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked; // Swapnil Patki For DMND0005325 Point Number 7
            ApprovalRelatedEventsEnabled = true;
            PrintActions<FormOP14, FormOP14Report, FormOP14ReportAdapter> printActions = new FormOP14FormPrintActions();//Addedby ppanigrahi
            reportPrintManager = new ReportPrintManager<FormOP14, FormOP14Report, FormOP14ReportAdapter>(printActions);

           
        }

        //ayman waiting for approval button status
        private void UpdateWaitingForApprovalButtonStatus()
        {
            if (editObject.AllApprovalsAreIn())
            {
                view.DisableWaitingForApprovalButton();
            }
            else
            {
                view.EnableWaitingForApprovalButton();
            }
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> Approvals
        {
            get { return approvals; }
            set { approvals = value; }
        }

        //ayman Sarnia eip DMND0008992
        public virtual List<FormApproval> AllApprovals
        {
            get { return Approvals; }
        }

        //private void HandleApprovalSelected(FormApproval approval)
        //{
        //    UpdateWaitingForApprovalButtonStatus();
        //}

        //private void HandleApprovalUnselected(FormApproval approval)
        //{
        //    UpdateWaitingForApprovalButtonStatus();
        //}

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            originalDepartment = editObject.Department;
            originalPressureSafetyValveAnswer = editObject.IsTheCSDForAPressureSafetyValve;
            originalCriticalSystemDefeated = editObject.CriticalSystemDefeated;
            originalListOfApprovers = editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static FormOP14 CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;
            
            //ayman generic forms
            long siteid = ClientSession.GetUserContext().Site.IdValue;


            FormOP14 form = new FormOP14(null, FormStatus.Draft, now, now, currentUser, now,siteid);   //ayman generic forms
            form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            
            //ayman generic forms
            editObject.SiteId = userContext.SiteId;

            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.Department = view.Department;
            editObject.IsTheCSDForAPressureSafetyValve = view.IsTheCSDForAPressureSafetyValve;
            editObject.CriticalSystemDefeated = view.CriticalSystemDefeated;
            editObject.DocumentLinks = view.DocumentLinks;

            //INC0458108 : Added By Vibhor {Sarnia : Remove references to "OP-14" within form labels and menu items}
            if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                if (editObject != null && editObject.Id.HasValue)
                {
                    view.SetFormTitleName = StringResources.EditMode_SetFormTitleName_Sarnia;
                }
            }
            //END
           
            UpdateEditObjectApprovalsFromView();
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            List<FormApproval> viewApprovals = new List<FormApproval>(view.Approvals);
            viewApprovals.AddRange(editObject.Approvals.FindAll(approval => !approval.Enabled));
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            editObject.Approvals = viewApprovals;

            //TO disable approvalbased on role using Edmonton pipeline Tag from roleMatrix Mukesh
            if (ClientSession.GetUserContext().IsSarniaSite)
            {
                bool enableEdit = ClientSession.GetUserContext().UserRoleElements.HasRoleElement(RoleElement.Pipeline_CSD_APPROVAL);
                foreach (FormApproval app in viewApprovals)
                {
                    app.DisableEdit = !enableEdit;
                }
            }

            editObject.Approvals = viewApprovals;
        }

        protected override void ShowEmail()
        {
            if (ClientSession.GetUserContext().IsSarniaSite)
            {
                FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.OP14.Name.Replace("OP-14 ", ""), editObject.FormNumber);
            }
            else
            {
                FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.OP14.Name, editObject.FormNumber);
            }
        }

        private void UpdateViewFromEditObject()
        {
            ApprovalRelatedEventsEnabled = false;

            view.FunctionalLocations = editObject.FunctionalLocations;
            UpdateViewApprovalsFromEditObject();
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;

            view.Content = editObject.Content;
            view.DocumentLinks = editObject.DocumentLinks;

            view.Department = editObject.Department;
            view.IsTheCSDForAPressureSafetyValve = editObject.IsTheCSDForAPressureSafetyValve;
            view.CriticalSystemDefeated = editObject.CriticalSystemDefeated;

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            ApprovalRelatedEventsEnabled = true;

            //INC0458108 : Added By Vibhor {Sarnia : Remove references to "OP-14" within form labels and menu items}
            if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                view.SetFormTitleName = StringResources.SetFormTitleName_Sarnia;
            }
            //END

            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();
            UpdateWaitingForApprovalButtonStatus(); //ayman waiting for approval status
            }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()   
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertOP14, editObject);
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateOP14, editObject);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            buttontext = ((System.Windows.Forms.Control)(sender)).Name; // Swapnil Patki For DMND0005325 Point Number 7
            Save(false, buttontext);
        }

        private void HandleWaitingApprovalClicked() // Swapnil Patki For DMND0005325 Point Number 7
        {
            Save(false, buttontext);
            //Added by ppanigrahi for EmailApproval
            if (editObject.FormStatus == FormStatus.WaitingForApproval)
            {
                //Added by ppanigrahi  
                DateTime now = Clock.Now;
                User currentUser = ClientSession.GetUserContext().User;
                FormOP14 form = new FormOP14(null, FormStatus.WaitingForApproval, now, now, currentUser, now, editObject.SiteId, false);
                service1 = ClientServiceRegistry.Instance.GetService<IFormGenericTemplateService>();
                form.Approvals = service1.QueryByFormSarniaCsdApproverByIdAndSiteId(editObject.SiteId, 3, 0);
                List<FormApproval> op14Approvals = service1.QueryByFormOP14Id(editObject.FormNumber);

                FormOP14 domainObject = service.QueryFormOP14ByIdAndSiteId(editObject.FormNumber, editObject.SiteId);

               
                if (Clock.Now <= editObject.FromDateTime.AddDays(9) && Clock.Now <= editObject.ToDateTime)
                {
                    foreach (FormApproval formapproval in op14Approvals)
                    {

                        if (formapproval.Enabled)
                        {
                            var Approver = form.Approvals.FirstOrDefault(x => x.Approver == formapproval.Approver);

                          //  FormApproval aproval = service1.QueryByFormOP14Id(editObject.FormNumber, Approver.Approver);

                            if (Approver != null &&
                                ((Approver.Approver.ToString().ToLower().Contains("shift supervisor/delegate")) ||
                                 (Approver.Approver.ToString().ToLower().Contains("operations manager/delegate"))))
                            {
                                if (!formapproval.isMailSent)
                                {
                                    string emailList = Approver.EmailList;
                                    long approveroleId = service.QueryByFormOp14ApprovalId(editObject.Id,
                                        Approver.Approver);
                                    bool isMailSent = true;
                                    // long id = formapproval.Id;

                                    SentMail(formapproval, emailList, approveroleId, Approver.Approver, domainObject);

                                    int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);
                                }
                            }

                        }
                    }
                    
                }
                else if ((Clock.Now >= editObject.FromDateTime.AddDays(10) && Clock.Now < editObject.FromDateTime.AddDays(29)) && Clock.Now <= editObject.ToDateTime)
                {
                    foreach (FormApproval formapproval in op14Approvals)
                    {

                        if (formapproval.Enabled)
                        {
                            var Approver = form.Approvals.FirstOrDefault(x => x.Approver == formapproval.Approver);
                             if (Approver != null &&
                                    ((Approver.Approver.ToString().ToLower().Contains("operations manager ( >= 10 days)/delegate"))))
                                {
                                    if (!formapproval.isMailSent)
                                    {
                                        string emailList = Approver.EmailList;
                                        long approveroleId = service.QueryByFormOp14ApprovalId(editObject.Id,
                                            Approver.Approver);
                                        bool isMailSent = true;
                                        // long id = formapproval.Id;

                                        SentMail(formapproval, emailList, approveroleId, Approver.Approver, domainObject);

                                        int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);
                                    }
                                }
                            

                        }
                    }

                }
                else if ((Clock.Now >= editObject.FromDateTime.AddDays(30)) && Clock.Now <= editObject.ToDateTime)
                {
                    foreach (FormApproval formapproval in op14Approvals)
                    {

                        if (formapproval.Enabled)
                        {
                            var Approver = form.Approvals.FirstOrDefault(x => x.Approver == formapproval.Approver);
                            if (Approver != null && ((Approver.Approver.ToString().ToLower().Contains("operations director (> 30 days)/delegate")) && (Approver.Approver.ToString().ToLower().Contains("engineering director (> 30 days)"))))
                            {
                                if (!formapproval.isMailSent)
                                {
                                    string emailList = Approver.EmailList;
                                    long approveroleId = service.QueryByFormOp14ApprovalId(editObject.Id,
                                        Approver.Approver);
                                    bool isMailSent = true;
                                    // long id = formapproval.Id;

                                    SentMail(formapproval, emailList, approveroleId, Approver.Approver, domainObject);

                                    int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);
                                }
                            }

                        }
                    }

                }

                //foreach (FormApproval formapproval in editObject.Approvals)
                //{
                //    if (formapproval.Enabled)
                //    {
                //        var Approver = form.Approvals.FirstOrDefault(x => x.Approver == formapproval.Approver);
                //        if (Approver != null)
                //        {

                //            string emailList = Approver.EmailList;
                //            long approveroleId = service.QueryByFormOp14ApprovalId(editObject.Id,
                //                Approver.Approver);

                //            if (emailList != null)
                //            {
                //                List<EmailAddress> emailAdd =
                //                    EmailAddress.ConvertDelimitedListToEmailAddresses(emailList);



                //                foreach (EmailAddress em in emailAdd)
                //                {
                //                    int enabled;
                //                    string usernamestring = em.ToString();
                //                    string[] usernameList = usernamestring.Split('@');
                //                    var username = usernameList[0];
                //                    long userID = service.QueryUserId(username);
                //                    long? Id = approveroleId;
                //                    long ShouldBeEnabledBehaviourId = formapproval.ShouldBeEnabledBehaviourId;
                //                    bool Enabled = formapproval.Enabled;
                //                    if (Enabled)
                //                    {
                //                        enabled = 1;

                //                    }
                //                    else
                //                    {
                //                        enabled = 0;
                //                    }
                //                    long? FormOP14Id = editObject.Id;
                //                    // long FunctionalLocationId = editObject.FunctionalLocations.;
                //                    long? FormStatusId = 2; //editObject.FormStatus.Id;
                //                    string CriticalSystemDefeated = editObject.CriticalSystemDefeated;
                //                    long LastModifiedByUserId = userID;
                //                    long sitid = editObject.SiteId;
                //                    //var subjectText = EdmontonFormType.OP14.Name + " Form" + "#" +
                //                    //                  editObject.FormNumber +
                //                    //                  " is waiting for approval for Role " + Approver.Approver;
                //                    var subjectText = "Critical System Defeat  Form" + "#" +
                //                                      editObject.FormNumber +
                //                                      " is waiting for approval for Role " + Approver.Approver;
                //                    var messageBodyText = BuildBodyText(Id, userID, ShouldBeEnabledBehaviourId,
                //                        enabled,
                //                        FormOP14Id, FormStatusId, CriticalSystemDefeated, sitid);
                //                    var attachmentFilename = BuildAttachmentFilename(EdmontonFormType.OP14.Name,
                //                        editObject.FormNumber);

                //                    //var emails = emailAddresses.ToCommaSeparatedString();



                //                    reportPrintManager.Email(domainObject, em, messageBodyText, subjectText,
                //                        attachmentFilename, true);
                //                }
                //            }
                //        }
                //    }


                //}




            }

        }

        private void SentMail(FormApproval approval, string emailList, long approveroleId,string approver,FormOP14 domainObject)
        {
            if (emailList != null)
            {
                List<EmailAddress> emailAdd =
                    EmailAddress.ConvertDelimitedListToEmailAddresses(emailList);
                foreach (EmailAddress em in emailAdd)
                {
                    int enabled;
                    string usernamestring = em.ToString();
                    string[] usernameList = usernamestring.Split('@');
                    var username = usernameList[0];
                    long userID = service.QueryUserId(username);
                    long? Id = approveroleId;
                    long ShouldBeEnabledBehaviourId = approval.ShouldBeEnabledBehaviourId;
                    bool Enabled = approval.Enabled;
                    if (Enabled)
                    {
                        enabled = 1;

                    }
                    else
                    {
                        enabled = 0;
                    }
                    long? FormOP14Id = editObject.Id;
                    // long FunctionalLocationId = editObject.FunctionalLocations.;
                    long? FormStatusId = 2; //editObject.FormStatus.Id;
                    string CriticalSystemDefeated = editObject.CriticalSystemDefeated;
                    long LastModifiedByUserId = userID;
                    long sitid = editObject.SiteId;
                    //var subjectText = EdmontonFormType.OP14.Name + " Form" + "#" +
                    //                  editObject.FormNumber +
                    //                  " is waiting for approval for Role " + Approver.Approver;
                    var subjectText = "Critical System Defeat  Form" + "#" +
                                      editObject.FormNumber +
                                      " is waiting for approval for Role " + approver;
                    var messageBodyText = BuildBodyText(Id, userID, ShouldBeEnabledBehaviourId,
                        enabled,
                        FormOP14Id, FormStatusId, CriticalSystemDefeated, sitid,approver);
                    var attachmentFilename = BuildAttachmentFilename(EdmontonFormType.OP14.Name,
                        editObject.FormNumber);

                    //var emails = emailAddresses.ToCommaSeparatedString();



                    reportPrintManager.Email(domainObject, em, messageBodyText, subjectText,
                        attachmentFilename, true);
                }
            }

        }

        private string BuildBodyText(long? id, long userid, long shouldBeEnabledBehaviourId, int enabled, long? formOp14Id, long? formStatusId, string criticalSystemDefeated, long sitid,string approver)
        {
            // var introText = "OP-14 Critical System Defeat Form#" + editObject.FormNumber + " is waiting for approval. Please log into OLT to review and approve.\n\n" + "Review the change prior to approving.";

            //string introText = "<body>"+
            //        " OP-14 Critical System Defeat Form#"+editObject.FormNumber+"is waiting for approval."+"<br/><br/> Please check the document prior to approving.<br/><br/><br/>"+
            //        "<button id=\"btnAccept\" type=\"button\" value=\"button\">Accept</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+
            //        "<button id=\"btnReject\" type=\"button\" value=\"button\">Reject</button>"+
            //       "</body>";


            string remoteServicesURL = ConfigurationManager.AppSettings["RemoteServicesURL"].ToString();
            string introText = "<!DOCTYPE html>" +
                               "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
                               "<head>" +
                              "<div>" +
                                "Critical System Defeat Form#" + editObject.FormNumber + " is waiting for approval." + "<br/><br/> Please check the document prior to approving.<br/><br/><br/>" +
                               "<a href=\"" + remoteServicesURL + "/EmailApprove.aspx?ID=" + formOp14Id + "&reqid=" + id + "&approvedByUserId=" + userid + "&shouldBeEnabledBehaviourId=" + shouldBeEnabledBehaviourId + "&enabled=" + enabled +"&approver="+approver +"\"" + " target=\"_blank\"" + ">" + "Click here to Approve or Reject CSD#" + editObject.FormNumber + "</a>" + "<br/><br/>" +
                               "</div>" +

                               "</body>" +

                               "</html>";
            //var workAssignments = configuration.WorkAsosignments;

            var builder = new StringBuilder();

            builder.AppendLine(introText);
            builder.AppendLine();



            return builder.ToString();
        }
        private string BuildAttachmentFilename(string Name, long number)
        {
            return String.Format("{0}_{1}.pdf", Name, number);

        }

        private void Save(bool showEmail, string buttontext)
        {
            if (Validate())
            {
                return;
            }
            /*RITM0265746 - Sarnia CSD marked as read start*/
            if (IsEdit && service.UserMarkedFormOp14AsRead(editObject.FormNumber, null, Convert.ToInt64(ClientSession.GetUserContext().UserShift.ShiftPatternId)).Count > 0) //if record is edited and Mark as read count is grated than 0
            {
                if ((!view.ShowLogMarkedAsReadWarning()))
                {
                    return;
                }
            }
            /*RITM0265746 - Sarnia CSD marked as read end*/
            UpdateEditObjectFromView();
            
            bool formWillNeedReapproval = FormWillNeedReapproval();

            if (IsEdit && !formWillNeedReapproval && NewApproversWereAddedButNotApproved())
            {
                DialogResult result = view.ShowFormHasAdditionalApproversRequired();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;

                    SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext);
                }
            }
            else if (IsEdit && formWillNeedReapproval)
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;

                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User, view.Approvals);
                    SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext);
                }
            }
            else
            {
                SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext);
            }
        }

        private bool NewApproversWereAddedButNotApproved()
        {
            List<string> currentUnapprovedApprovers = editObject.Approvals.FindAll(approval => approval.Enabled && !approval.IsApproved).ConvertAll(approval => approval.Approver);
            return (currentUnapprovedApprovers.Exists(approver => !originalListOfApprovers.Contains(approver)));
        }

        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(
                originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User, 
                originalDepartment, originalPressureSafetyValveAnswer, originalCriticalSystemDefeated);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User,
                originalDepartment, originalPressureSafetyValveAnswer, originalCriticalSystemDefeated);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> { QueryFormTemplate });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormOP14FormTitle);

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();         
        }

        
       private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.OP14,ClientSession.GetUserContext().SiteId)[0];        //ayman generic forms
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true, buttontext);
        }

        private void HandleChangeToSomethingThatChangesApprovals()
        {
            UpdateEditObjectFromView();
            editObject.Approvals.ForEach(approval =>
                                             {
                                                 approval.Enabled = approval.ShouldBeEnabled(editObject, Clock.Now);
                                                 if (!approval.Enabled)
                                                 {
                                                     approval.Unapprove();
                                                 }
                                             });
            UpdateViewApprovalsFromEditObject();
        }

        private bool ApprovalRelatedEventsEnabled
        {
            set
            {
                if (value)
                {
                    view.PressureSafetyValveAnswerChanged += HandleChangeToSomethingThatChangesApprovals;
                    // RITM0446491 CSD Approval Buttonsbug details 
                    view.DepartmentOperationsAnswerChanged += HandleChangeToSomethingThatChangesApprovals;
                    view.CriticalSystemDefeatedTextBoxChanged += HandleChangeToSomethingThatChangesApprovals;
                    view.ContentRichTextEditorChanged += HandleChangeToSomethingThatChangesApprovals;
                    view.FunctionalLocationListBoxChanged += HandleChangeToSomethingThatChangesApprovals;//RITM0446491:-End
                    view.ValidityDatesChanged += HandleChangeToSomethingThatChangesApprovals;
                }
                else
                {
                    view.PressureSafetyValveAnswerChanged -= HandleChangeToSomethingThatChangesApprovals;
                    // RITM0446491 CSD Approval Buttonsbug details 
                    view.DepartmentOperationsAnswerChanged -= HandleChangeToSomethingThatChangesApprovals;
                    view.CriticalSystemDefeatedTextBoxChanged -= HandleChangeToSomethingThatChangesApprovals;
                    view.ContentRichTextEditorChanged -= HandleChangeToSomethingThatChangesApprovals;
                    view.FunctionalLocationListBoxChanged -= HandleChangeToSomethingThatChangesApprovals;//RITM0446491:-End
                    view.ValidityDatesChanged -= HandleChangeToSomethingThatChangesApprovals;
                }
            }
        }

        protected override bool ValidateViewHasError()
        {
            bool hasError = base.ValidateViewHasError();

            if(view.CriticalSystemDefeated.IsNullOrEmptyOrWhitespace())
            {
                ((IFormOP14View) view).SetErrorForEmptyOP14CriticalSystemDefeated();
                hasError = true;
            }

            if (Clock.Now > view.ValidTo)
            {
                ((IFormOP14View) view).SetErrorForValidToIsInThePast();
                hasError = true;
            }
            return hasError;
        }
    }
}
