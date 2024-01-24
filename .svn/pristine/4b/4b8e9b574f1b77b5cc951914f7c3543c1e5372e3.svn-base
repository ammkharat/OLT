using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditCustomFieldFormPresenter
    {
        private readonly IAddEditCustomFieldFormView view;
        private readonly IPlantHistorianService plantHistorianService;
        private CustomField editObject;
        private readonly bool isAddMode;
        private readonly ClientBackgroundWorker backgroundWorker = new ClientBackgroundWorker();

        private readonly List<CustomFieldDropDownValue> originalDropDownValues;
        private readonly List<CustomFieldDropDownValue> dropDownValues;

        public AddEditCustomFieldFormPresenter(IAddEditCustomFieldFormView view, CustomField editObject)
        {
            this.view = view;
            this.editObject = editObject;
            isAddMode = (editObject == null);
            plantHistorianService = ClientServiceRegistry.Instance.GetService<IPlantHistorianService>();
            
            dropDownValues = editObject != null && editObject.DropDownValues != null ? new List<CustomFieldDropDownValue>(editObject.DropDownValues) : new List<CustomFieldDropDownValue>();
            originalDropDownValues = new List<CustomFieldDropDownValue>(dropDownValues);
        }

        public CustomField EditObject
        {
            get { return editObject; }
        }

        public void Form_Load(object sender, EventArgs e)
        {
            bool hasPlantHistorian = plantHistorianService.HasPlantHistorian(ClientSession.GetUserContext().Site);

            if (!hasPlantHistorian)
            {
                view.DisablePlantHistorianSection();
            }

            view.Types = CustomFieldType.All;

            if (isAddMode)
            {
                view.RefreshButtonEnabled = false;
                view.PhdLinkType = CustomFieldPhdLinkType.Off;
            }
            else
            {
                view.FieldName = editObject.Name;
                view.PhdLinkType = editObject.PhdLinkType;
                view.Type = editObject.Type;
                view.LessThanValue = editObject.LessThanValue; // Custom Field Changes By : Swapnil Patki
                view.GreaterThanValue = editObject.GreaterThanValue; // Custom Field Changes By : Swapnil Patki
                view.MinRangeValue = editObject.MinValueofRange; // Custom Field Changes By : Swapnil Patki
                view.MaxRangeValue = editObject.MaxValueofRange; // Custom Field Changes By : Swapnil Patki
                view.IsActive = editObject.IsActive; // Custom Field Changes By : Swapnil Patki
                SortAndSetDropDownValuesOnListView();

                if (editObject.TagInfo != null)
                {
                    view.TagInfo = editObject.TagInfo;
                    if (editObject.TagInfo.Deleted)
                    {
                        view.IndicateThatTagInfoIsDeleted();
                        view.RefreshButtonEnabled = false;
                    }
                    else if (hasPlantHistorian)
                    {
                        SetTagValueOnView();
                    }
                }
            }

            EnableOrDisableDropDownButtons();
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            DisplayOrderHelper.ResetDisplayValues(originalDropDownValues);
            view.Close();
        }

        public void OkButton_Click(object sender, EventArgs e)
        {
            if (DataIsValid())
            {
                if(view.TagInfo != null && !CustomFieldType.NumericValue.Equals(view.Type) && view.PhdLinkType == CustomFieldPhdLinkType.Read)
                {
                    bool continueAfterNumericResultWarning = view.ShowWarningForNonNumericTypeAndReturnUserResult();

                    if (!continueAfterNumericResultWarning)
                    {
                        return;
                    }
                }

                if (editObject == null)
                {
                    editObject = new CustomField(null, view.FieldName, 0, view.TagInfo, view.Type, view.PhdLinkType, dropDownValues, view.MinRangeValue, view.MaxRangeValue, view.GreaterThanValue, view.LessThanValue, null,view.IsActive,Clock.Now); // Custom Field Changes By : Swapnil Patki
                }
                else
                {
                    editObject.Name =  view.FieldName;
                    editObject.TagInfo = view.TagInfo;
                    editObject.Type = view.Type;
                    editObject.PhdLinkType = view.PhdLinkType;
                    editObject.MinValueofRange = view.MinRangeValue; // Custom Field Changes By : Swapnil Patki
                    editObject.MaxValueofRange = view.MaxRangeValue; // Custom Field Changes By : Swapnil Patki
                    editObject.GreaterThanValue = view.GreaterThanValue; // Custom Field Changes By : Swapnil Patki
                    editObject.LessThanValue = view.LessThanValue; // Custom Field Changes By : Swapnil Patki
                    editObject.IsActive = view.IsActive; // Custom Field Changes By : Swapnil Patki
                    //editObject.Color = view.Color; // Custom Field Changes By : Swapnil Patki
                    editObject.Date = Clock.Now;
                }

                if (editObject.Type.Equals(CustomFieldType.DropDownList))
                {
                    editObject.DropDownValues = dropDownValues;
                }

                // make sure to clear any old tag info from the Custom Field if it is no longer linked to a Phd Tag for read or write.
                if (editObject.PhdLinkType == CustomFieldPhdLinkType.Off)
                {
                    editObject.TagInfo = null;
                }

                view.Close();
            }
        }

        private bool DataIsValid()
        {
            view.ClearAllErrors();
            bool isValid = true;

            if (view.FieldName.IsNullOrEmptyOrWhitespace() && view.Type != CustomFieldType.BlankSpace)
            {
                view.SetErrorForNoNameProvided();
                isValid = false;
            }

            if (view.Type.Equals(CustomFieldType.DropDownList) && dropDownValues.Count == 0)
            {
                view.SetErrorForDropDownValuesRequired();
                isValid = false;
            }
                      
           
             //Removed Validation by Mukesh to allow Creation of Custom field with type General Text :-RITM0238302
            //if (view.PhdLinkType == CustomFieldPhdLinkType.Write && !view.Type.Equals(CustomFieldType.NumericValue))
            //{
            //    view.SetErrorForWriteMustUseNumericType();
            //    isValid = false;
            //}

            if (view.PhdLinkType != CustomFieldPhdLinkType.Off && view.TagInfo == null)
            {
                view.SetErrorForNoPhdTagSelected();
                isValid = false;
            }

             // Added by Mukesh to validate Tag type with custom field type:-RITM0238302
            if ((view.PhdLinkType != CustomFieldPhdLinkType.Off && view.Type.Equals(CustomFieldType.NumericValue) && plantHistorianService.TagType(view.TagInfo).ToUpper().Contains("STRING")))
            {
                view.SetErrorForStringTagMustUseTextType();
                isValid = false;
            }

            if (view.PhdLinkType == CustomFieldPhdLinkType.Write && view.TagInfo != null && !plantHistorianService.CanWriteTagValue(view.TagInfo))
            {
                view.SetErrorForNotAWriteTag();
                isValid = false;
            }
            if (view.MinRangeValue > view.MaxRangeValue )
            {
                view.SetErrorForCustomFieldRange();
                isValid = false;
            }
            
            return isValid;
        }

        public void TagSearchButton_Click(object sender, EventArgs e)
        {
            DialogResultAndOutput<TagInfo> result = view.ShowTagSelector();
            if (result.Result == DialogResult.OK)
            {
                TagInfo tagInfo = result.Output;
                view.TagInfo = tagInfo;
                SetTagValueOnView();
            }
        }

        private void SetTagValueOnView()
        {
            ReadSelectedTagInfoValue(view.TagInfo);
        }

        private void ReadSelectedTagInfoValue(TagInfo tagInfo)
        {
            CustomFieldTagValueReader tagValueReader = new CustomFieldTagValueReader(backgroundWorker, plantHistorianService, view.DisableControlsForBackgroundWorker, view.EnableControlsForBackgroundWorker, DoneReadingTagInfoValue);
            tagValueReader.Run(new List<TagInfo> { tagInfo });
        }

        public void TagRefreshButton_Click(object sender, EventArgs e)
        {
            SetTagValueOnView();
        }

        public void TagRemoveButton_Click(object sender, EventArgs e)
        {
            view.TagInfo = null;
            view.TagValue = null;
            view.TurnOffDeletedTagIndicators();
        }

        //Chnaged by Mukesh :-RITM0238302 from Dictionary<long, decimal?> to Dictionary<long, object?> 
        private void DoneReadingTagInfoValue(Dictionary<long, object> results)
        {            
            object value = new decimal?();

            // there will only be one value in our case
            foreach (KeyValuePair<long, object> keyValuePair in results)
            {
                value = keyValuePair.Value;
            }
            
            view.TagValue = (value!=null ? value.ToString() : StringResources.Unavailable);
            view.RefreshButtonEnabled = value!=null;//value.HasValue;
            view.TurnOffDeletedTagIndicators();
        }

        public void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        public void CustomFieldType_Changed(object sender, EventArgs e)
        {
            if (view.Type.Equals(CustomFieldType.DropDownList))
            {
                view.DropDownListEditingEnabled = true;
                //Commented By Mukesh for RITM0238302
               // view.PhdLinkType = CustomFieldPhdLinkType.Off;
            }
            else
            {
                view.DropDownListEditingEnabled = false;
            }

            if (view.Type.Equals(CustomFieldType.BlankSpace))
            {
                view.NameEditingEnabled = false;
                view.FieldName = string.Empty;
                view.PhdLinkTypeEditingEnabled = false;
                view.PhdLinkType = CustomFieldPhdLinkType.Off;
            }
            else
            {
                view.NameEditingEnabled = true;
                view.PhdLinkTypeEditingEnabled = true;
            }

            if (view.Type.Equals(CustomFieldType.Heading))
            {
                view.PhdLinkTypeEditingEnabled = false;
                view.PhdLinkType = CustomFieldPhdLinkType.Off;
            }
            else
            {
                view.PhdLinkTypeEditingEnabled = true;
            }
            //Added by Mukesh to show range only for numeric:-RITM0238302
            if(view.Type.Equals(CustomFieldType.NumericValue))
            {
               view. DisableRangeGroupBox = true;
               

            }
            else
            {
                view.DisableRangeGroupBox = false;

            }
           
        }

        public void AddDropDownValueButton_Click(object sender, EventArgs e)
        {
            CustomFieldDropDownValue newValue = view.LaunchAddEditValueForm(null);
            if (newValue != null)
            {
                newValue.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(dropDownValues) + 1;
                dropDownValues.Add(newValue);
                SortAndSetDropDownValuesOnListView();
                view.SelectedDropDownValue = newValue;
            }
        }

        public void EditDropDownValueButton_Click(object sender, EventArgs e)
        {
            CustomFieldDropDownValue selectedValue = view.SelectedDropDownValue;
            if (selectedValue != null)
            {
                view.LaunchAddEditValueForm(selectedValue);
                SortAndSetDropDownValuesOnListView();
                view.SelectedDropDownValue = selectedValue;
            }
        }

        public void DeleteDropDownValueButton_Click(object sender, EventArgs e)
        {
            CustomFieldDropDownValue selectedValue = view.SelectedDropDownValue;
            if (selectedValue != null)
            {
                dropDownValues.Remove(selectedValue);
                SortAndSetDropDownValuesOnListView();
                view.SelectFirstDropDownValue();
            }
        }

        private void SortAndSetDropDownValuesOnListView()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(dropDownValues);
            view.DropDownValues = dropDownValues;
            EnableOrDisableDropDownButtons();
        }

        private void EnableOrDisableDropDownButtons()
        {
            view.EditAndDeleteDropDownButtonsEnabled = view.SelectedDropDownValue != null;
            //view.DisableRangeGroupBox = false; // Custom Field Changes By : Swapnil Patki
        }
    }

}
