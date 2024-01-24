
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class EditWorkPermitDropdownsConfigurationFormPresenter
    {
        private readonly BackgroundWorker backgroundWorker = new ClientBackgroundWorker();
        private readonly IEditWorkPermitDropdownsConfigurationForm view;
        private readonly WorkPermitDropdown dropdown;
        private readonly List<DropdownValue> originalValues;
        private readonly List<DropdownValue> values;
        private readonly IDropdownValueService service;

        public EditWorkPermitDropdownsConfigurationFormPresenter(
            IEditWorkPermitDropdownsConfigurationForm editWorkPermitDropdownsConfigurationForm, List<DropdownValue> values, string key)
        {
            this.view = editWorkPermitDropdownsConfigurationForm;
            this.originalValues = values;
            this.dropdown = WorkPermitDropdown.FindByKey(key);
            this.values = new List<DropdownValue>(values);
            this.service = ClientServiceRegistry.Instance.GetService<IDropdownValueService>();

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
            if (ViewIsValid())
            {
                List<DropdownValue> deletedValues = new List<DropdownValue>();

                foreach (DropdownValue oldValue in originalValues)
                {
                    if (oldValue.IsInDatabase() && !values.ExistsById(oldValue))
                    {
                        deletedValues.Add(oldValue);
                    }
                }

                view.Disable();
                backgroundWorker.RunWorkerAsync(deletedValues);
            }
        }

        private void SaveDropdownValues(object sender, DoWorkEventArgs e)
        {
            List<DropdownValue> deletedValues = (List<DropdownValue>)e.Argument;
            service.UpdateValues(values, deletedValues);
            
            BackgroundWorker bgWorker = (BackgroundWorker)sender;
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
            else
            {
                view.Close();
            }
        }


        public void MoveValueUpButton_Clicked(object sender, EventArgs e)
        {
            if (values.Count == 0)
            {
                return;
            }

            DropdownValue value = view.SelectedValue;

            int index = values.IndexOf(value);

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

            DropdownValue value = view.SelectedValue;

            int index = values.IndexOf(value);

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
            DropdownValue newValue = view.LaunchAddEditValueForm(dropdown, null);
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
            DropdownValue selectedValue = view.SelectedValue;
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
                view.LaunchAddEditValueForm(dropdown, value);
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
            bool hasErrors = false;

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
            DropdownValue value = (DropdownValue)e.SelectedItem;
            EditValue(value);
        }
    }
}
