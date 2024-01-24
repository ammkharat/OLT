using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace Com.Suncor.Olt.Client
{
    public class CokerCardSummaryRenderer
    {
        private readonly RichTextDisplay textBoxToAppendTo;

        private readonly List<string> headers = new List<string>
                                                    {
                                                        StringResources.DrumHeader,
                                                        StringResources.LastCycleStepHeader,
                                                        StringResources.HoursInHeader,
                                                        StringResources.CommentsHeader
                                                    };
               
        public CokerCardSummaryRenderer(RichTextDisplay textBoxToAppendTo)
        {
            this.textBoxToAppendTo = textBoxToAppendTo;
        }

        private RichEditControl TextControl
        {
            get { return textBoxToAppendTo.RichEditControl; }
        }

        public void RenderCokerCardSummaries(List<CokerCardDrumEntryDTO> cokerCardSummaries)
        {
            Dictionary<string, List<CokerCardDrumEntryDTO>> summaries = cokerCardSummaries.GroupUsing(dto => dto.CokerCardName);

            foreach(string cokerCard in summaries.Keys)
            {
                List<CokerCardDrumEntryDTO> cokerCardDrumEntryReportDtos = summaries[cokerCard];

                CreateCokerCardTitle(cokerCard);
              
                int rowCount = cokerCardDrumEntryReportDtos.Count;
                DocumentPosition position = TextControl.Document.CreatePosition(TextControl.Text.Length);
                Table table = TextControl.Document.InsertTable(position, rowCount + 1, headers.Count);
                
                table.BeginUpdate();

                try
                {
                    CreateCokerCardHeader(table);                
                    AddDataRowsToTable(cokerCardDrumEntryReportDtos, table);
                }
                finally
                {
                    table.EndUpdate();
                }

                textBoxToAppendTo.AppendText(Environment.NewLine);
            }
        }

        private void CreateCokerCardHeader(Table table)
        {
            for (int i = 0; i < headers.Count; i++)
            {
                string text = headers[i];
                string rtfHeaderText = RichTextUtilities.ConvertTextToRTF(text, 10f, true, false, false);                

                InsertRTFTextIntoTable(table, 0, i, rtfHeaderText);
            }               
        }

        private static void AddDataRowsToTable(IEnumerable<CokerCardDrumEntryDTO> cokerCardDrumEntryReportDtos, Table table)
        {
            int currentRowIndex = 1;

            foreach (CokerCardDrumEntryDTO dto in cokerCardDrumEntryReportDtos)
            {
                decimal hoursIntoCycle = dto.HoursIntoCycle;
                string hoursIntoCycleAsString = hoursIntoCycle == 0 ? string.Empty : hoursIntoCycle.ToString();

                string drumName = RichTextUtilities.ConvertTextToRTF(dto.DrumName, 10, false, false, false);
                string cycleStepName = RichTextUtilities.ConvertTextToRTF(dto.CycleStepName, 10, false, false, false);
                string hours = RichTextUtilities.ConvertTextToRTF(hoursIntoCycleAsString, 10, false, false, false);

                InsertRTFTextIntoTable(table, currentRowIndex, 0, drumName);
                InsertRTFTextIntoTable(table, currentRowIndex, 1, cycleStepName);
                InsertRTFTextIntoTable(table, currentRowIndex, 2, hours);
                
                string comments = dto.Comments;

                if (comments != null)
                {
                    string rtfComments = RichTextUtilities.ConvertTextToRTF(comments, 10, false, false, false);
                    InsertRTFTextIntoTable(table, currentRowIndex, 3, rtfComments);                    
                }               

                currentRowIndex++;
            }
        }

        private static void InsertRTFTextIntoTable(Table table, int row, int column, string rtfText)
        {
            TableCell cell = table[row, column];
            SubDocument subDocument = cell.Range.BeginUpdateDocument();
            subDocument.InsertRtfText(cell.Range.Start, rtfText);
            cell.Range.EndUpdateDocument(subDocument);                
        }
       
        private void CreateCokerCardTitle(string cokerCard)
        {           
            string textToAppend = Environment.NewLine + cokerCard + Environment.NewLine;
            textBoxToAppendTo.AppendText(RichTextUtilities.ConvertTextToRTF(textToAppend, 14f, true, false, false));           
        }
    }
}