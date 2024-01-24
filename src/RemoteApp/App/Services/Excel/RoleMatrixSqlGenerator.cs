using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class RoleMatrixSqlGenerator
    {
        private readonly Workbook workbook;

        private readonly IRoleElementService roleElementService;
        private readonly IRoleService roleService;
        private readonly ISiteService siteService;

        public RoleMatrixSqlGenerator(Workbook workbook, IRoleService roleService, IRoleElementService roleElementService, ISiteService siteService)
        {
            this.workbook = workbook;
            this.roleElementService = roleElementService;
            this.siteService = siteService;
            this.roleService = roleService;
        }

        public List<RoleElementChange> GenerateRoleMatrixSql()
        {
            List<RoleElementChange> results = new List<RoleElementChange>();

            List<Site> sites = siteService.GetAll();
            foreach(Site site in sites)
            {
                results.AddRange(GenerateChangesForSite(site));
            }
            return results;
        }

        private List<RoleElementChange> GenerateChangesForSite(Site site)
        {
            if (workbook == null || !workbook.Worksheets.Exists("Role Matrix"))
                return new List<RoleElementChange>(0);

            Worksheet worksheet = workbook.Worksheets["Role Matrix"];

            RoleElementTemplateValuesContainer rolesInMatrix = ReadRolesAndRoleElementsFromMatrix(site, worksheet);
            RoleElementTemplateValuesContainer rolesInDb = ReadRolesAndRoleElementsFromDatabase(site);

            List<RoleElementTemplateValue> newRoleElements = rolesInMatrix.GetItemsInThisThatAreNotIn(rolesInDb);
            List<RoleElementTemplateValue> deletedRoleElements = rolesInDb.GetItemsInThisThatAreNotIn(rolesInMatrix);

            List<RoleElementChange> changes = new List<RoleElementChange>();

            foreach (RoleElementTemplateValue value in newRoleElements)
            {
                changes.Add(new RoleElementChange(value.Role.Name, value.RoleElement.Name, RoleElementChangeType.Add, site));
            }
            foreach (RoleElementTemplateValue value in deletedRoleElements)
            {
                changes.Add(new RoleElementChange(value.Role.Name, value.RoleElement.Name, RoleElementChangeType.Delete, site));
            }

            return changes;

        }

        private RoleElementTemplateValuesContainer ReadRolesAndRoleElementsFromDatabase(Site site)
        {
            RoleElementTemplateValuesContainer rolesInDb = new RoleElementTemplateValuesContainer();
            // let's get the RoleElements from the database.
            List<Role> rolesInSite = roleService.QueryRolesBySite(site);
            foreach (Role role in rolesInSite)
            {
                List<RoleElement> roleElementsCurrentlySetupForRole = roleElementService.QueryTemplateForRole(role);
                roleElementsCurrentlySetupForRole.ForEach(re => rolesInDb.Add(new RoleElementTemplateValue(role, re)));
            }

            return rolesInDb;
        }

        public RoleElementTemplateValuesContainer ReadRolesAndRoleElementsFromMatrix(Site site, Worksheet worksheet)
        {
            RoleElementTemplateValuesContainer rolesInMatrix = new RoleElementTemplateValuesContainer();

            List<RoleElement> roleElements = roleElementService.QueryAll();
            List<Role> rolesInSite = roleService.QueryRolesBySite(site);

            // starting from Column D, Row 1 read the names of the sites until you find the matching site. Find the starting and ending columns for the site
            Range<ExcelColumn> columnsContainingRolesForSite = GetRangeOfColumnsForSite(site, worksheet);
            if (columnsContainingRolesForSite == null)
            {
                // the spreadsheet doesn't define this site, so skip it.
                return rolesInMatrix;
            }

            
            // Starting from the first column in range, read the roles until the last column in the range
            ExcelColumn column = columnsContainingRolesForSite.LowerBound;

            while (true)
            {
                string role = worksheet.GetCellValue(column, 2);
                
                int indexOfOpen = role.IndexOf('(');
                int indexOfClose = role.IndexOf(')');
                if (indexOfOpen != -1 && indexOfOpen < indexOfClose)
                {
                    role = role.Substring(0, role.IndexOf('(')).Trim();
                }

                Role roleInSite = rolesInSite.Find(r => role.Equals(r.Name));
                if (roleInSite != null)
                {
                    // starting from the third row of the current column read the values in this column, the role element id is in the first column of the row.
                    AddRoleElementsForRoleDefinedInMatrix(rolesInMatrix, worksheet, column, roleInSite, roleElements);
                }

                if (column.Equals(columnsContainingRolesForSite.UpperBound))
                {
                    break;
                }
                column.MoveNext();
            }

            return rolesInMatrix;
        }

        private Range<ExcelColumn> GetRangeOfColumnsForSite(Site site, Worksheet worksheet)
        {
            Range<ExcelColumn> result;

            ExcelColumn currentColumn = new ExcelColumn("D");
            while (true)
            {
                WorksheetCell worksheetCell = worksheet.GetCell(currentColumn.Address(1));
                object value = worksheetCell.Value;
                if (value == null)
                {
                    return null;
                }

                if (value.ToString().Equals(site.Name))
                {
                    // found the site we are looking for
                    ExcelColumn lastColumn = worksheetCell.AssociatedMergedCellsRegion == null
                                                 ? currentColumn
                                                 : new ExcelColumn(worksheetCell.AssociatedMergedCellsRegion.LastColumn);
                    
                    result = new Range<ExcelColumn>(currentColumn, lastColumn);
                    break;
                }
                currentColumn = new ExcelColumn(worksheetCell.AssociatedMergedCellsRegion.LastColumn);
                currentColumn.MoveNext();
            }

            return result;
        }

        private void AddRoleElementsForRoleDefinedInMatrix(RoleElementTemplateValuesContainer rolesInMatrix, Worksheet worksheet, ExcelColumn column, Role role, List<RoleElement> roleElements)
        {
            int row = 3;
            // for the current column, the name of the role element is in column "C"
            while (worksheet.GetCell("C", row).Value != null)
            {
                string cellValue = worksheet.GetCellValue(column, row);
                if ("Y".Equals(cellValue))
                {
                    string roleElementName = worksheet.GetCellValue("C", row);
                    RoleElement roleElement = roleElements.Find(re => re.Name == roleElementName);
                    rolesInMatrix.Add(new RoleElementTemplateValue(role, roleElement));
                }
                row++;
            }
        }

    }
}