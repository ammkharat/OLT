﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class ExcursionResponseDetails : AbstractDetails, IExcursionResponseDetails
    {
        private OpmExcursion excursion;


        public ExcursionResponseDetails()
        {
            InitializeComponent();

            expireButton.Visible = false;
            markAsReadButton.Visible = false;
            cloneButton.Visible = false;
            deleteButton.Visible = false;
            printButton.Visible = false;
            printPreviewButton.Visible = false;
            editButton.Text = "Respond";
            editButton.Click += HandleEditButtonClick;
            printButton.Click += HandlePrint;
            printPreviewButton.Click += HandlePrintPreviewButtonClicked;
            // disabled/invisible feature for now
            envelopeCommentsHistoryButton.Visible = false;
            envelopeCommentsHistoryButton.Click += EnvelopeCommentsHistoryButtonOnClick;
            historyButton.Click += HandleHistoryButtonClick;
            detailsPanel.Layout += HandleDetailsPanelLayout;
            exportAllButton.Click += HandleExportButtonClick;


            expandExursionResponseLink.Click += ExpandExursionResponseLinkOnClick;
            expandExcursionConsequencesLink.Click += ExpandExcursionConsequencesLinkOnClick;
            expandExcursionCorrectiveActionsLink.Click += ExpandExcursionCorrectiveActionsLinkOnClick;
            expandOltToeDefinitionCommentLink.Click += ExpandOltToeDefinitionCommentLinkOnClick;
            expandExcursionCausesLink.Click += ExpandExcursionCausesLinkOnClick;
            expandEngineeringCommentsLink.Click += ExpandEngineeringCommentsLinkOnClick;
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }


        public bool EnvelopeCommentsHistoryEnabled
        {
            set
            {
                envelopeCommentsHistoryButton.Enabled = value;
                envelopeCommentsHistoryButton.Enabled = value;
            }
        }

        public bool PrintAndPrintPreviewEnabled
        {
            set
            {
                printButton.Enabled = value;
                printPreviewButton.Enabled = value;
            }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveLayoutToolStripButton; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public bool ExpireEnabled
        {
            set { expireButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }


        public bool PrintButtonVisible
        {
            set { printButton.Visible = value; }
        }

        public event EventHandler ExportAll;
        public event EventHandler Delete;
        public event EventHandler Edit;

        public event EventHandler ViewEditHistory;
        public event EventHandler ViewEnvelopeCommentsHistory;

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, EventArgs.Empty);
            }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public void SetDetails(OpmExcursion selectedExcursion)
        {
            excursion = selectedExcursion;
            currentTagValueLabelValue.Text = string.Empty;
            if (excursion == null)
            {
                excursionToeTypeLabelValue.Text = string.Empty;
                excursionToeNameLabelValue.Text = string.Empty;
                excursionFunctionalLocationLabelValue.Text = string.Empty;
                excursionHistorieanTagLabelValue.Text = string.Empty;
                excursionResponseLastModifiedDateTimeLabelValue.Text = string.Empty;
                excursionResponseResponderFullNameLabelValue.Text = string.Empty;
                excursionResponseCommentsOltTextBox.Text = string.Empty;
                excursionLastUpdatedDateTimeLabelValue.Text = string.Empty;
                excursionEndDateTimeLabelValue.Text = string.Empty;
                excursionStartDateTimeLabelValue.Text = string.Empty;
                excursionDurationLabelValue.Text = string.Empty;
                excursionStatusLabelValue.Text = string.Empty;
                excursionUnitOfMeasureLabelValue.Text = string.Empty;
                excursionToeLimitValueLabelValue.Text = string.Empty;
                excursionAverageLabelValue.Text = string.Empty;
                excursionPeakLabelValue.Text = string.Empty;
                excursionIlpNumberLabelValue.Text = string.Empty;
                excursionReasonCodeLabelValue.Text = string.Empty;
                excursionEngineerCommentsOltTextBox.Text = string.Empty;
                toeDefinitionToeVersionPublishDateValueLabel.Text = string.Empty;
                toeDefinitionUnitOfMeasureValueLabel.Text = string.Empty;
                toeDefinitionCausesDescriptionOltTextBox.Text = string.Empty;
                toeDefinitionCommentLastUpdatedDateTimeValueLabel.Text = string.Empty;
                toeDefinitionCommentOltOperatorLastUpdatedByValueLabel.Text = string.Empty;
                toeDefinitionCommentOltOperatorCommentsOltTextBox.Text = string.Empty;
                toeDefinitionToeLimitValueValueLabel.Text = string.Empty;
                toeDefinitionFunctionalLocationValueLabel.Text = string.Empty;
                toeDefinitionHistorianTagValueLabel.Text = string.Empty;
                toeDefinitionToeTypeValueLabel.Text = string.Empty;
                toeDefinitionToeNameValueLabel.Text = string.Empty;
                toeDefinitionCorrectiveActionOltTextBox.Text = string.Empty;
                toeDefinitionConsequencesDescriptionOltTextBox.Text = string.Empty;
                documentLinksControl.DataSource = new List<DocumentLink>();
            }
            else
            {
                excursionToeTypeLabelValue.Text = excursion.ToeType.GetName();
                excursionToeNameLabelValue.Text = excursion.ToeName;
                excursionFunctionalLocationLabelValue.Text = excursion.FunctionalLocation;
                excursionHistorieanTagLabelValue.Text = excursion.HistorianTag;

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM

                Asset.Text = excursion.OpmExcursionResponse.Asset; // Vibhor
                Code.Text = excursion.OpmExcursionResponse.Code; // Vibhor

                if (excursion.OpmExcursionResponse.HasResponse)
                {
                    excursionResponseLastModifiedDateTimeLabelValue.Text =
                        excursion.OpmExcursionResponse.LastModifiedDateTime.ToShortDateAndTimeString();
                    excursionResponseResponderFullNameLabelValue.Text =
                        excursion.OpmExcursionResponse.LastModifiedBy.FullNameWithUserName;
                    excursionResponseCommentsOltTextBox.Text = excursion.OpmExcursionResponse.Response;

                   
                }
                else
                {
                    excursionResponseLastModifiedDateTimeLabelValue.Text = string.Empty;
                    excursionResponseResponderFullNameLabelValue.Text = string.Empty;
                    excursionResponseCommentsOltTextBox.Text = string.Empty;
                }
                excursionLastUpdatedDateTimeLabelValue.Text = excursion.LastUpdatedDateTime.ToShortDateAndTimeString();
                excursionEndDateTimeLabelValue.Text = excursion.EndDateTime.ToShortDateAndTimeStringOrEmptyString();
                excursionStartDateTimeLabelValue.Text = excursion.StartDateTime.ToShortDateAndTimeString();
                excursionDurationLabelValue.Text = excursion.Duration.NullableToString();
                excursionStatusLabelValue.Text = excursion.Status.GetName();
                excursionUnitOfMeasureLabelValue.Text = excursion.UnitOfMeasure;
                excursionToeLimitValueLabelValue.Text = excursion.ToeLimitValue.FormatToThreePlaces();
                excursionAverageLabelValue.Text = excursion.Average.FormatToThreePlaces();
                excursionPeakLabelValue.Text = excursion.Peak.FormatToThreePlaces();
                excursionIlpNumberLabelValue.Text = excursion.IlpNumber.NullableToString();
                excursionReasonCodeLabelValue.Text = excursion.ReasonCode;
                excursionEngineerCommentsOltTextBox.Text = excursion.EngineerComments;

                if (excursion.OpmToeDefinition != null)
                {
                    toeDefinitionToeVersionPublishDateValueLabel.Text =
                        excursion.OpmToeDefinition.ToeVersionPublishDate.ToShortDateAndTimeString();
                    toeDefinitionUnitOfMeasureValueLabel.Text = excursion.OpmToeDefinition.UnitOfMeasure;
                    toeDefinitionCausesDescriptionOltTextBox.Text = excursion.OpmToeDefinition.CausesDescription;


                    var opmToeDefinitionComment = excursion.OpmToeDefinition.OpmToeDefinitionComment;
                    if (opmToeDefinitionComment.Comment.IsNullOrEmptyOrWhitespace())
                    {
                        toeDefinitionCommentLastUpdatedDateTimeValueLabel.Text = string.Empty;
                        toeDefinitionCommentOltOperatorLastUpdatedByValueLabel.Text = string.Empty;
                        toeDefinitionCommentOltOperatorCommentsOltTextBox.Text = string.Empty;
                    }
                    else
                    {
                        toeDefinitionCommentLastUpdatedDateTimeValueLabel.Text =
                            opmToeDefinitionComment.LastModifiedDateTime.ToShortDateAndTimeString();
                        toeDefinitionCommentOltOperatorLastUpdatedByValueLabel.Text =
                            opmToeDefinitionComment.LastModifiedBy.FullNameWithUserName;
                        toeDefinitionCommentOltOperatorCommentsOltTextBox.Text = opmToeDefinitionComment.Comment;
                    }
                    toeDefinitionToeLimitValueValueLabel.Text = excursion.OpmToeDefinition.LimitValue.FormatToThreePlaces();
                    toeDefinitionFunctionalLocationValueLabel.Text = excursion.OpmToeDefinition.FunctionalLocation;
                    toeDefinitionHistorianTagValueLabel.Text = excursion.OpmToeDefinition.HistorianTag;
                    toeDefinitionToeTypeValueLabel.Text = excursion.OpmToeDefinition.ToeType.GetName();
                    toeDefinitionToeNameValueLabel.Text = excursion.OpmToeDefinition.ToeName;
                    toeDefinitionCorrectiveActionOltTextBox.Text =
                        excursion.OpmToeDefinition.CorrectiveActionDescription;
                    toeDefinitionConsequencesDescriptionOltTextBox.Text =
                        excursion.OpmToeDefinition.ConsequencesDescription;
                }
                else
                {
                    toeDefinitionToeNameValueLabel.Text = "Not available from OPM";
                    toeDefinitionCommentLastUpdatedDateTimeValueLabel.Text = string.Empty;
                    toeDefinitionCommentOltOperatorLastUpdatedByValueLabel.Text = string.Empty;
                    toeDefinitionCommentOltOperatorCommentsOltTextBox.Text = string.Empty;
                    toeDefinitionToeLimitValueValueLabel.Text = string.Empty;
                    toeDefinitionFunctionalLocationValueLabel.Text = string.Empty;
                    toeDefinitionHistorianTagValueLabel.Text = string.Empty;
                    toeDefinitionToeTypeValueLabel.Text = string.Empty;
                    toeDefinitionCorrectiveActionOltTextBox.Text =
                        string.Empty;
                    toeDefinitionConsequencesDescriptionOltTextBox.Text =
                        string.Empty;
                    toeDefinitionToeVersionPublishDateValueLabel.Text =
                        string.Empty;
                    toeDefinitionUnitOfMeasureValueLabel.Text = string.Empty;
                    toeDefinitionCausesDescriptionOltTextBox.Text = string.Empty;
                }

                documentLinksControl.DataSource = new List<DocumentLink>();
            }
        }

        public void SetCurrentTagValue(object result)
        {
            currentTagValueLabelValue.Text = result != null ? result.ToString() : string.Empty;
        }

        public event EventHandler Print;
        public event EventHandler Preview;

        private void ExpandEngineeringCommentsLinkOnClick(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(excursion.EngineerComments, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void ExpandExcursionCausesLinkOnClick(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(excursion.OpmToeDefinition.CausesDescription, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void ExpandOltToeDefinitionCommentLinkOnClick(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm =
                new ExpandedLogCommentForm(excursion.OpmToeDefinition.OpmToeDefinitionComment.Comment, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void ExpandExcursionCorrectiveActionsLinkOnClick(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm =
                new ExpandedLogCommentForm(excursion.OpmToeDefinition.CorrectiveActionDescription, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void ExpandExcursionConsequencesLinkOnClick(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(excursion.OpmToeDefinition.ConsequencesDescription,
                true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void ExpandExursionResponseLinkOnClick(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(excursion.OpmExcursionResponse.Response, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        public event EventHandler Expire;
        public event EventHandler Clone;
        public event Action MarkAsRead;

        public event Action<Directive> MarkedAsReadByToggled;

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        private void HandleExportButtonClick(object sender, EventArgs eventArgs)
        {
            if (ExportAll != null)
            {
                ExportAll(sender, eventArgs);
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs eventArgs)
        {
            if (Edit != null)
            {
                Edit(sender, eventArgs);
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(sender, EventArgs.Empty);
            }
        }

        private void HandleExpireButtonClick(object sender, EventArgs e)
        {
            if (Expire != null)
            {
                Expire(sender, EventArgs.Empty);
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(sender, EventArgs.Empty);
            }
        }

        private void HandleDetailsPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }

        private void EnvelopeCommentsHistoryButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (ViewEnvelopeCommentsHistory != null)
            {
                ViewEnvelopeCommentsHistory(null, EventArgs.Empty);
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(null, EventArgs.Empty);
            }
        }

        private void HandlePrint(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(null, EventArgs.Empty);
            }
        }

        private void HandlePrintPreviewButtonClicked(object sender, EventArgs e)
        {
            if (Preview != null)
            {
                Preview(null, EventArgs.Empty);
            }
        }

    
    }
}