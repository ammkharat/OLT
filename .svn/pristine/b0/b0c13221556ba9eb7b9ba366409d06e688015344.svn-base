using Com.Suncor.Olt.Common.Domain;
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
    public partial class WorkPermitAttachment : BaseForm
    {
        public WorkPermitAttachment()
        {
            InitializeComponent();
        }
        public WorkPermitAttachment(List<WorkpermitScan> lst)
        {
            InitializeComponent();
            this.CenterToParent();
            oltDGVAttachment.AutoGenerateColumns = false;
            oltDGVAttachment.DataSource = lst;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oltDGVAttachment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                string FileName = Convert.ToString(oltDGVAttachment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (System.IO.File.Exists(FileName))
                {
                    System.Diagnostics.Process.Start(FileName);
                }

            }
        }
    }
}
