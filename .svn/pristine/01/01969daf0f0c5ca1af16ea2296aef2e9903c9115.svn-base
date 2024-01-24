using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
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
      
    public partial class GasTestMudsForm : BaseForm
    {
        GasTestMudsFormPresenter Present;
       public long workpermitId;
       public string permitnumber;
       public PermitRequestBasedWorkPermitStatus Permitstatus;
        public GasTestMudsForm()
        {
            InitializeComponent();
            this.Text = "Résultats test de gaz";
            this.gasTestTestResultsGroupBox.Text = "Résultats test de gaz";
        }


        public void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            SuspendLayout();
            //gasTestInfoExplorerBarContainerControl.SuspendLayout();
            gasTestElementInfoTableLayoutPanel.showonlyFirstColum = false;
            if (Permitstatus != null && Permitstatus == PermitRequestBasedWorkPermitStatus.Issued)
            {
                gasTestElementInfoTableLayoutPanel.disbaleFirstColumn = true;
            }
            else
            {
                gasTestElementInfoTableLayoutPanel.disbaleFirstColumn = false;
            }
            
            gasTestElementInfoTableLayoutPanel.BuildGasTestElementControls(standardGasTestElementInfoList, ClientSession.GetUserContext().Site);
            //gasTestInfoExplorerBarContainerControl.ResumeLayout();
            ResumeLayout();

             Present = new GasTestMudsFormPresenter(workpermitId);
            Present.standardGasTestElementInfoList = standardGasTestElementInfoList;
            Present.LoadWorkItemGasTests(gasTestElementInfoTableLayoutPanel);
            gasTestElementInfoTableLayoutPanel.GetSignControl.SetValue(Convert.ToString(permitnumber));
             if (Permitstatus != null && Permitstatus == PermitRequestBasedWorkPermitStatus.Issued)
            {
              gasTestElementInfoTableLayoutPanel.DisbaleFirstTime = true;
            }
             if (Permitstatus != null && Permitstatus == PermitRequestBasedWorkPermitStatus.Issued)
             {
                 gasTestElementInfoTableLayoutPanel.GetSignControl.FirstSignEnabled = false;
             }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Present.ValidateGasTest(gasTestElementInfoTableLayoutPanel) && gasTestElementInfoTableLayoutPanel.GetSignControl.Validate())
            {
                Present.SavePermitandGastest(gasTestElementInfoTableLayoutPanel);
                WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                WPSign.SaveMudsSign(gasTestElementInfoTableLayoutPanel.GetSignControl.objWorkPermitSign);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oltBtnshowDetails_Click(object sender, EventArgs e)
        {
            PriorityPageWorkPermitMudsDetailsPresenter P = new PriorityPageWorkPermitMudsDetailsPresenter(workpermitId);
            // Control C = P.GetCOntrolForSign();
            // C.Controls.Find("toolStrip1", true)[0].Visible = false;
            // C.Controls.Find("toolStrip1", true)[1].Visible = false;
            P.Run(this);
            // oltTableLayoutPanel2.Controls.Add(C);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (gasTestElementInfoTableLayoutPanel.GetSignControl != null && gasTestElementInfoTableLayoutPanel.GetSignControl.objWorkPermitSign != null)
            {
                gasTestElementInfoTableLayoutPanel.GetSignControl.objWorkPermitSign.Id = 1;
                EditWorkPermitMudsSignHistoryPresenter EP = new EditWorkPermitMudsSignHistoryPresenter(gasTestElementInfoTableLayoutPanel.GetSignControl.objWorkPermitSign);
                EP.Run(this);
            }
        }
    }
}
