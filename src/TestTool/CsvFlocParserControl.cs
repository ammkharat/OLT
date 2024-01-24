using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TestTool
{
    public partial class CsvFlocParserControl : UserControl
    {
        private static readonly char[] Separator = {'\\'};
        private string csvFileToParse = string.Empty;
        private string progressBarText = string.Empty;

        public CsvFlocParserControl()
        {
            InitializeComponent();

            elapsedTimeLabel.Text = string.Empty;

            fileSelectButton.Click += FileSelectButtonOnClick;
            resetButton.Click += ResetButtonOnClick;

            progressBar.Properties.Step = 1;
            progressBar.Properties.Maximum = 100;
            progressBar.Properties.PercentView = false;
            progressBar.Properties.ShowTitle = true;
            progressBar.CustomDisplayText += ProgressBarOnCustomDisplayFormattingText;

            ResetControl();
        }

        private void ProgressBarOnCustomDisplayFormattingText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = progressBarText;
        }

        private void ResetButtonOnClick(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void FileSelectButtonOnClick(object sender, EventArgs eventArgs)
        {
            openFileDialog.ShowDialog();
            var splitPath = openFileDialog.FileName.Split(Separator);
            //            filenameTextBox.Text = splitPath[splitPath.Length - 1];

            csvFileToParse = openFileDialog.FileName;
            filenameTextBox.Text = csvFileToParse;

            var pathToSelectedFile = Path.GetFullPath(csvFileToParse);
            csvFileToParse = openFileDialog.FileName;

            if (File.Exists(pathToSelectedFile))
            {
                SubmitButton.Enabled = true;
            }
        }

        private void ResetControl()
        {
            csvFileToParse = string.Empty;
            filenameTextBox.Text = string.Empty;
            generateSQLCheckBox.Checked = false;
            responseTextBox.Text = string.Empty;

            // Default settings for Fort Hills Operations
            siteIdTextBox.Text = "15";
            level1FlocTextBox.Text = "FH1";
            plantIdTextBox.Text = "764";
            cultureTextBox.Text = "en";
            sourceTextBox.Text = "1";
            batchSeparatorTextBox.Text = "100";

            elapsedTimeLabel.Text = string.Empty;
            flocCountLabel.Text = string.Empty;
            responseTextBox.Text = string.Empty;
            progressBar.Reset();

            SubmitButton.Enabled = false;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            responseTextBox.BeginInvoke(new Action(() => { responseTextBox.Text = "Parsing file..."; }));

            Application.DoEvents();

            try
            {
                var siteId = int.Parse(siteIdTextBox.Text);
                var level1Floc = level1FlocTextBox.Text;
                var plantId = int.Parse(plantIdTextBox.Text);
                var culture = cultureTextBox.Text;
                var source = int.Parse(sourceTextBox.Text);

                var generateSQL = generateSQLCheckBox.Checked;
                var batchSeparatorCount = batchSeparatorTextBox.Text.IsNullOrEmptyOrWhitespace()
                    ? 0
                    : int.Parse(batchSeparatorTextBox.Text);

                var csvParser = new CsvParser(Path.GetFullPath(csvFileToParse), siteId, level1Floc, plantId, culture,
                    source);

                var flocCount = csvParser.PreParseFlocCount();
                responseTextBox.AppendText(string.Format("\r\nFound {0} flocs", flocCount));

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                Cursor.Current = Cursors.WaitCursor;

                progressBarText = "Extracting flocs from CSV file...";

                var flocHeaders = csvParser.ExtractAllFlocs(true, responseTextBox, progressBar, flocCount).ToList();

                stopwatch.Stop();

                var formattedFlocCount = 1;
                var formattedFlocPercentComplete = 0;

                progressBarText = generateSQL
                    ? "Formatting floc insert SQL statements..."
                    : "Formatting floc debug output statements...";

                progressBar.BeginInvoke(new Action(() => { progressBar.Reset(); }));

                responseTextBox.BeginInvoke(new Action(() => { responseTextBox.Text = string.Empty; }));

                Application.DoEvents();

                if (flocCount > 0 && flocHeaders != null && flocHeaders.Count() > 0)
                {
                    foreach (var flocHeader in flocHeaders)
                    {
                        var formattedLine = generateSQL
                            ? flocHeader.FormatAsSQLInsertOutput()
                            : flocHeader.FormatAsDebugOutput();

                        var addBatchSeparatorAfterThisLine = generateSQL && formattedFlocCount%batchSeparatorCount == 0;
                        formattedFlocPercentComplete = formattedFlocCount++*100/flocCount;

                        responseTextBox.BeginInvoke(
                            new Action(() =>
                            {
                                responseTextBox.AppendText(string.Format("\r\n{0}", formattedLine));
                                if (addBatchSeparatorAfterThisLine)
                                {
                                    responseTextBox.AppendText("\r\nGO");
                                }
                            }));

                        progressBar.BeginInvoke(
                            new Action(() => { progressBar.Position = formattedFlocPercentComplete; }));

                        Application.DoEvents();
                    }

                    progressBarText = "Done!";

                    progressBar.BeginInvoke(new Action(() =>
                    {
                        progressBar.Position = 100;
                        progressBar.Refresh();
                    }));

                    elapsedTimeLabel.Text = string.Format("Elapsed time {0} ms", stopwatch.ElapsedMilliseconds);
                    flocCountLabel.Text = string.Format("Flocs {0}", flocHeaders.Count);
                }
                else
                {
                    responseTextBox.Text = "No data found";
                    elapsedTimeLabel.Text = "No data found";
                    flocCountLabel.Text = string.Empty;
                }
            }
            catch (Exception exception)
            {
                responseTextBox.Text = string.Format("Error: {0}\r\n\r\n{1}\r\n{2}", exception.Message,
                    exception.StackTrace,
                    exception.InnerException);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public class CsvParser
        {
            private readonly string culture;
            private readonly string level1Floc;
            private readonly string pathToCsvFile;
            private readonly int plantId;
            private readonly int siteId;
            private readonly int source;

            public CsvParser(string pathToCsvFile, int siteId, string level1Floc, int plantId, string culture,
                int source)
            {
                this.pathToCsvFile = pathToCsvFile;
                this.siteId = siteId;
                this.level1Floc = level1Floc;
                this.plantId = plantId;
                this.culture = culture;
                this.source = source;
            }

            public CsvParser()
            {
            }

            public int PreParseFlocCount()
            {
                char[] delimiters = {' '};
                using (var reader = new StreamReader(pathToCsvFile))
                {
                    var flocCount = 0;

                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null) break;
                        if (line.Contains(level1Floc))
                        {
                            flocCount++;
                        }
                    }

                    return flocCount;
                }
            }

            public IEnumerable<FlocHeader> ExtractAllFlocs(bool displayProgress, TextBox progressTextBox,
                ProgressBarControl progressBarControl, int totalFlocCount)
            {
                char[] delimiters = {' '};
                using (var reader = new StreamReader(pathToCsvFile))
                {
                    var processedFlocCount = 1;
                    var percentComplete = 0;

                    progressBarControl.BeginInvoke(new Action(() => { progressBarControl.Reset(); }));

                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null) break;
                        if (line.Contains(level1Floc) == false) continue;

                        percentComplete = processedFlocCount++*100/totalFlocCount;

                        progressTextBox.BeginInvoke(new Action(() =>
                        {
                            progressTextBox.AppendText(string.Format("\r\nProcessing floc #{0} of {1}...",
                                processedFlocCount, totalFlocCount));
                        }));

                        progressBarControl.BeginInvoke(
                            new Action(() => { progressBarControl.Position = percentComplete; }));

                        Application.DoEvents();

                        line = CleanLine(line);

                        var fields = line.Split(delimiters);

                        if (fields.Exists(s => s.StartsWith(level1Floc)))
                        {
                            var field1 = ExtractFullHierarchyFromFields(fields);
                            var field2 = ExtractDescriptionFromFields(fields);
                            var level = field1.Count(x => x == '-') + 1;

                            yield return new FlocHeader(field1, field2, siteId, plantId, level, culture, source);
                        }
                    }

                    progressTextBox.BeginInvoke(
                        new Action(() => { progressTextBox.AppendText("\r\nProcessing complete!"); }));

                    progressBarControl.BeginInvoke(new Action(() => { progressBarControl.Position = 100; }));

                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
            }

            private string ExtractFullHierarchyFromFields(string[] fields)
            {
                if (fields.Length == 0) return string.Empty;

                var fullHierarchy = Array.Find(fields, s => s.StartsWith(level1Floc));

                return fullHierarchy;
            }

            private string ExtractDescriptionFromFields(string[] fields)
            {
                if (fields.Length < 2) return string.Empty;

                var description = string.Empty;

                var fullHierarchy = ExtractFullHierarchyFromFields(fields);

                // If we can't find a full hierarchy, we are toast
                if (fullHierarchy.IsNullOrEmptyOrWhitespace()) return string.Empty;

                // Find the hierarchy, then concatenate all remaining fields with spaces between
                var indexOfFullHierarchy = Array.IndexOf(fields, fullHierarchy);
                if (indexOfFullHierarchy >= 0)
                {
                    var count = fields.Length - indexOfFullHierarchy - 1;
                    description = string.Join(" ", fields, indexOfFullHierarchy + 1, count);
                }

                return description.Trim();
            }

            private string CleanLine(string line)
            {
                // 1) Replace multiple spaces with singles
                //string cleanedString = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " "); // all whitespace including new lines
                var cleanedString = Regex.Replace(line, @"[ ]+", " "); // spaces only

                // 2) Remove leaf node characters
                var cleanLine = cleanedString.Trim().Replace("|---", "");
                cleanLine = cleanLine.Trim().Replace("|--", "");

                // 3) Remove remaining pipe characters used in tree branches
                cleanLine = cleanLine.Trim().Replace("|", "");

                return cleanLine.Trim();
            }
        }

        public class FlocHeader
        {
            private readonly string _debugOutputFormatString =
                @"SiteId:{0}, PlantId:{1}, FullHierarchy:{2}, Description:{3}, Level:{4}, Culture:{5}, Source:{6}";

            private readonly string _sqlOutputFormatString =
                @"INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES ({0}, N'{1}', N'{2}', 0, 0, {3}, {4}, N'{5}', {6})";

            public FlocHeader(string fullHierarchy, string description, int siteId, int plantId, int level,
                string culture, int source)
            {
                FullHierarchy = fullHierarchy;
                Description = description;
                SiteId = siteId;
                PlantId = plantId;
                Level = level;
                Culture = culture;
                Source = source;
            }

            public int SiteId { get; set; }
            public int PlantId { get; set; }
            public string Culture { get; set; }
            public string FullHierarchy { get; set; }
            public string Description { get; set; }
            public int Level { get; set; }
            public int Source { get; set; }

            public string FormatAsDebugOutput()
            {
                return string.Format(_debugOutputFormatString,
                    SiteId,
                    PlantId,
                    FullHierarchy,
                    Description,
                    Level,
                    Culture,
                    Source);
            }

            public string FormatAsSQLInsertOutput()
            {
                return string.Format(_sqlOutputFormatString,
                    SiteId,
                    Description,
                    FullHierarchy,
                    Level,
                    PlantId,
                    Culture,
                    Source);
            }
        }
    }
}