using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardDataLoader
    {
        public static CokerCardData Load(
            ShiftPattern currentCardShift,
            Date currentCardShiftDate,
            List<ShiftPattern> allShifts,
            CokerCardConfiguration configuration,
            ICokerCardService service)
        {
            UserShift currentCardUserShift = new UserShift(currentCardShift, currentCardShiftDate);

            Common.Domain.CokerCard.CokerCard previousCard = service.QueryCokerCardByConfigurationAndShift(
                configuration.IdValue,
                currentCardUserShift.ChoosePreviousShift(allShifts));
            Common.Domain.CokerCard.CokerCard nextCard = service.QueryCokerCardByConfigurationAndShift(
                configuration.IdValue,
                currentCardUserShift.ChooseNextShift(allShifts));

            Common.Domain.CokerCard.CokerCard previousPreviousCard = null;
            if (previousCard != null && !previousCard.HasAtLeastOneEntryPerDrum(configuration.Drums))
            {
                previousPreviousCard = service.QueryCokerCardByConfigurationAndShift(
                    configuration.IdValue,
                    currentCardUserShift.ChoosePreviousShift(allShifts).ChoosePreviousShift(allShifts));
            }

            return new CokerCardData(previousCard, nextCard, previousPreviousCard);
        }

        public class CokerCardData
        {
            private readonly Common.Domain.CokerCard.CokerCard previousCard;
            private readonly Common.Domain.CokerCard.CokerCard nextCard;
            private readonly Common.Domain.CokerCard.CokerCard previousPreviousCard;

            public CokerCardData(
                Common.Domain.CokerCard.CokerCard previousCard, 
                Common.Domain.CokerCard.CokerCard nextCard, 
                Common.Domain.CokerCard.CokerCard previousPreviousCard)
            {
                this.previousCard = previousCard;
                this.nextCard = nextCard;
                this.previousPreviousCard = previousPreviousCard;
            }

            public Common.Domain.CokerCard.CokerCard PreviousCard
            {
                get { return previousCard; }
            }

            public Common.Domain.CokerCard.CokerCard NextCard
            {
                get { return nextCard; }
            }

            public Common.Domain.CokerCard.CokerCard PreviousPreviousCard
            {
                get { return previousPreviousCard; }
            }
        }
    }
}
