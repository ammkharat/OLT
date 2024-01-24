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
    public partial class PermitAssessmentControl : UserControl
    {
        private PermitAssessment permitAssessment;

        private int totalScoreValue;

        public PermitAssessmentControl()
        {
            InitializeComponent();

            commentsMemoEdit.TextChanged += CommentsMemoEditOnTextChanged;
        }

        public int TotalScore
        {
            get { return totalScoreValue; }
            set
            {
                totalScoreValue = value;
                var displayScore = string.Format("Total Score: {0}%", value);
                totalScoreLabel.Text = displayScore;
            }
        }

        public bool ReadOnly { get; set; }

        public PermitAssessment PermitAssessment
        {
            get
            {
                if (permitAssessment == null || sectionsPanel == null || sectionsPanel.Controls.IsNullOrEmpty())
                    return permitAssessment;

                var updatedAnswers = new List<PermitAssessmentAnswer>();

                foreach (var section in sectionsPanel.Controls.OfType<PermitAssessmentSectionControl>())
                {
                    updatedAnswers.AddRange(section.SectionAnswers);
                }

                permitAssessment.RefreshAnswersAndTotals(updatedAnswers);

                return permitAssessment;
            }
            set
            {
                permitAssessment = value;

                if (permitAssessment == null) return;

                SuspendLayout();

                RemoveExistingSectionControls();

                var totalSize = 0;

                var sectionIds = permitAssessment.PermitAssessmentSectionIds;

                if (sectionIds.Count > 0)
                {
                    PermitAssessmentSectionControl previousControl = null;

                    var totalConfiguredWeight = permitAssessment.Answers.Sum(answer => answer.ConfiguredWeight)*
                                                PermitAssessmentAnswer.MaxWeight;

                    for (var i = 0; i < sectionIds.Count; i++)
                    {
                        var sectionId = sectionIds[i];

                        var sectionAnswers = permitAssessment.GetAnswersBySectionId(sectionId);

                        if (sectionAnswers == null || sectionAnswers.Count == 0) continue;

                        var sectionName = sectionAnswers[0].SectionName;

                        var sectionScore = (int) Math.Truncate(sectionAnswers[0].SectionScoredPercentage);

                        {
                            var singleSectionControl = new PermitAssessmentSectionControl
                            {
                                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                                Left = 0,
                                Width = Width,
                                ReadOnly = ReadOnly
                            };

                            if (previousControl == null)
                            {
                                singleSectionControl.Top = 0;
                            }
                            else
                            {
                                singleSectionControl.Top = previousControl.Top + previousControl.Height;
                            }

                            singleSectionControl.SetSection(sectionName, sectionScore, sectionAnswers,
                                totalConfiguredWeight);

                            singleSectionControl.SectionScoreValueChanged +=
                                SingleSectionControlOnSectionScoreValueChanged;

                            sectionsPanel.Controls.Add(singleSectionControl);

                            totalSize += singleSectionControl.Height;

                            previousControl = singleSectionControl;
                        }
                    }
                }

                sectionsPanel.Height = totalSize;

                totalSize += footerPanel.Height;
                Size = new Size(Size.Width, totalSize + 2);

                UpdateTotalScore();

                commentsMemoEdit.Text = value.OverallFeedback;
                commentsMemoEdit.Properties.ReadOnly = ReadOnly;

                ResumeLayout(false);
                PerformLayout();
            }
        }

        private void CommentsMemoEditOnTextChanged(object sender, EventArgs eventArgs)
        {
            permitAssessment.OverallFeedback = commentsMemoEdit.Text.Trim();
        }

        private void SingleSectionControlOnSectionScoreValueChanged(object sender, EventArgs eventArgs)
        {
            UpdateTotalScore();
        }

        private void UpdateTotalScore()
        {
            // Total Score % = (Sum weighted section scores * 100) / Total Configured Weight of all answers * 5

            var totalConfiguredWeight = permitAssessment.Answers.Sum(answer => answer.ConfiguredWeight)*
                                        PermitAssessmentAnswer.MaxWeight;

            var totalWeightedScore = permitAssessment.Answers.Sum(answer => answer.WeightedScore);
            var totalScoredPercent = totalWeightedScore.ToPercent(totalConfiguredWeight);

            var totalAnswerScore = permitAssessment.Answers.Sum(answer => answer.Score);
            var totalAnswersWeightedScore = permitAssessment.Answers.Sum(answer => answer.WeightedScore);

            permitAssessment.TotalAnswerScore = totalAnswerScore;
            permitAssessment.TotalAnswerWeightedScore = totalAnswersWeightedScore;
            permitAssessment.TotalScoredPercentage = totalScoredPercent;

            TotalScore = totalScoredPercent;
        }

        private void RemoveExistingSectionControls()
        {
            var controlsToRemove = sectionsPanel.Controls.Cast<Control>().ToList();
            sectionsPanel.Controls.Clear();

            foreach (var control in controlsToRemove)
            {
                sectionsPanel.Height -= control.Height;
                Height -= control.Height;

                control.Dispose();
            }
        }
    }
}