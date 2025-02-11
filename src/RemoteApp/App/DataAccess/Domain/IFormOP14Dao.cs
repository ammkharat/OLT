﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormOP14Dao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        FormOP14 Insert(FormOP14 form);

       

        [CachedQueryById]
        FormOP14 QueryById(long id);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormOP14 QueryByIdAndSiteId(long id, long siteid);

        [CachedInsertOrUpdate(false, false)]
        void Update(FormOP14 form);
        [CachedRemove(false, false)]
        void Remove(FormOP14 form);
        List<FormOP14> QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now);
        /*RITM0265746 - Sarnia CSD marked as read start*/

        FormOP14Read InsertFormOp14MarkAsRead(long id, long userId, DateTime datetimenow, long shiftId);
        List<ItemReadBy> UserMarkedFormOp14AsRead(long formOp14Id, long? userId, long shiftId);

        List<ItemReadBy> UserMarkedFormOp14AsReadOnPriorityPage(long formOp14Id, long? userId, long shiftId, Date date); //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD
        

        List<CSDMarkAsReadReportItem> GetFormOP14MarkedAsReadReport(DateRange startendDate, long siteId);
        /*RITM0265746 - Sarnia CSD marked as read start*/

        [CachedInsertOrUpdate(false, false)]
        void UpdateEmail(long id, long sitid, long lastModifiedByUserId, int formStatusId);//Added by ppanigrahi

        long QueryByUserName(string username);//Added by ppanigrahi

        long QueryByFormOp14ApprovalId(long? formop14Id, string approver);//Added by ppanigrahi

        int UpdaterRest(long Id, int FormStatusId, string CriticalSystemDefeated, long LastModifiedByUserId, long siteid, long ApproveId, long ApprovedByUserId, string ApprovalDateTime, int ShouldBeEnabledBehaviourId, bool Enabled);//Added by ppanigrahi
    }
}
