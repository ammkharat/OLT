using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CustomFieldService : ICustomFieldService
    {
        private enum CustomFieldUsageArea { SummaryLogs, Logs, DailyDirectives, LogDefinitions, StandingOrders }

        private readonly ICustomFieldGroupDao groupDao;
        private readonly ICustomFieldDao fieldDao;
        private readonly ICustomFieldDropDownValueDao customFieldDropDownValueDao;             //ayman action item reading

        public CustomFieldService()
        {
            groupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            fieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
            customFieldDropDownValueDao = DaoRegistry.GetDao<ICustomFieldDropDownValueDao>();         //ayman action item reading
            
        }

        //ayman action item reading
        public List<CustomFieldDropDownValue> QueryCustomFieldDropDownValues(long customfieldid)
        {
            return customFieldDropDownValueDao.QueryByCustomFieldId(customfieldid);
        }

        public List<CustomFieldGroup> QueryCustomFieldGroupsForActionItems()
        {
            return groupDao.QueryCustomFieldGroupsForActionItems();
        }

        public List<CustomFieldGroup> QueryBySite(Site site)
        {
            return groupDao.QueryBySite(site);
        }

        public List<CustomField> QueryCustomFieldsForActionItems(long id)
        {
            return fieldDao.QueryCustomFieldsForActionItems(id);
        }

        //ayman action item reading
        public List<Dictionary<long,string>> GetLastReading(long actionitemdefinitionId)
        {
            return fieldDao.GetLastReading(actionitemdefinitionId);
        }

        //ayman action item reading
        public List<ActionItemResponseTracker> QueryForActionItemResponseTracker(long aidid, long aiid)
        {
            return fieldDao.QueryActionItemResponseTracker(aidid,aiid);
        }

        //ayman action item reading
        public List<ActionItemResponseTracker> QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId(long id,long actionitemid)
        {
            return fieldDao.QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId(id,actionitemid);
        }


        public CustomFieldGroup Insert(CustomFieldGroup group)
        {
            return groupDao.Insert(group);
        }

        public CustomFieldGroup Update(CustomFieldGroup @group)
        {
            return groupDao.Update(group);
        }

        public void Delete(CustomFieldGroup group)
        {
            groupDao.Remove(group);
        }

        public List<CustomFieldGroup> QueryGroupsByLogDefinitionId(long logDefinitionId)
        {
            return groupDao.QueryByLogDefinitionId(logDefinitionId);
        }

        public List<CustomField> QueryOrderedFieldsByWorkAssignmentForSummaryLogs(WorkAssignment assignment)
        {
            return QueryOrderedFieldsByWorkAssignment(assignment, CustomFieldUsageArea.SummaryLogs);           
        }

        public List<CustomField> QueryOrderedFieldsByWorkAssignmentForLogs(WorkAssignment assignment)
        {
            return QueryOrderedFieldsByWorkAssignment(assignment, CustomFieldUsageArea.Logs);
        }

        public List<CustomField> QueryOrderedFieldsByWorkAssignmentForDailyDirectives(WorkAssignment assignment)
        {
            return QueryOrderedFieldsByWorkAssignment(assignment, CustomFieldUsageArea.DailyDirectives);
        }

        //ayman custom fields DMND0010030
        public List<CustomField> QueryOrderedFieldsForActionItems(long actionitemId)
        {
            List<CustomField> allFieldsForSections;
            allFieldsForSections = fieldDao.QueryCustomFieldsForActionItems(actionitemId);
            return allFieldsForSections;
        }



        private List<CustomField> QueryOrderedFieldsByWorkAssignment(WorkAssignment assignment, CustomFieldUsageArea customFieldUsageArea)
        {
            if (assignment == null)
            {
                return new List<CustomField>();
            }

            List<CustomField> allFieldsForSections;

            if (CustomFieldUsageArea.SummaryLogs.Equals(customFieldUsageArea))
            {
                allFieldsForSections = fieldDao.QueryByWorkAssignmentForSummaryLogs(assignment);
            }
            else if (CustomFieldUsageArea.Logs.Equals(customFieldUsageArea) || CustomFieldUsageArea.LogDefinitions.Equals(customFieldUsageArea))
            {
                allFieldsForSections = fieldDao.QueryByWorkAssignmentForLogs(assignment);
            }
            else if (CustomFieldUsageArea.DailyDirectives.Equals(customFieldUsageArea) || CustomFieldUsageArea.StandingOrders.Equals(customFieldUsageArea))
            {
                allFieldsForSections = fieldDao.QueryByWorkAssignmentForDailyDirectives(assignment);
            }
            else
            {
                throw new ApplicationException("Internal error: Custom Field Usage Area not configured.");
            }
            
            CustomField.SortAndResetDisplayOrder(allFieldsForSections);

            return allFieldsForSections;
        }


    }
}
