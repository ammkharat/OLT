using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class DirectiveFormPresenter : AbstractMultithreadedAddEditFormPresenter<IDirectiveFormView, Directive>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (DirectiveForm));
        private readonly IDirectiveService directiveService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly bool isClone;
        private UserContext userContext; //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        private readonly LogTemplatePresenterHelper logTemplatePresenterHelper;
        private List<FunctionalLocation> defaultFunctionalLocations = new List<FunctionalLocation>();

        public DirectiveFormPresenter() : this(GetDefaultNewDirective(), false)
        {
        }

        public DirectiveFormPresenter(Directive editObject, bool isClone) : base(new DirectiveForm(), editObject)
        {
            this.isClone = isClone;

            var clientServiceRegistry = ClientServiceRegistry.Instance;
            userContext = ClientSession.GetUserContext(); //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            var highestType = GetSiteConfiguredMaxFlocLevel(ClientSession.GetUserContext().SiteConfiguration);

            var flocSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetSiteConfiguredMaxLevelAndBelow(highestType,
                        ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(highestType), true);

            view.FlocSelector = flocSelector;

            logTemplatePresenterHelper = new LogTemplatePresenterHelper(view,
                clientServiceRegistry.GetService<ILogTemplateService>(), ClientSession.GetUserContext().Assignment,
                LogTemplate.LogType.DailyDirective);

            directiveService = clientServiceRegistry.GetService<IDirectiveService>();
            functionalLocationService = clientServiceRegistry.GetService<IFunctionalLocationService>();

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationClicked;
            view.HandleLogTemplateButtonClick += logTemplatePresenterHelper.HandleInsertTemplateButtonClick;
            view.AddRemoveWorkAssignmentButtonClicked += HandleAddRemoveWorkAssignmentButtonClicked;
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
        }

        public override IForm View
        {
            get { return view; }
        }

        private void HandleHistoryButtonClicked()
        {
            var presenter = new EditDirectiveHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void HandleAddRemoveWorkAssignmentButtonClicked()
        {
            var result = view.ShowWorkAssignmentSelector(view.SelectedWorkAssignments);

            if (result.Result == DialogResult.OK)
            {
                view.SelectedWorkAssignments = new List<WorkAssignment>(result.Output);
            }
        }

        private void HandleAddFunctionalLocationClicked()
        {
            var result = view.ShowFunctionalLocationSelector(view.FunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null
                    ? new List<FunctionalLocation>()
                    : new List<FunctionalLocation>(newFlocList);
            }
        }

        private void HandleRemoveFunctionalLocationClicked()
        {
            var floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                var associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
            }
        }

        private static Directive GetDefaultNewDirective()
        {
            var now = Clock.Now;

            var currentUser = ClientSession.GetUserContext().User;
            var currentRole = ClientSession.GetUserContext().Role;
            var defaultEndTime = Directive.CreateDefaultEndTime(now, ClientSession.GetUserContext().UserShift);

            return new Directive(now, defaultEndTime, null, null, currentUser, now, currentUser, currentRole, now);     
        }

        protected override void OnFormLoad()
        {
            LoadData(new List<Action> {logTemplatePresenterHelper.QueryLogTemplates, LoadDefaultFlocs});
        }

        private void LoadDefaultFlocs()
        {
            if (!IsEdit &&
                ClientSession.GetUserContext()
                    .SiteConfiguration.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders)
            {
                var highestType = GetSiteConfiguredMaxFlocLevel(ClientSession.GetUserContext().SiteConfiguration);

                defaultFunctionalLocations = functionalLocationService.GetDefaultFLOCs(highestType,
                    ClientSession.GetUserContext().RootsForSelectedFunctionalLocations);
            }
        }

        protected override void AfterDataLoad()
        {
            base.AfterDataLoad();

            if (!IsEdit && !isClone)
            {
                editObject.Content = RichTextUtilities.ConvertTextToRTF(string.Empty);
                editObject.FunctionalLocations = defaultFunctionalLocations;
            }

            UpdateViewFromEditObject();

            view.HistoryButtonEnabled = IsEdit;
            logTemplatePresenterHelper.LoadLogTemplates(IsEdit);
        }

        private void UpdateViewFromEditObject()
        {
            view.WindowTitleText = IsEdit
                ? StringResources.DirectiveForm_EditDirectiveTitle
                : StringResources.DirectiveForm_CreateDirectiveTitle;

            view.LastModifiedBy = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            view.CreatedBy = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.ActiveFromDateTime = editObject.ActiveFromDateTime;
            view.ActiveToDateTime = editObject.ActiveToDateTime;

            view.Content = editObject.Content;
            view.FunctionalLocations = editObject.FunctionalLocations;
            view.DocumentLinks = editObject.DocumentLinks;

            if (editObject.ExtraInfoFromMigrationSource == null)
            {
                view.HideExtraInfo();
            }
            else
            {
                view.ExtraInfoFromMigrationSource = editObject.ExtraInfoFromMigrationSource;
            }

            view.SelectedWorkAssignments = editObject.WorkAssignments;

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            
                if (  userContext.SiteConfiguration.EnableDirectiveImage)
                {
                    if (editObject.Imagelist != null)
                    {
                        view.ImageDirectivedetails = editObject.Imagelist;
                        view.setDirectiveImage = true; //userContext.SiteConfiguration.EnableLogImage;
                        view.EnableImagePanel = true;
                        view.EnableImagePanelDirective = true;
                        view.EnableImagePanelDirectiveTitle = true;
                    }
                }
                else
                {
                    view.setDirectiveImage = false;
                    view.EnableImagePanel = false;
                    view.EnableImagePanelDirective = false;
                    view.EnableImagePanelDirectiveTitle = false;
                }
            
            
            
        }

        protected override bool DoPreSaveWork()
        {
            var continueOn = !ViewHasErrorsAndErrorMessagesSet();
            UpdateEditObjectFromView();
            return continueOn;
        }

        private bool ViewHasErrorsAndErrorMessagesSet()
        {
            var hasErrors = false;

            view.ClearErrorProviders();

            if (view.ActiveFromDateTime > view.ActiveToDateTime)
            {
                view.SetErrorForActiveFromMustBeBeforeActiveTo();
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(view.PlainTextContent))
            {
                view.SetErrorForEmptyContent();
                hasErrors = true;
            }

            if (view.SelectedFunctionalLocation == null)
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasErrors = true;
            }
            if (view.EnableAddButton && view.FilePathText != string.Empty)
            {
                view.SetErrorForAddButton();
                hasErrors = true;
            }

            return hasErrors;
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = ClientSession.GetUserContext().User;
            editObject.ActiveFromDateTime = view.ActiveFromDateTime;
            editObject.ActiveToDateTime = view.ActiveToDateTime;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.WorkAssignments = view.SelectedWorkAssignments;
            editObject.DocumentLinks = view.DocumentLinks;

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
           editObject.Imagelist = UpoloadFileandUpdatePath(view.ImageDirectivedetails, editObject); 
            
            
        }

        protected override void SaveData()
        {
            base.SaveData();

            if (IsEdit)
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(directiveService.Update,
                    editObject);
            }
            else
            {
                if (IsEdit)
                {
                    
                }

                editObject.CreatedByWorkAssignmentName = ClientSession.GetUserContext().Assignment != null
                    ? ClientSession.GetUserContext().Assignment.Name
                    : null;

                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(directiveService.Insert,
                    editObject);
            }
        }

        public FunctionalLocationType GetSiteConfiguredMaxFlocLevel(SiteConfiguration siteConfiguration)
        {
            var maxFlocLevel = siteConfiguration.MaximumDirectiveFlocLevel;

            FunctionalLocationType highestType;

            if (maxFlocLevel < 1 || maxFlocLevel > 3 || Enum.TryParse(maxFlocLevel.ToString(), out highestType) == false)
            {
                logger.ErrorFormat(
                    "The MaximumDirectiveFlocLevel {0} for site {1} is not valid - level 3 will be used instead; please have the Technical Administrator update the site configuration with a value between 1 and 3.",
                    maxFlocLevel,
                    siteConfiguration.Id);

                highestType = FunctionalLocationType.Level3;
            }

            return highestType;
        }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        public List<ImageUploader> UpoloadFileandUpdatePath(List<ImageUploader> lstImages, Directive Dir)
        {
            foreach (ImageUploader Img in lstImages)
            {
                if (Img.Id == 0 && Img.Action != "Remove")
                {
                    if (ClientSession.GetUserContext().SiteConfiguration.LogImagePath != null)
                    {
                        if (File.Exists(Img.ImagePath))
                        {
                            string fileName = userContext.SiteConfiguration.LogImagePath + "\\" +ClientSession.GetUserContext().User.Username + "-" + Clock.Now.ToString("yyyyMMddTHHmmss") + "-" + Path.GetFileName(Img.ImagePath);
                            File.Copy(Img.ImagePath, fileName, true);
                            Img.ImagePath = fileName;
                        }
                    }

                }


            }
            return lstImages;
        }
    }
}