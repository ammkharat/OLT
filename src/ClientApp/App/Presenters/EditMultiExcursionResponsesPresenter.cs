﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditMultiExcursionResponsesPresenter :
        AddEditBaseFormPresenter<IMultiExcursionResponsesForm, OpmExcursionEditPackage>
    {
        private readonly ShiftPattern emptyShiftPattern = new ShiftPattern(-1, "", null, null, DateTime.MinValue, null,
            TimeSpan.Zero, TimeSpan.Zero);

        private readonly IExcursionResponseService service;

        private List<WorkAssignment> initialSelectedAssignments;
        private string originalToeComment;

        public EditMultiExcursionResponsesPresenter(IMultiExcursionResponsesForm view,
            OpmExcursionEditPackage editObject)
            : base(view, editObject)
        {
            view.Load += HandleLoad;

            service = ClientServiceRegistry.Instance.GetService<IExcursionResponseService>();
        }

        public EditMultiExcursionResponsesPresenter(OpmExcursionEditPackage excursionEditPackage)
            : this(new MultiExcursionResponsesForm(), excursionEditPackage)
        {
        }


        private void HandleLoad(object sender, EventArgs e)
        {
            UpdateViewFromEditObject();
        }


        private void UpdateViewFromEditObject()
        {
            view.ExcursionsToUpdate = editObject.ExcursionsForGridEditing;
            if (editObject.Excursions.Any(excursion => excursion.OpmExcursionResponse.HasResponse))
            {
                view.WarnThatSomePreviousExcursionResponsesWillBeOverwritten();
            }
        }

        private void UpdateEditObjectFromView()
        {
            var currentUser = ClientSession.GetUserContext().User;
            editObject.Excursions.ForEach(
                excursion =>
                    UpdateExcursionWithGlobalComment(excursion, currentUser,
                        view.ExcursionResponseCommentForAllExcursions, view.AssetDropdown, view.CodeDropdown));
        }

        private void UpdateExcursionWithGlobalComment(OpmExcursion excursion, User currentUser, string globalComment, string assetValue, string codeValue)
        {
            excursion.OpmExcursionResponse.Response = globalComment;

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM

            excursion.OpmExcursionResponse.Asset = assetValue;

            excursion.OpmExcursionResponse.Code = codeValue;

            excursion.OpmExcursionResponse.LastModifiedDateTime = Clock.Now;
            excursion.OpmExcursionResponse.LastModifiedBy = currentUser;
            excursion.OpmExcursionResponse.IsDirty = true;
        }


        protected override bool ValidateViewHasError()
        {
            var hasError = false;
            // todo check if empty, warn if one or more will be overwritten
            if (view.ExcursionResponseCommentForAllExcursions.IsNullOrEmptyOrWhitespace())
            {
                hasError = true;
                view.SetErrorForMissingResponse();
            }
            return hasError;
        }


        protected override void Insert()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateEditPackageChanges,
                editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateEditPackageChanges,
                editObject);
        }
    }
}