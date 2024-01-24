using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class StandingOrderPagePresenter : AbstractLogDefinitionPagePresenter
    {
        private readonly IFlocSet flocSet;
        private readonly ISiteConfigurationService siteConfigurationService;

        public StandingOrderPagePresenter() : base(new StandingOrderPage())
        {
            flocSet = userContext.RootFlocSet;
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
        }

        protected override IList<LogDefinitionDTO> GetDtos(Range<Date> dateRange)
        {
            return service.QueryDtoByUserRootFlocsAndLogType(flocSet, LogType.DailyDirective, userContext.ReadableVisibilityGroupIds);
        }

        protected override bool ShouldBeDisplayed(LogDefinition logDefinition)
        {
            return LogType.DailyDirective == logDefinition.LogType;
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_StandingOrder; }
        }

        protected override bool IsAuthorizedToEdit(LogDefinitionDTO logDefinitionDto)
        {
            return authorized.ToEditStandingOrders(logDefinitionDto, userContext);
        }

        protected override bool IsAuthorizedToCancel(List<LogDefinitionDTO> logDefinitionDtos)
        {
            return authorized.ToCancelStandingOrders(logDefinitionDtos, userContext);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.StandingOrders; }
        }

        public override void DeleteButton_Clicked()
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.DeleteButton_Clicked();
        }

        protected override void Edit(LogDefinition domainObject)
        {
            if (DirectiveUtility.ShouldShowConvertingDirectivesToNewSystemMessage(siteConfigurationService, userContext.SiteId))
            {
                DirectiveUtility.ShowConvertingDirectivesToNewSystemMessage();
                return;
            }

            base.Edit(domainObject);
        }
    }
}
