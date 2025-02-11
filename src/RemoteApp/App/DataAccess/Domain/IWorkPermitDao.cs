using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    
    public interface IWorkPermitDao : IDao
    {
        WorkPermit QueryById(long id);

        WorkPermit QueryByIdTemplate(long id, string templateName, string categories);

        //ayman USPipeline workpermit
        WorkPermit QueryByIdForUSPipeline(long id);

        WorkPermit QueryBySapWorkOrderOperationKeys(string workOrderNumber, string operationNumber, string subOperation);
        WorkPermit QueryBySapWorkOrderOperationKeysForUSPipeline(string workOrderNumber, string operationNumber, string subOperation);  //ayman USPipeline workpermit
        WorkPermit Insert(WorkPermit workPermit);
        WorkPermit InsertTemplate(WorkPermit workPermit);
        WorkPermit UpdateTemplate(WorkPermit workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        

        WorkPermit InsertUSPipeline(WorkPermit workPermit);                   //ayman USPipeline workpermit
        void Remove(WorkPermit workPermit);
        void Update(WorkPermit workPermit);

        void RemoveTemplate(WorkPermit workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**
        
        List<WorkPermit> QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(DateTime requestDateTime, long siteId, WorkPermitStatus status);
        List<WorkPermit> QueryByFunctionalLocationsAndStatuses(IFlocSet flocSet, WorkPermitStatus[] statuses);
        List<WorkPermit> QueryAllWorkPermitsByStatus(WorkPermitStatus status);

        // #3003 - Need to remove the association to craft or trades and just store the text so that we don't have to do this funny stuff.  Like we do in other permits. Can pick from a list or just type something in.
        void UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade(long? craftOrTradeId);


        //Adde by Mukesh for WOrkpermit Sign

        WorkPermitSign GetWorkPermitSign(string WorkPermitId, int SiteId);
        void InserUpdateWorkPermitSign(WorkPermitSign workPermitSign);
        BADGE GetBadgeInfo(string Badgenumber, string strConnection, string strQuery);
        LenleConnection GetWorkPermitSignLenelConnection();
    }
}