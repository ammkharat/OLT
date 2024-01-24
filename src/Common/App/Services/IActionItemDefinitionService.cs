using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IActionItemDefinitionService
    {
        [OperationContract]
        int GetCountOfSAPSourced(string name, long siteId);

        [OperationContract]
        ActionItemDefinition QueryById(long actionItemId);

        //ayman action item reading
        [OperationContract]
        object QueryActionItemDefAutoPopulateByActionItemDefinitionId(long Id);

        [OperationContract]
        object QueryActionItemDefReadingByActionItemDefinitionId(long Id);

        [OperationContract]
        List<ActionItemDefinition> QueryActionItemDefReadingBySiteId(long SiteId,Date startdate,Date enddate);                 //ayman action item reading

        [OperationContract(Name = "InsertActionItemDefinition")]
        List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition);

        [OperationContract(Name = "InsertActionItemDefinitionWithWorkOrderOperation")]
        ActionItemDefinition Insert(ActionItemDefinition actionItemDefinition, SapWorkOrderOperation workOrderOperation);

        [OperationContract(Name = "InsertActionItemDefinitionWithCustomFieldsGroupIds")]
        List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition, CustomFieldGroup customfieldsgroupids); //ayman custom fields DMND0010030

        [OperationContract]
        void InsertActionItemCustomFieldGroup(ActionItemDefinition actionitemDefinition, CustomFieldGroup customFieldGroupId);   //ayman custom fields DMND0010030

        [OperationContract]
        List<NotifiedEvent> Remove(ActionItemDefinition actionItemDefinition);

        [OperationContract]
        List<NotifiedEvent> Update(ActionItemDefinition actionItemDefinition);

        [OperationContract]
        List<NotifiedEvent> UpdateAndClearCurrentActionItems(ActionItemDefinition actionItemDefinition);

        [OperationContract]
        List<ActionItemDefinitionDTO> QueryDTOByFunctionalLocationsAndDateRange(Site site, IFlocSet flocSet,
            Range<Date> range, List<long> readableVisibilityGroupIds);

        //ayman action item definition
        [OperationContract]
        List<ActionItemDefinitionDTO> QueryDTOByActionItemDefinitionIds(Site site, List<long> aidSet,
            List<long> readableVisibilityGroupIds);

        //ayman action item email
        [OperationContract]
        List<string> QueryMailingList(long actionitemdefId);


        [OperationContract]
        List<string> QueryForActionItemNameListByTargetDefinitionId(long? targetId);

        [OperationContract]
        List<ActionItemDefinition> QueryAllAvailableForScheduling();

        [OperationContract]
        ActionItemDefinition QueryBySapOperationWorkOrderDetails(string workOrderNumber, string operationNumber,
            string subOperation);

        [OperationContract]
        List<ActionItemDefinition> QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(
            WorkAssignment assignment, IFlocSet flocSet, DateTime todaysDate, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ActionItemDefinition> QueryActiveDtosByParentFunctionalLocations(IFlocSet flocSet, DateTime todaysDate,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        int QueryCountByGN75BId(long id);

        [OperationContract(Name = "InsertActionItemDefinitionWorkPermitFH")]
        List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition, PermitRequestFortHills permit);
        //Added by ppanigrahi
        [OperationContract(Name="InsertActionItemDefinitionWorkPermitMuds")]
        List<NotifiedEvent> Insert(ActionItemDefinition actionItemDefinition, WorkPermitMuds permit);
    }
}