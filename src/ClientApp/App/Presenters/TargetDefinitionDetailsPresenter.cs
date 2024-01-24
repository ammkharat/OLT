using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;
using System;

namespace Com.Suncor.Olt.Client.Presenters
{
    /// <summary>
    /// Presents the details of the given target definition.
    /// </summary>
    public class TargetDefinitionDetailsPresenter
    {
        private readonly ITargetDefinitionDetails view;
        private readonly TargetDefinition targetDefinition;

        public TargetDefinitionDetailsPresenter(ITargetDefinitionDetails view, TargetDefinition targetDefinition)
        {
            this.view = view;
            this.targetDefinition = targetDefinition;
        }

        public void LoadView()
        {
            if (targetDefinition == null)
            {
                PopulateEmptyView();
            }
            else
            {
                MapTargetDefinitionToView();
            }
        }

        private void MapTargetDefinitionToView()
        {
            view.EditedBy = targetDefinition.LastModifiedBy.FullNameWithUserName;

            view.RequiredApproval = targetDefinition.RequiresApproval;
            view.RequiredAlert = targetDefinition.IsAlertRequired;
            view.RequiresResponseWhenAlerted = targetDefinition.RequiresResponseWhenAlerted;
            view.Active = targetDefinition.IsActive;
            view.GenerateActionItem = targetDefinition.GenerateActionItem;

            view.TargetName = targetDefinition.Name;
            view.FunctionalLocation = targetDefinition.FunctionalLocation.FullHierarchyWithDescription;
            view.Description = targetDefinition.Description;
            view.Tag = string.Format("{0} ({1})", targetDefinition.TagInfo.Name, targetDefinition.TagInfo.Description);
            view.Category = targetDefinition.Category.Name;
            view.Priority = targetDefinition.Priority.Name;
            view.WorkAssignment = targetDefinition.Assignment != null ? targetDefinition.Assignment.Name : null;

            // Threshold
            view.NeverToExceedMaxValue = NullableDecimalAsString(targetDefinition.NeverToExceedMaximum);
            view.MaxValue = NullableDecimalAsString(targetDefinition.MaxValue);
            view.NeverToExceedMinValue = NullableDecimalAsString(targetDefinition.NeverToExceedMinimum);
            view.MinValue = NullableDecimalAsString(targetDefinition.MinValue);
            view.TargetValue = targetDefinition.TargetValue.Title;

            view.GapUnitValue = GapUnitValueAsString(targetDefinition.GapUnitValue);
            view.GapUnitValueUnits = targetDefinition.GapUnitValue.HasValue ? targetDefinition.TagInfo.Units : string.Empty;
                        
            view.NeverToExceedMaxFrequency = GetFrequencyDisplayString(targetDefinition.NeverToExceedMaximum, targetDefinition.NeverToExceedMaxFrequency);
            view.NeverToExceedMinFrequency = GetFrequencyDisplayString(targetDefinition.NeverToExceedMinimum, targetDefinition.NeverToExceedMinFrequency);
            view.MaxValueFrequency = GetFrequencyDisplayString(targetDefinition.MaxValue, targetDefinition.MaxValueFrequency);
            view.MinValueFrequency = GetFrequencyDisplayString(targetDefinition.MinValue, targetDefinition.MinValueFrequency);

            view.PreApprovedNeverToExceedMinValue =
                NullableDecimalAsString(targetDefinition.PreApprovedNeverToExceedMinimum);
            view.PreApprovedNeverToExceedMaxValue =
                NullableDecimalAsString(targetDefinition.PreApprovedNeverToExceedMaximum);
            view.PreApprovedMinValue = NullableDecimalAsString(targetDefinition.PreApprovedMinValue);
            view.PreApprovedMaxValue = NullableDecimalAsString(targetDefinition.PreApprovedMaxValue);
            
            view.Schedule = targetDefinition.Schedule;
            view.Comments = targetDefinition.Comments;
            view.OperationalMode = targetDefinition.OperationalMode.Name;

            view.TargetDefinitions = targetDefinition.AssociatedTargetDTOs;

            view.MaxReadWriteDirection = targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction;
            view.MinReadWriteDirection = targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction;
            view.TargetReadWriteDirection = targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction;
            view.GapUnitReadWriteDirection = targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction;

            view.DocumentLinks = targetDefinition.DocumentLinks;
        }

        private void PopulateEmptyView()
        {
            view.EditedBy = string.Empty;
            view.RequiredApproval = false;
            view.RequiredAlert = false;
            view.Active = false;
            view.TargetName = string.Empty;
            view.FunctionalLocation = string.Empty;
            view.Description = string.Empty;
            view.Tag = string.Empty;
            view.Category = string.Empty;
            view.Priority = string.Empty;

            // Threshold
            view.NeverToExceedMaxValue = string.Empty;
            view.MaxValue = string.Empty;
            view.NeverToExceedMinValue = string.Empty;
            view.MinValue = string.Empty;
            
            view.PreApprovedNeverToExceedMinValue = string.Empty;
            view.PreApprovedNeverToExceedMaxValue = string.Empty;
            view.PreApprovedMinValue = string.Empty;
            view.PreApprovedMaxValue = string.Empty;

            view.TargetValue = string.Empty;
            view.GapUnitValue = string.Empty;
            view.GapUnitValueUnits = string.Empty;
            view.OperationalMode = string.Empty;

            view.Schedule = null;
            view.Comments = null;
            view.TargetDefinitions = null;
            view.MaxReadWriteDirection = TagDirection.None;
            view.MinReadWriteDirection = TagDirection.None;
            view.TargetReadWriteDirection = TagDirection.None;
            view.GapUnitReadWriteDirection = TagDirection.None;

            view.DocumentLinks = new List<DocumentLink>();
        }

        //RITM0252906-changed by Mukesh
        private static string NullableDecimalAsString(decimal? value)
        {
            return value.HasValue ? value.Value.ToString("N3") : String.Empty;// value.Format();
            
        }

        private static string GetFrequencyDisplayString(decimal? threshold,  int? value)
        {
            if (!value.HasValue || !threshold.HasValue)
            {
                return string.Empty;
            }
            return value.Value.ToString(CultureInfo.InvariantCulture);
        }

        private static string GapUnitValueAsString(decimal? guv)
        {
            if (guv.HasValue)
            {
                
                return guv.Value.ToCurrency();
            }

            return string.Empty;
        }

    }
}

