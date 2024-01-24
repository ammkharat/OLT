using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class PermitAssessmentSectionControl : UserControl
    {
        private int defaultControlHeight;
        private int defaultHeaderPanelHeight;
        private int defaultSectionNameHeight;
        private int sectionScorePercentValue;
        private int sectionWeightPercentValue;
        private int totalSectionScore;
        private int totalSectionWeight;

        public PermitAssessmentSectionControl()
        {
            InitializeComponent();

            Resize += OnResize;
        }

        public string SectionName
        {
            set { sectionNameLabel.Text = value.ToUpper(); }
        }

        public int SectionScore
        {
            get { return totalSectionScore; }
        }

        public int SectionWeightPercent
        {
            get { return sectionWeightPercentValue; }
            set
            {
                sectionWeightPercentValue = value;
                var displayWeight = string.Format("Weight: {0}%", value);
                sectionWeightLabel.Text = displayWeight;
            }
        }

        public int SectionScorePercent
        {
            get { return sectionScorePercentValue; }
            set
            {
                sectionScorePercentValue = value;
                var displayScore = string.Format("Score: {0}%", value);
                sectionScoreLabel.Text = displayScore;
            }
        }

        public bool ReadOnly { get; set; }

        public List<PermitAssessmentAnswer> SectionAnswers
        {
            get
            {
                var sectionAnswers =
                    answersPanel.Controls.OfType<PermitAssessmentAnswerControl>()
                        .Select(answerControl => answerControl.Answer);

                return sectionAnswers.ToList();
            }
            private set
            {
                SuspendLayout();

                RemoveExistingAnswerControls();

                var totalSize = headerPanel.Height;

                if (value.Count > 0)
                {
                    PermitAssessmentAnswerControl previousControl = null;

                    for (var i = 0; i < value.Count; i++)
                    {
                        var answer = value[i];

                        {
                            var singleAnswerControl = new PermitAssessmentAnswerControl
                            {
                                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                                Left = 0,
                                Width = Width,
                                ReadOnly = ReadOnly
                            };

                            if (previousControl == null)
                            {
                                singleAnswerControl.Top = 0;
                            }
                            else
                            {
                                singleAnswerControl.Top = previousControl.Top + previousControl.Height;
                            }

                            singleAnswerControl.Scores = new[] {0, 1, 2, 3, 4, 5};
                            singleAnswerControl.SetAnswer(i + 1, answer);
                            singleAnswerControl.DisplayHeaderLabelRow = (i == 0);
                            singleAnswerControl.DisplayAlternateBackgroundColour = (i%2 > 0);

                            singleAnswerControl.ScoreValueChanged += SingleAnswerControlOnScoreValueChanged;
                            singleAnswerControl.CommentsValueChanged += SingleAnswerControlOnCommentsValueChanged;

                            answersPanel.Controls.Add(singleAnswerControl);

                            totalSize += singleAnswerControl.Height;

                            previousControl = singleAnswerControl;
                        }
                    }
                }

                Size = new Size(Size.Width, totalSize + 5);

                ResumeLayout(false);
            }
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            if (defaultControlHeight > 0 && defaultHeaderPanelHeight > 0 && defaultSectionNameHeight > 0 &&
                !sectionNameLabel.Text.IsNullOrEmpty())
            {
                UpdateHeaderPanelHeight();
            }
        }

        private void SingleAnswerControlOnCommentsValueChanged(object sender, EventArgs eventArgs)
        {
            // TODO: ???
        }

        public event EventHandler SectionScoreValueChanged;

        private void SingleAnswerControlOnScoreValueChanged(object sender, EventArgs e)
        {
            UpdateSectionScore();

            if (null != SectionScoreValueChanged)
            {
                SectionScoreValueChanged(sender, e);
            }
        }

        private void UpdateSectionScore()
        {
            // Section Score % = (Sum weighted answer scores * 100) / Total Configured Weight of all answers * 5

            var answerControls = answersPanel.Controls.OfType<PermitAssessmentAnswerControl>().ToList();

            var sectionScore = answerControls.Sum(answerControl => answerControl.WeightedScore);

            totalSectionScore = sectionScore;

            var sectionTotalPercent = sectionScore.ToPercent(totalSectionWeight);

            foreach (var permitAssessmentAnswerControl in answerControls)
            {
                permitAssessmentAnswerControl.SectionScoredPercentage = sectionTotalPercent;
            }

            SectionScorePercent = sectionTotalPercent;
        }

        private void RemoveExistingAnswerControls()
        {
            var controlsToRemove = new List<Control>();
            foreach (Control control in answersPanel.Controls)
            {
                controlsToRemove.Add(control);
            }
            answersPanel.Controls.Clear();
            foreach (var control in controlsToRemove)
            {
                control.Dispose();
            }
        }

        public void SetSection(string sectionName, int sectionScore,
            List<PermitAssessmentAnswer> sectionAnswers, int totalQuestionnaireWeight)
        {
            var calculatedSectionWeight = sectionAnswers.Sum(answer => answer.ConfiguredWeight)*
                                          PermitAssessmentAnswer.MaxWeight;
            totalSectionWeight = calculatedSectionWeight;

            if (defaultSectionNameHeight == 0)
            {
                defaultSectionNameHeight = sectionNameLabel.Height;
            }

            if (defaultHeaderPanelHeight == 0)
            {
                defaultHeaderPanelHeight = headerPanel.Height;
            }

            SectionName = sectionName;

            SectionWeightPercent = calculatedSectionWeight.ToPercent(totalQuestionnaireWeight);
            SectionScorePercent = sectionScore;
            SectionAnswers = sectionAnswers;

            if (defaultControlHeight == 0)
            {
                defaultControlHeight = Height;
            }

            UpdateHeaderPanelHeight();
        }

        private void UpdateHeaderPanelHeight()
        {
            var heightDelta = sectionNameLabel.Height - defaultSectionNameHeight;

            // Allow grow & shrink
            if (heightDelta != 0)
            {
                headerPanel.Height = defaultHeaderPanelHeight + heightDelta;
                Height = defaultControlHeight + heightDelta;
            }
        }
    }
}