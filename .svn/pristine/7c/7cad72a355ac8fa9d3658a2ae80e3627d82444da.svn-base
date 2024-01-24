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
    public class FormDropdownsConfigurationFormPresenter
    {
        private readonly BackgroundHelper<FormDropdown, BackgroundWorkerResult> backgroundHelper;
        private readonly IFormDropdownsConfigurationView view;

        public FormDropdownsConfigurationFormPresenter(IFormDropdownsConfigurationView view)
        {
            this.view = view;

            backgroundHelper =
                new BackgroundHelper<FormDropdown, BackgroundWorkerResult>(new ClientBackgroundWorker(),
                    new DropdownValuesLoader(view));
        }

        public void Load(object sender, EventArgs e)
        {
            ReloadGrid();
            view.SelectFirstRow();
        }

        private void ReloadGrid()
        {
            var dropdowns = FormDropdown.AllDropdowns(ClientSession.GetUserContext().Site.IdValue);
            view.Dropdowns = dropdowns;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Form Dropdown Configuration Form-{0}", site.Id);
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            var selectedDropdown = view.SelectedItem;
            Edit(selectedDropdown);
        }

        private void Edit(FormDropdown dropdown)
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

        public void GridRow_DoubleClick(object sender, DomainEventArgs<FormDropdown> e)
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

        private class DropdownValuesLoader : ClientBackgroundingFriendly<FormDropdown, BackgroundWorkerResult>
        {
            private readonly IDropdownValueService service;
            private readonly IFormDropdownsConfigurationView view;

            public DropdownValuesLoader(IFormDropdownsConfigurationView view)
            {
                this.view = view;
                service = ClientServiceRegistry.Instance.GetService<IDropdownValueService>();
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

            public override BackgroundWorkerResult DoWork(FormDropdown formDropdown)
            {
                var dropdownValues = service.QueryByKey(ClientSession.GetUserContext().Site.IdValue,
                    formDropdown.Key);
                return new BackgroundWorkerResult(formDropdown.Key, dropdownValues);
            }

            public override void WorkSuccessfullyCompleted(BackgroundWorkerResult result)
            {
                var nameAlreadyExistsErrorMessage = FormDropdown.GetNameAlreadyExistsErrorMessage(result.Key);
                view.LaunchEditForm(result.DropDownValueList, result.Key, nameAlreadyExistsErrorMessage);
            }

            public override void OnError(Exception e)
            {
                throw e;
            }
        }
    }
}