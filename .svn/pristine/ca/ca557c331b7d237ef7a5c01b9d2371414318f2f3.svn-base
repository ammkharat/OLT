using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LabAlertDefinitionDetailsPresenter
    {
        private readonly ILabAlertDefinitionDetails view;
        private readonly LabAlertDefinition definition;

        public LabAlertDefinitionDetailsPresenter(ILabAlertDefinitionDetails view, LabAlertDefinition definition)
        {
            this.view = view;
            this.definition = definition;
        }

        public void LoadView()
        {
            if (definition == null)
            {
                PopulateEmptyView();
            }
            else
            {
                MapDefinitionToView();
            }
        }

        private void MapDefinitionToView()
        {
            view.CreatedBy = definition.CreatedBy.FullNameWithUserName;
            view.EditedBy = definition.LastModifiedBy.FullNameWithUserName;
            view.Active = definition.IsActive;

            view.DefinitionName = definition.Name;
            view.FunctionalLocation = definition.FunctionalLocation.FullHierarchyWithDescription;
            view.Description = definition.Description;
            view.Tag = definition.TagInfo.NameAndDescription;
            view.MinimumNumberOfSamples = definition.MinimumNumberOfSamples.ToString();

            view.LabAlertTagQueryRangeFrom = definition.LabAlertTagQueryRange.FromDescription;
            view.LabAlertTagQueryRangeTo = definition.LabAlertTagQueryRange.ToDescription;                

            view.Schedule = definition.ScheduleDescription;
        }

        private void PopulateEmptyView()
        {
            view.CreatedBy = string.Empty;
            view.EditedBy = string.Empty;
            view.Active = false;

            view.DefinitionName = string.Empty;
            view.FunctionalLocation = string.Empty;
            view.Description = string.Empty;
            view.Tag = string.Empty;
            view.MinimumNumberOfSamples = string.Empty;

            view.LabAlertTagQueryRangeFrom = string.Empty;
            view.LabAlertTagQueryRangeTo = string.Empty;
            view.Schedule = null;
        }
    }
}

