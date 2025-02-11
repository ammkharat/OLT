﻿using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPermitRequestMontrealService
    {
        [OperationContract]
        List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelowForTemlate(IFlocSet flocSet, DateRange dateRange, string username);

        [OperationContract]
        PermitRequestMontreal QueryById(long id);

        [OperationContract]
        PermitRequestMontreal QueryByIdTemplate(long id, string templateName, string categories);

        [OperationContract]
        List<NotifiedEvent> Insert(PermitRequestMontreal request);

        [OperationContract]
        List<NotifiedEvent> Update(PermitRequestMontreal request);

        [OperationContract]
        List<NotifiedEvent> Remove(PermitRequestMontreal request);

        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(PermitRequestMontreal request); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(PermitRequestMontreal workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        [OperationContract]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestMontrealDTO> dtos, User user);

        [OperationContract]
        List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestMontreal request, User user);
    }
}