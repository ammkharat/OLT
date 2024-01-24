using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Infragistics.Win.SupportDialogs.Glyphs.Design;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FlocLevelSettingForAdmin : BaseForm, IAdminFlocLevelSiteConfigurationView
    {

        public FlocLevelSettingForAdmin()
        {
            InitializeComponent();
            var items = new BindingList<KeyValuePair<string, int>>();

            // ayman added 0 to go to default value
            items.Add(new KeyValuePair<string, int>("Default",0));
            items.Add(new KeyValuePair<string, int>("First Level", 1));
            items.Add(new KeyValuePair<string, int>("Second Level", 2));
            items.Add(new KeyValuePair<string, int>("Third Level", 3));

            var itemsShiftLog = new BindingList<KeyValuePair<string, int>>();

            itemsShiftLog.Add(new KeyValuePair<string, int>("Default",0));
            itemsShiftLog.Add(new KeyValuePair<string, int>("First Level", 1));
            itemsShiftLog.Add(new KeyValuePair<string, int>("Second Level", 2));
            itemsShiftLog.Add(new KeyValuePair<string, int>("Third Level", 3));

            var itemsShiftHandover = new BindingList<KeyValuePair<string, int>>();

            itemsShiftHandover.Add(new KeyValuePair<string, int>("Default",0));
            itemsShiftHandover.Add(new KeyValuePair<string, int>("First Level", 1));
            itemsShiftHandover.Add(new KeyValuePair<string, int>("Second Level", 2));
            itemsShiftHandover.Add(new KeyValuePair<string, int>("Third Level", 3));

            cmbActionItemFlocLevel.DataSource = items;
            cmbActionItemFlocLevel.DisplayMember = "Key";
            cmbActionItemFlocLevel.ValueMember = "Value";

            cmbShiftLogFlocLevel.DataSource = itemsShiftLog;
            cmbShiftLogFlocLevel.DisplayMember = "Key";
            cmbShiftLogFlocLevel.ValueMember = "Value";

            cmbShiftHandoverFlocLevel.DataSource = itemsShiftHandover;
            cmbShiftHandoverFlocLevel.DisplayMember = "Key";
            cmbShiftHandoverFlocLevel.ValueMember = "Value";


            EnableDisableItem(1,false);
            EnableDisableItem(2,false);
            EnableDisableItem(3,false);
            
            
            btnSave.Click += HandleSaveButtonClick;
            btnCancel.Click += HandleCancelButtonClick;
        }

        public event Action Save;


        private void EnableDisableItem(int which, bool enable)
        {
            switch (which)
            {
                case 1:
                    lblActionItem.Enabled = enable;
                    cmbActionItemFlocLevel.Enabled = enable;
                    break;
                case 2:
                    lblShiftLog.Enabled = enable;
                    cmbShiftLogFlocLevel.Enabled = enable;
                    break;
                case 3:
                    lblShiftHandover.Enabled = enable;
                    cmbShiftHandoverFlocLevel.Enabled = enable;
                    break;
            }
        }
        
        public int ActionItemFlocLevel
        {
            get { return Convert.ToInt16(cmbActionItemFlocLevel.SelectedValue); }
            set
            {
                cmbActionItemFlocLevel.SelectedValue = value;  //ayman floc level
            }
        }

        public int ShiftLogFlocLevel
        {
            get { return Convert.ToInt16(cmbShiftLogFlocLevel.SelectedValue); }
            set { cmbShiftLogFlocLevel.SelectedValue = value; }
        }

        public int ShiftHandoverFlocLevel
        {
            get { return Convert.ToInt16(cmbShiftHandoverFlocLevel.SelectedValue); }
            set { cmbShiftHandoverFlocLevel.SelectedValue = value; }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
                this.Close();
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
         
            if (Save != null)

                Save();
        }

        private void chkActionItem_CheckedChanged(object sender, EventArgs e)
        {
           EnableDisableItem(1,chkActionItem.Checked);
        }

        private void chkShiftLog_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableItem(2,chkShiftLog.Checked);
        }

        private void chkShiftHandover_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableItem(3,chkShiftHandover.Checked);
        }

       
    }
}
