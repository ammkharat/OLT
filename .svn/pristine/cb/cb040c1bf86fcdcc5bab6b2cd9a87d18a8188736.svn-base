using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkAssignmentMultiSelectGridRenderer : AbstractSimpleGridRenderer
    {
        public enum Layout
        {
            ConfigurationLayout,
            ReportParameterLayout
        }

        private const string EDIT_COLUMN_KEY = "Selected";
        private const string NAME_COLUMN_KEY = "Name";
        public const string ROLE_COLUMN_KEY = "Role";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        public const string CATEGORY_COLUMN_KEY = "Category";

        private readonly Layout layout;
        private readonly bool allowAssignmentNameFiltering;

        public WorkAssignmentMultiSelectGridRenderer(Layout layout) : this(layout, false)
        {   
        }

        public WorkAssignmentMultiSelectGridRenderer(Layout layout, bool allowAssignmentNameFiltering)
        {
            this.layout = layout;
            this.allowAssignmentNameFiltering = allowAssignmentNameFiltering;
        }

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = DefaultableBoolean.False;

            int i = 0;

            band.HideAllColumns();

            if (layout == Layout.ConfigurationLayout)
            {
                band.Columns[EDIT_COLUMN_KEY].Format(RendererStringResources.Selected, i++);
                band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.Name, i++, 200);
                band.Columns[ROLE_COLUMN_KEY].Format(RendererStringResources.Role, i++, 150);
                band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, i++, 200);
                band.Columns[CATEGORY_COLUMN_KEY].Format(RendererStringResources.Category, i++);
            }
            else if (layout == Layout.ReportParameterLayout)
            {
                band.Columns[EDIT_COLUMN_KEY].Format("", i++, 30);
                band.Columns[EDIT_COLUMN_KEY].AllowRowFiltering = DefaultableBoolean.False;
                band.Columns[EDIT_COLUMN_KEY].CellAppearance.TextHAlign = HAlign.Center;
                band.Columns[EDIT_COLUMN_KEY].SortIndicator = SortIndicator.Disabled;
                band.Columns[EDIT_COLUMN_KEY].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
                band.Columns[EDIT_COLUMN_KEY].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;

                band.Columns[ROLE_COLUMN_KEY].Format(RendererStringResources.Role, i++, 150);
                band.Columns[CATEGORY_COLUMN_KEY].Format(RendererStringResources.Category, i++);
                band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.Name, i++, 200);
            }

            if (!allowAssignmentNameFiltering)
            {
                band.Columns[NAME_COLUMN_KEY].AllowRowFiltering = DefaultableBoolean.False;
            }

            foreach (UltraGridColumn column in band.Columns)
            {
                if (column.Key != EDIT_COLUMN_KEY)
                {
                    column.CellActivation = Activation.NoEdit;
                }
                else
                {
                    column.CellActivation = Activation.AllowEdit;
                }
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            if (layout == Layout.ConfigurationLayout)
            {
                sortedColumns.Add(NAME_COLUMN_KEY, false);
            }
            else if (layout == Layout.ReportParameterLayout)
            {
                sortedColumns.Add(ROLE_COLUMN_KEY, false);
                sortedColumns.Add(CATEGORY_COLUMN_KEY, false);
                sortedColumns.Add(NAME_COLUMN_KEY, false);
            }
        }

        public class DisplayAdapter
        {
            private readonly WorkAssignment workAssignment;

            public DisplayAdapter(WorkAssignment workAssignment)
            {
                this.workAssignment = workAssignment;
            }

            public DisplayAdapter(WorkAssignment workAssignment, bool selected)
            {
                this.workAssignment = workAssignment;
                Selected = selected;
            }

            public bool Selected { get; set; }

            public string Name
            {
                get { return workAssignment.Name; }
            }

            public string Role
            {
                get { return workAssignment.RoleName; }
            }

            public string Description
            {
                get { return workAssignment.Description; }
            }

            public string Category
            {
                get { return workAssignment.Category; }
            }

            // This is a method because I don't want the grid control to pick it up.
            public WorkAssignment GetWorkAssignment()
            {
                return workAssignment;
            }
        }
    }
}
