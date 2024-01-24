using System;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RestrictionDefinitionFormPresenter : AbstractFormPresenter <IRestrictionDefinitionFormView, RestrictionDefinition>
    {
        private readonly IRestrictionDefinitionService service;
        private readonly IPlantHistorianService plantHistorianService;

        private readonly BackgroundWorker readTagInfoBackgroundWorker = new ClientBackgroundWorker();

		private enum TagValueType { ProductionTarget, Measured }

        public RestrictionDefinitionFormPresenter(IRestrictionDefinitionFormView view) 
            : this(view, CreateDefaultRestrictionDefinition())
        {
        }

        public RestrictionDefinitionFormPresenter(IRestrictionDefinitionFormView view, RestrictionDefinition definition) 
            : base(view, definition)
        {            
            service = ClientServiceRegistry.Instance.GetService<IRestrictionDefinitionService>();
            plantHistorianService = ClientServiceRegistry.Instance.GetService<IPlantHistorianService>();

            readTagInfoBackgroundWorker.DoWork += HandleReadTagInfoBackgroundWorkerDoWork;
            readTagInfoBackgroundWorker.RunWorkerCompleted += HandleReadTagInfoBackgroundWorkerCompleted;            
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.RestrictionDefinitionFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;
            
            UpdateViewFromEditObject();
        }

        protected override bool ShouldCancelOnFormClosing()
        {
            return readTagInfoBackgroundWorker.IsBusy;
        }

        private static RestrictionDefinition CreateDefaultRestrictionDefinition()
        {
            RestrictionDefinition definition = new RestrictionDefinition
                                                   {
                                                       Status = RestrictionDefinitionStatus.Valid,
                                                       IsActive = true,
                                                       CreatedDate = Clock.Now,
                                                       LastModifiedBy = ClientSession.GetUserContext().User
                                                   };
            definition.LastModifiedDateTime = definition.CreatedDate;
            return definition;
        }

        private void UpdateViewFromEditObject()
        {
            PopulateView(editObject);
            EnableDisableIsActiveCheckBox();
        }

        private void EnableDisableIsActiveCheckBox()
        {
            view.IsActiveCheckBoxEnabled = true;
        }

        private void PopulateView(RestrictionDefinition definition)
        {
            view.Name = definition.Name;
            view.Description = definition.Description;
            view.FunctionalLocation = definition.FunctionalLocation;
            view.MeasurementTagInfo = definition.MeasurementTagInfo;
            view.IsProductionTargetTypeValue = definition.ProductionTargetValue.HasValue || definition.ProductionTargetTagInfo == null;
            view.ProductionTargetValue = definition.ProductionTargetValue;
            view.ProductionTargetTagInfo = definition.ProductionTargetTagInfo;
            view.IsActive = definition.IsActive;
            view.HideDeviationAlerts = definition.IsOnlyVisibleOnReports;
            view.Author = definition.LastModifiedBy;
            view.CreateDateTime = definition.LastModifiedDateTime;
            //Added by Mukesh for RITM0219490
            view.ToleranceValue = definition.ToleranceValue;

            view.HourFrequency = definition.HourFrequency == "0" ? "1" : definition.HourFrequency; //DMND0010124 mangesh
        }

        private void PopulateRestrictionDefinitionFromView()
        {           
            editObject.Name = view.Name;
            editObject.Description = view.Description;
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.MeasurementTagInfo = view.MeasurementTagInfo;
            editObject.ProductionTargetValue = view.ProductionTargetValue;
            editObject.ProductionTargetTagInfo = view.ProductionTargetTagInfo;
            editObject.IsActive = view.IsActive;
            editObject.IsOnlyVisibleOnReports = view.HideDeviationAlerts;
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDateTime = Clock.Now;
            //Added by Mukesh for RITM0219490
            editObject.ToleranceValue = view.ToleranceValue;

            editObject.HourFrequency = view.HourFrequency; //DMND0010124 mangesh
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            DialogResultAndOutput<FunctionalLocation> result = view.ShowFunctionalLocationSelector();
            if (result.Result == DialogResult.OK)
            {
                view.FunctionalLocation = result.Output;
            }
        }

        public void HandleSearchMeasurementTagButtonClick(object sender, EventArgs eventArgs)
        {
            DialogResultAndOutput<TagInfo> result = view.ShowTagSelector();
            if(result.Result == DialogResult.OK)
            {
                TagInfo tagInfo = result.Output;
                view.MeasurementTagInfo = tagInfo;
                SetMeasurementTagValueOnView();
            }
        }

        private void SetMeasurementTagValueOnView()
        {
            TagValueBackgroundWorkerParameter parameter = 
                new TagValueBackgroundWorkerParameter(view.MeasurementTagInfo, TagValueType.Measured);
            ReadSelectedTagInfoValue(parameter);                      
        }

        public void HandleSearchProductionTargetTagButtonClick(object sender, EventArgs eventArgs)
        {
            DialogResultAndOutput<TagInfo> result = view.ShowTagSelector();
            if (result.Result == DialogResult.OK)
            {
                TagInfo tagInfo = result.Output;
                view.ProductionTargetTagInfo = tagInfo;
                SetProductionTargetTagValueOnView();
            }
        }

        private void SetProductionTargetTagValueOnView()
        {
            if (view.ProductionTargetTagInfo != null)
            {
                TagValueBackgroundWorkerParameter parameter = 
                        new TagValueBackgroundWorkerParameter(view.ProductionTargetTagInfo, TagValueType.ProductionTarget);
                ReadSelectedTagInfoValue(parameter);                             
            }
        }
        
        private void HandleReadTagInfoBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            TagValueBackgroundWorkerParameter parameter = (TagValueBackgroundWorkerParameter)e.Argument;

            decimal? result = null;

            try
            {
                if (parameter.TagInfo != null)
                {
                    result = GetTagValueFromPlantHistorian(parameter.TagInfo);
                }                
            }
            // Do not want the stop creation/edit of target definition if unable to communicate with Plant Historian.
            catch (Exception)
            {
                result = null;
            }

            e.Result = new TagValueBackgroundWorkerResult(result, parameter.Type);
        }

        private void ReadSelectedTagInfoValue(TagValueBackgroundWorkerParameter parameter)
        {            
            view.DisableControlsForBackgroundWorker();
            readTagInfoBackgroundWorker.RunWorkerAsync(parameter);            
        }

        private void HandleReadTagInfoBackgroundWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TagValueBackgroundWorkerResult result = (TagValueBackgroundWorkerResult) e.Result;
            decimal? value = result.Result;

            if (result.Type == TagValueType.Measured)
            {                
                view.RefreshMeasurmentTagValueEnabled = value.HasValue;
                view.MeasurementTagValue = (value.HasValue ? value.Value.ToString(Culture.CultureInfo) : StringResources.Unavailable);    
            }
            else
            {                
                view.RefreshProductionTargetTagValueEnabled = value.HasValue;
                view.ProductionTargetTagValue = (value.HasValue ? value.Value.ToString(Culture.CultureInfo) : StringResources.Unavailable);
            }

            view.EnableControlsForBackgroundWorker();
        }
    
        private decimal? GetTagValueFromPlantHistorian(TagInfo tag)
        {
            DateTime rightNow = Clock.Now;
            DateTime lastWholeHour = new DateTime(rightNow.Year, rightNow.Month, rightNow.Day, rightNow.Hour, 0, 0);
            return plantHistorianService.ReadRestrictionDeviationTagValue(tag, lastWholeHour.AddHours(-1), lastWholeHour);                
        }

        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            EditRestrictionDefinitionHistoryFormPresenter presenter = new EditRestrictionDefinitionHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public override void Insert(SaveUpdateDomainObjectContainer<RestrictionDefinition> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<RestrictionDefinition> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<RestrictionDefinition> GetNewObjectToInsert()
        {
            PopulateRestrictionDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<RestrictionDefinition>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<RestrictionDefinition> GetPopulatedEditObjectToUpdate()
        {
            PopulateRestrictionDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<RestrictionDefinition>(editObject);
        }
       
        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            bool hasError = false;

            if (view.Name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
                hasError = true;
            }

            //DMND0010124 mangesh
            //if (view.HourFrequency.IsNullOrEmptyOrWhitespace())
            //{
            //    view.ShowHourFrequencyIsEmptyError();
            //    hasError = true;
            //}


            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                view.ShowDescriptionIsEmptyError();
                hasError = true;
            }
            if(view.FunctionalLocation == null)
            {
                view.ShowNoFunctionalLocationsSelectedError();
                hasError = true;
            }
            if (view.MeasurementTagInfo == null)
            {
                view.ShowNoMeasurementTagInfoSelectedError();
                hasError = true;                
            }
            if (view.ProductionTargetValue == null && view.ProductionTargetTagInfo == null)
            {
                view.ShowNoProductionTargetValueError();
                view.ShowNoProductionTargetTagInfoError();
                hasError = true;
            }

            Site site = userContext.Site;            
            Error nameError = service.IsValidName(view.Name, site, editObject);
            if (nameError.HasError)
            {
                view.ShowNameError(nameError.Message);
                hasError = true;
            }
            
            return hasError;
        }

        public void HandleRefreshMeasurementTagValueButtonClick(object sender, EventArgs e)
        {
            SetMeasurementTagValueOnView();
        }

        public void HandleRefreshProductionTargetTagValueButtonClick(object sender, EventArgs e)
        {
            SetProductionTargetTagValueOnView();
        }
		
		private class TagValueBackgroundWorkerResult
        {
            public TagValueBackgroundWorkerResult(decimal? result, TagValueType type)
            {
                Result = result;
                Type = type;
            }

            public decimal? Result { get; private set; }
            public TagValueType Type { get; private set; }
        }

        private class TagValueBackgroundWorkerParameter
        {
            public TagValueBackgroundWorkerParameter(TagInfo tagInfo, TagValueType type)
            {
                TagInfo = tagInfo;
                Type = type;
            }

            public TagInfo TagInfo { get; private set; }
            public TagValueType Type {get; private set; }
        }
    }
}
