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
    public class AddEditCustomFieldGroupFormPresenter
    {
        private readonly IAddEditCustomFieldGroupView view;
        private readonly ICustomFieldService customFieldService;
        private readonly IPlantHistorianService plantHistorianService;
        private CustomFieldGroup editObject;
        private readonly List<CustomFieldGroup> allGroupsForSite;
        private readonly IWorkAssignmentService service;    //ayman action item reading




        public AddEditCustomFieldGroupFormPresenter(
            IAddEditCustomFieldGroupView view,
            CustomFieldGroup editObject, 
            List<CustomFieldGroup> allGroupsForSite)
        {
            this.view = view;
            this.editObject = editObject;
            this.allGroupsForSite = allGroupsForSite;
            service = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            customFieldService = ClientServiceRegistry.Instance.GetService<ICustomFieldService>();
            plantHistorianService = ClientServiceRegistry.Instance.GetService<IPlantHistorianService>();
        }

        public CustomFieldGroup EditObject
        {
            get { return editObject; }
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            view.ShouldShowPhTagIndicators = plantHistorianService.HasPlantHistorian(ClientSession.GetUserContext().Site);

            if (editObject != null)
            {
                view.GroupName = editObject.Name;
                view.AppliesToLogs = editObject.AppliesToLogs;
                view.AppliesToSummaryLogs = editObject.AppliesToSummaryLogs;
                view.AppliesToDailyDirectives = editObject.AppliesToDailyDirectives;
                view.AppliesToActionItems = editObject.AppliesToActionItems;            //ayman action item reading

                view.WorkAssignments = new List<WorkAssignment>(editObject.WorkAssignments);
                List<CustomField> fields =
                    editObject.Fields.ConvertAll(
                        obj =>
                            new CustomField(obj.Id, obj.Name, obj.DisplayOrder, obj.TagInfo, obj.Type, obj.PhdLinkType,
                                obj.DropDownValues,
                                obj.MinValueofRange, obj.MaxValueofRange, obj.GreaterThanValue, obj.LessThanValue,
                                obj.Color, obj.IsActive,obj.Date)); // Custom Field Changes By : Swapnil Patki
                                
                fields.Sort((x, y) => x.DisplayOrder.CompareTo(y.DisplayOrder));
                view.CustomFields = fields;
            }
            else
            {
                view.WorkAssignments = new List<WorkAssignment>();           
                view.CustomFields = new List<CustomField>();
            }

            // If the site uses the new directives, hide the old directives option. New directives don't have custom fields.
            if (!ClientSession.GetUserContext().SiteConfiguration.UseLogBasedDirectives)
            {
                view.HideDirectiveLogsOption();
            }
        }

        public void SelectWorkAssignments_Click(object sender, EventArgs e)
        {           
            List<WorkAssignment> selectedAssignments = view.WorkAssignments;
            DialogResultAndOutput<IList<WorkAssignment>> result = view.ShowWorkAssignmentSelector(selectedAssignments);

            if (result.Result == DialogResult.OK)
            {
                IList<WorkAssignment> assignments = result.Output;
                view.WorkAssignments = assignments == null ? new List<WorkAssignment>() : new List<WorkAssignment>(assignments);
            }
        }
       
        public void AddFieldButton_Click(object sender, EventArgs e)
        {
            CustomField addedField = view.ShowAddEditFieldForm(null);
            if (addedField != null)
            {
                view.AddField(addedField);
            }

            if (addedField != null && addedField.Type == CustomFieldType.BlankSpace)
            {
                view.DisableMovingAndSuggestSaving();
            }
            
        }

        public void EditFieldButton_Click(object sender, EventArgs e)
        {            
            if (view.SelectedField != null)
            {
                view.ShowAddEditFieldForm(view.SelectedField);
                view.RefreshFields();
            }
        }

        public void DeleteFieldButton_Click(object sender, EventArgs e)
        {
            if (view.SelectedField != null)
            {
                view.RemoveField(view.SelectedField);
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (editObject == null)
                {
                    editObject = new CustomFieldGroup(null, new List<WorkAssignment>(), new List<CustomField>(), false, false, false, false);          //ayman custom fields DMND0010030
                    PopulateFromView(editObject);
                    editObject = customFieldService.Insert(editObject);
                }
                else
                {
                    PopulateFromView(editObject);
                    editObject = customFieldService.Update(editObject);
                }
                view.SaveSucceededMessage();
                view.SetDialogResultOk();
                view.Close();
            }
        }

        private void PopulateFromView(CustomFieldGroup group)
        {
            group.Name = view.GroupName;

            group.AppliesToLogs = view.AppliesToLogs;
            group.AppliesToSummaryLogs = view.AppliesToSummaryLogs;
            group.AppliesToDailyDirectives = view.AppliesToDailyDirectives;
            group.AppliesToActionItems = view.AppliesToActionItems;                 //ayman custom fields DMND0010030

            group.WorkAssignments.Clear();            
            group.WorkAssignments.AddRange(view.WorkAssignments);       

            group.Fields.Clear();
            List<CustomField> fields = view.CustomFields;
            UpdateDisplayOrder(fields);
            group.Fields.AddRange(fields);
        }

        private static void UpdateDisplayOrder(List<CustomField> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                CustomField field = fields[i];
                field.DisplayOrder = i;
            }
        }

        private bool IsValid()
        {
            view.ClearAllErrors();
            bool isValid = true;

            if (view.GroupName.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoNameProvided();
                isValid = false;
            }

            if (view.WorkAssignments.Count == 0)
            {
                if (view.AppliesToActionItems && !view.AppliesToDailyDirectives && !view.AppliesToLogs && !view.AppliesToSummaryLogs)
                {
                    List<WorkAssignment> myassignment = service.QueryBySite(ClientSession.GetUserContext().Site);
                    myassignment.RemoveAll(fld => fld.Name != "Dummy WA For Action Item");
                    view.WorkAssignments = myassignment == null ? new List<WorkAssignment>() : new List<WorkAssignment>(myassignment);
                    isValid = true;
                }
                else
                {
                    view.SetErrorForNoAssociatedWorkAssignments();
                    isValid = false;
                }
            }

            if (allGroupsForSite.Exists(obj => Equals(obj.Name, view.GroupName) && obj != editObject))
            {
                view.SetErrorForDuplicateName();
                isValid = false;
            }
            if (DuplicateFieldNamesExists())
            {
                view.SetErrorForDuplicateFieldName();
                isValid = false;
            }
            if (view.CustomFields.Count == 0)
            {
                view.SetErrorForAtLeastOneFieldIsRequired();
                isValid = false;
            }

            if (!view.AppliesToLogs && !view.AppliesToSummaryLogs && !view.AppliesToDailyDirectives && !view.AppliesToActionItems)   //ayman custom fields DMND0010030
            {
                view.SetErrorForAtLeastOneApplicationAreaIsRequired();
                isValid = false;
            }

            return isValid;
        }

        private bool DuplicateFieldNamesExists()
        {
            foreach (CustomField current in view.CustomFields)
            {
                if (view.CustomFields.Exists(other => current != other && Equals(current.Name, other.Name) && current.Type != CustomFieldType.BlankSpace))
                    return true;
            }
            return false;
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

    }
}