using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestDao<T> : IDao where T : BasePermitRequest
    {
        //[CachedQueryById]
        T QueryById(long id);        
        //[CachedInsertOrUpdate(false, false)]
        T Insert(T permitRequest);
        //[CachedInsertOrUpdate(false, false)]
        void Update(T permitRequest);
        //[CachedRemove(false, false)]
        void Remove(T permitRequest);


        PermitRequestEdmonton InsertTemplate(PermitRequestEdmonton permit);
        PermitRequestMontreal InsertTemplate(PermitRequestMontreal permit);
        PermitRequestMuds InsertTemplate(PermitRequestMuds permit);

        PermitRequestMuds QueryByIdTemplate(long id, string templateName, string categories);
        PermitRequestEdmonton QueryByIdTemplateEdmonton(long id, string templateName, string categories);
        PermitRequestMontreal QueryByIdTemplateMontreal(long id, string templateName, string categories);
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        void RemoveTemplate(PermitRequestMuds permitRequest);
        void RemoveTemplate(PermitRequestMontreal permitRequest);
        void RemoveTemplate(PermitRequestEdmonton permitRequest);

        PermitRequestMuds UpdateTemplate(PermitRequestMuds workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        PermitRequestEdmonton UpdateTemplate(PermitRequestEdmonton workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        PermitRequestMontreal UpdateTemplate(PermitRequestMontreal workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        

        
        
        List<T> QueryByWorkOrderNumberAndOperationAndSource(string workOrderNumber, string operationNumber, string subOperationNumber, DataSource dataSource);

        DateTime? QueryLastImportDateTime();

        List<T> QueryByDateRangeAndDataSource(Date fromDate, Date toDate, DataSource dataSource);
    }
}
