using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.UserPreference;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public abstract class AbstractQueryByDateRangeShiftRoleAndWorkAssignmentReportPresenter<TControl, TDomainObject, TReport, TReportAdapter, TPreference> :
        AbstractReportPagePresenter<TControl, TDomainObject, TReport, TReportAdapter>
        where TControl : class, IDateRangeShiftRoleAndWorkAssignmentReportParametersControl
        where TDomainObject : DomainObject
        where TReportAdapter : IReportAdapter
        where TReport : XtraReport, IOltReport<TReportAdapter>
        where TPreference : ReportParameterPreference
    {
        private static readonly ILog logger =
            GenericLogManager.GetLogger<AbstractQueryByDateRangeShiftRoleAndWorkAssignmentReportPresenter<TControl, TDomainObject, TReport, TReportAdapter, TPreference>>();

        protected readonly IRoleService roleService;
        private readonly IWorkAssignmentService workAssignmentService;
        private List<WorkAssignment> allAvailableWorkAssignments;

        protected AbstractQueryByDateRangeShiftRoleAndWorkAssignmentReportPresenter(
            IRoleService roleService,
            IWorkAssignmentService workAssignmentService,
            string reportName,
            IReportsPage reportsPage)
            : base(reportName, reportsPage)
        {
            this.roleService = roleService;
            this.workAssignmentService = workAssignmentService;
        }

        protected abstract string GetDomainObjectNamePlural();
        protected abstract TPreference GetReportParameterPreference();
        protected abstract List<Role> GetValidRoles();

        protected abstract List<TDomainObject> CreateDataSource(UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment);
       
        protected abstract List<TDomainObject> CreateDataSource(UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment, bool showFlexibleShiftHandoverData);

        protected override void InitializeParameters()
        {
            LoadDefaultData(parameters);
            LoadSavedSelections(parameters);            
        }

        protected virtual void LoadDefaultData(TControl parameterControl)
        {
            List<FunctionalLocation> flocList = ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations;
            parameterControl.SelectedRootFunctionalLocations = flocList;

            parameterControl.IncludeDataWithNoWorkAssignmentText = 
                string.Format(StringResources.IncludeDataWithNoWorkAssignmentReportParameterText, GetDomainObjectNamePlural());
            parameterControl.SetAvailableWorkAssignments(FilterByFunctionalLocation(flocList, AllAvailableWorkAssignments));

            List<ShiftPattern> possibleShifts = GetPossibleShifts(flocList[0].Site);
            parameterControl.AvailableShiftPatterns = possibleShifts;

            UserShift latestCompletedUserShift = UserShift.GetLatestCompletedUserShift(possibleShifts, Clock.Now);
            parameterControl.SelectedStartDate = latestCompletedUserShift.StartDateTime.ToDate();
            parameterControl.SelectedStartShiftPattern = latestCompletedUserShift.ShiftPattern;
            parameterControl.SelectedEndDate = latestCompletedUserShift.EndDateTime.ToDate();
            parameterControl.SelectedEndShiftPattern = latestCompletedUserShift.ShiftPattern;
        }

        private static List<WorkAssignment> FilterByFunctionalLocation(
            IList<FunctionalLocation> flocs, 
            List<WorkAssignment> workAssignments)
        {
            return workAssignments.FindAll(
                assignment => assignment.FunctionalLocations.Exists(
                    assignmentFloc => flocs.Exists(floc => floc.IsOrIsAncestorOfOrIsDescendantOf(assignmentFloc))));
        }

        private List<WorkAssignment> AllAvailableWorkAssignments
        {
            get
            {
                if (allAvailableWorkAssignments == null)
                {
                    List<Role> validRoles = GetValidRoles();
                    List<WorkAssignment> assignments = workAssignmentService.QueryBySite(ClientSession.GetUserContext().Site);
                    allAvailableWorkAssignments = assignments.FindAll(
                        assignment => validRoles.ExistsById(assignment.Role));
                }
                return allAvailableWorkAssignments;
            }
        }

        private void LoadSavedSelections(TControl parameterControl)
        {
            try
            {
                TPreference reportParameterPreference = GetReportParameterPreference();
                if (reportParameterPreference != null)
                {
                    PopulateControlFromPreference(reportParameterPreference, parameterControl);
                }
            }
            catch (Exception e)
            {
                logger.Error("Error loading user layout preference for report parameter.", e);
            }
        }

        protected virtual void PopulateControlFromPreference(TPreference reportParameterPreference, TControl parameterControl)
        {
            parameterControl.SelectRolesCategoriesAndWorkAssignments(
                reportParameterPreference.SelectedRoleIds,
                reportParameterPreference.SelectedCategories,
                reportParameterPreference.SelectedWorkAssignmentIds,
                reportParameterPreference.IncludeDataWithNoWorkAssignment);
        }

        protected sealed override List<TDomainObject> CreateDataSource()
        {
            List<FunctionalLocation> flocList = parameters.SelectedFunctionalLocations;
            UserShift startUserShift = GetSelectedStartUserShift(parameters);
            UserShift endUserShift = GetSelectedEndUserShift(parameters);
            List<WorkAssignment> workAssignments = parameters.SelectedWorkAssignments;
            bool includeNullWorkAssignment = parameters.IncludeDataWithNoWorkAssignment;
            bool objshowFlexibleshiftDataonly = parameters.ShowFlexibleShiftHandoverData;
            SaveReportParameterPreference(parameters);
            if (objshowFlexibleshiftDataonly)
            {
                return CreateDataSource(startUserShift, endUserShift, flocList, workAssignments, includeNullWorkAssignment, parameters.ShowFlexibleShiftHandoverData);
            }
            return CreateDataSource(startUserShift, endUserShift, flocList, workAssignments, includeNullWorkAssignment);
            
        }

        private static UserShift GetSelectedStartUserShift(TControl parameterControl)
        {
            return CreateCorrectUserShift(parameterControl.SelectedStartShiftPattern, parameterControl.SelectedStartDate);
        }

        private static UserShift GetSelectedEndUserShift(TControl parameterControl)
        {
            return CreateCorrectUserShift(parameterControl.SelectedEndShiftPattern, parameterControl.SelectedEndDate);
        }

        private void SaveReportParameterPreference(TControl parameterControl)
        {
            try
            {
                TPreference reportParameterPreference = GetReportParameterPreference();
                PopulatePreferenceFromControl(reportParameterPreference, parameterControl);
            }
            catch (Exception e)
            {
                logger.Error("Error saving user layout preference for report parameter.", e);
            }
        }

        protected virtual void PopulatePreferenceFromControl(TPreference reportParameterPreference, TControl parameterControl)
        {
            reportParameterPreference.SelectedRoleIds.Clear();
            reportParameterPreference.SelectedCategories.Clear();
            reportParameterPreference.SelectedWorkAssignmentIds.Clear();
            reportParameterPreference.IncludeDataWithNoWorkAssignment = parameterControl.IncludeDataWithNoWorkAssignment;

            foreach (Role role in parameterControl.SelectedRoles)
            {
                if (role.Id.HasValue)
                {
                    reportParameterPreference.SelectedRoleIds.Add(role.IdValue);
                }
            }
            foreach (string category in parameterControl.SelectedCategories)
            {
                reportParameterPreference.SelectedCategories.Add(category);
            }
            foreach (WorkAssignment assignment in parameterControl.SelectedWorkAssignments)
            {
                if (assignment.Id.HasValue)
                {
                    reportParameterPreference.SelectedWorkAssignmentIds.Add(assignment.IdValue);
                }
            }
        }
    }
}
