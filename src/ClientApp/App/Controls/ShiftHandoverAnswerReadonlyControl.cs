using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ShiftHandoverAnswerReadonlyControl : UserControl
    {
        private const int MIN_HEIGHT = 40;

        public ShiftHandoverAnswerReadonlyControl()
        {
            InitializeComponent();
            yesRadioButton.AutoCheck = false;
            noRadioButton.AutoCheck = false;
        }

        private ShiftHandoverAnswer Answer
        {
            set
            {
                questionTextLabel.Text = value.QuestionText;
                if (value.Answer)
                {
                    yesRadioButton.Checked = true;
                }
                else
                {
                    noRadioButton.Checked = true;
                }
                commentsTextBox.Text = value.Comments;
                FitToContents();
            }
        }

        public void SetAnswer(int answerNumber, ShiftHandoverAnswer newAnswer)
        {
            questionNumberLabel.Text = answerNumber + ".";
            Answer = newAnswer;
        }

        public void FitToContents()
        {
            if (commentsTextBox.Visible)
            {
                SuspendLayout();

                Size proposedSize = new Size(commentsTextBox.Width, int.MaxValue);
                Size newSize = TextRenderer.MeasureText(
                    commentsTextBox.Text, 
                    commentsTextBox.Font, 
                    proposedSize, 
                    TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);

                int chromeHeight = commentsTextBox.Height - commentsTextBox.ClientSize.Height;
                int newHeight = newSize.Height + chromeHeight + commentsTextBox.Margin.Vertical;
                if (newHeight < MIN_HEIGHT)
                {
                    newHeight = MIN_HEIGHT;
                }

                int beforeHeight = commentsTextBox.Height;
                commentsTextBox.Height = newHeight;
                int deltaHeight = newHeight - beforeHeight;

                Height = Height + deltaHeight;

                ResumeLayout(false);
            }
        }
    }
}
