using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Infragistics.Win.UltraWinGrid;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class DateRangeShiftRoleAndWorkAssignmentReportParametersControl : UserControl, IDateRangeShiftRoleAndWorkAssignmentReportParametersControl
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DateRangeShiftRoleAndWorkAssignmentReportParametersControl));

        private readonly SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid;
        private readonly DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator;
        private List<WorkAssignment> allAvailableWorkAssignments = new List<WorkAssignment>();
        private List<Role> allAvailableRoles = new List<Role>();
        private List<string> allAvailableCategories = new List<string>();

        public DateRangeShiftRoleAndWorkAssignmentReportParametersControl() : this(true)
        {
        }

        public DateRangeShiftRoleAndWorkAssignmentReportParametersControl(bool showGroupBy)
        {
            InitializeComponent();

            flocSelectionControl.Mode = FunctionalLocationMode.LevelThreeAndAbove;
            flocSelectionControl.ShowSearchPanel = false;

            assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(
                new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ReportParameterLayout),
                OltGridAppearance.EDIT_CELL_SELECT_WITH_FILTER);
            assignmentGrid.Dock = DockStyle.Fill;
            gridPanel.Controls.Add(assignmentGrid);
            assignmentGrid.Items = new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>();

            assignmentGrid.DisplayLayout.Override.TipStyleScroll = TipStyle.Hide;

            validator = new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(this);

            if (!showGroupBy)
            {
                oltGroupBox3.Visible = false;
                functionalLocationGroupBox.Height =
                    functionalLocationGroupBox.Height +
                    (oltGroupBox3.Location.Y -
                     (functionalLocationGroupBox.Location.Y + functionalLocationGroupBox.Height)) +
                    oltGroupBox3.Height;
            }
            else
            {FlexiShiftDatacheckBox.Visible = false;}
            
        }

        public bool IsValid
        {
            get { return validator.IsValid; } 
        }

        public string ErrorMessage
        {
            get { return validator.ErrorMessage; } 
        }

        public ShiftPattern SelectedStartShiftPattern
        {
            get { return (ShiftPattern)startShiftComboBox.SelectedItem; }
            set { startShiftComboBox.SelectedItem = value; }
        }

        public ShiftPattern SelectedEndShiftPattern
        {
            get { return (ShiftPattern)endShiftComboBox.SelectedItem; }
            set { endShiftComboBox.SelectedItem = value; }
        }

        public Date SelectedStartDate
        {
            get { return startDatePicker.Value; }
            set { startDatePicker.Value = value; }
        }

        public Date SelectedEndDate
        {
            get { return endDatePicker.Value; }
            set { endDatePicker.Value = value; }
        }

        public IList<FunctionalLocation> SelectedRootFunctionalLocations
        {
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
            set { flocSelectionControl.UserCheckedFunctionalLocations = value; }
        }

        public List<FunctionalLocation> SelectedFunctionalLocations
        {
            get { return flocSelectionControl.AllCheckedFunctionalLocations; }
        }

        public List<WorkAssignment> SelectedWorkAssignments
        {
            get
            {
                List<WorkAssignment> selectedWorkAssignments = new List<WorkAssignment>();
                foreach (WorkAssignmentMultiSelectGridRenderer.DisplayAdapter wrapper in assignmentGrid.FilteredInItems)
                {
                    if (wrapper.Selected)
                    {
                        selectedWorkAssignments.Add(wrapper.GetWorkAssignment());
                    }
                }
                
                return selectedWorkAssignments;
            }
        }

        public bool IncludeDataWithNoWorkAssignment
        {
            get { return includeNullAssignmentCheckBox.Checked; }
            private set { includeNullAssignmentCheckBox.Checked = value; }
        }

        /* amit shukla Flexi Shift Handover RITM0185797 */
        public bool ShowFlexibleShiftHandoverData
        {
            get { return FlexiShiftDatacheckBox.Checked; }
            private set { FlexiShiftDatacheckBox.Checked = value; }
        }
        /**/

        public string IncludeDataWithNoWorkAssignmentText
        {
            set { includeNullAssignmentCheckBox.Text = value; }
        }

        public void SetAvailableWorkAssignments(List<WorkAssignment> assignments)
        {
            allAvailableWorkAssignments = new List<WorkAssignment>(assignments);
            includeNullAssignmentCheckBox.Enabled = allAvailableWorkAssignments.Count > 0;
            IncludeDataWithNoWorkAssignment = true;

            allAvailableRoles = assignments.ConvertAll(obj => obj.Role);
            allAvailableRoles.Unique(obj => obj.Id);

            allAvailableCategories = new List<string>();
            foreach (WorkAssignment assignment in assignments)
            {
                string category = GetCategoryConvertNullToEmptyString(assignment);
                if (!allAvailableCategories.Contains(category))
                {
                    allAvailableCategories.Add(category);
                }
            }

            List<WorkAssignment> originallySelectedWorkAssignments = SelectedWorkAssignments;
            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> wrappers = new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>();
            foreach (WorkAssignment assignment in allAvailableWorkAssignments)
            {
                WorkAssignmentMultiSelectGridRenderer.DisplayAdapter wrapper = new WorkAssignmentMultiSelectGridRenderer.DisplayAdapter(
                    assignment,
                    originallySelectedWorkAssignments.Count == 0 || originallySelectedWorkAssignments.ExistsById(assignment));
                wrappers.Add(wrapper);
            }
            assignmentGrid.Items = wrappers;

        }

        private static string GetCategoryConvertNullToEmptyString(WorkAssignment assignment)
        {
            return string.IsNullOrEmpty(assignment.Category) ? "" : assignment.Category;
        }

        public List<ShiftPattern> AvailableShiftPatterns
        {
            set
            {                
                List<ShiftPattern> startShifts = new List<ShiftPattern>(value);
                startShiftComboBox.DataSource = startShifts;
                startShiftComboBox.DisplayMember = "Name";

                List<ShiftPattern> endShifts = new List<ShiftPattern>(value);
                endShiftComboBox.DataSource = endShifts;
                endShiftComboBox.DisplayMember = "Name";
            }           
        }

        public List<Role> SelectedRoles
        {
            get
            {
                List<Role> roles = GetFilterValues(
                    WorkAssignmentMultiSelectGridRenderer.ROLE_COLUMN_KEY,
                    allAvailableRoles);
                roles.Unique(obj => obj.Id);
                return roles;
            }
        }

        public List<string> SelectedCategories
        {
            get
            {
                List<string> allValues = GetFilterValues(
                    WorkAssignmentMultiSelectGridRenderer.CATEGORY_COLUMN_KEY,
                    allAvailableCategories);
                List<string> categories = new List<string>();
                foreach (string category in allValues)
                {
                    if (!categories.Contains(category))
                    {
                        categories.Add(category);
                    }
                }
                return categories;
            }
        }

        private List<T> GetFilterValues<T>(string columnKey, List<T> allAvailableItems) where T : class
        {
            List<T> filterValues = new List<T>();

            try
            {
                UltraGridBand band = assignmentGrid.DisplayLayout.Bands[0];
                if (band.ColumnFilters.IndexOf(columnKey) != -1)
                {
                    FilterConditionsCollection filterConditionsCollection = band.ColumnFilters[columnKey].FilterConditions;
                    foreach (var filter in filterConditionsCollection)
                    {
                        if (filter is FilterCondition)
                        {
                            FilterCondition filterCondition = (FilterCondition) filter;
                            if (filterCondition.ComparisionOperator == FilterComparisionOperator.Equals)
                            {
                                T filterValue = allAvailableItems.Find(obj =>
                                    ((obj == null || obj.ToString() == "") &&
                                     (filterCondition.CompareValue == null || filterCondition.CompareValue is BlanksClass)) ||
                                    (obj != null &&
                                     filterCondition.CompareValue != null &&
                                     obj.ToString() == filterCondition.CompareValue.ToString()));
                                if (filterValue != null)
                                {
                                    filterValues.Add(filterValue);
                                }
                            }
                        }
                    }
                }
                else
                {
                    logger.Error("Could not get filter values for key: " + columnKey);
                }
            }
            catch (Exception e)
            {
                logger.Error("Error getting filter values for " + typeof(T).Name, e);
            }


            return filterValues;
        }

        public void SelectRolesCategoriesAndWorkAssignments(
            List<long> selectedRoleIds, 
            List<string> selectedCategories,
            List<long> selectedWorkAssignmentIds,
            bool includeDataWithNoWorkAssignment)
        {
            SetupFilters(selectedRoleIds);
            SetupFilters(selectedCategories);

            if (selectedWorkAssignmentIds.Count > 0 &&
                allAvailableWorkAssignments.Exists(obj => selectedWorkAssignmentIds.Exists(id => id == obj.Id)))
            {
                assignmentGrid.Items.ForEach(obj => obj.Selected = false);
                foreach (long assignmentId in selectedWorkAssignmentIds)
                {
                    WorkAssignmentMultiSelectGridRenderer.DisplayAdapter wrapper = assignmentGrid.Items.Find(obj => obj.GetWorkAssignment().Id == assignmentId);
                    if (wrapper != null)
                    {
                        wrapper.Selected = true;
                    }
                }
            }

            if (selectedWorkAssignmentIds.Count > 0)
            {
                IncludeDataWithNoWorkAssignment = includeDataWithNoWorkAssignment || allAvailableWorkAssignments.Count == 0;
            }
        }

        private void SetupFilters(List<long> selectedRoleIds)
        {
            List<Role> rolesToFilterIn = new List<Role>();

            foreach (long roleId in selectedRoleIds)
            {
                Role role = allAvailableRoles.Find(obj => obj.Id == roleId);
                if (role != null)
                {
                    rolesToFilterIn.Add(role);
                }
            }

            AddFilters(rolesToFilterIn, WorkAssignmentMultiSelectGridRenderer.ROLE_COLUMN_KEY);
        }


        private void SetupFilters(List<string> selectedCategories)
        {
            List<string> categoriesToFilterIn = new List<string>();

            foreach (string category in selectedCategories)
            {
                if (allAvailableWorkAssignments.Exists(obj => GetCategoryConvertNullToEmptyString(obj) == category))
                {
                    categoriesToFilterIn.Add(category);
                }
            }

            AddFilters(categoriesToFilterIn, WorkAssignmentMultiSelectGridRenderer.CATEGORY_COLUMN_KEY);
        }

        private void AddFilters<T>(List<T> itemsToFilterIn, string columnKey)
        {
            if (itemsToFilterIn.Count > 0)
            {
                ColumnFiltersCollection columnFiltersCollection = assignmentGrid.DisplayLayout.Bands[0].ColumnFilters;
                ColumnFilter columnFilter = columnFiltersCollection[columnKey];
                columnFilter.ClearFilterConditions();
                columnFilter.LogicalOperator = FilterLogicalOperator.Or;

                foreach (T item in itemsToFilterIn)
                {
                    if (item is string && Equals(item, ""))
                    {
                        columnFilter.FilterConditions.Add(
                            new FilterCondition(FilterComparisionOperator.Equals, null));                        
                    }
                    else
                    {
                        columnFilter.FilterConditions.Add(
                            new FilterCondition(FilterComparisionOperator.Equals, item));                        
                    }
                }
            }
        }

        public List<AssignmentSectionUnitReportGroupBy> GroupByItems
        {
            set
            {
                groupByComboBox.DataSource = value;
                if (value.Count > 0)
                {
                    groupByComboBox.SelectedIndex = 0;
                }
            }
            private get { return (List<AssignmentSectionUnitReportGroupBy>)groupByComboBox.DataSource; }
        }

        public AssignmentSectionUnitReportGroupBy SelectedGroupBy
        {
            get { return (AssignmentSectionUnitReportGroupBy)groupByComboBox.SelectedValue; }
            set
            {
                int indexOf = GroupByItems.IndexOf(value);
                if (indexOf >= 0)
                {
                    groupByComboBox.SelectedIndex = indexOf;
                }
            }
        }
        /* amit shukla Flexi shift Handover RITM0185797 */
        private void FlexiShiftDatacheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShowFlexibleShiftHandoverData = FlexiShiftDatacheckBox.Checked;
            if (FlexiShiftDatacheckBox.Checked)
            {
               
                startShiftComboBox.Enabled = false;
                endShiftComboBox.Enabled = false;
            }else
            {
                startShiftComboBox.Enabled = true;
                endShiftComboBox.Enabled = true;
            }
        }
    }
}
