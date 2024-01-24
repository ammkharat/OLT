using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class PermitAssessmentAnswerControl : UserControl
    {
        private PermitAssessmentAnswer answer;

        public PermitAssessmentAnswerControl()
        {
            InitializeComponent();

            scoreComboBoxEdit.SelectedValueChanged += ScoreComboBoxEditOnSelectedValueChanged;
            commentsTextEditor.TextChanged += CommentsTextEditorOnTextChanged;
        }

        public bool ReadOnly { get; set; }

        public int WeightedScore
        {
            get { return answer.WeightedScore; }
        }

        public decimal SectionScoredPercentage
        {
            set { answer.SectionScoredPercentage = value; }
        }

        public bool DisplayAlternateBackgroundColour
        {
            set
            {
                var backColor = value ? Color.LightGray : SystemColors.Control;

                BackColor = backColor;
            }
        }

        public bool DisplayHeaderLabelRow
        {
            set
            {
                SuspendLayout();

                var totalHeight = Height;

                headerLabelPanel.Visible = value;

                if (value == false)
                {
                    totalHeight = mainPanel.Height;
                    mainPanel.Top = 0;
                }

                Size = new Size(Size.Width, totalHeight);

                ResumeLayout(false);
            }
        }

        public int[] Scores
        {
            set
            {
                scoreComboBoxEdit.Properties.Items.Clear();
                scoreComboBoxEdit.Properties.Items.AddRange(value);
            }
        }

        public PermitAssessmentAnswer Answer
        {
            get { return answer; }
        }

        public event EventHandler ScoreValueChanged;
        public event EventHandler CommentsValueChanged;

        private void ScoreComboBoxEditOnSelectedValueChanged(object sender, EventArgs e)
        {
            var score = (int) scoreComboBoxEdit.EditValue;

            const int translucentAlpha = 128;

            var redTranslucentArgb = Color.FromArgb(translucentAlpha, Color.PaleVioletRed.R, Color.PaleVioletRed.G,
                Color.PaleVioletRed.B);

            var greenTranslucentArgb = Color.FromArgb(translucentAlpha, Color.LightGreen.R, Color.LightGreen.G,
                Color.LightGreen.B);

            var yellowTranslucentArgb = Color.FromArgb(translucentAlpha, Color.PaleGoldenrod.R, Color.PaleGoldenrod.G,
                Color.PaleGoldenrod.B);

            var translucentColor = (score == 0 || score == 1)
                ? redTranslucentArgb
                : (score == 2 || score == 3) ? yellowTranslucentArgb : greenTranslucentArgb;

            scoreComboBoxEdit.BackColor = translucentColor;

            answer.Score = score;

            if (null != ScoreValueChanged)
            {
                ScoreValueChanged(sender, e);
            }
        }

        private void CommentsTextEditorOnTextChanged(object sender, EventArgs e)
        {
            answer.Comments = commentsTextEditor.Text.Trim();

            if (null != CommentsValueChanged)
            {
                CommentsValueChanged(sender, e);
            }
        }

        public void SetAnswer(int answerNumber, PermitAssessmentAnswer answer)
        {
            this.answer = answer;

            answerNumberLabel.Text = string.Format("{0}.", answerNumber);

            var defaultQuestionHeight = answerQuestionLabel.Height;
            answerQuestionLabel.Text = answer.QuestionText;

            scoreComboBoxEdit.SelectedItem = answer.Score;

            weightTextEdit.EditValue = answer.ConfiguredWeight;

            commentsTextEditor.Text = answer.Comments;

            scoreComboBoxEdit.Properties.ReadOnly = ReadOnly;
            commentsTextEditor.ReadOnly = ReadOnly;

            var heightDelta = answerQuestionLabel.Height - defaultQuestionHeight;
            mainPanel.Height = mainPanel.Height += heightDelta;
            this.Height = this.Height += heightDelta;
        }
    }
}