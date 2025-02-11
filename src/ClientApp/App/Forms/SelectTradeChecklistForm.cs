﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SelectTradeChecklistForm : BaseForm
    {
        private List<TradeChecklistInfo> displayItemPairs;

        string selectedTradeChecklistNumber = null;
        long? selectedTradeChecklistId = null;

        public SelectTradeChecklistForm(List<TradeChecklistInfo> displayItemPairs)
        {
            InitializeComponent();

            this.displayItemPairs = displayItemPairs;

            selectButton.Click += HandleSelectButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            listBox.MouseDoubleClick += HandleSelectButtonClick; //RITM0513099 - mangesh
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            listBox.Items.Clear();
            displayItemPairs.ForEach(dip => listBox.Items.Add(dip));

            listBox.SelectedIndex = 0;
        }

        public string SelectedTradeChecklistNumber
        {
            get { return selectedTradeChecklistNumber; }           
        }

        public long? SelectedTradeChecklistId
        {
            get { return selectedTradeChecklistId; }           
        }

        private void HandleSelectButtonClick(object sender, EventArgs e)
        {
            TradeChecklistInfo item = (TradeChecklistInfo) listBox.SelectedItem;

            if (item == null)
            {
                OltMessageBox.Show(this, "Please select an item.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedTradeChecklistNumber = item.InformationDisplayText;
            selectedTradeChecklistId = item.Id;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }               
    }
}
