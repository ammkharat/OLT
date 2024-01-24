using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.CokerCard;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class CokerCardPagePresenter : AbstractDeletableDomainPagePresenter<CokerCardDTO, CokerCard, ICokerCardDetails, ICokerCardPage>
    {
        private readonly ICokerCardService cokerCardService;

        private readonly List<ShiftPattern> allShifts;

        public CokerCardPagePresenter() : base(new CokerCardPage())
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;

            cokerCardService = clientServiceRegistry.GetService<ICokerCardService>();

            allShifts = clientServiceRegistry.GetService<IShiftPatternService>().QueryBySite(userContext.Site);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(CokerCard item)
        {
            return new EditCokerCardHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(CokerCard item)
        {
            return new CokerCardForm(item);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerCokerCardCreated += repeater_CokerCardCreated;
            remoteEventRepeater.ServerCokerCardUpdated += repeater_CokerCardUpdated;
            remoteEventRepeater.ServerCokerCardRemoved += repeater_CokerCardRemoved;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerCokerCardCreated -= repeater_CokerCardCreated;
            remoteEventRepeater.ServerCokerCardUpdated -= repeater_CokerCardUpdated;
            remoteEventRepeater.ServerCokerCardRemoved -= repeater_CokerCardRemoved;
        }

        private void repeater_CokerCardRemoved(object sender, DomainEventArgs<CokerCard> e)
        {
            // make sure we call the "base" delete first.
            repeater_Removed(sender, e);

            // update current grid item if it's before or after the item we just received.
            CokerCard cardRemoved = e.SelectedItem;
            UpdateCokerCardDetailsForChangesToPreviousOrNextCokerCard(cardRemoved);
        }

        private void repeater_CokerCardUpdated(object sender, DomainEventArgs<CokerCard> e)
        {
            // make sure we call the "base" Update first.
            repeater_Updated(sender, e);

            // update current grid item if it's before or after the item we just received.
            CokerCard cardUpdated = e.SelectedItem;
            UpdateCokerCardDetailsForChangesToPreviousOrNextCokerCard(cardUpdated);
        }

        private void repeater_CokerCardCreated(object sender, DomainEventArgs<CokerCard> e)
        {
            // make sure we call the "base" add first.
            repeater_Created(sender, e);

            // update current grid item if it's before or after the item we just received.
            CokerCard cardCreated = e.SelectedItem;
            UpdateCokerCardDetailsForChangesToPreviousOrNextCokerCard(cardCreated);
        }

        private void UpdateCokerCardDetailsForChangesToPreviousOrNextCokerCard(CokerCard changedCokerCard)
        {
            CokerCardDTO selectedCokerCard = page.FirstSelectedItem;
            if (selectedCokerCard == null)
                return;

            UserShift previousShift = new UserShift(changedCokerCard.Shift, changedCokerCard.ShiftStartDate).ChoosePreviousShift(allShifts);
            UserShift nextShift = new UserShift(changedCokerCard.Shift, changedCokerCard.ShiftStartDate).ChooseNextShift(allShifts);

            if (previousShift.IsSameShift(selectedCokerCard.ShiftId, selectedCokerCard.ShiftDate) ||
                nextShift.IsSameShift(selectedCokerCard.ShiftId, selectedCokerCard.ShiftDate))
            {
                if (!page.IsDisposed)
                {
                    page.Invoke(new Action(ControlShowingOfDetailsPane));
                }
            }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_CokerCard; }
        }

        protected override void ControlDetailButtons()
        {
            List<CokerCardDTO> selectedDTOs = page.SelectedItems;
            CokerCardDTO firstSelectedItem = page.FirstSelectedItem;
            
            bool hasSingleItemSelected = selectedDTOs.Count == 1;
            bool hasItemsSelected = selectedDTOs.Count > 0;

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            UserShift userShift = userContext.UserShift;

            ICokerCardDetails cokerCardDetails = page.Details;
            
            cokerCardDetails.DeleteEnabled = hasItemsSelected 
                && authorized.ToDeleteCokerCards(selectedDTOs, userRoleElements, userShift);
            
            cokerCardDetails.EditEnabled = hasSingleItemSelected 
                && authorized.ToEditCokerCard(firstSelectedItem, userRoleElements, userShift);
            
            cokerCardDetails.ViewEditHistoryEnabled = hasSingleItemSelected;
        }

        protected override bool IsItemInDateRange(CokerCard item, Range<Date> dateRange)
        {
            return new DateRange(dateRange).ContainsInclusive(item.CreatedDateTime);
        }

        protected override bool ShouldBeDisplayed(CokerCard item)
        {
            foreach (FunctionalLocation floc in userContext.DivisionsAndSectionsForSelectedFunctionalLocations)
            {
                if (item.FunctionalLocation.Id == floc.Id)
                {
                    return true;
                }
            }

            return false;
        }

        protected override CokerCardDTO CreateDTOFromDomainObject(CokerCard cokerCard)
        {
            CokerCardDTO newDto = new CokerCardDTO(cokerCard);
            return newDto;
        }

        protected override CokerCard QueryByDto(CokerCardDTO dto)
        {
            return cokerCardService.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(ICokerCardDetails details, CokerCard value)
        {
            UserShift nextCokerCardUserShift = null;
            if (value != null)
            {
                nextCokerCardUserShift = new UserShift(value.Shift, value.ShiftStartDate).ChooseNextShift(allShifts);
            }

            CokerCardConfiguration configuration = null;
            if (value != null)
            {
                configuration = cokerCardService.QueryCokerCardConfigurationByIdWithCaching(value.ConfigurationId);
            }

            CokerCard previousCokerCard = null;
            CokerCard nextCokerCard = null;
            CokerCard previousPreviousCard = null;
            if (value != null && configuration != null)
            {
                CokerCardDataLoader.CokerCardData cokerCardData = CokerCardDataLoader.Load(
                    value.Shift, value.ShiftStartDate, allShifts, configuration, cokerCardService);
                previousCokerCard = cokerCardData.PreviousCard;
                nextCokerCard = cokerCardData.NextCard;
                previousPreviousCard = cokerCardData.PreviousPreviousCard;
            }

            details.SetDetails(nextCokerCardUserShift, configuration, value, previousCokerCard, nextCokerCard, previousPreviousCard);
        }

        protected override void Delete(CokerCard cokerCard)
        {
            cokerCard.LastModifiedBy = ClientSession.GetUserContext().User;
            cokerCard.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(cokerCardService.Remove, cokerCard);
        }
           
        // Overriding this because we want to lock at the CokerCardConfiguration, not at the CokerCard.  
        // We do this because we don't want a user editing the coker card from the previous or next shift at the same time
        // as someone editing for the current shift - and vice versa.  This is because the values of the previous card affect
        // the editable cells in the current card.  See Mingle Story #1106.
        protected override bool LockDatabaseObjectWhileInUse(Action<CokerCard> action, CokerCard domainObject, LockType lockType)
        {
            string lockIdentifier = CokerCardFormLauncher.LockIdentifier(domainObject.ConfigurationId);
            return LockDatabaseObjectWhileInUse(action, domainObject, lockIdentifier, lockType);
        }

        protected override IList<CokerCardDTO> GetDtos(Range<Date> dateRange)
        {
            if (dateRange == null)
            {
                int daysToDisplayCokerCards = userContext.SiteConfiguration.DaysToDisplayCokerCards;

                DateTime lowerBound = DateTime.Now.SubtractDays(daysToDisplayCokerCards).GetNetworkPortable();
                Range<Date> defaultRange = new Range<Date>(new Date(lowerBound), new Date(Clock.Now));

                return cokerCardService.QueryByExactFlocMatch(
                    new ExactFlocSet(userContext.DivisionsAndSectionsForSelectedFunctionalLocations), defaultRange);                
            }
            return cokerCardService.QueryByExactFlocMatch(
                new ExactFlocSet(userContext.DivisionsAndSectionsForSelectedFunctionalLocations), dateRange);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.CokerCards; }
        }
    }
}