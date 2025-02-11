﻿using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitMudsSign : BaseForm
    {
        GasTestMudsFormPresenter Present;

        WorkPermitMudsDTO objworkPermit;
        WorkPermitMudSign objWorkPermitSign;
        WorkPermitMudSign objOriginellWorkPermitSign;
        string LenelSource = "LENEL";
        string OLTSOURCE = "OLT";
        string ManualSource = "Manual";
        bool SkipForm = true;

        public WorkPermitMudsSign()
        {
            InitializeComponent();



        }


        public WorkPermitMudsSign(WorkPermitMudsDTO workPermit)
        {
            InitializeComponent();
            rdbVerifiertxt.GotFocus += GotCous;
            rdbDETENTEURtxt.GotFocus += GotCous;
            rdbEMETTEURtxt.GotFocus += GotCous;
            //Logic To add Workpermit details Control
            objworkPermit = workPermit;

            this.Text = "signature Numéro permis:-" + objworkPermit.PermitNumber;
            //Load Data
            LoadData();

            if (objworkPermit.WorkPermitMudsType != WorkPermitMudsType.ELEVATED_HOT)
            {
                oltExplorerBar1.Groups[1].Visible = false;
                //oltExplorerBar1.Groups[1].Expanded = true;
                this.Height -= gasTestElementInfoTableLayoutPanel.Height;

            }
            else
            {
                oltExplorerBar1.Groups[1].Expanded = true;
            }

        }

        public void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            SuspendLayout();
            //gasTestInfoExplorerBarContainerControl.SuspendLayout();
            gasTestElementInfoTableLayoutPanel.showonlyFirstColum = true;
            gasTestElementInfoTableLayoutPanel.disbaleFirstColumn = true;


            gasTestElementInfoTableLayoutPanel.BuildGasTestElementControls(standardGasTestElementInfoList, ClientSession.GetUserContext().Site);
            //gasTestInfoExplorerBarContainerControl.ResumeLayout();
            ResumeLayout();

            Present = new GasTestMudsFormPresenter(objworkPermit.IdValue);
            Present.standardGasTestElementInfoList = standardGasTestElementInfoList;
            Present.LoadWorkItemGasTests(gasTestElementInfoTableLayoutPanel);
            gasTestElementInfoTableLayoutPanel.GetSignControl.Visible = false;
            gasTestElementInfoTableLayoutPanel.DisbaleFirstTime = true;

        }
        private void rdbVerifierManual_Click(object sender, EventArgs e)
        {
            OltRadioButton rdb = sender as OltRadioButton;

            switch (rdb.Name)
            {

                case "rdbVerifierManual":


                    txtVerifier.Text = "";
                    rdbVerifiertxt.Text = "";
                    objWorkPermitSign.Verifier_BADGENUMBER = null;
                    objWorkPermitSign.Verifier_BADGETYPE = null;
                    objWorkPermitSign.Verifier_FNAME = null;
                    objWorkPermitSign.Verifier_LNAME = null;
                    objWorkPermitSign.Verifier_SOURCE = ManualSource;

                    break;

                case "rdbDETENTEURManual":

                    rdbDETENTEURtxt.Text = "";

                    txtDETENTEUR.Text = "";
                    objWorkPermitSign.DETENTEUR_BADGENUMBER = null;
                    objWorkPermitSign.DETENTEUR_BADGETYPE = null;
                    objWorkPermitSign.DETENTEUR_FNAME = null;
                    objWorkPermitSign.DETENTEUR_LNAME = null;
                    objWorkPermitSign.DETENTEUR_SOURCE = ManualSource;


                    break;

                case "rdbEMETTEURManual":


                    rdbEMETTEURtxt.Text = "";
                    rdbEMETTEURtxt.Enabled = false;
                    // rdbCrossZoneAuthtxt.BackColor = Color.Empty;
                    txtEMETTEUR.Text = "";

                    objWorkPermitSign.EMETTEUR_FNAME = null;
                    objWorkPermitSign.EMETTEUR_LNAME = null;
                    objWorkPermitSign.EMETTEUR_BADGENUMBER = null;
                    objWorkPermitSign.EMETTEUR_BADGETYPE = null;
                    objWorkPermitSign.EMETTEUR_SOURCE = ManualSource;

                    break;

                case "rdbGasTestManual":


                    rdbGastTesttxt.Text = "";
                    rdbGastTesttxt.Enabled = false;
                    // rdbCrossZoneAuthtxt.BackColor = Color.Empty;
                    txtGasTest.Text = "";

                    objWorkPermitSign.FirstNameFirstResult = null;
                    objWorkPermitSign.LasttNameFirstResult = null;
                    objWorkPermitSign.BadgeFirstResult = null;
                    //objWorkPermitSign.EMETTEUR_BADGETYPE = null;
                    objWorkPermitSign.SourceFirstResult = ManualSource;

                    break;
            }

        }

        private void rdbVerifierOLT_Click(object sender, EventArgs e)
        {
            OltRadioButton rdb = sender as OltRadioButton;
            var User = Client.ClientSession.GetUserContext().User;
            switch (rdb.Name)
            {

                case "rdbVerifierOLT":

                    objWorkPermitSign.Verifier_BADGENUMBER = "";
                    objWorkPermitSign.Verifier_BADGETYPE = "";

                    objWorkPermitSign.Verifier_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.Verifier_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objWorkPermitSign.Verifier_SOURCE = OLTSOURCE; ;
                    txtVerifier.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbVerifiertxt.Text = "";
                    // rdbVerifiertxt.Enabled = false;


                    break;



                case "rdbDETENTEUROLT":

                    objWorkPermitSign.DETENTEUR_BADGENUMBER = "";
                    objWorkPermitSign.DETENTEUR_BADGETYPE = "";

                    objWorkPermitSign.DETENTEUR_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.DETENTEUR_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objWorkPermitSign.DETENTEUR_SOURCE = OLTSOURCE; ;
                    txtDETENTEUR.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbDETENTEURtxt.Text = "";
                    // rdbDETENTEURtxt.Enabled = false;


                    break;

                case "rdbEMETTEUROLT":


                    objWorkPermitSign.EMETTEUR_BADGENUMBER = "";
                    objWorkPermitSign.EMETTEUR_BADGETYPE = "";

                    objWorkPermitSign.EMETTEUR_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.EMETTEUR_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objWorkPermitSign.EMETTEUR_SOURCE = OLTSOURCE; ;
                    txtEMETTEUR.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbEMETTEURtxt.Text = "";
                    // rdbEMETTEURtxt.Enabled = false;


                    break;
                case "rdbGasTestOLT":


                    objWorkPermitSign.BadgeFirstResult = "";
                    // objWorkPermitSign.EMETTEUR_BADGETYPE = "";

                    objWorkPermitSign.FirstNameFirstResult = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.LasttNameFirstResult = Convert.ToString(User.LastName).ToUpper();
                    objWorkPermitSign.SourceFirstResult = OLTSOURCE; ;
                    txtGasTest.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbGastTesttxt.Text = "";

                    break;
            }
        }

        private void rdbVerifierId_Click(object sender, EventArgs e)
        {
            OltRadioButton rdb = sender as OltRadioButton;
            var User = Client.ClientSession.GetUserContext().User;
            switch (rdb.Name)
            {

                case "rdbVerifierId":

                    txtVerifier.Text = "";
                    rdbVerifiertxt.Text = "";
                    rdbVerifiertxt.Enabled = true;

                    rdbVerifiertxt.ReadOnly = true;
                    rdbVerifiertxt.Focus();


                    break;



                case "rdbDETENTEURId":

                    txtDETENTEUR.Text = "";
                    rdbDETENTEURtxt.Text = "";
                    rdbDETENTEURtxt.Enabled = true;


                    rdbDETENTEURtxt.ReadOnly = true;
                    rdbDETENTEURtxt.Focus();


                    break;

                case "rdbEMETTEURId":


                    txtEMETTEUR.Text = "";
                    rdbEMETTEURtxt.Text = "";
                    rdbEMETTEURtxt.Enabled = true;

                    rdbEMETTEURtxt.ReadOnly = true;
                    rdbEMETTEURtxt.Focus();


                    break;

                case "rdbGasTestId":


                    txtGasTest.Text = "";
                    rdbGastTesttxt.Text = "";
                    rdbGastTesttxt.Enabled = true;

                    rdbGastTesttxt.ReadOnly = true;
                    rdbGastTesttxt.Focus();


                    break;
            }
        }
        private void GotCous(object sender, EventArgs e)
        {
            OltTextBox rdb = sender as OltTextBox;

            switch (rdb.Name)
            {

                case "rdbVerifiertxt":

                    txtVerifier.Text = "";
                    rdbVerifiertxt.Text = "";
                    rdbVerifiertxt.Enabled = true;

                    rdbVerifiertxt.ReadOnly = true;
                    rdbVerifiertxt.Focus();
                    rdbVerifierId.Checked = true;

                    break;



                case "rdbDETENTEURtxt":

                    txtDETENTEUR.Text = "";
                    rdbDETENTEURtxt.Text = "";
                    rdbDETENTEURtxt.Enabled = true;


                    rdbDETENTEURtxt.ReadOnly = true;
                    rdbDETENTEURtxt.Focus();
                    rdbDETENTEURId.Checked = true;

                    break;

                case "rdbEMETTEURtxt":


                    txtEMETTEUR.Text = "";
                    rdbEMETTEURtxt.Text = "";
                    rdbEMETTEURtxt.Enabled = true;

                    rdbEMETTEURtxt.ReadOnly = true;
                    rdbEMETTEURtxt.Focus();
                    rdbEMETTEURId.Checked = true;

                    break;

                case "rdbGastTesttxt":


                    txtGasTest.Text = "";
                    rdbGastTesttxt.Text = "";
                    rdbGastTesttxt.Enabled = true;

                    rdbGastTesttxt.ReadOnly = true;
                    rdbGastTesttxt.Focus();
                    rdbGasTestId.Checked = true;

                    break;
            }
        }

        int i = 0;
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender.GetType() != typeof(OltControls.OltTextBox))
            {
                return;
            }
            TextBox txtNextLvl = sender as OltControls.OltTextBox;
            if (i == 0)
            {
                txtNextLvl.Text = string.Empty;
            }
            if (e.KeyCode == Keys.Enter)
            {
                //reset i=0 as Cardnumbetgot and Enter prseeed.
                i = 0;

                //Get  Badgeinfor from lenle and Set Badge info
                WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                BADGE objBadge = WPSign.GetBadgeInfo(txtNextLvl.Text);

                if (objBadge.FNAME == null)
                {
                    MessageBox.Show("Badge Info Not Found");
                    txtNextLvl.Text = "";
                    return;
                }
                objBadge.FNAME = Convert.ToString(objBadge.FNAME).ToUpper();
                objBadge.LNAME = Convert.ToString(objBadge.LNAME).ToUpper();

                switch (txtNextLvl.Name)
                {

                    case "rdbVerifiertxt":


                        objWorkPermitSign.Verifier_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.Verifier_FNAME = objBadge.FNAME;
                        objWorkPermitSign.Verifier_LNAME = objBadge.LNAME;
                        objWorkPermitSign.Verifier_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.Verifier_SOURCE = LenelSource;
                        txtVerifier.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;

                    case "rdbDETENTEURtxt":

                        objWorkPermitSign.DETENTEUR_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.DETENTEUR_FNAME = objBadge.FNAME;
                        objWorkPermitSign.DETENTEUR_LNAME = objBadge.LNAME;
                        objWorkPermitSign.DETENTEUR_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.DETENTEUR_SOURCE = LenelSource;
                        txtDETENTEUR.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;
                    case "rdbEMETTEURtxt":

                        objWorkPermitSign.EMETTEUR_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.EMETTEUR_FNAME = objBadge.FNAME;
                        objWorkPermitSign.EMETTEUR_LNAME = objBadge.LNAME;
                        objWorkPermitSign.EMETTEUR_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.EMETTEUR_SOURCE = LenelSource;
                        txtEMETTEUR.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;

                    case "rdbGastTesttxt":

                        objWorkPermitSign.BadgeFirstResult = txtNextLvl.Text;
                        objWorkPermitSign.FirstNameFirstResult = objBadge.FNAME;
                        objWorkPermitSign.LasttNameFirstResult = objBadge.LNAME;
                        //objWorkPermitSign.EMETTEUR_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.SourceFirstResult = LenelSource;
                        txtGasTest.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;

                }

                // MessageBox.Show("Enter key pressed");
            }
            else
            {
                if (char.IsNumber((char)e.KeyCode))
                {
                    i++;
                    txtNextLvl.Text += (char)e.KeyCode;
                }
            }
        }


        private void LoadData()
        {
            WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();

            objWorkPermitSign = WPSign.GetMudSign(Convert.ToString(objworkPermit.PermitNumber));

            if (objworkPermit.WorkPermitTypeName == Com.Suncor.Olt.Common.Domain.WorkPermit.WorkPermitType.HOT.Name)
            {

                olttblpnlHot.Visible = true;

            }
            else
            {

                olttblpnlHot.Visible = false;
                oltTableLayoutPanel1.Location = olttblpnlHot.Location;
                this.Height = this.Height - olttblpnlHot.Height;
            }

            if (objWorkPermitSign == null)
            {
                objWorkPermitSign = new WorkPermitMudSign();
                objWorkPermitSign.WorkPermitId = Convert.ToString(objworkPermit.PermitNumber);
                objOriginellWorkPermitSign = objWorkPermitSign.Clone() as WorkPermitMudSign;
                return;
            }
            objOriginellWorkPermitSign = objWorkPermitSign.Clone() as WorkPermitMudSign;
            if (objWorkPermitSign != null)
            {
                txtVerifier.Text = Convert.ToString(objWorkPermitSign.Verifier_FNAME) + " " + Convert.ToString(objWorkPermitSign.Verifier_LNAME);
                rdbVerifiertxt.Text = Convert.ToString(objWorkPermitSign.Verifier_BADGENUMBER);

                txtDETENTEUR.Text = Convert.ToString(objWorkPermitSign.DETENTEUR_FNAME) + " " + Convert.ToString(objWorkPermitSign.DETENTEUR_LNAME);
                rdbDETENTEURtxt.Text = Convert.ToString(objWorkPermitSign.DETENTEUR_BADGENUMBER);

                txtEMETTEUR.Text = Convert.ToString(objWorkPermitSign.EMETTEUR_FNAME) + " " + Convert.ToString(objWorkPermitSign.EMETTEUR_LNAME);
                rdbEMETTEURtxt.Text = Convert.ToString(objWorkPermitSign.EMETTEUR_BADGENUMBER);

                txtGasTest.Text = Convert.ToString(objWorkPermitSign.FirstNameFirstResult) + " " + Convert.ToString(objWorkPermitSign.LasttNameFirstResult);
                rdbGastTesttxt.Text = Convert.ToString(objWorkPermitSign.BadgeFirstResult);

                if (objWorkPermitSign.Verifier_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.Verifier_SOURCE == LenelSource)
                {
                    rdbVerifierId.Checked = true;

                }
                else if (objWorkPermitSign.Verifier_SOURCE == OLTSOURCE)
                {
                    rdbVerifierOLT.Checked = true;

                }
                else
                {
                    rdbVerifierManual.Checked = true;
                    SkipForm = false;
                }


                if (objWorkPermitSign.DETENTEUR_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.DETENTEUR_SOURCE == LenelSource)
                {
                    rdbDETENTEURId.Checked = true;

                }
                else if (objWorkPermitSign.DETENTEUR_SOURCE == OLTSOURCE)
                {
                    rdbDETENTEUROLT.Checked = true;

                }
                else
                {
                    rdbDETENTEURManual.Checked = true;
                    SkipForm = false;
                }

                if (objWorkPermitSign.EMETTEUR_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.EMETTEUR_SOURCE == LenelSource)
                {
                    rdbEMETTEURId.Checked = true;

                }
                else if (objWorkPermitSign.EMETTEUR_SOURCE == OLTSOURCE)
                {
                    rdbEMETTEUROLT.Checked = true;

                }
                else
                {
                    rdbEMETTEURManual.Checked = true;
                    SkipForm = false;
                }

                if (objWorkPermitSign.SourceFirstResult == null)
                {

                }
                else if (objWorkPermitSign.SourceFirstResult == LenelSource)
                {
                    rdbGasTestId.Checked = true;

                }
                else if (objWorkPermitSign.SourceFirstResult == OLTSOURCE)
                {
                    rdbGasTestOLT.Checked = true;

                }
                else
                {
                    rdbGasTestManual.Checked = true;
                    SkipForm = false;
                }

            }







        }

        private bool SaveValidate()
        {
            errorProvider1.Clear();


            if (rdbVerifierId.Checked == true && rdbVerifiertxt.Text == "")
            {
                errorProvider1.SetError(rdbVerifiertxt, "Please Scan  Badge or Select Manual option");
                return false;
            }

            if (rdbDETENTEURId.Checked == true && rdbDETENTEURtxt.Text == "")
            {
                errorProvider1.SetError(rdbDETENTEURtxt, "Please Scan  Badge or Select Manual option");
                return false;
            }

            if (rdbEMETTEURId.Checked == true && rdbEMETTEURtxt.Text == "")
            {
                errorProvider1.SetError(rdbEMETTEURtxt, "Please Scan  Badge or Select Manual option");
                return false;
            }

            if (rdbGasTestId.Checked == true && rdbGastTesttxt.Text == "")
            {
                errorProvider1.SetError(rdbGastTesttxt, "Please Scan  Badge or Select Manual option");
                return false;
            }

            return true;
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SaveValidate() == false)
            {
                return;
            }
            if (objWorkPermitSign != null)
            {
                if (!objWorkPermitSign.Equals(objOriginellWorkPermitSign))
                {
                    WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                    WPSign.SaveMudsSign(objWorkPermitSign);
                }
            }
            this.DialogResult = DialogResult.Cancel;
            ChangeStatus = true;
        }

        private void btnSaveIssue_Click(object sender, EventArgs e)
        {
            if (SaveValidate() == false)
            {
                return;
            }
            if (objWorkPermitSign != null)
            {
                if (!objWorkPermitSign.Equals(objOriginellWorkPermitSign))
                {
                    WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                    WPSign.SaveMudsSign(objWorkPermitSign);
                }
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            ChangeStatus = false;
        }

        private void oltBtnshowDetails_Click(object sender, EventArgs e)
        {
            PriorityPageWorkPermitMudsDetailsPresenter P = new PriorityPageWorkPermitMudsDetailsPresenter(objworkPermit.IdValue);
            // Control C = P.GetCOntrolForSign();
            // C.Controls.Find("toolStrip1", true)[0].Visible = false;
            // C.Controls.Find("toolStrip1", true)[1].Visible = false;
            P.Run(this);
            // oltTableLayoutPanel2.Controls.Add(C);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (objWorkPermitSign != null && objWorkPermitSign.WorkPermitId != null)
            {
                objWorkPermitSign.Id = 1;
                EditWorkPermitMudsSignHistoryPresenter EP = new EditWorkPermitMudsSignHistoryPresenter(objWorkPermitSign);
                EP.Run(this);
            }
        }

        // Added By Vibhor : RITM0556998 - Add new status signed

        public string VERIFICATEUR_Text
        {
            get { return txtVerifier.Text; }
            set { txtVerifier.Text = value; }
        }

        public string EMETTEUR_Text
        {
            get { return txtEMETTEUR.Text; }
            set { txtEMETTEUR.Text = value; }
        }
        public string DETENTEUR_Text
        {
            get { return txtDETENTEUR.Text; }
            set { txtDETENTEUR.Text = value; }
        }

        public string GasResultat_Text
        {
            get { return txtGasTest.Text; }
            set { txtGasTest.Text = value; }
        }

        public bool ChangeStatus { get; set; }
        
        


    }
}
