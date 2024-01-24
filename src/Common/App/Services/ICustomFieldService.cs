using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ICustomFieldService
    {
        [OperationContract]
        List<CustomFieldGroup> QueryBySite(Site site);

        [OperationContract]
        List<CustomFieldGroup> QueryCustomFieldGroupsForActionItems();

        [OperationContract]
        List<CustomField> QueryCustomFieldsForActionItems(long id); //ayman custom fields DMND0010030

        [OperationContract]
        List<ActionItemResponseTracker> QueryForActionItemResponseTracker(long actionitemdefinitionId, long actionitemid); //ayman custom fields reading

        [OperationContract]
       List<Dictionary<long, string>> GetLastReading(long actionitemdefintionId);                       //ayman action item reading

        [OperationContract]
        List<ActionItemResponseTracker> QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId(long id,long actionitemid); //ayman custom fields reading

        [OperationContract]
        CustomFieldGroup Insert(CustomFieldGroup group);

        [OperationContract]
        CustomFieldGroup Update(CustomFieldGroup @group);

        [OperationContract]
        void Delete(CustomFieldGroup group);

        [OperationContract]
        List<CustomField> QueryOrderedFieldsByWorkAssignmentForSummaryLogs(WorkAssignment assignment);

        [OperationContract]
        List<CustomField> QueryOrderedFieldsByWorkAssignmentForLogs(WorkAssignment assignment);

        [OperationContract]
        List<CustomField> QueryOrderedFieldsByWorkAssignmentForDailyDirectives(WorkAssignment assignment);

        [OperationContract]
        List<CustomField> QueryOrderedFieldsForActionItems(long actionitemDefinitionId);          //ayman custom fields DMND0010030

    }
}