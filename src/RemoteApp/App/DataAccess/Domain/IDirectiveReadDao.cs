﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDirectiveReadDao : IDao
    {
        ItemRead<Directive> UserMarkedAsRead(long directiveId, long userId);
        void Insert(ItemRead<Directive> itemRead);
        List<ItemReadBy> UsersThatMarkedAsRead(long directiveId);
        void ConvertMarkedAsReadInformation(long fromLogId, long toDirectiveId);
        List<ItemNotReadBy> UsersThatMarkedAsNotRead(long directiveId,IFlocSet flocset);
    }
}