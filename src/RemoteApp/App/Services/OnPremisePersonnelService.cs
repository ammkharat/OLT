using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Integration;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OnPremisePersonnelService : IOnPremisePersonnelService
    {
     
        private readonly IEdmontonSwipeCardReader swipeCardReader;
        private readonly ITimeService timeService;

        public OnPremisePersonnelService(IEdmontonSwipeCardReader swipeCardReader, ITimeService timeService)
        {
            this.swipeCardReader = swipeCardReader;
            this.timeService = timeService;
        }

        public OnPremisePersonnelService() : this(new EdmontonSwipeCardReader(), new TimeService())
        {
        }

        public void UpdateOnPremisePersonnel(OvertimeForm oldVersion, OvertimeForm newVersion)
        {
            // purposely doing this here so that that we get data from the swipe card system before we start updating stuff all over people's clients.
            var cardsFromSwipeCardSystem = swipeCardReader.GetCardsFromSwipeCardSystem(2);

            var deletedItems = CreateDeletedOnPremisePersonnel(oldVersion, newVersion);
            deletedItems.ForEach(item => ServiceUtility.PushEventIntoQueue(ApplicationEvent.OnPremiseContractorRemove, item));

            var currentTimeAtSite = timeService.GetTime(newVersion.FunctionalLocation.Site.TimeZone);

            var updatedItems = CreateUpdatedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, currentTimeAtSite);
            updatedItems.ForEach(item => ServiceUtility.PushEventIntoQueue(ApplicationEvent.OnPremiseContractorUpdate, item));

            var insertItems = CreateInsertedOnPremisePersonnel(oldVersion, newVersion, cardsFromSwipeCardSystem, currentTimeAtSite);
            insertItems.ForEach(item => ServiceUtility.PushEventIntoQueue(ApplicationEvent.OnPremiseContractorCreate, item));
        }

        public void InsertOnPremisePersonnel(OvertimeForm overtimeForm)
        {
            // purposely doing this here so that that we get data from the swipe card system before we start updating stuff all over people's clients.
            var cardsFromSwipeCardSystem = swipeCardReader.GetCardsFromSwipeCardSystem(2);

            var currentTimeAtSite = timeService.GetTime(overtimeForm.FunctionalLocation.Site.TimeZone);

            var insertItems = CreateInsertedOnPremisePersonnel(null, overtimeForm, cardsFromSwipeCardSystem, currentTimeAtSite);
            insertItems.ForEach(item => ServiceUtility.PushEventIntoQueue(ApplicationEvent.OnPremiseContractorCreate, item));
        }

        public void RemoveOnPremisePersonnel(OvertimeForm overtimeForm)
        {
            var deletedItems = CreateDeletedOnPremisePersonnel(overtimeForm, null);
            deletedItems.ForEach(item => ServiceUtility.PushEventIntoQueue(ApplicationEvent.OnPremiseContractorRemove, item));
        }

        public List<OnPremisePersonnel> CreateDeletedOnPremisePersonnel(OvertimeForm oldVersion, OvertimeForm newVersion)
        {
            var currentOnPremiseContractors = newVersion == null ? new List<OnPremiseContractor>(0) : newVersion.OnPremiseContractors;
            var oldOnPremiseContractors = oldVersion.OnPremiseContractors;

            var deleted = oldOnPremiseContractors.FindAll(c => !currentOnPremiseContractors.ExistsById(c));

            return deleted.ConvertAll(c => new OnPremisePersonnel(oldVersion, c, CardEntryStatus.UnKnown));
        }

        public List<OnPremisePersonnel> CreateUpdatedOnPremisePersonnel(OvertimeForm oldVersion,
            OvertimeForm newVersion,
            List<EdmontonPerson> cardsFromSwipeCardSystem,
            DateTime currentTimeAtSite)
        {
            var currentOnPremiseContractors = newVersion.OnPremiseContractors;
            var oldOnPremiseContractors = oldVersion.OnPremiseContractors;

            var updated = currentOnPremiseContractors.FindAll(oldOnPremiseContractors.ExistsById);

            return updated.ConvertAll(c =>
            {
                var cardEntryStatus = CreateCardStatus(cardsFromSwipeCardSystem, c.PersonnelName, currentTimeAtSite);
                return new OnPremisePersonnel(newVersion, c, cardEntryStatus);
            });
        }

        public List<OnPremisePersonnel> CreateInsertedOnPremisePersonnel(OvertimeForm oldVersion,
            OvertimeForm newVersion,
            List<EdmontonPerson> cardsFromSwipeCardSystem,
            DateTime currentTimeAtSite)
        {
            var currentOnPremiseContractors = newVersion.OnPremiseContractors;
            var oldOnPremiseContractors = oldVersion == null ? new List<OnPremiseContractor>(0) : oldVersion.OnPremiseContractors;

            var inserted = currentOnPremiseContractors.FindAll(c => !oldOnPremiseContractors.ExistsById(c));

            return inserted.ConvertAll(c =>
            {
                var cardEntryStatus = CreateCardStatus(cardsFromSwipeCardSystem, c.PersonnelName, currentTimeAtSite);
                return new OnPremisePersonnel(newVersion, c, cardEntryStatus);
            });
        }

        public static CardEntryStatus CreateCardStatus(List<EdmontonPerson> cardsFromSwipeCardSystem, string person, DateTime currentTimeAtSite)
        {
            var cardEntryStatus = CardEntryStatus.UnKnown;

            if (person.IsInFormatOfEdmontonCardSwipeSystem())
            {
                var edmontonPerson = cardsFromSwipeCardSystem.Find(swipe => swipe.DisplayString.Equals(person));
                if (edmontonPerson == null)
                {
                    cardEntryStatus = CardEntryStatus.OffSite;
                }
                else
                {
                    var badgeScanStatus = edmontonPerson.ScanStatus;
                    var scanWasOver24HoursAgo = edmontonPerson.LastScan  < currentTimeAtSite.SubtractDays(1);

                    if (badgeScanStatus == BadgeScanStatus.In && !scanWasOver24HoursAgo)
                    {
                        cardEntryStatus = CardEntryStatus.OnSite;
                    }

                    else if (badgeScanStatus == BadgeScanStatus.Out)
                    {
                        cardEntryStatus = CardEntryStatus.OffSite;
                    }
               
                }
            }

            return cardEntryStatus;
        }
    }
}