using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ShiftHandoverCustomFieldEntrySetsControl : UserControl
    {
        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;

        private bool isHidden;

        public ShiftHandoverCustomFieldEntrySetsControl()
        {
            InitializeComponent();
        }

        public void SetCustomFields(List<IHasCustomFieldEntries> iHasEntriesList, Dictionary<long, List<CustomField>> idToCustomFieldListMap)
        {
            RemoveExistingEntrySetControls();

            int totalSize = 1;

            if (iHasEntriesList.Count > 0)
            {
                ShiftHandoverCustomFieldEntrySetControl previousControl = null;

                foreach (IHasCustomFieldEntries iHasEntriesItem in iHasEntriesList)
                {
                    if (idToCustomFieldListMap.ContainsKey(iHasEntriesItem.IdValue) && !idToCustomFieldListMap[iHasEntriesItem.IdValue].IsEmpty() && CustomFieldEntry.HasAtLeastOneNonEmptyEntry(iHasEntriesItem.CustomFieldEntries))
                    {
                        ShiftHandoverCustomFieldEntrySetControl singleSetControl = new ShiftHandoverCustomFieldEntrySetControl();

                        singleSetControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        singleSetControl.Left = 0;
                        singleSetControl.Width = Width;

                        if (previousControl == null)
                        {
                            singleSetControl.Top = 0;
                        }
                        else
                        {
                            singleSetControl.Top = previousControl.Top + previousControl.Height;
                        }

                        singleSetControl.SetIHasEntriesItem(iHasEntriesItem, idToCustomFieldListMap[iHasEntriesItem.IdValue]);
                        singleSetControl.CustomFieldEntryClicked += singleSetControl_CustomFieldEntryClicked;
                        Controls.Add(singleSetControl);

                        totalSize += singleSetControl.Height;

                        previousControl = singleSetControl;
                    }
                }
            }

            Size = new Size(Size.Width, totalSize + 2);

            ResumeLayout(false);


        }

        void singleSetControl_CustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            if (CustomFieldEntryClicked != null && !customFieldEntry.IsJustForDisplay)
            {
                CustomFieldEntryClicked(customFieldEntry);
            }
        }

        private void RemoveExistingEntrySetControls()
        {
            List<Control> controlsToRemove = new List<Control>();
            foreach (Control control in Controls)
            {
                controlsToRemove.Add(control);
            }
            Controls.Clear();
            foreach (Control control in controlsToRemove)
            {
                control.Dispose();
            }
        }

        public void FitToContents()
        {
            SuspendLayout();

            int totalSize = 1;

            ShiftHandoverCustomFieldEntrySetControl previousControl = null;

            foreach (Control control in Controls)
            {
                if (control is ShiftHandoverCustomFieldEntrySetControl)
                {
                    ShiftHandoverCustomFieldEntrySetControl singleSetControl = (ShiftHandoverCustomFieldEntrySetControl)control;
                    singleSetControl.FitToContents();

                    if (previousControl == null)
                    {
                        singleSetControl.Top = 0;
                    }
                    else
                    {
                        singleSetControl.Top = previousControl.Top + previousControl.Height;
                    }

                    totalSize += singleSetControl.Height;

                    previousControl = singleSetControl;
                }
            }


            Size = new Size(Size.Width, totalSize + 2);

            ResumeLayout(false);

        }

        public bool IsHidden
        {
            get { return isHidden; }
        }

        public new void Hide()
        {
            isHidden = true;
            base.Hide();
        }

        public new void Show()
        {
            isHidden = false;
            base.Show();
        }
    }
}
