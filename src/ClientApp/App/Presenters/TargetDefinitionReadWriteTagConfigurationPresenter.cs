using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TargetDefinitionReadWriteTagConfigurationPresenter
    {
        public const string MAX_THRESHOLD = "MaxThreshold";
        public const string MIN_THRESHOLD = "MinThreshold";
        public const string TARGET_THRESHOLD = "TargetThreshold";
        public const string GAP_UNIT_VALUE = "GapUnitValue";

        private readonly ITargetDefinitionService service;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly ITargetDefinitionReadWriteTagConfigurationView view;
        private readonly TargetDefinition targetDefinition;
        private readonly TargetDefinitionReadWriteTagConfiguration targetDefinitionTagConfiguration;

        public TargetDefinitionReadWriteTagConfigurationPresenter(
            ITargetDefinitionReadWriteTagConfigurationView view,
            TargetDefinition targetDefinition) 
            : this(
            view,
            targetDefinition,
            ClientServiceRegistry.Instance.GetService<ITargetDefinitionService>(),
            ClientServiceRegistry.Instance.GetService<IPlantHistorianService>())
        {
        }

        public TargetDefinitionReadWriteTagConfigurationPresenter(
            ITargetDefinitionReadWriteTagConfigurationView view,
            TargetDefinition targetDefinition,
            ITargetDefinitionService service,
            IPlantHistorianService plantHistorianService)
        {
            this.view = view;

            this.service = service;
            this.plantHistorianService = plantHistorianService;

            this.targetDefinition = targetDefinition;
            
            // We don't want to modify the original target definition's r/w configuration,
            // so we clone.
            targetDefinitionTagConfiguration = (TargetDefinitionReadWriteTagConfiguration)targetDefinition.ReadWriteTagsConfiguration.Clone();
        }

        public TargetDefinitionReadWriteTagConfiguration ReadWriteTagConfigurations
        {
            get { return targetDefinitionTagConfiguration; }
        }

        public void Load()
        {
            view.TargetDefinitionName = targetDefinition.Name;
            view.TargetDefinitionNameEnabled = false;
            view.MaxThresholdTagEnabled = false;
            view.MinThresholdTagEnabled = false;
            view.GapUnitValueEnabled = false;
            view.TargetThresholdEnabled = false;
            view.MaxThresholdDirectionList = new List<TagDirection>(TagDirection.All);
            view.MinThresholdDirectionList = new List <TagDirection>(TagDirection.All);
            view.GapUnitValueDirectionList = new List <TagDirection>(TagDirection.All);
            view.TargetThresholdDirectionList = new List<TagDirection>(TagDirection.All);
            view.MaxThresholdDirection = targetDefinitionTagConfiguration.MaxValue.Direction;
            view.MinThresholdDirection = targetDefinitionTagConfiguration.MinValue.Direction;
            view.GapUnitDirection = targetDefinitionTagConfiguration.GapUnitValue.Direction;
            view.TargetThresholdDirection = targetDefinitionTagConfiguration.TargetValue.Direction;
            view.MaxThresholdTag = targetDefinitionTagConfiguration.MaxValue.Tag;
            view.MinThresholdTag = targetDefinitionTagConfiguration.MinValue.Tag;
            view.GapUnitValueTag = targetDefinitionTagConfiguration.GapUnitValue.Tag; 
            view.TargetThresholdTag = targetDefinitionTagConfiguration.TargetValue.Tag;
        }
        
        public void DirectionChanged(string propertyName)
        {
            TagDirection direction = GetDirection(propertyName);
            if (direction == TagDirection.None)
            {
                SetTag(propertyName, TagInfo.CreateEmpty());
            }
        }
        
        private TagDirection GetDirection(string propertyName)
        {
            if (propertyName == MAX_THRESHOLD)
            {
                return view.MaxThresholdDirection;
            }
            if (propertyName == MIN_THRESHOLD)
            {
                return view.MinThresholdDirection;
            }
            if (propertyName == GAP_UNIT_VALUE)
            {
                return view.GapUnitDirection;
            }
            if (propertyName == TARGET_THRESHOLD)
            {
                return view.TargetThresholdDirection;
            }
            throw new ApplicationException();
        }
        
        public void TagSearch(string propertyName)
        {
            ITagSearchFormView tagSearchFormView = view.DisplayTagSearchForm();
            if(DialogResult.OK == tagSearchFormView.ShowDialog())
            {
                TagInfo selectedTag = tagSearchFormView.SelectedTag;
                SetTag(propertyName, selectedTag ?? TagInfo.CreateEmpty());
            }
        }

        private void SetTag(string propertyName, TagInfo tag)
        {
            if(propertyName == MAX_THRESHOLD)
            {
                view.MaxThresholdTag = tag;
            }
            else if(propertyName == MIN_THRESHOLD)
            {
                view.MinThresholdTag = tag;
            }
            else if(propertyName == GAP_UNIT_VALUE)
            {
                view.GapUnitValueTag = tag;
            }
            else if (propertyName == TARGET_THRESHOLD)
            {
                view.TargetThresholdTag = tag;
            }
        }

        public void Clear()
        {
            view.ClearErrors();
            view.MaxThresholdDirection = TagDirection.None;
            view.MinThresholdDirection = TagDirection.None;
            view.GapUnitDirection = TagDirection.None;
            view.TargetThresholdDirection = TagDirection.None;
            view.MaxThresholdTag = TagInfo.CreateEmpty();
            view.MinThresholdTag = TagInfo.CreateEmpty();
            view.GapUnitValueTag = TagInfo.CreateEmpty();
            view.TargetThresholdTag = TagInfo.CreateEmpty();
        }

        public void Cancel()
        {
            view.CloseView();
        }

        public void Accept()
        {
            UpdateFromView();
            if(AreConfigurationSettingsValid())
            {
                view.SetDialogResultOK();
                view.CloseView();
            }
        }

        private void UpdateFromView()
        {
            targetDefinitionTagConfiguration.MaxValue = new ReadWriteTagConfiguration(view.MaxThresholdDirection, view.MaxThresholdTag);
            targetDefinitionTagConfiguration.MinValue = new ReadWriteTagConfiguration(view.MinThresholdDirection, view.MinThresholdTag);
            targetDefinitionTagConfiguration.GapUnitValue = new ReadWriteTagConfiguration(view.GapUnitDirection, view.GapUnitValueTag);
            targetDefinitionTagConfiguration.TargetValue = new ReadWriteTagConfiguration(view.TargetThresholdDirection, view.TargetThresholdTag);
        }

        private bool AreConfigurationSettingsValid()
        {
            view.ClearErrors();
            bool isValid = CheckIfDirectionsAreValid(true);
            isValid = CheckIfTagsAreValid(isValid);
            isValid = CheckForMultipleWritesToSameTags(isValid);
            isValid = CheckIfTagReadsValid(isValid);
            isValid = CheckIfTagWritesValid(isValid);
            isValid = CheckIfOtherTargetDefinitionsWriteToTags(isValid);
            return isValid;
        }

        private bool CheckIfTagsAreValid(bool isValid)
        {
            if(targetDefinitionTagConfiguration.MaxValue.IsTagInValid())
            {
                view.ShowInvalidMaxThresholdTagError();
                isValid = false;
            }
            if(targetDefinitionTagConfiguration.MinValue.IsTagInValid())
            {
                view.ShowInvalidMinThresholdTagError();
                isValid = false;
            }
            if(targetDefinitionTagConfiguration.TargetValue.IsTagInValid())
            {
                view.ShowInvalidTargetThresholdTagError();
                isValid = false;
            }
            if(targetDefinitionTagConfiguration.GapUnitValue.IsTagInValid())
            {
                view.ShowInvalidGapUnitValueTagError();
                isValid = false;
            }
            return isValid;
        }

        private bool CheckIfDirectionsAreValid(bool isValid)
        {
            if(targetDefinitionTagConfiguration.MaxValue.IsDirectionInValid())
            {
                view.ShowInvalidMaxThresholdDirectionError();
                isValid = false;
            }
            if(targetDefinitionTagConfiguration.MinValue.IsDirectionInValid())
            {
                view.ShowInvalidMinThresholdDirectionError();
                isValid = false;
            }
            if (targetDefinitionTagConfiguration.GapUnitValue.IsDirectionInValid())
            {
                view.ShowInvalidGapUnitValueDirectionError();
                isValid = false;
            }
            if (targetDefinitionTagConfiguration.TargetValue.IsDirectionInValid())
            {
                view.ShowInvalidTargetThresholdDirectionError();
                isValid = false;
            }
            return isValid;
        }

        private bool CheckForMultipleWritesToSameTags(bool isValid)
        {
            if(isValid)
            {
                if(targetDefinitionTagConfiguration.MaxValue.IsWriteDirectionAndSameTagAs(targetDefinitionTagConfiguration.MinValue))
                {
                    view.ShowMaxAndMinSameTagError();
                    isValid = false;
                }
                if(targetDefinitionTagConfiguration.MaxValue.IsWriteDirectionAndSameTagAs(targetDefinitionTagConfiguration.TargetValue))
                {
                    view.ShowMaxAndTargetSameTagError();
                    isValid = false;
                }
                if(targetDefinitionTagConfiguration.MaxValue.IsWriteDirectionAndSameTagAs(targetDefinitionTagConfiguration.GapUnitValue))
                {
                    view.ShowMaxAndGapUnitValueSameTagError();
                    isValid = false;
                }
                if(targetDefinitionTagConfiguration.MinValue.IsWriteDirectionAndSameTagAs(targetDefinitionTagConfiguration.TargetValue))
                {
                    view.ShowMinAndTargetSameTagError();
                    isValid = false;
                }
                if(targetDefinitionTagConfiguration.MinValue.IsWriteDirectionAndSameTagAs(targetDefinitionTagConfiguration.GapUnitValue))
                {
                    view.ShowMinAndGapUnitValueSameTagError();
                    isValid = false;
                }
                if(targetDefinitionTagConfiguration.TargetValue.IsWriteDirectionAndSameTagAs(targetDefinitionTagConfiguration.GapUnitValue))
                {
                    view.ShowTargetAndGapUnitValueSameTagError();
                    isValid = false;
                }
            }
            return isValid;
        }

        private bool CheckIfTagReadsValid(bool isValid)
        {
            if (isValid)
            {
                if (IsTagReadInvalid(targetDefinitionTagConfiguration.MaxValue))
                {
                    view.ShowMaxTagInvalidReadError();
                    isValid = false;
                }
                if (IsTagReadInvalid(targetDefinitionTagConfiguration.MinValue))
                {
                    view.ShowMinTagInvalidReadError();
                    isValid = false;
                }
                if (IsTagReadInvalid(targetDefinitionTagConfiguration.GapUnitValue))
                {
                    view.ShowGapUnitValueTagInvalidReadError();
                    isValid = false;
                }
                if (IsTagReadInvalid(targetDefinitionTagConfiguration.TargetValue))
                {
                    view.ShowTargetTagInvalidReadError();
                    isValid = false;
                }
            }
            return isValid;
        }
        private bool CheckIfTagWritesValid(bool isValid)
        {
            if (isValid)
            {
                if (IsTagWriteInvalid(targetDefinitionTagConfiguration.MaxValue))
                {
                    view.ShowMaxTagInvalidWriteError();
                    isValid = false;
                }
                if (IsTagWriteInvalid(targetDefinitionTagConfiguration.MinValue))
                {
                    view.ShowMinTagInvalidWriteError();
                    isValid = false;
                }
                if (IsTagWriteInvalid(targetDefinitionTagConfiguration.GapUnitValue))
                {
                    view.ShowGapUnitValueTagInvalidWriteError();
                    isValid = false;
                }
                if (IsTagWriteInvalid(targetDefinitionTagConfiguration.TargetValue))
                {
                    view.ShowTargetTagInvalidWriteError();
                    isValid = false;
                }
            }
            return isValid;
        }
        private bool CheckIfOtherTargetDefinitionsWriteToTags(bool isValid)
        {
            if(isValid)
            {
                Error error = IsWriteTagAssociatedToOtherTargetDefinition(targetDefinitionTagConfiguration.MaxValue);
                if(error.HasError)
                {
                    view.ShowMaxTagAssociatedToOtherTargetDefinitionError(error.Message);
                    isValid = false;
                }

                error = IsWriteTagAssociatedToOtherTargetDefinition(targetDefinitionTagConfiguration.MinValue);
                if(error.HasError)
                {
                    view.ShowMinTagAssociatedToOtherTargetDefinitionError(error.Message);
                    isValid = false;
                }
                error = IsWriteTagAssociatedToOtherTargetDefinition(targetDefinitionTagConfiguration.GapUnitValue);
                if(error.HasError)
                {
                    view.ShowGapUnitValueTagAssociatedToOtherTargetDefinitionError(error.Message);
                    isValid = false;
                }
                error = IsWriteTagAssociatedToOtherTargetDefinition(targetDefinitionTagConfiguration.TargetValue);
                if (error.HasError)
                {
                    view.ShowTargetTagAssociatedToOtherTargetDefinitionError(error.Message);
                    isValid = false;
                }
            }
            return isValid;
        }
        
        private Error IsWriteTagAssociatedToOtherTargetDefinition(ReadWriteTagConfiguration tagConfiguration)
        {
            if(tagConfiguration.IsWriteDirection())
            {
                return service.IsValidWriteTag(targetDefinition.Id, targetDefinition.Schedule, tagConfiguration.Tag);
            }
            return Error.HasNoError;
        }
        
        private bool IsTagReadInvalid(ReadWriteTagConfiguration config)
        {
            if (config.IsReadDirection())
            {
                return !plantHistorianService.CanReadTagValue(config.Tag);
            }
            return false;
        }
        private bool IsTagWriteInvalid(ReadWriteTagConfiguration config)
        {
            if (config.IsWriteDirection())
            {
                return !plantHistorianService.CanWriteTagValue(config.Tag);
            }
            return false;
        }
    }
}