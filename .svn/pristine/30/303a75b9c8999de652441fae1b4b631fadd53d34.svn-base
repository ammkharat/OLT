using System;
using System.ComponentModel;
using System.Windows.Forms;
using log4net;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltTableLayoutPanel : TableLayoutPanel
    {
        private Control controlThatShouldFillEmptySpace;

        public OltTableLayoutPanel()
        {
            Disposed += This_Disposed;
            ParentChanged += This_ParentChanged;
        }

        private void This_Disposed(object sender, EventArgs e)
        {
            Disposed -= This_Disposed;
            ParentChanged -= This_ParentChanged;

            controlThatShouldFillEmptySpace = null;
        }

        private void This_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Layout += Parent_Layout;
            }
        }

        private void Parent_Layout(object sender, LayoutEventArgs e)
        {
            if (e.AffectedControl == Parent)
            {
                FillUpAnyExtraVerticalSpace();
            }
        }

        public void FillUpAnyExtraVerticalSpace()
        {
            try
            {
                if (Parent != null && ControlThatShouldFillEmptySpace != null &&
                    IsSetUpToFill(ControlThatShouldFillEmptySpace))
                {
                    int parentHeight = GetClientSizeHeight(Parent);
                    
                    int tableLayoutPanelHeight = GetHeight(this);
                    tableLayoutPanelHeight += PositiveOrZero(Location.Y);

                    int fillingControlHeight = GetHeight(ControlThatShouldFillEmptySpace);
                    fillingControlHeight += PositiveOrZero(Padding.Top);
                    fillingControlHeight += PositiveOrZero(Padding.Bottom);

                    if (parentHeight > 0 &&
                        tableLayoutPanelHeight > 0 &&
                        fillingControlHeight > 0 &&
                        tableLayoutPanelHeight > fillingControlHeight)
                    {
                        int availableHeightForCommentsContainer =
                            parentHeight -
                            (tableLayoutPanelHeight - fillingControlHeight);


                        int minimumHeight = ControlThatShouldFillEmptySpace.MinimumSize.Height;
                        if (availableHeightForCommentsContainer < minimumHeight)
                        {
                            UpdateFillHeight(minimumHeight);
                        }
                        else if (availableHeightForCommentsContainer > minimumHeight)
                        {
                            UpdateFillHeight(availableHeightForCommentsContainer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(typeof(OltTableLayoutPanel));
                logger.Error("Error resizing log form layout to make comments text box fill up space.", ex);
            }
        }

        private bool IsSetUpToFill(Control control)
        {
            try
            {
                int rowIndex = GetRow(control);
                if (rowIndex >= 0 && rowIndex < RowStyles.Count)
                {
                    RowStyle rowStyle = RowStyles[rowIndex];
                    return rowStyle.SizeType == SizeType.AutoSize;
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(typeof(OltTableLayoutPanel));
                logger.Error("Error checking to see if control is set up to fill space.", ex);
            }
            return false;
        }

        private void UpdateFillHeight(int height)
        {
            if (ControlThatShouldFillEmptySpace != null)
            {
                SuspendLayout();
                ControlThatShouldFillEmptySpace.Height = height;
                ResumeLayout(false);
                PerformLayout();
            }
        }

        private static int GetClientSizeHeight(Control control)
        {
            int height = control.ClientSize.Height;
            height -= PositiveOrZero(control.Padding.Top);
            height -= PositiveOrZero(control.Padding.Bottom);
            return height;
        }

        private static int GetHeight(Control control)
        {
            int height = control.Height;
            height += PositiveOrZero(control.Margin.Top);
            height += PositiveOrZero(control.Margin.Bottom);
            return height;
        }

        private static int PositiveOrZero(int number)
        {
            if (number > 0)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Control ControlThatShouldFillEmptySpace
        {
            get { return controlThatShouldFillEmptySpace; }
            set { controlThatShouldFillEmptySpace = value; }
        }
    }
}
