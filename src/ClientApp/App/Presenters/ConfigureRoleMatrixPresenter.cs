using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureRoleMatrixPresenter : BaseFormPresenter<IConfigureRoleMatrixView>
    {
        private readonly IRoleElementTemplateService roleElementTemplateService;
        private readonly IRoleElementService roleElementService;
        private readonly IRoleService roleService;

        private List<Role> roles = new List<Role>();
        private readonly List<RoleMatrixDisplayAdapter> roleMatrixDisplayAdapters = new List<RoleMatrixDisplayAdapter>();
        private readonly RoleElementTemplateValuesContainer roleElementTemplateValuesFromDb = new RoleElementTemplateValuesContainer();

        public ConfigureRoleMatrixPresenter(IConfigureRoleMatrixView view) : base(view)
        {
            roleElementTemplateService = ClientServiceRegistry.Instance.GetService<IRoleElementTemplateService>();
            roleElementService = ClientServiceRegistry.Instance.GetService<IRoleElementService>();
            roleService = ClientServiceRegistry.Instance.GetService<IRoleService>();

            view.InitializeGridLayout += HandleInitializeGridLayout;
            view.Load += HandleLoad;
            view.PreviewChanges += HandlePreviewChanges;
            view.GenerateSql += HandleGenerateSql;
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            Site site = ClientSession.GetUserContext().Site;
            roles = roleService.QueryRolesBySite(site);

            List<RoleElement> roleElements = roleElementService.QueryAll();

            Dictionary<Role, List<RoleElement>> roleElementsForRoleMap = new Dictionary<Role, List<RoleElement>>();

            foreach (Role role in roles)
            {
                List<RoleElement> roleElementsForRole = roleElementService.QueryTemplateForRole(role);
                roleElementTemplateValuesFromDb.AddRange(roleElementsForRole.ConvertAll(roleElement => new RoleElementTemplateValue(role, roleElement)));
                roleElementsForRoleMap.Add(role, roleElementsForRole);
            }

            foreach (RoleElement roleElement in roleElements)
            {
                RoleMatrixDisplayAdapter displayAdapter = new RoleMatrixDisplayAdapter(roleElement);

                foreach (Role role in roles)
                {
                    List<RoleElement> roleElementsForRole = roleElementsForRoleMap[role];
                    displayAdapter.SetValue(RoleMatrixDisplayAdapter.Key(role), roleElementsForRole.Contains(roleElement));
                }

                roleMatrixDisplayAdapters.Add(displayAdapter);
            }

            view.RoleMatrixDisplayAdapters = roleMatrixDisplayAdapters;
        }

        private void HandleInitializeGridLayout(InitializeLayoutEventArgs e)
        {
            foreach (Role role in roles)
            {
                view.AddCheckColumn(role, e);
            }
        }

        private RoleElementTemplateValuesContainer GetRoleElementTemplateValuesFromUi()
        {
            RoleElementTemplateValuesContainer roleElementTemplateValuesFromUi = new RoleElementTemplateValuesContainer();
            List<RoleMatrixDisplayAdapter> displayAdapters = view.RoleMatrixDisplayAdapters;

            foreach (RoleMatrixDisplayAdapter adapter in displayAdapters)
            {
                foreach (Role role in roles)
                {
                    if (adapter.GetValue(role))
                    {
                        roleElementTemplateValuesFromUi.Add(new RoleElementTemplateValue(role, adapter.RoleElement));
                    }
                }
            }

            return roleElementTemplateValuesFromUi;
        }

        private List<RoleElementChange> GetChanges()
        {
            Site site = ClientSession.GetUserContext().Site;
            RoleElementTemplateValuesContainer roleElementTemplateValuesFromUi = GetRoleElementTemplateValuesFromUi();

            List<RoleElementChange> roleChanges = new List<RoleElementChange>();

            List<RoleElementTemplateValue> newValues = roleElementTemplateValuesFromUi.GetItemsInThisThatAreNotIn(roleElementTemplateValuesFromDb);
            List<RoleElementTemplateValue> deletedValues = roleElementTemplateValuesFromDb.GetItemsInThisThatAreNotIn(roleElementTemplateValuesFromUi);

            roleChanges.AddRange(newValues.ConvertAll(value => new RoleElementChange(value.Role.Name, value.RoleElement.Name, RoleElementChangeType.Add, site)));
            roleChanges.AddRange(deletedValues.ConvertAll(value => new RoleElementChange(value.Role.Name, value.RoleElement.Name, RoleElementChangeType.Delete, site)));

            return roleChanges;
        }

        private void HandlePreviewChanges()
        {
            List<RoleElementChange> roleChanges = GetChanges();

            if (roleChanges.IsEmpty())
            {
                view.ShowNoChangesMessage();
            }
            else
            {
                ShowPreviewChangesForm(roleChanges);
            }
        }

        private void HandleGenerateSql()
        {
            List<RoleElementChange> roleChanges = GetChanges();
            ShowGeneratedSqlForm(roleChanges);
        }

        private void ShowPreviewChangesForm(List<RoleElementChange> changes)
        {
            PreviewRoleElementChangesForm previewRoleElementChangesForm = new PreviewRoleElementChangesForm(changes);
            DialogResult dialogResult = previewRoleElementChangesForm.ShowDialog(view);

            if (dialogResult == DialogResult.OK)
            {
                List<RoleElementChange> selectedChanges = previewRoleElementChangesForm.SelectedChanges;
                MakeChanges(selectedChanges);
            }

            previewRoleElementChangesForm.Dispose();
        }

        private void ShowGeneratedSqlForm(List<RoleElementChange> changes)
        {
            RoleElementChangesAsSqlForm form = new RoleElementChangesAsSqlForm(changes);
            form.ShowDialog(view);
            form.Dispose();
        }

        private void MakeChanges(List<RoleElementChange> roleElementChanges)
        {
            foreach (RoleElementChange change in roleElementChanges)
            {
                if (change.IsAdd)
                {
                    roleElementTemplateService.InsertRoleElementTemplate(change.Site, change.Role, change.RoleElement);
                }
                else if (change.IsDelete)
                {
                    roleElementTemplateService.DeleteRoleElementTemplate(change.Site, change.Role, change.RoleElement);
                }
            }

            view.ShowSuccessMessageAndCloseForm();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Role Matrix " + site.IdValue;
        }
    }
}
