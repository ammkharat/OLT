using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RoleElementChangesAsSqlForm : BaseForm
    {
        private readonly List<RoleElementChange> changes;

        public RoleElementChangesAsSqlForm()
        {
            InitializeComponent();
        }

        public RoleElementChangesAsSqlForm(List<RoleElementChange> changes)
            : this()            
        {
            this.changes = changes;

            okButton.Click += HandleOkButtonClick;
        }

        private void HandleOkButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            StringBuilder builder = new StringBuilder();
            changes.ForEach(c => builder.AppendLine(c.ConvertToSql()));
            sqlTextBox.Text = builder.ToString();
        }
    }
}
