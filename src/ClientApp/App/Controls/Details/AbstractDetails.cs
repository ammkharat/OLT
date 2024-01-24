using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public class AbstractDetails : UserControl
    {
        public event Action ToggleShow;
        public event Action SaveGridLayout;        
            
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ToolStripButton toggleDateRangeButton = ToggleDateRangeButton;

            if (toggleDateRangeButton != null)
            {
                toggleDateRangeButton.Click += toggleShowButton_Click;
            }

            ToolStripButton saveLayoutButton = SaveGridLayoutButton;

            if (saveLayoutButton != null)
            {
                saveLayoutButton.Click += HandleSaveGridLayoutButtonClick;
            }
        }
        
        public virtual ToolStripButton SaveGridLayoutButton
        {
            get { return null; }
        }

        public bool EnableLayoutIsActiveIndicator
        {
            set
            {
                ToolStripButton saveLayoutButton = SaveGridLayoutButton;
                if (saveLayoutButton != null)
                {
                    saveLayoutButton.BackColor = value ? SystemColors.ScrollBar : SystemColors.Control;
                }
            }
        }

        public new virtual void Hide()
        {
            Panel detailsPanel = Details;
            if (detailsPanel != null)
                detailsPanel.Hide();
        }

        public new void Show()
        {
            Panel detailsPanel = Details;
            if (detailsPanel != null)
                detailsPanel.Show();
        }

        private void toggleShowButton_Click(object sender, EventArgs e)
        {
            if (ToggleShow != null)
            {
                ToggleShow();
            }
        }

        private void HandleSaveGridLayoutButtonClick(object sender, EventArgs e)
        {
            if (SaveGridLayout != null)
            {
                SaveGridLayout();
            }
        }

        public WidgetAppearance ShowButtonAppearance
        {
            get { return ToggleDateRangeButton != null ? (WidgetAppearance) ToggleDateRangeButton.Tag : null; }
            set
            {
                // This null check is for the designer
                if (ToggleDateRangeButton != null && value != null)
                {
                    ToggleDateRangeButton.Text = value.ShortText;
                    ToggleDateRangeButton.Image = value.Icon;
                    ToggleDateRangeButton.ToolTipText = value.LongText;
                    ToggleDateRangeButton.Tag = value;
                }
            }
        }

        protected virtual ToolStripButton ToggleDateRangeButton
        {
            get { return null; }
        }

        //HACK :trg - this is done so that the designer can still be used to edit the details control.
        //      a bug in VS won't allow you to visually edit a control that inherits from an abstract class
        //      using a virtual property and throwing an exception if dev forgets to override property should catch most,  
        //      Sucks big time, but pros outway cons to me. convince me otherwise or find an alternative. 
        //      discuss.
        //
        //      THIS MUST BE OVERRIDEN BY ANYONE INHERITING ABSTRACTDETAILS!!!!!!!!!!!!!!!!!!!!!!!!!
        protected virtual Panel Details { get{ throw new NotImplementedException();}}

    }
}