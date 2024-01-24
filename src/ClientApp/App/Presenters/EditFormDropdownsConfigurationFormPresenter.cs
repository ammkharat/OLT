using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditFormDropdownsConfigurationFormPresenter
    {
        private readonly BackgroundWorker backgroundWorker = new ClientBackgroundWorker();
        private readonly FormDropdown dropdown;
        private readonly string nameAlreadyExistsErrorMessage;
        private readonly List<DropdownValue> originalValues;
        private readonly IDropdownValueService service;
        private readonly List<DropdownValue> values;
        private readonly IEditFormDropdownsConfigurationForm view;

        public EditFormDropdownsConfigurationFormPresenter(
            IEditFormDropdownsConfigurationForm editFormDropdownsConfigurationForm, List<DropdownValue> values,
            string key, string nameAlreadyExistsErrorMessage)
        {
            view = editFormDropdownsConfigurationForm;
            originalValues = values;
            dropdown = FormDropdown.FindByKey(key);
            this.values = new List<DropdownValue>(values);
            this.nameAlreadyExistsErrorMessage = nameAlreadyExistsErrorMessage;
            service = ClientServiceRegistry.Instance.GetService<IDropdownValueService>();

            backgroundWorker.DoWork += SaveDropdownValues;
            backgroundWorker.RunWorkerCompleted += SavingDropdownValuesComplete;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        public void Load(object sender, EventArgs e)
        {
            SortAndSetValuesOnGrid();

            view.SelectFirstValue();
            view.DropdownName = dropdown.Name;
        }

        public void SaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            if (!ViewIsValid()) return;

            var deletedValues =
                originalValues.Where(oldValue => oldValue.IsInDatabase() && !values.ExistsById(oldValue)).ToList();

            view.Disable();
            backgroundWorker.RunWorkerAsync(deletedValues);
        }

        private void SaveDropdownValues(object sender, DoWorkEventArgs e)
        {
            var deletedValues = (List<DropdownValue>) e.Argument;
            service.UpdateValues(values, deletedValues);

            var bgWorker = (BackgroundWorker) sender;
            if (bgWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void SavingDropdownValuesComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            view.Enable();

            if (e.Error != null)
            {
                throw e.Error;
            }
            view.Close();
        }


        public void MoveValueUpButton_Clicked(object sender, EventArgs e)
        {
            if (values.Count == 0)
            {
                return;
            }

            var value = view.SelectedValue;

            var index = values.IndexOf(value);

            if (index == 0)
            {
                return;
            }

            values.Remove(value);
            values.Insert(index - 1, value);

            DisplayOrderHelper.ResetDisplayValues(values);
            SortAndSetValuesOnGrid();

            view.SelectedValue = value;
        }

        public void MoveValueDownButton_Clicked(object sender, EventArgs e)
        {
            if (values.Count == 0)
            {
                return;
            }

            var value = view.SelectedValue;

            var index = values.IndexOf(value);

            if (index == values.Count - 1)
            {
                return;
            }

            values.Remove(value);
            values.Insert(index + 1, value);

            DisplayOrderHelper.ResetDisplayValues(values);
            SortAndSetValuesOnGrid();

            view.SelectedValue = value;
        }

        public void AddValueButton_Clicked(object sender, EventArgs e)
        {
            var newValue = view.LaunchAddEditValueForm(dropdown, null, values, nameAlreadyExistsErrorMessage);
            if (newValue != null)
            {
                newValue.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(values) + 1;
                values.Add(newValue);
                SortAndSetValuesOnGrid();
                view.SelectedValue = newValue;
            }
        }

        public void EditValueButton_Clicked(object sender, EventArgs e)
        {
            EditValue(view.SelectedValue);
        }

        public void DeleteValueButton_Clicked(object sender, EventArgs e)
        {
            var selectedValue = view.SelectedValue;
            if (selectedValue != null && view.UserIsSure())
            {
                values.Remove(selectedValue);
                SortAndSetValuesOnGrid();
                view.SelectFirstValue();
            }
        }

        private void EditValue(DropdownValue value)
        {
            if (value != null)
            {
                view.LaunchAddEditValueForm(dropdown, value, values, nameAlreadyExistsErrorMessage);
                SortAndSetValuesOnGrid();
                view.SelectedValue = value;
            }
        }

        private void SortAndSetValuesOnGrid()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(values);
            view.DropdownValues = values;
        }

        private bool ViewIsValid()
        {
            view.ClearErrors();
            var hasErrors = false;

            if (values.Count == 0)
            {
                view.SetAtLeastOneValueRequiredError();
                hasErrors = true;
            }

            return !hasErrors;
        }

        public void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        public void GridRow_DoubleClicked(object sender, DomainEventArgs<DropdownValue> e)
        {
            var value = e.SelectedItem;
            EditValue(value);
        }
    }
}