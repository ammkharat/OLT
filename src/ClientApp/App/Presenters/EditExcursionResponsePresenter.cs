﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditExcursionResponsePresenter :
        AddEditBaseFormPresenter<IExcursionResponseForm, OpmExcursionEditPackage>
    {
        private readonly ClientBackgroundWorker backgroundWorker;

        private readonly ShiftPattern emptyShiftPattern = new ShiftPattern(-1, "", null, null, DateTime.MinValue, null,
            TimeSpan.Zero, TimeSpan.Zero);

        private readonly IFunctionalLocationService functionalLocationService;
        private readonly IExcursionImportService importService;

        private readonly IExcursionResponseService service;

        private readonly IAuthorized authorized;

        private List<WorkAssignment> initialSelectedAssignments;
        private string originalToeComment;

        public EditExcursionResponsePresenter(IExcursionResponseForm view, OpmExcursionEditPackage editObject)
            : base(view, editObject)
        {
            view.Load += HandleLoad;
            service = ClientServiceRegistry.Instance.GetService<IExcursionResponseService>();
            importService = ClientServiceRegistry.Instance.GetService<IExcursionImportService>();
            functionalLocationService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            backgroundWorker = new ClientBackgroundWorker();
            backgroundWorker.DoWork += GetCurrentTagValue;
            backgroundWorker.RunWorkerCompleted += SetCurrentTagValue;
            backgroundWorker.WorkerSupportsCancellation = true;

            authorized = new Authorized();
        }

        public EditExcursionResponsePresenter(OpmExcursionEditPackage excursionEditPackage)
            : this(new ExcursionResponseForm(), excursionEditPackage)
        {
        }
    
        private void HandleLoad(object sender, EventArgs e)
        {
            UpdateViewFromEditObject();

            LockFormControlsIfReadOnlyMode();

            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                Thread.Sleep(300);
            }
            if (!backgroundWorker.CancellationPending && !view.ExcursionHistorianTag.IsNullOrEmptyOrWhitespace())
            {
                backgroundWorker.RunWorkerAsync(view.ExcursionHistorianTag);
            }
        }

        private void LockFormControlsIfReadOnlyMode()
        {
            var userRoleElements = userContext.UserRoleElements;
            var canRespond = authorized.ToRespondToExcursionEvents(userRoleElements);
            view.EditEnabled = canRespond;
        }

        private void SetCurrentTagValue(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;

            var opmCurrentTagValueDto = e.Result as OpmTagValueDTO;
            var currentTagValue = opmCurrentTagValueDto != null
                ? opmCurrentTagValueDto.Value.FormatToThreePlaces()
                : "N/A from OPM";

            view.CurrentTagValue = currentTagValue;
        }

        private void GetCurrentTagValue(object sender, DoWorkEventArgs e)
        {
            e.Result = importService.GetCurrentOpmTagValue(e.Argument.ToString());
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void UpdateViewFromEditObject()
        {
            view.ExcursionToeName = editObject.ExcursionToeName;
            view.ExcursionHistorianTag = editObject.ExcursionHistorianTag;
            view.ExcursionUnitOfMeasure = editObject.ExcursionUnitOfMeasure;
            view.ExcursionsToUpdate = editObject.ExcursionsForGridEditing;
            view.MostRecentExcursionResponseComment = editObject.MostRecentExcursionResponseComment;

            view.MostRecentExcursionAsset = editObject.MostRecentExcursionAsset;
            view.MostRecentExcursionResponseCode = editObject.MostRecentExcursionResponseCode;

            if (editObject.OpmToeDefinition != null)
            {
                view.ToeOpmHistoryUrl = editObject.OpmToeDefinition.OpmToeHistoryUrl;
                view.ToeFloc = editObject.ToeFloc;
                view.ToePublishDate = editObject.ToePublishDate;
                view.HasCommentForEngineer = editObject.ToeHasCommentForEngineer;
                originalToeComment = editObject.ToeCommentForEngineer;
                view.ToeCommentForEngineer = editObject.ToeCommentForEngineer;
                view.ToeCauseOfDeviation = editObject.ToeCauseOfDeviation;
                view.ToeReferenceDocuments = editObject.ToeReferenceDocuments;
                view.ToeConsequencesOfDeviation = editObject.ToeConsequencesOfDeviation;
                view.ToeCorrectiveActions = editObject.ToeCorrectiveActions;
            }
            else
            {
                view.ToeOpmHistoryUrl = string.Empty;
                view.ToeFloc = string.Empty;
                view.ToePublishDate = null;
                view.HasCommentForEngineer = false;
                originalToeComment = string.Empty;
                view.ToeCommentForEngineer = string.Empty;
                view.ToeCauseOfDeviation = string.Empty;
                view.ToeReferenceDocuments = string.Empty;
                view.ToeConsequencesOfDeviation = string.Empty;
                view.ToeCorrectiveActions = string.Empty;
            }

            view.IsToeDefinitionCommentingEnabled = editObject.OpmToeDefinition != null;
        }

        private void UpdateEditObjectFromView()
        {
            var currentUser = ClientSession.GetUserContext().User;
            if (!(originalToeComment.IsNullOrEmptyOrWhitespace() && view.ToeCommentForEngineer.IsNullOrEmptyOrWhitespace()) && originalToeComment != view.ToeCommentForEngineer)
            {
                editObject.ToeCommentForEngineer = view.ToeCommentForEngineer;
                editObject.ToeCommentLastModifiedBy = currentUser;
                editObject.ToeCommentLastModifiedDateTime = Clock.Now;
                editObject.IsToeCommentDirty = true;
            }
            var excursionResponseEditingGridRowDtos = view.ExcursionsToUpdate;
            
            foreach (var excursionResponseEditingGridRowDto in excursionResponseEditingGridRowDtos)
            {
               // if (excursionResponseEditingGridRowDto.IsDirty)
               // {
                    var opmExcursion =
                        editObject.Excursions.Find(
                            excursion => excursion.Id == excursionResponseEditingGridRowDto.Id);
                    opmExcursion.OpmExcursionResponse.Response =
                        excursionResponseEditingGridRowDto.ExcursionResponseComment;
                    opmExcursion.OpmExcursionResponse.LastModifiedDateTime = Clock.Now;
                    opmExcursion.OpmExcursionResponse.LastModifiedBy = currentUser;
                    opmExcursion.OpmExcursionResponse.IsDirty = true;

                    opmExcursion.OpmExcursionResponse.Asset = excursionResponseEditingGridRowDto.Assest; //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
                    opmExcursion.OpmExcursionResponse.Code = excursionResponseEditingGridRowDto.Code;

                //}
                //else //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
                //{
                //     var opmExcursion =
                //        editObject.Excursions.Find(
                //            excursion => excursion.Id == excursionResponseEditingGridRowDto.Id);

                //    opmExcursion.OpmExcursionResponse.Asset = excursionResponseEditingGridRowDto.Assest;
                //    opmExcursion.OpmExcursionResponse.Code = excursionResponseEditingGridRowDto.Code;
                //    opmExcursion.OpmExcursionResponse.LastModifiedDateTime = Clock.Now;
                //    opmExcursion.OpmExcursionResponse.LastModifiedBy = currentUser;

                //}

                
               
                 
            }
            if (view.CopyToLog
                //&& HasAtLeastOneNewResponse(excursionResponseEditingGridRowDtos)------Condition commnted by Vibhor
                
                )
            {
                editObject.ExcursionLog = CreateLogForExcursion(excursionResponseEditingGridRowDtos);
            }

            



        //     public string Asset
        //{
        //    get { return opmExcursion.OpmExcursionResponse.Asset; }
        //    set { opmExcursion.OpmExcursionResponse.Asset = value; }
        //}
        //public string Code
        //{
        //    get { return opmExcursion.OpmExcursionResponse.Code; }
        //    set { opmExcursion.OpmExcursionResponse.Code = value; }
        //}
        }

        private Log CreateLogForExcursion(List<ExcursionResponseEditingGridRowDTO> excursionResponseEditingGridRowDtos)
        {
            var logComment = BuildLogComment(excursionResponseEditingGridRowDtos);
            var firstOpmExcursion =
                editObject.Excursions.Find(
                    excursion => excursion.Id == excursionResponseEditingGridRowDtos.First().Id);

            var log = new Log(null,
                null,
                null,
                DataSource.EXCURSION,
                new List<FunctionalLocation>
                {
                    functionalLocationService.QueryById(firstOpmExcursion.FunctionalLocationId)
                },
                false, false, false, false, false, false,
                logComment,
                logComment,
                Clock.Now,
                userContext.UserShift.ShiftPattern,
                userContext.User,
                userContext.User,
                Clock.Now,
                Clock.Now,
                false,
                false,
                userContext.Role,
                LogType.Standard,
                userContext.Assignment);
            return log;
        }

        private string BuildLogComment(List<ExcursionResponseEditingGridRowDTO> excursionResponseEditingGridRowDtos)
        {
            var sb = new StringBuilder();
            var firstOpmExcursion =
                editObject.Excursions.Find(
                    excursion => excursion.Id == excursionResponseEditingGridRowDtos.First().Id);

            sb.AppendLine(string.Format(StringResources.ExcursionLogComments_ToeName, firstOpmExcursion.ToeName));
            sb.AppendLine(string.Format(StringResources.ExcursionLogComments_HistorianTag,
                firstOpmExcursion.HistorianTag));
            sb.AppendLine(string.Format(StringResources.ExcursionLogComments_Unit, firstOpmExcursion.UnitOfMeasure));

            foreach (var excursionResponseEditingGridRowDto in excursionResponseEditingGridRowDtos)
            {
                //if (excursionResponseEditingGridRowDto.IsDirty)
                //{

                if (ClientSession.GetUserContext().Site.Id == Site.FORT_HILLS_ID)
                {
                    var opmExcursion =
                        editObject.Excursions.Find(
                            excursion => excursion.Id == excursionResponseEditingGridRowDto.Id);
                    sb.AppendLine(string.Format(StringResources.ExcursionLogComments_ExcursionDetail_FH,
                        opmExcursion.OpmExcursionId, opmExcursion.StartDateTime.ToString("MM/dd/yyyy HH:mm"),
                        opmExcursion.ToeType.GetName(), opmExcursion.Status.GetName(), opmExcursion.Duration,
                        opmExcursion.OpmExcursionResponse.Response, opmExcursion.OpmExcursionResponse.Asset, opmExcursion.OpmExcursionResponse.Code));
                }
                else
                {
                    var opmExcursion =
                        editObject.Excursions.Find(
                            excursion => excursion.Id == excursionResponseEditingGridRowDto.Id);
                    sb.AppendLine(string.Format(StringResources.ExcursionLogComments_ExcursionDetail,
                        opmExcursion.OpmExcursionId, opmExcursion.StartDateTime.ToString("MM/dd/yyyy HH:mm"),
                        opmExcursion.ToeType.GetName(), opmExcursion.Status.GetName(), opmExcursion.Duration,
                        opmExcursion.OpmExcursionResponse.Response));
                }
                    
               
               
            }
            return sb.ToString();
        }

        private bool HasAtLeastOneNewResponse(
            List<ExcursionResponseEditingGridRowDTO> excursionResponseEditingGridRowDtos)
        {
            return excursionResponseEditingGridRowDtos.Any(dto => dto.IsDirty);
        }

        protected override bool ValidateViewHasError()
        {
            var hasError = false;
            view.ClearErrorProviders();
            if (view.ExcursionsToUpdate.Any(dto => dto.ExcursionResponseComment.IsNullOrEmptyOrWhitespace()))
            {
                hasError = true;
                view.SetErrorForMissingResponses();
            }

            if (view.HasCommentForEngineer && view.ToeCommentForEngineer.IsNullOrEmptyOrWhitespace())
            {
                hasError = true;
                view.SetErrorForMissingToeCommentForEngineer();
            }

            return hasError;
        }

        private void CancelBackgroundWorker()
        {
            try
            {
                backgroundWorker.CancelAsync();
            }
            finally
            {
                backgroundWorker.Dispose();
            }
        }

        protected override void Insert()
        {
            CancelBackgroundWorker();
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                service.UpdateEditPackageChanges,
                editObject);
        }


        protected override void Update()
        {
            CancelBackgroundWorker();
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateEditPackageChanges,
                editObject);
        }
    }
}