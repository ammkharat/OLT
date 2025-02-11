﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    public class DirectiveService : IDirectiveService
    {
        private readonly IDirectiveDao dao;
        private readonly IDirectiveDTODao dtoDao;
        private readonly IDirectiveReadDao readDao;

        private readonly IEditHistoryService editHistoryService;
        private readonly ITimeService timeService;

        public DirectiveService()
        {
            dao = DaoRegistry.GetDao<IDirectiveDao>();
            dtoDao = DaoRegistry.GetDao<IDirectiveDTODao>();
            readDao = DaoRegistry.GetDao<IDirectiveReadDao>();

            editHistoryService = new EditHistoryService();
            timeService = new TimeService();
        }

        public List<NotifiedEvent> Insert(Directive directive)
        {
            dao.Insert(directive);
            editHistoryService.TakeSnapshot(directive);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.DirectiveCreate, directive));
            return notifiedEvents;            
        }

        public List<NotifiedEvent> Update(Directive directive)
        {
            directive.LastModifiedDateTime = timeService.GetTime(directive.FunctionalLocations[0].Site.TimeZone);
            
            dao.Update(directive);

            editHistoryService.TakeSnapshot(directive);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.DirectiveUpdate, directive));
            return notifiedEvents;            
        }

        public List<NotifiedEvent> Remove(Directive directive, User user)
        {
            directive.LastModifiedDateTime = timeService.GetTime(directive.FunctionalLocations[0].Site.TimeZone);
            directive.LastModifiedBy = user;

            dao.Remove(directive);

            return new List<NotifiedEvent> { ServiceUtility.PushEventIntoQueue(ApplicationEvent.DirectiveRemove, directive) };                        
        }

        public List<NotifiedEvent> Expire(Directive directive, User user)
        {
            DateTime rightNow = timeService.GetTime(directive.FunctionalLocations[0].Site.TimeZone);
            directive.ActiveToDateTime = rightNow;
            directive.LastModifiedDateTime = rightNow;
            directive.LastModifiedBy = user;

            dao.Update(directive);

            editHistoryService.TakeSnapshot(directive);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.DirectiveUpdate, directive));
            return notifiedEvents;            
        }

        public List<ItemReadBy> UsersThatMarkedDirectiveAsRead(long directiveId)
        {
            return readDao.UsersThatMarkedAsRead(directiveId);
        }
        //Added by ppanigrahi
        public List<ItemNotReadBy> UsersThatMarkedDirectiveAsNotRead(long directiveId, IFlocSet flocSet)
        {
            return readDao.UsersThatMarkedAsNotRead(directiveId, flocSet);
        }
        public bool UserMarkedDirectiveAsRead(long directiveId, long userId)
        {
            ItemRead<Directive> itemRead = readDao.UserMarkedAsRead(directiveId, userId);
            return (itemRead != null);
        }

        public bool MarkAsRead(long directiveId, long userId, DateTime dateTime)
        {
            bool markAsReadWasSuccessful = true;

            Directive directive = dao.QueryById(directiveId);
            if (directive != null && readDao.UserMarkedAsRead(directiveId, userId) == null)
            {
                readDao.Insert(new ItemRead<Directive>(directiveId, userId, dateTime));
            }
            else
            {
                markAsReadWasSuccessful = false;
            }

            return markAsReadWasSuccessful;
        }

        public Directive QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public List<DirectiveDTO> QueryDTOsByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet, List<long> readableVisibilityGroupIds, long? readByUserId)  
        {
            return dtoDao.QueryByDateRangeAndFlocs(dateRange, flocSet, readableVisibilityGroupIds, readByUserId);    
        }

    }   
}
