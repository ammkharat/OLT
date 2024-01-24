using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    internal class DtoFetcher : ClientBackgroundingFriendly<DtoFilters, IList<DomainObject>>
    {
        private WidgetAppearance WidgetToDisplayOnError { get; set; }
        private readonly IMultiGridContext context;

        public DtoFetcher(IMultiGridContext context, WidgetAppearance widgetToDisplayOnError)
        {
            WidgetToDisplayOnError = widgetToDisplayOnError;
            this.context = context;
        }

        public override IList<DomainObject> DoWork(DtoFilters filters)
        {
            IList<DomainObject> dtos = context.GetData(filters);
            return dtos;
        }

        public override bool ViewEnabled
        {
            set { context.Page.ButtonsEnabled = value; }
        }

        public override void WorkSuccessfullyCompleted(IList<DomainObject> result)
        {
            context.RefreshData(result);
        }

        public override void OnError(Exception e)
        {
            if (e.Message.Contains("Timeout expired") || e.Message.Contains("Transaction Timeout"))
            {
                context.Page.ShowUnableToReturnTheAmountOfDataRequestedError(StringResources.UnableToReturnAmountOfDataError);
                context.Details.ShowButtonAppearance = WidgetToDisplayOnError;
                context.RefreshData(true);
            }
            else
            {
                throw new Exception("Error fetching DTO data", e);
            }
        }
    }
}