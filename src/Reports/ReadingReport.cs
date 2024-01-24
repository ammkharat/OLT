using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;
using DevExpress.XtraCharts;
using System.Data;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Reports
{
    public partial class ReadingReport : XtraReport , IOltReport<ReadingReportAdapter>
    {
        public ReadingReport()
        {
            InitializeComponent();

        }

        public void SetMasterAndSubReportDataSource(List<ReadingReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            if (adapters != null && adapters.Count > 0)
            {
                var adapter = adapters[0];
                AddSeries(adapter);

                xrLabel1.Text ="Reading:- "+ adapter.ActionItemDefinitionName;
               // Series series = new Series("Series1", ViewType.Line);


               
                
              


               
            }
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }
        private void AddSeries(ReadingReportAdapter adp)
        {
            try
            {

                DataTable dt = adp.dt;
                if (dt == null) return;
                dt.TableName = "Table1";
                List<DataTable> lstdt = new List<DataTable>();
                foreach (DataRow drow in dt.Rows)
                {
                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Argument", typeof(DateTime));
                    dt1.Columns.Add("Value", typeof(decimal));
                    dt1.TableName = drow[0].ToString();
                    foreach (DataColumn dcol in dt.Columns)
                    {
                        if (!dcol.ColumnName.Contains("COMMENT") && !dcol.ColumnName.Contains("Field") && !dcol.ColumnName.Contains("Column") && !dcol.ColumnName.Contains("NAME"))
                        {
                            if (Convert.ToString(drow[dcol.ColumnName]) != "")
                            {
                                DataRow drow1 = dt1.NewRow();
                                DateTime d;
                                decimal dc;
                                if (DateTime.TryParse(dcol.ColumnName.Substring(0, dcol.ColumnName.Length - 2), out d) && decimal.TryParse(Convert.ToString(drow[dcol.ColumnName]),out dc))
                                {
                                    drow1["Argument"] = Convert.ToDateTime(dcol.ColumnName.Substring(0, dcol.ColumnName.Length - 2));
                                    drow1["Value"] = Convert.ToString(drow[dcol.ColumnName]) == "" ? 0 : drow[dcol.ColumnName];
                                    dt1.Rows.Add(drow1);
                                }
                            }
                        }


                    }
                    if (dt1.Rows.Count > 0)
                    {
                        lstdt.Add(dt1);
                    }

                }
                xrChart1.Series.Clear();
                foreach (DataTable ds in lstdt)
                {
                    if (ds.Rows.Count > 0)
                    {
                        //Series series = new Series(ds.TableName, ViewType.Line);

                        Series series = new Series(ds.TableName, adp.graphtype);
                        // Generate a data table and bind the series to it. 
                        series.DataSource = ds;

                        // Specify data members to bind the series. 
                        series.ArgumentScaleType = ScaleType.DateTime;
                        series.ArgumentDataMember = "Argument";
                        series.ValueScaleType = ScaleType.Numerical;
                        series.ValueDataMembers.AddRange(new string[] { "Value" });
                        xrChart1.Series.Add(series);
                    }

                }
            }
            catch(Exception ex)
            {
               
            }
        }
        private DataTable CreateChartData(int rowCount)
        {
            // Create an empty table. 
            DataTable table = new DataTable("Table1");

            // Add two columns to the table. 
            table.Columns.Add("Argument", typeof(Int32));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table. 
            Random rnd = new Random();
            DataRow row = null;
            for (int i = 0; i < rowCount; i++)
            {
                row = table.NewRow();
                row["Argument"] = i;
                row["Value"] = rnd.Next(100);
                table.Rows.Add(row);
            }

            return table;
        }
    }
}