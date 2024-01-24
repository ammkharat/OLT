using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;


namespace Com.Suncor.Olt.Client.Forms
{
   
    public partial class ScanWorkPermit : BaseForm
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanWorkPermit));
        Thread th;
        ScanPdfFormPresenter Presenter = new ScanPdfFormPresenter();
        public ScanWorkPermit()
        {
            InitializeComponent();
            BindDocumentList();
            this.CenterToParent();
            addcheckBox();
            oltRadioManual.Checked = true;
        }
        public ScanWorkPermit(string PermitNumber)
        {
            InitializeComponent();
            BindDocumentList();
            this.CenterToParent();
            addcheckBox();
            oltRadiobuttonPermitSpecific.Checked = true;
            txtPermitNumber.Text = PermitNumber;
            oltRadiobuttonPermitSpecific.Checked = true;
            oltRadioManual.Checked = true;

        }

        private void oltButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFilePath.Text = openFileDialog1.FileName;

        }

        private void btnManualScanIndex_Click(object sender, EventArgs e)
        {
            errorProviderPermitValidate.Clear();

            if (txtFilePath.Text != "")
            {
                if (!System.IO.File.Exists(txtFilePath.Text))
                {
                    return;
                }
                if (oltRadiobuttonPermitSpecific.Checked)
                {
                    if (Presenter.IsWorkpermitExist(txtPermitNumber.Text)==false)
                    {
                        errorProviderPermitValidate.SetError(txtPermitNumber, "Permit not exists");
                        
                        return;
                    }
                    OLTDGVWorkPermit.AutoGenerateColumns = false;
                    string strdocType = string.Empty;
                    foreach (ScanDocumentType chk in oltchklstPermityType.CheckedItems)
                    {
                        
                        strdocType += chk.Text + ",";
                    }
                    if (strdocType.Length > 0)
                    {
                        strdocType = strdocType.Substring(0, strdocType.Length - 1);
                    }
                    OLTDGVWorkPermit.DataSource = ScanPdfFormPresenter.AttachPermitSpecificPDF(txtFilePath.Text, txtPermitNumber.Text, strdocType);
                    OLTDGVWorkPermit.Enabled = OLTDGVWorkPermit.RowCount>0;
                    oltBtnAttachDocument.Enabled = OLTDGVWorkPermit.RowCount > 0;
                }
                else
                {
                    List<ScanINdexDocument> lstScanINdexDocument = ScanPdfFormPresenter.ExtractTextFromPdf(txtFilePath.Text).ToList();
                    SetDocumentType(lstScanINdexDocument);
                    OLTDGVWorkPermit.AutoGenerateColumns = false;
                    OLTDGVWorkPermit.DataSource = lstScanINdexDocument.ToList();
                    OLTDGVWorkPermit.Enabled = OLTDGVWorkPermit.RowCount > 0;
                    oltBtnAttachDocument.Enabled = OLTDGVWorkPermit.RowCount > 0;
                  
                }

            }

        }

        private void oltDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                string FileName = Convert.ToString(OLTDGVWorkPermit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (System.IO.File.Exists(FileName))
                {
                    System.Diagnostics.Process.Start(FileName);
                }

            }
        }

        private void OltRadioScanner_CheckedChanged(object sender, EventArgs e)
        {
            oltGroupScanner.Enabled = OltRadioScanner.Checked;
            oltGroupManual.Enabled = oltRadioManual.Checked;
        }

        private void oltBtnAttachDocument_Click(object sender, EventArgs e)
        {
            ScanPdfFormPresenter presenter = new ScanPdfFormPresenter();
            List<WorkpermitScan> lst = new List<WorkpermitScan>();
            foreach (DataGridViewRow row in OLTDGVWorkPermit.Rows)
            {

                if (row.Index >= 0)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                    {
                        WorkpermitScan Scan = new WorkpermitScan();

                        Scan.WorkPermitId = Convert.ToString(row.Cells["WorkPermit"].Value);
                        Scan.DocumentPath = Convert.ToString(row.Cells["File"].Value);
                        Scan.Comment = Convert.ToString(row.Cells["Comment"].Value);
                        Scan.UploadedDocumentType = Convert.ToString(row.Cells["DocumentTypes"].Value);
                        lst.Add(Scan);
                    }



                }
            }
            if(lst.Count<=0)
            {
                OltMessageBox.Show(Form.ActiveForm, Convert.ToString(StringResources.MessageNorecordselected), Convert.ToString(StringResources.MessageboxTitle), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            presenter.InsertWorkPermitScan(lst, oltRadiobuttonPermitSpecific.Checked);

            OltMessageBox.Show(Form.ActiveForm,Convert.ToString(StringResources.MessageUploadSuccess), Convert.ToString(StringResources.MessageboxTitle), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oltRadiobuttonPermitSpecific_CheckedChanged(object sender, EventArgs e)
        {
            OLTgrpboxPermitspecifi.Enabled = oltRadiobuttonPermitSpecific.Checked;
            if (!oltRadiobuttonPermitSpecific.Checked)
            {
                txtPermitNumber.Text = string.Empty;
                oltchklstPermityType.ClearSelected();
            }
        }

        private void oltScanandIndex_Click(object sender, EventArgs e)
        {
              errorProviderPermitValidate.Clear();
            if (oltRadiobuttonPermitSpecific.Checked)
            {
                if (Presenter.IsWorkpermitExist(txtPermitNumber.Text) == false)
                {
                    errorProviderPermitValidate.SetError(txtPermitNumber,Convert.ToString(StringResources.MessageErrorPermitnotExists));
                    return;
                }
            }

            DialogResult Result = OltMessageBox.ShowCustomYesNo(Form.ActiveForm, Convert.ToString(StringResources.MessageScanConfirm), Convert.ToString(StringResources.MessageboxTitle), MessageBoxIcon.Information, "YES", "NO");
         if (Result == DialogResult.No)
         {
             return;
         }

         
           

          th = new Thread(t =>
         {
             this.Invoke((MethodInvoker)delegate
                 {
                     oltScanandIndex.Enabled = false;
                 });
         string strmessage= ScanPdfFormPresenter.Scanprocess();
             if(strmessage!="")
             {
                
                 return;
             }

          string[] fileNames = System.IO.Directory.GetFiles(ScanPdfFormPresenter.ScanDirectory);
            while(fileNames.Count()<=0)
            {
                fileNames = System.IO.Directory.GetFiles(ScanPdfFormPresenter.ScanDirectory);
            }
          if (fileNames.Count()>0 && System.IO.File.Exists(fileNames[0]))
         {

             while (IsFileLocked(new FileInfo(fileNames[0])))
             { }

             

             if (oltRadiobuttonPermitSpecific.Checked)
             {
                 
                 this.Invoke((MethodInvoker)delegate
                 {
                     string strdocType = string.Empty;
                     foreach (ScanDocumentType chk in oltchklstPermityType.CheckedItems)
                     {
                        
                       strdocType +=  chk.Text+",";
                     }
                   if(strdocType.Length>0)
                   {
                       strdocType = strdocType.Substring(0, strdocType.Length - 1);
                   }
                     OLTDGVWorkPermit.AutoGenerateColumns = false;
                     OLTDGVWorkPermit.DataSource = ScanPdfFormPresenter.AttachPermitSpecificPDF(fileNames[0], txtPermitNumber.Text, strdocType);
                     OLTDGVWorkPermit.Enabled = OLTDGVWorkPermit.RowCount > 0;
                     oltBtnAttachDocument.Enabled = OLTDGVWorkPermit.RowCount > 0;
                     OltMessageBox.Show(Form.ActiveForm, Convert.ToString(StringResources.MessageDocumentuploaded), Convert.ToString(StringResources.MessageboxTitle), MessageBoxButtons.OK);
                    
                 });
                
             }
             else
             {
                
                     this.Invoke((MethodInvoker)delegate
                     {
                         try
                         {
                           
                             OLTDGVWorkPermit.AutoGenerateColumns = false;
                             List<ScanINdexDocument> lstScanINdexDocument = ScanPdfFormPresenter.ExtractTextFromPdf(fileNames[0]).ToList();
                             SetDocumentType(lstScanINdexDocument);

                             OLTDGVWorkPermit.DataSource = lstScanINdexDocument.ToList();
                             OLTDGVWorkPermit.Enabled = OLTDGVWorkPermit.RowCount > 0;
                             oltBtnAttachDocument.Enabled = OLTDGVWorkPermit.RowCount > 0;
                             // MessageBox.Show("Document Scanned successfully!", "Work Permit Scan");
                             OltMessageBox.Show(Form.ActiveForm, Convert.ToString(StringResources.MessageScanSuccessfully), Convert.ToString(StringResources.MessageboxTitle), MessageBoxButtons.OK);
                         }
                         catch(Exception ex)
                         {
                             MessageBox.Show(Form.ActiveForm, ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                         }
                     });
                 
                
             }
         }



         }) { IsBackground = true };

         th.Start();  
           
       

        }

        private void SetDocumentType(List<ScanINdexDocument> lstScanINdexDocument)
        {
           // ScanPdfFormPresenter Presenter = new ScanPdfFormPresenter();
            List<ScanDocumentType> DocumentTypes = Presenter.GetDocumentType();
            foreach (ScanINdexDocument scanINdexDocument in lstScanINdexDocument)
            {
                string docs = "";
                List<ScanDocumentType> scandocType = DocumentTypes.Where(A => scanINdexDocument.DcoumentType.Contains(A.Tag)).ToList();
                foreach (ScanDocumentType doctype in scandocType)
                {
                    docs += doctype.Text + ",";
                }
                if (docs.Length > 0)
                {
                    docs = docs.Substring(0, docs.Length - 1);
                }
                scanINdexDocument.DcoumentType = docs;

            }
        }
        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        

        private void BindDocumentList()
        {
            ScanPdfFormPresenter Presenter = new ScanPdfFormPresenter();
           List<ScanDocumentType> strArr = Presenter.GetDocumentType();
           foreach (ScanDocumentType chkbox in strArr)
            {

                oltchklstPermityType.Items.Add(chkbox);
            }
   
         
        }

        private void txtPermitNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void oltchkBoxselectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in OLTDGVWorkPermit.Rows)
            {

                row.Cells[0].Value = (sender as CheckBox).Checked;

            }
            this.OLTDGVWorkPermit.EndEdit();
        }

        private void addcheckBox()
        {
            //add

            CheckBox ckBox = new CheckBox();
            //Get the column header cell bounds
            Rectangle rect =
                this.OLTDGVWorkPermit.GetCellDisplayRectangle(0, -1, true);
            ckBox.Size = new Size(18, 15);
            //Change the location of the CheckBox to make it stay on the header
            ckBox.Location =new Point(rect.X+10,rect.Location.Y + 5);

           // ckBox.Location = rect.Location;
            ckBox.CheckAlign = ContentAlignment.MiddleRight;
            ckBox.CheckedChanged += new EventHandler(oltchkBoxselectAll_CheckedChanged);
            //Add the CheckBox into the DataGridView
            this.OLTDGVWorkPermit.Controls.Add(ckBox);


        }

        private void ScanWorkPermit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
                th.Abort();
        }

       
        


    }
       
}
