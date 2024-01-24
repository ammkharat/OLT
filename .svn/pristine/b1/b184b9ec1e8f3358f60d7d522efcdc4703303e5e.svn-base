using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using log4net;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltExcelExporter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(OltExcelExporter));

        private readonly UltraGridExcelExporter exporter;

        public event InitializeColumnEventHandler InitializeColumn;


        public OltExcelExporter()
        {
            exporter = new UltraGridExcelExporter();
            exporter.InitializeColumn += exporter_InitializeColumn;
            exporter.CellExported += exporter_CellExported;
        }

        private static void exporter_CellExported(object sender, CellExportedEventArgs e)
        {
            if (e.GridColumn.DataType == typeof(Image))
            {
                UltraGridCell cell = e.GridRow.Cells[e.GridColumn];
                e.CurrentWorksheet.Rows[e.CurrentRowIndex].Cells[e.CurrentColumnIndex].Value = cell.ToolTipText;
            }            
        }

        public void Export(UltraGrid grid)
        {
            SaveFileDialog dialog = CreateSaveAsDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    
                    Workbook book = exporter.Export(grid);
                    RemoveImages(book);
                    BIFF8Writer.WriteWorkbookToFile(book, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
                catch (Exception exception)
                {
                    logger.Error("Error exporting grid:" + exception);
                    OltMessageBox.Show(Form.ActiveForm, StringResources.ExcelExporter_ExportError);
                }
            }
        }

        private void exporter_InitializeColumn(object sender, InitializeColumnEventArgs e)
        {
            if (e.Column.DataType == typeof(DateTime?) || e.Column.DataType == typeof(DateTime))
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            }
            else if (e.Column.DataType == typeof(Time))
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ShortTimePattern;
            }
            else if (e.Column.DataType == typeof(Date))
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ShortDatePattern;
            }
            else if (e.Column.DataType == typeof(decimal?) || e.Column.DataType == typeof(decimal))
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ExcelDecimalFormat;
            }
            else
            {
                e.ExcelFormatStr = e.FrameworkFormatStr;
            }

            if (InitializeColumn != null)
            {
                InitializeColumn(sender, e);
            }
        }

        private static void RemoveImages(Workbook workbook)
        {
            foreach (Worksheet worksheet in workbook.Worksheets)
            {
                worksheet.Shapes.Clear();
            }
        }

        private static SaveFileDialog CreateSaveAsDialog()
        {
            
            var dialog = new SaveFileDialog
            {
                AddExtension = true,
                Filter = StringResources.ExcelExporter_FileFilterDescription + "|*.xls", 
                FilterIndex = 2,
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                RestoreDirectory = true
            };
            return dialog;
        }
    }
}