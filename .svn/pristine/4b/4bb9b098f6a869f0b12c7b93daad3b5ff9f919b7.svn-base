using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditAreaLabelForm : BaseForm
    {
        private AreaLabel editObject;
        private readonly long siteId;
        private readonly List<string> existingSapPlannerGroups;

        public AddEditAreaLabelForm(long siteId, List<string> existingSapPlannerGroups)
            : this(null, siteId, existingSapPlannerGroups)
        {
        }

        public AddEditAreaLabelForm(AreaLabel editObject, long siteId, List<string> existingSapPlannerGroups)
        {
            InitializeComponent();

            this.editObject = editObject;
            this.siteId = siteId;
            this.existingSapPlannerGroups = existingSapPlannerGroups;

            okButton.Click += HandleOkButtonClick;
        }

        public AreaLabel AreaLabel
        {
            get { return editObject; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (editObject != null)
            {
                areaLabelTextBox.Text = editObject.Name;
                allowManualSelectionCheckBox.Checked = editObject.AllowManualSelection;
                sapPlannerGroupTextBox.Text = editObject.SapPlannerGroup;
            }
        }

        private void HandleOkButtonClick(object sender, EventArgs e)
        {
            string areaLabelText = areaLabelTextBox.Text.TrimOrNull();
            string sapPlannerGroup = sapPlannerGroupTextBox.Text.TrimOrNull();
            bool allowManualSelection = allowManualSelectionCheckBox.Checked;

            bool hasError = Validate(areaLabelText, sapPlannerGroup);
            if (hasError)
            {
                return;
            }

            if (editObject == null)
            {
                editObject = new AreaLabel(null, areaLabelText, siteId, 0, allowManualSelection, sapPlannerGroup);
            }
            else
            {
                editObject.Name = areaLabelText;
                editObject.AllowManualSelection = allowManualSelection;
                editObject.SapPlannerGroup = sapPlannerGroup;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool Validate(string areaLabelText, string sapPlannerGroup)
        {
            bool hasError = false;

            if (areaLabelText == null)
            {
                errorProvider.SetError(areaLabelTextBox, StringResources.EnterAValidValue);
                hasError = true;
            }

            if (sapPlannerGroup != null && existingSapPlannerGroups.Exists(groupName => groupName.ToLower() == sapPlannerGroup.ToLower()))
            {
                errorProvider.SetError(sapPlannerGroupTextBox, StringResources.PlannerGroupAlreadyAssigned);
                hasError = true;
            }

            return hasError;
        }



    }
}
