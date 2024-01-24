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
    public interface IPermitRequestMudsService
    {
        [OperationContract]
        List<PermitRequestMudsDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<PermitRequestMudsDTO> QueryByFlocUnitAndBelowForTemlate(IFlocSet flocSet, DateRange dateRange, string username);

        [OperationContract]
        List<NotifiedEvent> InsertTemplate(PermitRequestMuds workPermit);

        [OperationContract]
        PermitRequestMuds QueryById(long id);

        [OperationContract]
        PermitRequestMuds QueryByIdTemplate(long id, string templateName, string categories);

        [OperationContract]
        List<NotifiedEvent> Insert(PermitRequestMuds request);

        [OperationContract]
        List<NotifiedEvent> Update(PermitRequestMuds request);

        [OperationContract]
        List<NotifiedEvent> Remove(PermitRequestMuds request);

        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(PermitRequestMuds request); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(PermitRequestMuds workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        [OperationContract]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestMudsDTO> dtos, User user);

        [OperationContract]
        List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestMuds request, User user);
    }
}