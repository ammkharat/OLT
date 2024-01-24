using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IShiftHandoverService
    {
        [OperationContract]
        List<ShiftHandoverConfiguration> GetAllQuestions(long workAssignmentId);

        [OperationContract]
        ShiftHandoverQuestionnaire QueryById(long id);

        [OperationContract]
        List<ShiftHandoverQuestionnaire> QueryByUserWorkAssignmentAndShift(long userId, long? workAssignmentId,
            UserShift userShift);

        [OperationContract]
        List<ShiftHandoverQuestionnaire> QueryByWorkAssignmentAndShift(long workAssignmentId, UserShift userShift);

        [OperationContract]
        List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation(IFlocSet flocSet,
            Range<Date> dateRange, long? userId, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment(
            IFlocSet flocSet, long? workAssignmentId, Range<Date> dateRange, long? userId,
            List<long> readableVisibilityGroupIds);

        //Added for View shifthandover based on rolepermission
        [OperationContract(Name="QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation1")]
        List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocation(IFlocSet flocSet,
            Range<Date> dateRange, long? userId, List<long> readableVisibilityGroupIds,long? RoleId);

        [OperationContract (Name="QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment1")]
       
        List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment(
            IFlocSet flocSet, long? workAssignmentId, Range<Date> dateRange, long? userId,
            List<long> readableVisibilityGroupIds,long? RoleId);
        //End

        [OperationContract]
        List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFlocAndShift(
            RootFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ShiftHandoverQuestionnaireDTO> QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFlocAndDateRange(
            RootFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ShiftHandoverQuestionnairePriorityPageDTO> QueryForPriorityPageDTOs(IFlocSet flocSet, Range<Date> dateRange,
            bool queryByWorkAssignment, long? workAssignmentId, long? userId, List<long> readableVisibilityGroupIds,long? RoleId);

        [OperationContract]
        List<ShiftHandoverQuestionnaireDTO> QueryPriorityDTOs(IFlocSet flocSet, long? workAssignmentId, long? userId,
            UserShift userShift, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<NotifiedEvent> Insert(ShiftHandoverQuestionnaire questionnaire);

        [OperationContract]
        List<NotifiedEvent> Update(ShiftHandoverQuestionnaire questionnaire, User updateUser);

        [OperationContract]
        List<NotifiedEvent> Remove(ShiftHandoverQuestionnaire questionnaire);

        [OperationContract]
        ShiftHandoverConfiguration QueryShiftHandoverConfigurationsById(long id);

        [OperationContract]
        List<ShiftHandoverConfigurationDTO> QueryShiftHandoverConfigurationDTOsBySite(long siteId);

        [OperationContract]
        ShiftHandoverConfiguration InsertShiftHandoverConfiguration(ShiftHandoverConfiguration configuration);

        [OperationContract]
        void UpdateShiftHandoverConfiguration(ShiftHandoverConfiguration configuration,
            List<ShiftHandoverQuestion> deletedQuestions);

        [OperationContract]
        void DeleteShiftHandoverConfiguration(long configurationId);

        [OperationContract]
        bool MarkAsRead(long shiftHandoverQuestionnaireId, long userId, DateTime now);

        [OperationContract]
        bool UserMarkedLogAsRead(long shiftHandoverQuestionnaireId, long userId);

        [OperationContract]
        List<ItemReadBy> UsersThatMarkedLogAsRead(long handoverQuestionnaireId);

        [OperationContract]
        bool ShiftHandoverIsMarkedAsRead(long handoverQuestionnaireId);

        [OperationContract]
        bool ShiftHandoversAreMarkedAsRead(List<long> handoverQuestionnaireIds);

        [OperationContract]
        List<ShiftHandoverEmailConfiguration> QueryShiftHandoverEmailConfigurationsBySiteId(long siteId);

        [OperationContract]
        List<NotifiedEvent> InsertShiftHandoverEmailConfiguration(ShiftHandoverEmailConfiguration configuration);

        [OperationContract]
        List<NotifiedEvent> UpdateShiftHandoverEmailConfiguration(ShiftHandoverEmailConfiguration configuration);

        [OperationContract]
        List<NotifiedEvent> DeleteShiftHandoverEmailConfiguration(ShiftHandoverEmailConfiguration configuration);

        [OperationContract]
        ShiftHandoverEmailConfiguration QueryShiftHandoverEmailConfigurationById(long configurationId);

        [OperationContract]
        ShiftHandoverQuestionnaireAssocations QueryAssocationedItems(long shiftHandoverQuestionnaireId,
            Date shiftStartDate, long shiftPatternId, long workAssignmentId, List<long> cokerCardConfigurationIds,long siteId);

        //RITM0164968-  mangesh
        [OperationContract]
        ShiftHandoverQuestionnaireAssocations QueryAssocationedLogItems(long shiftHandoverQuestionnaireId,
            Date shiftStartDate, long shiftPatternId, long workAssignmentId, List<long> cokerCardConfigurationIds);

        //Mukesh-for Operator Round Messgae
        [OperationContract]
        List<ShiftLogMessage> QueryShiftLogMessage(IFlocSet Floc, long siteId);
    }
}