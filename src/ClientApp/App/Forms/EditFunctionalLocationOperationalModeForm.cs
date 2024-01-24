using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditFunctionalLocationOperationalModeForm : BaseForm
    {
        readonly FunctionalLocationOperationalModeDTO operationalModeDTO;

        public EditFunctionalLocationOperationalModeForm(FunctionalLocationOperationalModeDTO originalOpModeDTO)
        {
            operationalModeDTO = originalOpModeDTO;

            InitializeComponent();
        }

        public FunctionalLocationOperationalModeDTO ShowDialogAndReturnChangedDTO(Form parentForm)
        {            
            DialogResult result = ShowDialog(parentForm);

            FunctionalLocationOperationalModeDTO modeDto = null;

            if (result == DialogResult.OK)
            {
                OperationalMode mode = (OperationalMode) operationalModeComboBox.SelectedItem;
                AvailabilityReason modeReason = (AvailabilityReason)availabilityReasonComboBox.SelectedItem;

                modeDto = new FunctionalLocationOperationalModeDTO(operationalModeDTO.FunctionalLocationId,
                                                                   operationalModeDTO.FullHierarchy,
                                                                   operationalModeDTO.Description, 
                                                                   mode,
                                                                   modeReason,
                                                                   Clock.Now);
            }

            return modeDto;
        }

        private void LoadForm(object sender, EventArgs e)
        {
            SetUpComboBox(operationalModeComboBox, OperationalMode.All, "Name", "Id");
            SetUpComboBox(availabilityReasonComboBox, AvailabilityReason.ALL, "Name", "Id");
            unitLevelFlocDisplayLabel.Text = operationalModeDTO.FullHierarchy;
            
            operationalModeComboBox.SelectedItem = operationalModeDTO.OperationalMode;
            availabilityReasonComboBox.SelectedItem = operationalModeDTO.AvailabilityReason;
        }

        private void SetUpComboBox(ComboBox comboBox, object[] opModeList, string displayMember, string valueMember)
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            // always put the DataSource last because one the members above could be a non-browsable type.
            comboBox.DataSource = opModeList;
        }
    }
}