using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class LogDefinitionPagePresenter : AbstractLogDefinitionPagePresenter
    {
        public LogDefinitionPagePresenter() : base(new LogDefinitionPage())
        {
        }

        protected override IList<LogDefinitionDTO> GetDtos(Range<Date> dateRange)
        {
            return service.QueryDtoByFunctionalLocationsAndLogType(userContext.RootFlocSet, LogType.Standard, userContext.ReadableVisibilityGroupIds);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_LogDefinition; }
        }

        protected override bool ShouldBeDisplayed(LogDefinition logDefinition)
        {
            return LogType.Standard == logDefinition.LogType;
        }

        protected override bool IsAuthorizedToEdit(LogDefinitionDTO logDefinitionDto)
        {
            return authorized.ToEditLogDefinition(logDefinitionDto, userContext);
        }

        protected override bool IsAuthorizedToCancel(List<LogDefinitionDTO> logDefinitionDtos)
        {
            return authorized.ToCancelLogDefinitions(logDefinitionDtos, userContext);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.LogDefinitions; }
        }
    }
}
