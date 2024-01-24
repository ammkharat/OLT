using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitDropdownsConfigurationFormPresenter
    {
        private readonly BackgroundHelper<WorkPermitDropdown, BackgroundWorkerResult> backgroundHelper;
        private readonly IWorkPermitDropdownsConfigurationView view;

        public WorkPermitDropdownsConfigurationFormPresenter(IWorkPermitDropdownsConfigurationView view)
        {
            this.view = view;

            backgroundHelper = new BackgroundHelper<WorkPermitDropdown, BackgroundWorkerResult>(new ClientBackgroundWorker(), new DropdownValuesLoader(view));
        }

        public void Load(object sender, EventArgs e)
        {
            ReloadGrid();
            view.SelectFirstRow();            
        }

        private void ReloadGrid()
        {
            List<WorkPermitDropdown> dropdowns = WorkPermitDropdown.AllDropdowns(ClientSession.GetUserContext().Site.IdValue);
            view.Dropdowns = dropdowns;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Work Permit Dropdown Configuration Form-{0}", site.Id);
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            WorkPermitDropdown selectedDropdown = view.SelectedItem;
            Edit(selectedDropdown);
        }

        private void Edit(WorkPermitDropdown dropdown)
        {
            if (dropdown != null)
            {
                backgroundHelper.Run(dropdown);
            }
        }

        public void CloseButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundHelper.Cancel();
        }

        public void GridRow_DoubleClick(object sender, DomainEventArgs<WorkPermitDropdown> e)
        {
            Edit(e.SelectedItem);
        }

        private class BackgroundWorkerResult
        {
            public BackgroundWorkerResult(string key, List<DropdownValue> dropDownValueList)
            {
                Key = key;
                DropDownValueList = dropDownValueList;
            }

            public string Key { get; private set; }
            public List<DropdownValue> DropDownValueList { get; private set; }
        }

        private class DropdownValuesLoader : ClientBackgroundingFriendly<WorkPermitDropdown, BackgroundWorkerResult>
        {
            private readonly IWorkPermitDropdownsConfigurationView view;
            private readonly IDropdownValueService service;

            public DropdownValuesLoader(IWorkPermitDropdownsConfigurationView view)
            {
                this.view = view;
                this.service = ClientServiceRegistry.Instance.GetService<IDropdownValueService>();
            }

            public override BackgroundWorkerResult DoWork(WorkPermitDropdown workPermitDropdown)
            {
                List<DropdownValue> dropdownValues = service.QueryByKey(ClientSession.GetUserContext().Site.IdValue, workPermitDropdown.Key);
                return new BackgroundWorkerResult(workPermitDropdown.Key, dropdownValues);
            }

            public override bool ViewEnabled
            {
                set
                {
                    if (value)
                    {
                        view.Enable();
                    }
                    else
                    {
                        view.Disable();
                    }
                }
            }

            public override void WorkSuccessfullyCompleted(BackgroundWorkerResult result)
            {
                view.LaunchEditForm(result.DropDownValueList, result.Key);
            }

            public override void OnError(Exception e)
            {
                throw e;
            }
        }
    }
}
