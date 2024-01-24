using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LabAlertResponseFormPresenter
    {
        private readonly ILabAlertResponseFormView view;
        private readonly LabAlert labAlert;
        private readonly ILabAlertService labAlertService;        
        private readonly IFunctionalLocationInfoService functionalLocationInfoService;

        public LabAlertResponseFormPresenter(ILabAlertResponseFormView view, LabAlert labAlert)
        {
            this.view = view;
            this.labAlert = labAlert;
            labAlertService = ClientServiceRegistry.Instance.GetService<ILabAlertService>();            
            functionalLocationInfoService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>();
        }

        public void Form_Load(object sender, EventArgs e)
        {
            view.Author = ClientSession.GetUserContext().User;
            view.CreateDateTime = Clock.Now;
            view.Shift = ClientSession.GetUserContext().UserShift.ShiftPatternName;
            view.SelectedStatus = labAlert.Status;
        }

        public void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (DataIsValid())
            {
                Save();
                view.Close();
            }
        }

        private bool DataIsValid()
        {
            view.ClearAllErrors();
            bool isValid = true;

            if (string.IsNullOrEmpty(view.Comments))
            {
                isValid = false;
                view.ShowCommentRequiredError();
            }

            return isValid;
        }

        private void Save()
        {
            LabAlertResponse response = new LabAlertResponse(
                null,
                labAlert.IdValue,
                view.SelectedStatus,
                view.Comments, 
                ClientSession.GetUserContext().User,
                Clock.Now);
            labAlert.Responses.Add(response);

            LabAlertStatus originalStatus = labAlert.Status;
            LabAlertStatus newStatus = view.SelectedStatus;

            labAlert.Status = newStatus;

            Log log = null;

            if (view.CreateLogChecked)
            {
                log = CreateLogForResponse(labAlert, view.Comments, originalStatus, newStatus);
            }

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(labAlertService.UpdateStatusAndResponses, labAlert, log);
        }

        private Log CreateLogForResponse(LabAlert alert, string comments, LabAlertStatus originalStatus, LabAlertStatus newStatus)
        {
            UserContext userContext = ClientSession.GetUserContext();
            
            List<FunctionalLocation> selectedFlocRoots = ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;

            List<FunctionalLocation> flocList = LabAlert.BuildFunctionalLocationListForResponseLog(selectedFlocRoots, userContext.SiteConfiguration.AllowStandardLogAtSecondLevelFunctionalLocation, functionalLocationInfoService);

            string logComments = LabAlertResponse.BuildLogComments(alert, comments, originalStatus, newStatus);

            Log log = new Log(null,
                                null,
                                null,
                                DataSource.LAB_ALERT,
                                flocList,
                                false, false, false, false, false, false,                                
                                logComments,
                                logComments,
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

       


        public void CancelButton_Clicked(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}
