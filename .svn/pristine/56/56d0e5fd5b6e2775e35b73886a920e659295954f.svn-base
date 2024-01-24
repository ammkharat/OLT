using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICustomFieldDao : IDao
    {
        List<CustomField> QueryByGroupId(long customFieldGroupId);
        CustomField Insert(long customFieldGroupId, CustomField field);
        List<CustomField> QueryByWorkAssignmentForSummaryLogs(WorkAssignment assignment);
        List<CustomField> QueryCustomFieldsForActionItems(long actionitemDefinitionId);        //ayman custom fields DMND0010030
        List<ActionItemResponseTracker> QueryActionItemResponseTracker(long actionitemdefinitionId, long actionitemId);        //ayman action item reading
        List<Dictionary<long, string>> GetLastReading(long actionitemdefinitionId);   //ayman action item reading
        void InsertTracker(ActionItemResponseTracker actionitem);             //ayman action item reading

        List<ActionItemResponseTracker> QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId(long entryId,long actionitemid);        //ayman custom fields reading
        List<CustomField> QueryByWorkAssignmentForLogs(WorkAssignment assignment);
        List<CustomField> QueryByWorkAssignmentForDailyDirectives(WorkAssignment assignment);
        void Update(CustomField field, out bool aNewCustomFieldWasInserted);
        List<CustomField> QueryByCustomFieldGroupsForSummaryLogs(long id);
        List<CustomField> QueryByCustomFieldGroupsForActionItems(long id);    //ayman custom fields DMND0010030
        List<CustomField> QueryByCustomFieldGroupsForActionItemDefinition(long id);           //ayman custom fields DMND0010030
        List<CustomField> QueryByCustomFieldGroupsForLogs(long id);
        List<CustomField> QueryByCustomFieldGroupsForLogDefinitions(long id);
    }
}
