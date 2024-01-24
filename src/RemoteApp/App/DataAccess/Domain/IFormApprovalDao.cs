using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormApprovalDao : IDao
    {
        List<FormApproval> QueryByFormGN7Id(long id);
        List<FormApproval> QueryByFormGN59Id(long id);
        List<FormApproval> QueryByFormOP14Id(long id);
        List<FormApproval> QueryByFormMontrealCsdId(long id);
        List<FormApproval> QueryByFormGN24Id(long id);
        List<FormApproval> QueryByFormGN6Id(long id);
        List<FormApproval> QueryByFormGN75AId(long id);
        List<FormApproval> QueryByFormGN75BId(long id);         //ayman Sarnia eip DMND0008992
        List<FormApproval> QueryByFormGN75BSarniaId(long id);         //ayman Sarnia eip DMND0008992
        List<FormApproval> QueryByOvertimeFormId(long id);

        List<FormApproval> QueryPlanningWorksheetApprovalsByFormGN1Id(long id);
        List<FormApproval> QueryRescuePlanApprovalsByFormGN1Id(long id);

        List<FormApproval> QueryByFormOilsandsTrainingId(long id);
        List<FormApproval> QueryByFormLubesCsdId(long id);
        List<FormApproval> QueryByFormLubesAlarmDisableId(long id);

        //generic template - mangesh
        List<FormApproval> QueryByFormGenericTemplateId(long id);
        List<FormApproval> QueryByFormGenericTemplateApprover(long siteid, long formtypeid, long plantid);

        List<FormApproval> QueryByFormMudsTemporaryInstallationId(long id);

        //ayman Sarnia eip DMND0008992
        List<FormApproval> QueryByFormSarniaEipIssueApprover(long siteid, long formtypeid, long plantid);

        //Added by ppanigrahi
        List<FormApproval> QueryByFormSarniaCsdApprover(long siteid, long formtypeid, long plantid);

        int Updatemailsentflag(long? Id, bool isMailSent);

       List<FormApproval> QueryByFormOP14EmailId(long Id);
    }
}