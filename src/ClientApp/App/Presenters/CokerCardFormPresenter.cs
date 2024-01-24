using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Domain.CokerCard;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CokerCardFormPresenter : AbstractFormPresenter <ICokerCardFormView, CokerCard>
    {
        private readonly ICokerCardService service;
        private readonly List<ShiftPattern> allShifts;
        private SupportingDataForEditObject supportingDataForEditObject;

        public CokerCardFormPresenter(ICokerCardFormView view, long configurationId, CokerCard cokerCard)
            : base(view, cokerCard)
        {
            service = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
            
            IShiftPatternService shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            allShifts = shiftPatternService.QueryBySite(userContext.Site);

            CokerCardConfiguration configuration = service.QueryCokerCardConfigurationById(configurationId);
            supportingDataForEditObject = new SupportingDataForEditObject(configuration, null, null, null);
                }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CokerCardFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;
            view.Shift = ClientSession.GetUserContext().UserShift.ShiftPattern.Name;
            view.Author = ClientSession.GetUserContext().User;
            view.CreateDateTime = Clock.Now;

            if (IsEdit)
            {
                SetupConfigurationPreviousCardAndNextCard();
            }
            else    
            {
                editObject = CreateNewCokerCard();
                }

            view.ConfigurationName = supportingDataForEditObject.CokerCardConfiguration.Name;
                    UpdateViewFromEditObject();
                }

        private CokerCard CreateNewCokerCard()
        {
            SetupConfigurationPreviousCardAndNextCard();

            CokerCard cokerCard = new CokerCard(
                null,
                supportingDataForEditObject.CokerCardConfiguration.IdValue,
                supportingDataForEditObject.CokerCardConfiguration.Name,
                supportingDataForEditObject.CokerCardConfiguration.FunctionalLocation,
                ClientSession.GetUserContext().Assignment,
                ClientSession.GetUserContext().UserShift.ShiftPattern,
                ClientSession.GetUserContext().UserShift.StartDate,
                ClientSession.GetUserContext().User,
                Clock.Now,
                ClientSession.GetUserContext().User,
                Clock.Now,
                false);

            return cokerCard;
        }


        private void SetupConfigurationPreviousCardAndNextCard()
        {
            CokerCardDataLoader.CokerCardData cokerCardData = CokerCardDataLoader.Load(
                userContext.UserShift.ShiftPattern,
                userContext.UserShift.StartDate,
                allShifts,
                supportingDataForEditObject.CokerCardConfiguration,
                service);
            supportingDataForEditObject = new SupportingDataForEditObject(
                supportingDataForEditObject.CokerCardConfiguration,
                cokerCardData.PreviousCard,
                cokerCardData.NextCard,
                cokerCardData.PreviousPreviousCard);
        }

        protected void UpdateViewWithDefaults()
        {
            // do nothing - this method is not called in the base class, nor is it called here
        }

        private void UpdateViewFromEditObject()
        {
            view.DisplayAdapter = new CokerCardDisplayAdapter(
                new UserShift(editObject.Shift, editObject.ShiftStartDate).ChooseNextShift(allShifts),
                supportingDataForEditObject.CokerCardConfiguration, 
                editObject, 
                supportingDataForEditObject.PreviousCard,
                supportingDataForEditObject.NextCard,
                supportingDataForEditObject.PreviousPreviousCard);
        }

        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            EditCokerCardHistoryFormPresenter presenter = new EditCokerCardHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public override void Insert(SaveUpdateDomainObjectContainer<CokerCard> cokerCardToInsert)
        {            
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, cokerCardToInsert.Item, view.DisplayAdapter.CycleStepEntriesForOtherCokerCard);
        }

        public override void Update(SaveUpdateDomainObjectContainer<CokerCard> cokerCard)
        {            
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, cokerCard.Item, view.DisplayAdapter.CycleStepEntriesForOtherCokerCard);
        }

        protected override SaveUpdateDomainObjectContainer<CokerCard> GetPopulatedEditObjectToUpdate()
        {
            PopulateFromView();
            return new SaveUpdateDomainObjectContainer<CokerCard>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<CokerCard> GetNewObjectToInsert()
        {
            PopulateFromView();
            return new SaveUpdateDomainObjectContainer<CokerCard>(editObject);
        }

        private void PopulateFromView()
        {
            editObject.LastModifiedDate = Clock.Now;
            editObject.LastModifiedBy = ClientSession.GetUserContext().User;

            editObject.DrumEntries.Clear();
            editObject.DrumEntries.AddRange(view.DisplayAdapter.DrumEntries);

            editObject.CycleStepEntries.Clear();
            editObject.CycleStepEntries.AddRange(view.DisplayAdapter.CycleStepEntriesForCurrentCokerCard);
        }

        public override bool ValidateViewHasError()
        {
            bool hasError = false;

            if (!view.DisplayAdapter.Validate())
            {
                hasError = true;
                view.ShowErrors();
            }

            return hasError;
        }

        private class SupportingDataForEditObject
        {
            private readonly CokerCardConfiguration cokerCardConfiguration;
            private readonly CokerCard previousCard;
            private readonly CokerCard nextCard;
            private readonly CokerCard previousPreviousCard;

            public SupportingDataForEditObject(
                CokerCardConfiguration cokerCardConfiguration,
                CokerCard previousCard,
                CokerCard nextCard,
                CokerCard previousPreviousCard)
            {
                this.cokerCardConfiguration = cokerCardConfiguration;
                this.previousCard = previousCard;
                this.nextCard = nextCard;
                this.previousPreviousCard = previousPreviousCard;
            }

            public CokerCardConfiguration CokerCardConfiguration
            {
                get { return cokerCardConfiguration; }
            }

            public CokerCard PreviousCard
            {
                get { return previousCard; }
            }

            public CokerCard NextCard
            {
                get { return nextCard; }
            }

            public CokerCard PreviousPreviousCard
            {
                get { return previousPreviousCard; }
            }
        }
    }
}
