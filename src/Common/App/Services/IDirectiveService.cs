﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IDirectiveService
    {
        [OperationContract]
        List<NotifiedEvent> Insert(Directive directive);

        [OperationContract]
        List<NotifiedEvent> Update(Directive directive);

        [OperationContract]
        List<NotifiedEvent> Remove(Directive directive, User user);

        [OperationContract]
        Directive QueryById(long id);

        [OperationContract]
        List<DirectiveDTO> QueryDTOsByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet,  
            List<long> readableVisibilityGroupIds, long? readByUserId);


        [OperationContract]
        List<NotifiedEvent> Expire(Directive directive, User user);

        [OperationContract]
        List<ItemReadBy> UsersThatMarkedDirectiveAsRead(long directiveId);


        [OperationContract]
        List<ItemNotReadBy> UsersThatMarkedDirectiveAsNotRead(long directiveId,IFlocSet flocset);

        [OperationContract]
        bool UserMarkedDirectiveAsRead(long directiveId, long userId);

        [OperationContract]
        bool MarkAsRead(long directiveId, long userId, DateTime dateTime);
    }
}