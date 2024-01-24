using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class RoleMatrixExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private readonly Dictionary<Site, List<Role>> rolesBySite = new Dictionary<Site, List<Role>>();
        private readonly Dictionary<Role, List<RoleElement>> roleElementsByRole = new Dictionary<Role, List<RoleElement>>();
        private readonly Dictionary<Role, List<RolePermission>> rolePermissionsByRole = new Dictionary<Role, List<RolePermission>>();
        private readonly List<RoleElement> uniqueRoleElements = new List<RoleElement>();

        public RoleMatrixExcelDataRenderer(Site currentSite,
            Dictionary<Site, List<Role>> roles, 
            Dictionary<Role, List<RoleElement>> roleElementsByRole,
            Dictionary<Role, List<RolePermission>> rolePermissionsByRole)
        {
            LoadRoles(currentSite, roles);
            this.roleElementsByRole = roleElementsByRole;
            this.rolePermissionsByRole = rolePermissionsByRole;

            foreach (List<RoleElement> roleElements in roleElementsByRole.Values)
            {
                foreach (RoleElement roleElement in roleElements)
                {
                    if (!uniqueRoleElements.Exists(obj => obj.Id == roleElement.Id))
                    {
                        uniqueRoleElements.Add(roleElement);
                    }
                }
            }

            uniqueRoleElements.Sort(SortRoleElement);
        }

        private static int SortRoleElement(RoleElement x, RoleElement y)
        {
            {
                int compareResult = GetAdminOrder(x).CompareTo(GetAdminOrder(y));
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                int compareResult = System.String.Compare(x.FunctionalArea, y.FunctionalArea, System.StringComparison.Ordinal);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                int compareResult = GetNameOrder(x).CompareTo(GetNameOrder(y));
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return x.IdValue.CompareTo(y.IdValue);
        }

        private static int GetAdminOrder(RoleElement roleElement)
        {
            if (!string.IsNullOrEmpty(roleElement.FunctionalArea) &&
                roleElement.FunctionalArea.ToLower().Contains("admin"))
            {
                return 1;
            }
            return 0;
        }

        private static int GetNameOrder(RoleElement roleElement)
        {
            if (!string.IsNullOrEmpty(roleElement.FunctionalArea) &&
                roleElement.Name.ToLower().Contains("view"))
            {
                return 0;
            }
            return 1;
        }

        private void LoadRoles(Site currentSite, Dictionary<Site, List<Role>> roles)
        {
            List<Site> sortedSites = new List<Site>(roles.Keys);
            sortedSites.Sort((x,y) => string.CompareOrdinal(x.Name, y.Name));

            if (currentSite != null)
            {
                sortedSites.Remove(currentSite);
                sortedSites.Insert(0, currentSite);
            }

            foreach (Site site in sortedSites)
            {
                roles[site].Sort((x,y) => string.CompareOrdinal(x.Name, y.Name));
                rolesBySite.Add(site, roles[site]);
            }
        }

        public void Populate(Workbook workbook)
        {
            PopulateMatrix(workbook);
            PopulateRolePermissions(workbook);
        }

        private void PopulateMatrix(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add("Role Matrix");
            worksheet.DisplayOptions.MagnificationInNormalView = 75;
            worksheet.DefaultColumnWidth = 500;
            CreateMatrixHeader(worksheet);
            CreateMatrixDataRows(worksheet);
        }

        private void CreateMatrixHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;

            worksheet.Columns[column].Width = 4000;
            MergeWithRowBefore(worksheet, row, column++, ""); // functional area
            worksheet.Columns[column].Width = 1000;
            MergeWithRowBefore(worksheet, row, column++, ""); // role element id
            worksheet.Columns[column].Width = 8000;
            MergeWithRowBefore(worksheet, row, column++, ""); // role element name

            foreach (KeyValuePair<Site, List<Role>> keyValuePair in rolesBySite)
            {
                worksheet.Rows[row].Cells[column].CellFormat.LeftBorderStyle = CellBorderLineStyle.Thick;

                List<string> names = keyValuePair.Value.ConvertAll(obj => obj.Name + " (" + obj.Alias + ")");
                MakeMergedRowBefore(worksheet, row, ref column, keyValuePair.Key.Name, names.ToArray());
            }
           
            ApplyHeaderFormat(worksheet, row);

            worksheet.Rows[1].CellFormat.Rotation = 90;
            worksheet.Rows[1].Height = 3000;
        }

        private void CreateMatrixDataRows(Worksheet worksheet)
        {
            int row = 2;

            string previousFunctionalArea = "";

            foreach (RoleElement roleElement in uniqueRoleElements)
            {
                if (roleElement.FunctionalArea != previousFunctionalArea)
                {
                    worksheet.Rows[row].CellFormat.TopBorderStyle = CellBorderLineStyle.Thick;                    
                }
                previousFunctionalArea = roleElement.FunctionalArea;

                CreateDataRow(row++, worksheet, roleElement);
            }
        }

        private void CreateDataRow(
            int row,
            Worksheet worksheet,
            RoleElement roleElement)
        {
            int column = 0;
            worksheet.Rows[row].Cells[column++].Value = roleElement.FunctionalArea;
            worksheet.Rows[row].Cells[column++].Value = roleElement.Id;
            worksheet.Rows[row].Cells[column++].Value = roleElement.Name;
            
            foreach (KeyValuePair<Site, List<Role>> keyValuePair in rolesBySite)
            {
                worksheet.Rows[row].Cells[column].CellFormat.LeftBorderStyle = CellBorderLineStyle.Thick;

                foreach (Role role in keyValuePair.Value)
                {
                    worksheet.Rows[row].Cells[column++].Value = HasRoleElement(role, roleElement) ? "Y" : "";
                }
            }
        }

        private bool HasRoleElement(Role role, RoleElement roleElement)
        {
            if (roleElementsByRole.ContainsKey(role))
            {
                List<RoleElement> roleElements = roleElementsByRole[role];
                if (roleElements.Exists(obj => obj.Id == roleElement.Id))
                {
                    return true;
                }
            }
            return false;
        }


        private void PopulateRolePermissions(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add("Role Permissions");
            worksheet.DisplayOptions.MagnificationInNormalView = 75;
            CreatePermissionHeader(worksheet);
            CreatePermissionDataRows(worksheet);
        }

        private static void CreatePermissionHeader(Worksheet worksheet)
        {
            const int row = 0;
            int column = 0;

            worksheet.Rows[row].Cells[column++].Value = "Site";
            worksheet.Columns[column].Width = 9000;
            worksheet.Rows[row].Cells[column++].Value = "Action By";
            worksheet.Rows[row].Cells[column++].Value = "Id";
            worksheet.Columns[column].Width = 10000;
            worksheet.Rows[row].Cells[column++].Value = "Name";
            worksheet.Columns[column].Width = 9000;
            worksheet.Rows[row].Cells[column++].Value = "Created By";

            IWorksheetCellFormat worksheetCellFormat = worksheet.Rows[row].CellFormat;
            ApplyHeaderFormat(worksheetCellFormat);
        }

        private void CreatePermissionDataRows(Worksheet worksheet)
        {
            int row = 1;

            foreach (KeyValuePair<Site, List<Role>> keyValuePair in rolesBySite)
            {
                int column = 0;
                worksheet.Rows[row].Cells[column++].Value = keyValuePair.Key.Name;
                worksheet.Rows[row].CellFormat.TopBorderStyle = CellBorderLineStyle.Thick;

                bool hasPermissions = false;

                List<Role> roles = keyValuePair.Value;
                foreach (Role role in roles)
                {
                    if (rolePermissionsByRole.ContainsKey(role))
                    {
                        List<RolePermission> permissions = rolePermissionsByRole[role];
                        permissions.Sort(SortRolePermission);

                        for (int i = 0; i < permissions.Count; i++)
                        {
                            RolePermission rolePermission = permissions[i];

                            column = 1;

                            RoleElement roleElement = uniqueRoleElements.Find(obj => obj.Id == rolePermission.RoleElementId);
                            Role createdByRole = roles.Find(obj => obj.Id == rolePermission.CreatedByRoleId);
                            if (roleElement != null)
                            {
                                hasPermissions = true;

                                SetFormat(worksheet, row, column, rolePermission, i == 0);
                                worksheet.Rows[row].Cells[column++].Value = role.Name;

                                SetFormat(worksheet, row, column, rolePermission, i == 0);
                                worksheet.Rows[row].Cells[column++].Value = roleElement.Id;

                                SetFormat(worksheet, row, column, rolePermission, i == 0);
                                worksheet.Rows[row].Cells[column++].Value = roleElement.Name;

                                SetFormat(worksheet, row, column, rolePermission, i == 0);
                                worksheet.Rows[row].Cells[column++].Value = createdByRole.Name;

                                row++;
                            }
                        }
                    }
                }

                if (!hasPermissions)
                {
                    worksheet.Rows[row].Cells[column].CellFormat.Font.Color = Color.Gray;
                    worksheet.Rows[row].Cells[column++].Value = "None";
                    row++;
                }
            }
        }

        private static void SetFormat(Worksheet worksheet, int row, int column, RolePermission rolePermission, bool isFirstForRole)
        {
            if (rolePermission.RoleId == rolePermission.CreatedByRoleId)
            {
                worksheet.Rows[row].Cells[column].CellFormat.Font.Color = Color.Gray;
            }
            if (isFirstForRole)
            {
                worksheet.Rows[row].Cells[column].CellFormat.TopBorderStyle = CellBorderLineStyle.Thick;
            }
        }

        private int SortRolePermission(RolePermission x, RolePermission y)
        {
            {
                int compareValue = x.CreatedByRoleId.CompareTo(y.CreatedByRoleId);
                if (compareValue != 0)
                {
                    return compareValue;
                }
            }

            {
                RoleElement xRoleElement = uniqueRoleElements.Find(obj => obj.Id == x.RoleElementId);
                RoleElement yRoleElement = uniqueRoleElements.Find(obj => obj.Id == y.RoleElementId);
                int compareValue = SortRoleElement(xRoleElement, yRoleElement);
                if (compareValue != 0)
                {
                    return compareValue;
                }
            }
            
            return 0;
        }
    }
}
