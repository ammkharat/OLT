using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditCustomFieldGroupForm : BaseForm, IAddEditCustomFieldGroupView
    {
        private const int COLUMNS_PER_ROW = 3;

        private readonly IAssignmentMultiSelectFormView assignmentMultiSelectForm;        
        private readonly AddEditCustomFieldGroupFormPresenter presenter;
        private bool shouldShowPhTagIndicators = false;

        public AddEditCustomFieldGroupForm(CustomFieldGroup editObject, List<CustomFieldGroup> allGroupsForSite)
        {
            presenter = new AddEditCustomFieldGroupFormPresenter(this, editObject, allGroupsForSite);

            InitializeComponent();
            RegisterEventHandler();
            
            assignmentMultiSelectForm = new AssignmentMultiSelectForm();

            customFieldsBindingSource.DataSource = new List<CustomFieldGridAdapter>();
        }

        private void RegisterEventHandler()
        {
            customFieldsGrid.Enter += customFieldGrid_Enter;
            customFieldsGrid.InitializeRow += customFieldGrid_InitializeRow;
            customFieldsGrid.BeforeCellActivate += customFieldGrid_BeforeCellActivate;

            moveUpButton.Click += moveUpButton_Clicked;
            moveDownButton.Click += moveDownButton_Clicked;
            moveRightButton.Click += moveRightButton_Clicked;
            moveLeftButton.Click += moveLeftButton_Clicked;

            Load += presenter.HandleLoad;
            workAssignmentButton.Click += presenter.SelectWorkAssignments_Click;            
            addButton.Click += presenter.AddFieldButton_Click;
            editButton.Click += presenter.EditFieldButton_Click;
            deleteButton.Click += presenter.DeleteFieldButton_Click;
            saveButton.Click += presenter.SaveButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;
        }

        public bool ShouldShowPhTagIndicators
        {
            set { shouldShowPhTagIndicators = value; }
        }

        private void HighlightPhTagRelatedCells()
        {
            foreach (UltraGridRow row in customFieldsGrid.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    CustomField customField = CustomFieldForCell(cell);
                    if (customField != null && customField.TagInfo != null && customField.PhdLinkType == CustomFieldPhdLinkType.Read)
                    {
                        cell.Appearance.BackColor = phTagLegendControl.ReadColour;
                    }
                    else if (customField != null && customField.TagInfo != null && customField.PhdLinkType == CustomFieldPhdLinkType.Write)
                    {
                        cell.Appearance.BackColor = phTagLegendControl.WriteColour;
                    }
                    else
                    {
                        cell.Appearance.BackColor = Color.White;
                    }
                }
            }
        }

        private static void customFieldGrid_Enter(object sender, EventArgs e)
        {
            UltraGrid grid = (UltraGrid)sender;
            if (grid.ActiveCell == null && grid.Rows.Count > 0)
            {
                UltraGridColumn firstColumn = grid.DisplayLayout.Bands[0].GetFirstVisibleCol(grid.ActiveColScrollRegion, false, true);
                if (firstColumn != null)
                {
                    grid.Rows[0].Cells[firstColumn].Activate();
                }
            }
        }

        private void customFieldGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            foreach (UltraGridCell cell in e.Row.Cells)
            {
                if (cell.Value == null)
                {
                    cell.Appearance.BorderColor = SystemColors.Control;
                    cell.Appearance.BorderColor3DBase = Color.Transparent;
                    cell.Appearance.BackColor = SystemColors.Control;
                }
            }
        }

        private static CustomField CustomFieldForCell(UltraGridCell cell)
        {
            if (cell.Value == null)
            {
                return null;
            }

            CustomFieldGridAdapter adapter = (CustomFieldGridAdapter) cell.Row.ListObject;
            return adapter.GetField(cell.Column.Header.VisiblePosition);
        }

        private static void customFieldGrid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Value == null)
            {
                e.Cancel = true;
            }
        }

        private void moveUpButton_Clicked(object sender, EventArgs e)
        {
            MoveSelectedField(-1, 0);
        }

        private void moveDownButton_Clicked(object sender, EventArgs e)
        {
            MoveSelectedField(1, 0);
        }

        private void moveLeftButton_Clicked(object sender, EventArgs e)
        {
            MoveSelectedField(0, -1);
        }

        private void moveRightButton_Clicked(object sender, EventArgs e)
        {
            MoveSelectedField(0, 1);
        }

        private void MoveSelectedField(int deltaRowPosition, int deltaColumnPosition)
        {
            CustomField selectedField = SelectedField;         
            if (selectedField != null)
            {
                int currentRowIndex;
                int currentColumnIndex;
                GetRowAndColumnIndex(selectedField, out currentRowIndex, out currentColumnIndex);

                int newRowIndex = currentRowIndex + deltaRowPosition;
                int newColumnIndex = currentColumnIndex + deltaColumnPosition;

                if (newRowIndex >= 0 && newRowIndex < customFieldsGrid.Rows.Count &&
                    newColumnIndex >= 0 && newColumnIndex < COLUMNS_PER_ROW)
                {
                    int newLinearIndex = newRowIndex*COLUMNS_PER_ROW + newColumnIndex;
                    
                    List<CustomField> fields = CustomFields;
                    if (newLinearIndex >= 0 && newLinearIndex < fields.Count)
                    {
                        fields.Remove(selectedField);
                        fields.Insert(newLinearIndex, selectedField);

                        CustomFields = fields;
                        SelectedField = selectedField;
                    }
                }
            }
        }

        public CustomField ShowAddEditFieldForm(CustomField editObject)
        {
            AddEditCustomFieldForm addEditCustomFieldForm = new AddEditCustomFieldForm(editObject);
            return addEditCustomFieldForm.ShowDialogAndReturnCustomField(this);
        }

        public CustomField SelectedField
        {
            get
            {
                if (customFieldsGrid.Selected.Cells.Count == 1)
                {
                    UltraGridCell selectedCell = customFieldsGrid.Selected.Cells[0];
                    return CustomFieldForCell(selectedCell);
                }
                return null;
            }
            private set
            {
                int rowIndex;
                int columnIndex;
                GetRowAndColumnIndex(value, out rowIndex, out columnIndex);
                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    customFieldsGrid.Selected.Cells.Clear();
                    customFieldsGrid.Rows[rowIndex].Cells[columnIndex].Selected = true;
                }
            }
        }

        private void GetRowAndColumnIndex(CustomField field, out int rowIndex, out int columnIndex)
        {
            rowIndex = -1;
            columnIndex = -1;

            List<CustomFieldGridAdapter> adapters = (List<CustomFieldGridAdapter>)customFieldsBindingSource.DataSource;
            for (int i = 0; i < adapters.Count; i++)
            {
                CustomFieldGridAdapter adapter = adapters[i];
                for (int j = 0; j < adapter.GetFields().Count; j++)
                {
                    if (adapter.GetField(j) == field)
                    {
                        rowIndex = i;
                        columnIndex = j;
                        return;
                    }
                }
            }
        }

        public string GroupName
        {
            get
            {
                string text = nameTextField.Text;
                if (text == null)
                {
                    return text;
                }
                else
                {
                    return text.Trim();
                }
            }
            set { nameTextField.Text = value; }
        }

        public bool AppliesToLogs
        {
            get { return appliesToLogCheckBox.Checked; }
            set { appliesToLogCheckBox.Checked = value; }
        }

        public bool AppliesToSummaryLogs
        {
            get { return appliesToSummaryLogCheckBox.Checked; }
            set { appliesToSummaryLogCheckBox.Checked = value; }
        }

        public bool AppliesToDailyDirectives
        {
            get { return appliesToDailyDirectiveCheckBox.Checked; }
            set { appliesToDailyDirectiveCheckBox.Checked = value; }
        }


        public bool AppliesToActionItems
        {
            get { return appliesToActionItemsCheckBox.Checked; }
            set { appliesToActionItemsCheckBox.Checked = value; }
        }


        public DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments)
        {
            assignmentMultiSelectForm.ShowMultiSelectDialog(selectedAssignments);            

            DialogResultAndOutput<IList<WorkAssignment>> result = 
                new DialogResultAndOutput<IList<WorkAssignment>>(
                    assignmentMultiSelectForm.DialogResult, assignmentMultiSelectForm.SelectedAssignments);

            return result;                        
        }

        public List<WorkAssignment> WorkAssignments
        {
            get { return workAssignmentListBox.DataSource as List<WorkAssignment>; }
            set { workAssignmentListBox.DataSource = value;}
        }
      
        public List<CustomField> CustomFields
        {
            get
            {
                List<CustomFieldGridAdapter> adapters = (List<CustomFieldGridAdapter>)customFieldsBindingSource.DataSource;
                List<CustomField> fields = new List<CustomField>();
                foreach (CustomFieldGridAdapter adapter in adapters)
                {
                    fields.AddRange(adapter.GetNonNullFields());
                }
                return fields;
            }
            set
            {
                List<CustomFieldGridAdapter> adapters = new List<CustomFieldGridAdapter>();
                for (int start = 0; start < value.Count; start += COLUMNS_PER_ROW)
                {
                    int index0 = start;
                    int index1 = start + 1;
                    int index2 = start + 2;

                    CustomField field1 = index0 >= 0 && index0 < value.Count ? value[index0] : null;
                    CustomField field2 = index1 >= 0 && index1 < value.Count ? value[index1] : null;
                    CustomField field3 = index2 >= 0 && index2 < value.Count ? value[index2] : null;

                    adapters.Add(new CustomFieldGridAdapter(field1, field2, field3));
                }

                customFieldsBindingSource.DataSource = adapters;
                if (shouldShowPhTagIndicators)
                {
                    HighlightPhTagRelatedCells();
                    phTagLegendControl.Visible = true;
                }
                else
                {
                    phTagLegendControl.Visible = false;
                }

                SelectFirstCell();
            }
        }

        private void SelectFirstCell()
        {
            if (customFieldsGrid.Rows.Count > 0)
            {
                customFieldsGrid.Rows[0].Cells[0].Selected = true;
            }
        }

        public void AddField(CustomField field)
        {
            List<CustomField> fields = CustomFields; 
            fields.Add(field);
            CustomFields = fields;
            SelectedField = field;
        }

        public void RemoveField(CustomField field)
        {
            List<CustomField> fields = CustomFields;
            fields.Remove(field);
            CustomFields = fields;
            SelectFirstCell();
        }

        public void RefreshFields()
        {
            customFieldsBindingSource.ResetBindings(false);
            if (shouldShowPhTagIndicators)
            {
                HighlightPhTagRelatedCells();    
            }            
        }

        public void HideDirectiveLogsOption()
        {
            appliesToDailyDirectiveCheckBox.Visible = false;
        }

        public void ClearAllErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorForNoAssociatedWorkAssignments()
        {
            errorProvider.SetError(workAssignmentListBox, StringResources.AtLeastOneWorkAssignmentMustBeSelected);
        }

        public void SetErrorForNoNameProvided()
        {
            errorProvider.SetError(nameTextField, StringResources.NameEmptyError);
        }

        public void SetErrorForDuplicateName()
        {
            errorProvider.SetError(nameTextField, StringResources.NameNotUniqueError);
        }

        public void SetErrorForDuplicateFieldName()
        {
            errorProvider.SetError(customFieldsGrid, StringResources.DuplicateCustomFieldName);
        }

        public void SetErrorForAtLeastOneFieldIsRequired()
        {
            errorProvider.SetError(customFieldsGrid, StringResources.AtLeastOneCustomFieldRequired);
        }

        public void SetErrorForAtLeastOneApplicationAreaIsRequired()
        {
            Control controlToPutErrorIconBeside = null;
            if (appliesToDailyDirectiveCheckBox.Visible)
            {
                controlToPutErrorIconBeside = appliesToDailyDirectiveCheckBox;
            }
            else if(appliesToActionItemsCheckBox.Visible)                 //ayman custom fields DMND0010030
            {
                controlToPutErrorIconBeside = appliesToActionItemsCheckBox;
            }
            else
            {
                controlToPutErrorIconBeside = appliesToSummaryLogCheckBox;
            }

            errorProvider.SetError(controlToPutErrorIconBeside, StringResources.CustomFieldsMustApplyToAtLeastOneArea);
        }

        public void DisableMovingAndSuggestSaving()
        {
            saveBlankFieldsLabel.Visible = true;
            moveDownButton.Enabled = false;
            moveUpButton.Enabled = false;
            moveRightButton.Enabled = false;
            moveLeftButton.Enabled = false;
        }

        public void SetDialogResultOk()
        {
            DialogResult  = DialogResult.OK;
        }

        public DialogResultAndOutput<CustomFieldGroup> ShowDialogAndReturnEditObject(Form parent)
        {
            DialogResult dialogResult = ShowDialog(parent);
            return new DialogResultAndOutput<CustomFieldGroup>(dialogResult, presenter.EditObject);
        }

        private class CustomFieldGridAdapter
        {
            private readonly List<CustomField> fields = new List<CustomField>();

            public CustomFieldGridAdapter(CustomField field0, CustomField field1, CustomField field2)
            {
                fields.Add(field0);
                fields.Add(field1);
                fields.Add(field2);
            }

// bound to grid
// ReSharper disable UnusedMember.Local
            public string Column0
// ReSharper restore UnusedMember.Local
            {
                get { return GetFieldName(0); }
            }

// bound to grid
// ReSharper disable UnusedMember.Local
            public string Column1
// ReSharper restore UnusedMember.Local
            {
                get { return GetFieldName(1); }
            }

// bound to grid
// ReSharper disable UnusedMember.Local
            public string Column2
// ReSharper restore UnusedMember.Local
            {
                get { return GetFieldName(2); }
            }

            private string GetFieldName(int index)
            {
                CustomField field = GetField(index);
                if (field != null)
                {
                    return field.Name;
                }
                else
                {
                    return null;
                }
            }

            public IEnumerable<CustomField> GetNonNullFields()
            {
                return fields.FindAll(obj => obj != null);
            }

            public List<CustomField> GetFields()
            {
                return fields;
            }

            public CustomField GetField(int index)
            {
                return fields[index];
            }
        }
    }
}
