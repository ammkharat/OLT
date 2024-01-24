using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class WorkAssignmentGridRenderer : BaseGridRenderer
    {
        private const string ASSIGNMENT_NAME_COLUMN_KEY = "Name";
        private const string ASSIGNMENT_DESCRIPTION_COLUMN_KEY = "Description";
        private const string ASSIGNMENT_ROLE_NAME_COLUMN_KEY = "RoleName";
        private const string ASSIGNMENT_CATEGORY_NAME_COLUMN_KEY = "Category";        

        private readonly bool showDescription;
        private readonly bool showCategory;

        private int nameColumnWidth = 200;
        private int roleColumnWidth = 120;
        private int descriptionColumnWidth = 150;
        private int categoryColumnWidth = 150;

        public WorkAssignmentGridRenderer(bool showDescription, bool showCategory)
        {
            this.showDescription = showDescription;
            this.showCategory = showCategory;            
        }

        public int NameColumnWidth
        {
            set { nameColumnWidth = value; }
        }

        public int RoleColumnWidth
        {
            set { roleColumnWidth = value; }
        }

        public int DescriptionColumnWidth
        {
            set { descriptionColumnWidth = value; }
        }

        public int CategoryColumnWidth
        {
            set { categoryColumnWidth = value; }
        }

        public override void SetupCustomFilters(UltraGrid grid, OltUltraGridFilterUIProvider provider)
        {
        }

        public override void SetupBand(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;            
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            band.Columns[ASSIGNMENT_NAME_COLUMN_KEY].Format(RendererStringResources.Name, column++, nameColumnWidth);
            band.Columns[ASSIGNMENT_ROLE_NAME_COLUMN_KEY].Format(RendererStringResources.Role, column++, roleColumnWidth);

            if (showDescription)
            {
                band.Columns[ASSIGNMENT_DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, descriptionColumnWidth);
            }

            if (showCategory)
            {
                band.Columns[ASSIGNMENT_CATEGORY_NAME_COLUMN_KEY].Format(RendererStringResources.Category, column++, categoryColumnWidth);
            }            
        }

        public override void SetupUnboundColumns(UltraGridBand ultraGridBand)
        {
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(ASSIGNMENT_NAME_COLUMN_KEY, false);
            if (showDescription)
            {
                sortedColumns.Add(ASSIGNMENT_DESCRIPTION_COLUMN_KEY, false);
            }
        }

        public override void SetupRow(UltraGridRow row)
        {
        }

    }
}
