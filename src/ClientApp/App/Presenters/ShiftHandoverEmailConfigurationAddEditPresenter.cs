using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftHandoverEmailConfigurationAddEditPresenter : AddEditBaseFormPresenter<IShiftHandoverEmailConfigurationAddEditFormView, ShiftHandoverEmailConfiguration>
    {
        readonly IShiftHandoverService shiftHandoverService;
        readonly IWorkAssignmentService workAssignmentService;
        readonly IShiftPatternService shiftPatternService;
        
        private List<WorkAssignment> initialSelectedAssignments;
        private readonly ShiftPattern emptyShiftPattern = new ShiftPattern(-1, "", null, null, DateTime.MinValue, null, TimeSpan.Zero, TimeSpan.Zero);

        public ShiftHandoverEmailConfigurationAddEditPresenter(IShiftHandoverEmailConfigurationAddEditFormView view, ShiftHandoverEmailConfiguration editObject)
            : base(view, editObject)
        {
            view.Load += HandleLoad;

            shiftHandoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
            workAssignmentService = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
        }

        public ShiftHandoverEmailConfigurationAddEditPresenter(ShiftHandoverEmailConfiguration shiftHandoverEmailConfiguration)
            : this(new ShiftHandoverEmailConfigurationAddEditForm(), shiftHandoverEmailConfiguration)
        {                       
        }

        public ShiftHandoverEmailConfigurationAddEditPresenter() : this(CreateDefaultEditObject())
        {
        }

        private static ShiftHandoverEmailConfiguration CreateDefaultEditObject()
        {            
            ShiftHandoverEmailConfiguration configuration =
                new ShiftHandoverEmailConfiguration(null, CreateDefaultSendTime(), new List<EmailAddress>(), new List<WorkAssignment>(), ClientSession.GetUserContext().Site);
            return configuration;
        }

        private static Time CreateDefaultSendTime()
        {
            DateTime dateTime = Clock.Now;
            return new Time(dateTime.Hour);
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            LoadAssignments();

            List<ShiftPattern> shifts = shiftPatternService.QueryBySite(userContext.Site);
            shifts.Insert(0, emptyShiftPattern);
            view.Shifts = shifts;
            
            UpdateViewFromEditObject();
        }

        private void UpdateViewFromEditObject()
        {
            view.SelectedShift = editObject.ShiftPattern;
            view.Time = editObject.EmailSendTime;
            view.EmailAddressList = editObject.EmailAddressesAsDelimitedString;            
        }

        private void UpdateEditObjectFromView()
        {
            editObject.ShiftPattern = view.SelectedShift;
            editObject.EmailSendTime = view.Time;
            editObject.SetEmailAddresses(view.EmailAddressList);
            editObject.WorkAssignments = GetSelectedAssignments();
        }

        private void LoadAssignments()
        {
            List<WorkAssignment> assignments = workAssignmentService.QueryBySite(userContext.Site);

            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> adapters = assignments.ConvertAll(a => new WorkAssignmentMultiSelectGridRenderer.DisplayAdapter(a));

            if (IsEdit)
            {
                initialSelectedAssignments = new List<WorkAssignment>(editObject.WorkAssignments);
                foreach (WorkAssignment selectedAssignment in initialSelectedAssignments)
                {
                    WorkAssignmentMultiSelectGridRenderer.DisplayAdapter adapter = adapters.Find(waa => waa.GetWorkAssignment().IdValue == selectedAssignment.IdValue);

                    // This happens if the work assignment has been deleted since being assigned to the parent entity
                    if (adapter != null)
                    {
                        adapter.Selected = true;
                    }
                }
            }
            
            view.Assignments = adapters;
        }

        protected override bool ValidateViewHasError()
        {
            bool hasError = false;

            if (view.SelectedShift == null || view.SelectedShift == emptyShiftPattern)
            {
                view.SetNoShiftSelectedError();
                hasError = true;
            }

            if (!EmailAddressesValid())
            {
                view.SetEmailAddressListError();
                hasError = true;
            }

            if (GetSelectedAssignments().Count == 0)
            {
                view.SetNoWorkAssignmentSelectedError();
                hasError = true;
            }

            return hasError;
        }

        private List<WorkAssignment> GetSelectedAssignments()
        {
            return view.Assignments.FindAll(a => a.Selected).ConvertAll(da => da.GetWorkAssignment());
        }

        private bool EmailAddressesValid()
        {
            string addressList = view.EmailAddressList;

            if (addressList.IsNullOrEmptyOrWhitespace() || addressList.Contains(","))
            {
                return false;
            }

            return EmailAddress.IsValid(addressList);
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(shiftHandoverService.InsertShiftHandoverEmailConfiguration, editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(shiftHandoverService.UpdateShiftHandoverEmailConfiguration, editObject);
        }
    }
}
