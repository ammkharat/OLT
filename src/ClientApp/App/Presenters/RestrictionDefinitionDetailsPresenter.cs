using System;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RestrictionDefinitionDetailsPresenter
    {
        private readonly IRestrictionDefinitionDetails view;
        private readonly RestrictionDefinition definition;

        public RestrictionDefinitionDetailsPresenter(IRestrictionDefinitionDetails view, RestrictionDefinition definition)
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
            view.EditedBy = definition.LastModifiedBy.FullNameWithUserName;
            view.Active = definition.IsActive;

            view.DefinitionName = definition.Name;
            view.FunctionalLocation = definition.FunctionalLocation.FullHierarchyWithDescription;
            view.Description = definition.Description;
            view.MeasurementTag = string.Format("{0} ({1})", definition.MeasurementTagInfo.Name, definition.MeasurementTagInfo.Description);
            if (definition.ProductionTargetValue.HasValue)
            {
                view.ProductionTarget = Convert.ToString(definition.ProductionTargetValue);
            }
            else if (definition.ProductionTargetTagInfo != null)
            {
                view.ProductionTarget = string.Format("{0} ({1})", definition.ProductionTargetTagInfo.Name, definition.ProductionTargetTagInfo.Description); 
            }
            if (!definition.LastInvokedDateTime.HasValue || definition.LastInvokedDateTime.Value < definition.CreatedDate)
            {
                view.PreviousInvocationDate = StringResources.RestrictionDefinitionNotInvokedYet;
            }
            else
            {
                view.PreviousInvocationDate = definition.LastInvokedDateTime.Value.ToLongDateAndTimeString();
            }
            view.ToleranceValue = definition.ToleranceValue;

            view.FrequencyValue = definition.HourFrequency == "0" ? "1" : definition.HourFrequency; // DMND0010124 mangesh
        }

        private void PopulateEmptyView()
        {
            view.EditedBy = string.Empty;
            view.Active = false;

            view.DefinitionName = string.Empty;
            view.FunctionalLocation = string.Empty;
            view.Description = string.Empty;
            view.MeasurementTag = string.Empty;
            view.ProductionTarget = string.Empty;
            view.PreviousInvocationDate = string.Empty;
        }
    }
}

