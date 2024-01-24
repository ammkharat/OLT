using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditLogTemplateFormPresenter
    {
        private readonly ILogTemplateService logTemplateService;
        private readonly IWorkAssignmentService workAssignmentService;

        private readonly IAddEditLogTemplateFormView view;
        private LogTemplate editObject;
        private readonly List<LogTemplate> logTemplatesForSite;        
        private readonly bool isAddMode;
        private readonly UserContext userContext;
        
        public AddEditLogTemplateFormPresenter(IAddEditLogTemplateFormView view, LogTemplate editObject, List<LogTemplate> logTemplatesForSite)
        {
            this.view = view;
            this.editObject = editObject;
            this.logTemplatesForSite = logTemplatesForSite;
            
            isAddMode = (editObject == null);
            userContext = ClientSession.GetUserContext();

            logTemplateService = ClientServiceRegistry.Instance.GetService<ILogTemplateService>();
            workAssignmentService = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();
        }

        public LogTemplate EditObject
        {
            get { return editObject; }
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            view.Site = userContext.Site;

            if (isAddMode)
            {
                view.LogTemplateAssignmentGridDisplayAdapters = new List<LogTemplateAssignmentGridDisplayAdapter>();
            }
            else
            {
                PopulateViewForEditMode();                
            }           
        }
       
        private void PopulateViewForEditMode()
        {
            view.LogTemplateName = editObject.Name;
            view.Site = ClientSession.GetUserContext().Site;
            view.LogTemplateText = editObject.Text;
            view.LogTemplateAssignmentGridDisplayAdapters = CreateDisplayAdapters(editObject.WorkAssignments);
            view.AppliesToLogs = editObject.AppliesToLogs;
            view.AppliesToSummaryLogs = editObject.AppliesToSummaryLogs;
            view.AppliesToDirectives = editObject.AppliesToDirectives;
        }

        private List<LogTemplateAssignmentGridDisplayAdapter> CreateDisplayAdapters(List<WorkAssignment> workAssignments)
        {
            return workAssignments.ConvertAll(assignment => new LogTemplateAssignmentGridDisplayAdapter(assignment, editObject.Id == assignment.AutoInsertLogTemplateId));
        }

        public void SelectWorkAssignments_Click(object sender, EventArgs e)
        {
            List<WorkAssignment> selectedAssignments = view.LogTemplateAssignmentGridDisplayAdapters.ConvertAll(a => a.GetAssignment());
            DialogResultAndOutput<IList<WorkAssignment>> result = view.ShowWorkAssignmentSelector(selectedAssignments);

            if (result.Result == DialogResult.OK)
            {
                IList<WorkAssignment> assignments = result.Output;

                List<LogTemplateAssignmentGridDisplayAdapter> adapters = new List<LogTemplateAssignmentGridDisplayAdapter>();
                if (assignments != null)
                {
                    foreach (WorkAssignment assignment in assignments)
                    {
                        LogTemplateAssignmentGridDisplayAdapter adapter = view.LogTemplateAssignmentGridDisplayAdapters.Find(a => a.GetAssignment().Id == assignment.Id);
                        adapters.Add(new LogTemplateAssignmentGridDisplayAdapter(assignment, adapter != null && adapter.AutoInsert));
                    }
                }

                view.LogTemplateAssignmentGridDisplayAdapters = adapters;
            }
        }
 
        public void HandleSubmit(object sender, EventArgs e)
        {   
            long? originalId = editObject == null ? null : editObject.Id;

            User currentUser = userContext.User;
            DateTime now = Clock.Now;
            
            List<WorkAssignment> workAssignments = view.LogTemplateAssignmentGridDisplayAdapters.ConvertAll(a => a.GetAssignment());

            if (isAddMode)
            {                
                editObject = new LogTemplate(view.LogTemplateName, view.LogTemplateText,
                                             workAssignments, 
                                             view.AppliesToLogs, view.AppliesToSummaryLogs, view.AppliesToDirectives,   
                                             currentUser, now, currentUser, now);
            }
            else
            {
                editObject = new LogTemplate(view.LogTemplateName, view.LogTemplateText,
                                             workAssignments, view.AppliesToLogs, view.AppliesToSummaryLogs, view.AppliesToDirectives,  
                                             currentUser, now, editObject.CreatedBy, editObject.CreatedDateTime) { Id = originalId };                
            }
            
            List<WorkAssignment> assignmentsWithAutoInsertChecked = view.LogTemplateAssignmentGridDisplayAdapters.FindAll(a => a.AutoInsert).ConvertAll(a => a.GetAssignment());

            if (!DataIsValid(editObject, assignmentsWithAutoInsertChecked))
            {
                return;
            }

            if (isAddMode)
            {
                //start -- dharmesh -- 25Jun2018 -- RITM0230494 -- 
                //logTemplateService.Insert(editObject);
                editObject = logTemplateService.Insert(editObject);
                //End -- dharmesh -- 25Jun2018 -- RITM0230494 -- 
            }
            else
            {
                logTemplateService.Update(editObject);
            }

            // update the auto-insert log template id
            foreach (WorkAssignment workAssignment in workAssignments)
            {
                LogTemplateAssignmentGridDisplayAdapter adapter = view.LogTemplateAssignmentGridDisplayAdapters.Find(a => a.GetAssignment().Id == workAssignment.Id);
                if (adapter.AutoInsert)
                {
                    workAssignment.AutoInsertLogTemplateId = editObject.Id;
                }
                else if (workAssignment.AutoInsertLogTemplateId == editObject.Id)
                {
                    workAssignment.AutoInsertLogTemplateId = null;
                }
            }
            workAssignmentService.Update(workAssignments);

            view.SaveSucceededMessage();
            view.CloseForm();            
        }

        public void HandleCancel(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        private bool DataIsValid(LogTemplate logTemplate, List<WorkAssignment> assignmentsWithAutoInsertChecked)
        {
            LogTemplateValidator validator = new LogTemplateValidator(view, logTemplatesForSite);
            validator.ValidateAndSetErrors(logTemplate);

            string plainTemplateText = view.LogTemplateTextAsPlainText;
            bool hasOtherError = false;

            if (plainTemplateText.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoTextProvided();
                hasOtherError = true;
            }

            if (!view.AppliesToLogs && !view.AppliesToSummaryLogs && !view.AppliesToDirectives)
            {
                view.SetErrorForAtLeastOneApplicationAreaIsRequired();
                hasOtherError = true;
            }
            
            string autoInsertErrorMessage = BuildAutoInsertErrorMessage(logTemplate, assignmentsWithAutoInsertChecked);
            if (!autoInsertErrorMessage.IsNullOrEmptyOrWhitespace())
            {
                hasOtherError = true;
                view.SetErrorForAssignmentAlreadyHasAnAutoInsertedTemplate(autoInsertErrorMessage);
            }

            return !validator.HasErrors && !hasOtherError;
        }

        private string BuildAutoInsertErrorMessage(LogTemplate logTemplate, List<WorkAssignment> assignmentsWithAutoInsertChecked)
        {
            List<LogTemplate> logTemplatesSetAsAutoInsert = logTemplateService.QueryLogTemplatesSetAsAutoInsertForTheseAssignments(assignmentsWithAutoInsertChecked);

            List<string> messages = new List<string>();

            foreach (LogTemplate template in logTemplatesSetAsAutoInsert)
            {
                if (template.Id != logTemplate.Id)
                {
                    List<WorkAssignment> conflictingAssignments = template.WorkAssignments.FindAll(wa => wa.AutoInsertLogTemplateId == template.Id && assignmentsWithAutoInsertChecked.Exists(a => a.Id == wa.Id));
                    conflictingAssignments.ForEach(assignment =>
                        {
                            messages.AddIfNotExist(String.Format(StringResources.LogTemplateAutoInsertErrorMessage, assignment.Name, template.Name));
                        });
                }
            }

            return messages.Join("\r\n");
        }
    }
}
