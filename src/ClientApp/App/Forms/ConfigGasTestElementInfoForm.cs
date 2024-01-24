using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigGasTestElementInfoForm : BaseForm, IConfigGasTestElementInfoFormView
    {
        private List<GasTestElementInfoDTO> gasTestElementInfoDTOList;

        public ConfigGasTestElementInfoForm()
        {
            InitializeComponent();
            InitializeGasLimitsDataGridView();            
            ConfigGasTestElementInfoFormPresenter presenter = new ConfigGasTestElementInfoFormPresenter(this, ClientSession.GetUserContext().Site);

            Load += presenter.HandleFormLoad;
            saveButton.Click += presenter.HandleSaveButtonClick;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistory;
        }
      
        #region Initialize Gas Limits Data Grid View

        DataGridViewColumn nameColumn;
        DataGridViewColumn coldLimitColumn;
        DataGridViewColumn hotLimitColumn;
        DataGridViewColumn cseLimitColumn;
        DataGridViewColumn inertCSELimitColumn;
        DataGridViewColumn unitColumn;

        private void InitializeGasLimitsDataGridView()
        {
            gasLimitsDataGridView.Columns.Clear();
            gasLimitsDataGridView.AllowUserToAddRows = false;
            gasLimitsDataGridView.AllowUserToDeleteRows = false;
            gasLimitsDataGridView.AutoGenerateColumns = false;
            gasLimitsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gasLimitsDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;

            nameColumn = CreateNameColumn("nameColumn", "Name");
            gasLimitsDataGridView.Columns.Add(nameColumn);

            coldLimitColumn = CreateLimitColumn("coldLimitColumn", "Cold", "");
            gasLimitsDataGridView.Columns.Add(coldLimitColumn);

            hotLimitColumn = CreateLimitColumn("hotLimitColumn", "Hot", "");
            gasLimitsDataGridView.Columns.Add(hotLimitColumn);

            cseLimitColumn = CreateLimitColumn("cseLimitColumn", "CSE", "");
            gasLimitsDataGridView.Columns.Add(cseLimitColumn);

            inertCSELimitColumn = CreateLimitColumn("inertCSELimitColumn", "Inert CSE", "");
            gasLimitsDataGridView.Columns.Add(inertCSELimitColumn);

            unitColumn = CreateUnitColumn("unitColumn", string.Empty);
            gasLimitsDataGridView.Columns.Add(unitColumn);
        }

        private DataGridViewColumn CreateNameColumn(string columnName, string dataPropertyName)
        {
            DataGridViewTextBoxColumn ret = new DataGridViewTextBoxColumn();
            ret.Name = columnName;
            ret.HeaderText = "Gas";
            ret.ReadOnly = true;
            ret.DataPropertyName = dataPropertyName;
            return ret;
        }

        private DataGridViewColumn CreateLimitColumn(string columnName, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn ret = new DataGridViewTextBoxColumn();
            ret.Name = columnName;
            ret.HeaderText = headerText;
            ret.ReadOnly = false;
            ret.DataPropertyName = dataPropertyName;
            return ret;
        }

        private DataGridViewColumn CreateUnitColumn(string columnName, string dataPropertyName)
        {
            DataGridViewComboBoxColumn ret = new DataGridViewComboBoxColumn();
            ret.Name = columnName;
            ret.HeaderText = "Units";
            ret.ReadOnly = false;
            ret.DataPropertyName = dataPropertyName;

            return ret;
        }

        #endregion

        private void PopulateGasLimitsDataGridView()
        {
            gasLimitsDataGridView.Rows.Clear();
            foreach (GasTestElementInfoDTO infoDTO in gasTestElementInfoDTOList)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = infoDTO.Name;
                nameCell.ValueType = typeof(string);
                row.Cells.Add(nameCell);

                DataGridViewTextBoxCell coldLimitCell = new DataGridViewTextBoxCell();
                coldLimitCell.Value = infoDTO.ColdLimit;
                coldLimitCell.ValueType = typeof(string);
                row.Cells.Add(coldLimitCell);

                DataGridViewTextBoxCell hotLimitCell = new DataGridViewTextBoxCell();
                hotLimitCell.Value = infoDTO.HotLimit;
                hotLimitCell.ValueType = typeof(string);
                row.Cells.Add(hotLimitCell);

                DataGridViewTextBoxCell cseLimitCell = new DataGridViewTextBoxCell();
                cseLimitCell.Value = infoDTO.CSELimit;
                cseLimitCell.ValueType = typeof(string);
                row.Cells.Add(cseLimitCell);

                DataGridViewTextBoxCell inertCSELimitCell = new DataGridViewTextBoxCell();
                inertCSELimitCell.Value = infoDTO.InertCSELimit;
                inertCSELimitCell.ValueType = typeof(string);
                row.Cells.Add(inertCSELimitCell);

                DataGridViewComboBoxCell unitCell = new DataGridViewComboBoxCell();
                foreach (GasLimitUnit unit in GasLimitUnit.ALL)
                {
                    unitCell.Items.Add(unit.UnitName);
                }
                unitCell.Value = infoDTO.UnitName;
                row.Cells.Add(unitCell);

                row.Tag = infoDTO;
                gasLimitsDataGridView.Rows.Add(row);
            }
        }

        #region IConfigGasTestElementInfoFormView Members

        public List<GasTestElementInfoDTO> StandardGasTestElementInfoDTOList
        {
            get
            {
                foreach (DataGridViewRow row in gasLimitsDataGridView.Rows)
                {
                    GasTestElementInfoDTO dto = row.Tag as GasTestElementInfoDTO;
                    if (dto != null)
                    {
                        dto.ColdLimit = row.Cells[coldLimitColumn.Name].Value as string;
                        dto.HotLimit = row.Cells[hotLimitColumn.Name].Value as string;
                        dto.CSELimit = row.Cells[cseLimitColumn.Name].Value as string;
                        dto.InertCSELimit = row.Cells[inertCSELimitColumn.Name].Value as string;
                        dto.UnitName = row.Cells[unitColumn.Name].Value as string;
                    }
                }
                return gasTestElementInfoDTOList;
            }
            set
            {
                gasTestElementInfoDTOList = value;
                PopulateGasLimitsDataGridView();
            }
        }

        public Site Site
        {
            set { siteDataLabel.Text = value.Name; }
        }

        public void ClearErrorMessage()
        {
            foreach (DataGridViewRow row in gasLimitsDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ErrorText = string.Empty;
                }
                row.ErrorText = string.Empty;
            }
        }

        public void SetColdLimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage)
        {
            SetErrorMessage(dto, errorMessage, coldLimitColumn);
        }

        public void SetHotLimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage)
        {
            SetErrorMessage(dto, errorMessage, hotLimitColumn);
        }

        public void SetCSELimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage)
        {
            SetErrorMessage(dto, errorMessage, cseLimitColumn);
        }

        public void SetInertCSELimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage)
        {
            SetErrorMessage(dto, errorMessage, inertCSELimitColumn);
        }

        public void SetUnitErrorMessage(GasTestElementInfoDTO dto, string errorMessage)
        {
            SetErrorMessage(dto, errorMessage, unitColumn);
        }

        private void SetErrorMessage(GasTestElementInfoDTO dto, string errorMessage, DataGridViewColumn column)
        {
            foreach (DataGridViewRow row in gasLimitsDataGridView.Rows)
            {
                if (row.Tag == dto)
                {
                    row.Cells[column.Name].ErrorText = errorMessage;
                }
            }
        }

        #endregion
    }
}