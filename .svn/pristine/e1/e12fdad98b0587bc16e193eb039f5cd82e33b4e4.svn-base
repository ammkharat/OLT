using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ShiftLogMessages : BaseForm
    {
        private DomainSummaryGrid<ShiftLogMessage> grid;
        public ShiftLogMessages()
        {
            InitializeComponent();
        }
        public ShiftLogMessages(List<ShiftLogMessage> lstMessages)
        {
            InitializeComponent();
            CenterToParent();
                   
            ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
   
            grid = new DomainSummaryGrid<ShiftLogMessage>(new OperatorRoundGridRender(), OltGridAppearance.EDIT_ROW_SELECT_WITH_FILTER, string.Empty) { Dock = DockStyle.Fill };
            grpboxGrid.Controls.Add(grid);
       
           List<ShiftLogMessage> lstMessage= objShiftLogMessagesPresenter.Getdata();
            grid.Items = objShiftLogMessagesPresenter.Getdata();


            foreach (ShiftLogMessage Shift in lstMessages)
            {
                foreach (UltraGridRow row in grid.Rows)
                {
                    if (Shift.Id == (row.ListObject as ShiftLogMessage).Id)
                    {
                        (row.ListObject as ShiftLogMessage).Selected = true;
                    }
                }


            }
           
            
             
        }

     

        private void appendToCommentsButton_Click(object sender, EventArgs e)
        {
            if (this.Owner == null)
            {
                return;
            }

            List<ShiftLogMessage> lst = new List<ShiftLogMessage>();
            ShiftLogMessagesPresenter objShiftLogMessagesPresenter = new ShiftLogMessagesPresenter();
           
                foreach(UltraGridRow row in grid.Rows)
                {
                    if(row.ListObject.GetType()==typeof(ShiftLogMessage))
                    {
                        ShiftLogMessage obj = row.ListObject as ShiftLogMessage;
                        if(obj.Selected==true)
                        {
                            lst.Add(obj);
                        }
                    }
                    
                   
                }
                if (lst.Count==0)
                {
                    DialogResult = DialogResult.OK;
                    return;
                }
                if (this.Owner.GetType() == typeof(ShiftHandoverQuestionnaireAndLogForm))
                {
                    ShiftHandoverQuestionnaireAndLogForm frm = (this.Owner as ShiftHandoverQuestionnaireAndLogForm);

                    frm.ShiftLogMessages = objShiftLogMessagesPresenter.GetTableRTF(lst);

                    frm.lstShiftLogMessages = lst;
                }

                if (this.Owner.GetType() == typeof(ShiftHandoverQuestionnaireForm))
                {
                    ShiftHandoverQuestionnaireForm frm = (this.Owner as ShiftHandoverQuestionnaireForm);

                    frm.ShiftLogMessages = objShiftLogMessagesPresenter.GetTableRTF(lst);

                    frm.lstShiftLogMessages = lst;
                }

            
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
