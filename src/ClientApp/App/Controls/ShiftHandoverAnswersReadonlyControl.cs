using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ShiftHandoverAnswersReadonlyControl : UserControl
    {
        public ShiftHandoverAnswersReadonlyControl()
        {
            InitializeComponent();
        }

        public List<ShiftHandoverAnswer> Answers
        {
            set
            {
                SuspendLayout();

                RemoveExistingAnswerControls();

                int totalSize = 1;

                if (value.Count > 0)
                {
                    ShiftHandoverAnswerReadonlyControl previousControl = null;

                    for (int i = 0; i < value.Count; i++)
                    {
                        ShiftHandoverAnswer answer = value[i];

                        {
                            ShiftHandoverAnswerReadonlyControl singleAnswerControl = new ShiftHandoverAnswerReadonlyControl();
                            singleAnswerControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                            singleAnswerControl.Left = 0;
                            singleAnswerControl.Width = Width;

                            if (previousControl == null)
                            {
                                singleAnswerControl.Top = 0;
                            }
                            else
                            {
                                singleAnswerControl.Top = previousControl.Top + previousControl.Height;
                            }

                            singleAnswerControl.SetAnswer(i+1, answer);

                            Controls.Add(singleAnswerControl);

                            totalSize += singleAnswerControl.Height;

                            previousControl = singleAnswerControl;
                        }
                    }
                }

                Size = new Size(Size.Width, totalSize + 2);

                ResumeLayout(false);
            }
        }

        private void RemoveExistingAnswerControls()
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

            ShiftHandoverAnswerReadonlyControl previousControl = null;

            foreach (Control control in Controls)
            {
                if (control is ShiftHandoverAnswerReadonlyControl)
                {
                    ShiftHandoverAnswerReadonlyControl singleAnswerControl = (ShiftHandoverAnswerReadonlyControl)control;
                    singleAnswerControl.FitToContents();

                    if (previousControl == null)
                    {
                        singleAnswerControl.Top = 0;
                    }
                    else
                    {
                        singleAnswerControl.Top = previousControl.Top + previousControl.Height;
                    }

                    totalSize += singleAnswerControl.Height;

                    previousControl = singleAnswerControl;
                }
            }


            Size = new Size(Size.Width, totalSize + 2);

            ResumeLayout(false);

        }
    }
}
