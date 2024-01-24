using Com.Suncor.Olt.Client.OltControls;
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
    public partial class ConfinedSpaceMudsSign : BaseForm
    {
        GasTestMudsFormPresenter Present;

        ConfinedSpaceMudsDTO objconfinedSpace;
        ConfinedSpaceMudSign objconfinedSpaceSign;
        ConfinedSpaceMudSign objOriginellconfinedSpaceSign;
        string LenelSource = "LENEL";
        string OLTSOURCE = "OLT";
        string ManualSource = "Manual";
        bool SkipForm = true;

        public ConfinedSpaceMudsSign()
        {
            InitializeComponent();



        }


        public ConfinedSpaceMudsSign(ConfinedSpaceMudsDTO confinedSpace)
        {
            InitializeComponent();
            rdbVerifiertxt.GotFocus += GotCous;
            rdbDETENTEURtxt.GotFocus += GotCous;
            rdbEMETTEURtxt.GotFocus += GotCous;
            //Logic To add Workpermit details Control
            objconfinedSpace = confinedSpace;

            this.Text = "signature Numéro permis:-" + objconfinedSpace.ConfinedSpaceNumber;
            //Load Data
            LoadData();

            //if (objconfinedSpace.WorkPermitMudsType != WorkPermitMudsType.ELEVATED_HOT)
            //{
            //    oltExplorerBar1.Groups[1].Visible = false;
            //    //oltExplorerBar1.Groups[1].Expanded = true;
            //    this.Height -= gasTestElementInfoTableLayoutPanel.Height;

            //}
            //else
            //{
            //    oltExplorerBar1.Groups[1].Expanded = true;
            //}

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

            Present = new GasTestMudsFormPresenter(objconfinedSpace.IdValue);
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
                    objconfinedSpaceSign.Verifier_BADGENUMBER = null;
                    objconfinedSpaceSign.Verifier_BADGETYPE = null;
                    objconfinedSpaceSign.Verifier_FNAME = null;
                    objconfinedSpaceSign.Verifier_LNAME = null;
                    objconfinedSpaceSign.Verifier_SOURCE = ManualSource;

                    break;

                case "rdbDETENTEURManual":

                    rdbDETENTEURtxt.Text = "";

                    txtDETENTEUR.Text = "";
                    objconfinedSpaceSign.DETENTEUR_BADGENUMBER = null;
                    objconfinedSpaceSign.DETENTEUR_BADGETYPE = null;
                    objconfinedSpaceSign.DETENTEUR_FNAME = null;
                    objconfinedSpaceSign.DETENTEUR_LNAME = null;
                    objconfinedSpaceSign.DETENTEUR_SOURCE = ManualSource;


                    break;

                case "rdbEMETTEURManual":


                    rdbEMETTEURtxt.Text = "";
                    rdbEMETTEURtxt.Enabled = false;
                    // rdbCrossZoneAuthtxt.BackColor = Color.Empty;
                    txtEMETTEUR.Text = "";

                    objconfinedSpaceSign.EMETTEUR_FNAME = null;
                    objconfinedSpaceSign.EMETTEUR_LNAME = null;
                    objconfinedSpaceSign.EMETTEUR_BADGENUMBER = null;
                    objconfinedSpaceSign.EMETTEUR_BADGETYPE = null;
                    objconfinedSpaceSign.EMETTEUR_SOURCE = ManualSource;

                    break;

                case "rdbGasTestManual":


                    rdbGastTesttxt.Text = "";
                    rdbGastTesttxt.Enabled = false;
                    // rdbCrossZoneAuthtxt.BackColor = Color.Empty;
                    txtGasTest.Text = "";

                    objconfinedSpaceSign.FirstNameFirstResult = null;
                    objconfinedSpaceSign.LasttNameFirstResult = null;
                    objconfinedSpaceSign.BadgeFirstResult = null;
                    //objconfinedSpaceSign.EMETTEUR_BADGETYPE = null;
                    objconfinedSpaceSign.SourceFirstResult = ManualSource;

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

                    objconfinedSpaceSign.Verifier_BADGENUMBER = "";
                    objconfinedSpaceSign.Verifier_BADGETYPE = "";

                    objconfinedSpaceSign.Verifier_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objconfinedSpaceSign.Verifier_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objconfinedSpaceSign.Verifier_SOURCE = OLTSOURCE; ;
                    txtVerifier.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbVerifiertxt.Text = "";
                    // rdbVerifiertxt.Enabled = false;


                    break;



                case "rdbDETENTEUROLT":

                    objconfinedSpaceSign.DETENTEUR_BADGENUMBER = "";
                    objconfinedSpaceSign.DETENTEUR_BADGETYPE = "";

                    objconfinedSpaceSign.DETENTEUR_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objconfinedSpaceSign.DETENTEUR_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objconfinedSpaceSign.DETENTEUR_SOURCE = OLTSOURCE; ;
                    txtDETENTEUR.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbDETENTEURtxt.Text = "";
                    // rdbDETENTEURtxt.Enabled = false;


                    break;

                case "rdbEMETTEUROLT":


                    objconfinedSpaceSign.EMETTEUR_BADGENUMBER = "";
                    objconfinedSpaceSign.EMETTEUR_BADGETYPE = "";

                    objconfinedSpaceSign.EMETTEUR_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objconfinedSpaceSign.EMETTEUR_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objconfinedSpaceSign.EMETTEUR_SOURCE = OLTSOURCE; ;
                    txtEMETTEUR.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbEMETTEURtxt.Text = "";
                    // rdbEMETTEURtxt.Enabled = false;


                    break;
                case "rdbGasTestOLT":


                    objconfinedSpaceSign.BadgeFirstResult = "";
                    // objconfinedSpaceSign.EMETTEUR_BADGETYPE = "";

                    objconfinedSpaceSign.FirstNameFirstResult = Convert.ToString(User.FirstName).ToUpper();
                    objconfinedSpaceSign.LasttNameFirstResult = Convert.ToString(User.LastName).ToUpper();
                    objconfinedSpaceSign.SourceFirstResult = OLTSOURCE; ;
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


                        objconfinedSpaceSign.Verifier_BADGENUMBER = txtNextLvl.Text;
                        objconfinedSpaceSign.Verifier_FNAME = objBadge.FNAME;
                        objconfinedSpaceSign.Verifier_LNAME = objBadge.LNAME;
                        objconfinedSpaceSign.Verifier_BADGETYPE = objBadge.BADGETYPE;
                        objconfinedSpaceSign.Verifier_SOURCE = LenelSource;
                        txtVerifier.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;

                    case "rdbDETENTEURtxt":

                        objconfinedSpaceSign.DETENTEUR_BADGENUMBER = txtNextLvl.Text;
                        objconfinedSpaceSign.DETENTEUR_FNAME = objBadge.FNAME;
                        objconfinedSpaceSign.DETENTEUR_LNAME = objBadge.LNAME;
                        objconfinedSpaceSign.DETENTEUR_BADGETYPE = objBadge.BADGETYPE;
                        objconfinedSpaceSign.DETENTEUR_SOURCE = LenelSource;
                        txtDETENTEUR.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;
                    case "rdbEMETTEURtxt":

                        objconfinedSpaceSign.EMETTEUR_BADGENUMBER = txtNextLvl.Text;
                        objconfinedSpaceSign.EMETTEUR_FNAME = objBadge.FNAME;
                        objconfinedSpaceSign.EMETTEUR_LNAME = objBadge.LNAME;
                        objconfinedSpaceSign.EMETTEUR_BADGETYPE = objBadge.BADGETYPE;
                        objconfinedSpaceSign.EMETTEUR_SOURCE = LenelSource;
                        txtEMETTEUR.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;

                    case "rdbGastTesttxt":

                        objconfinedSpaceSign.BadgeFirstResult = txtNextLvl.Text;
                        objconfinedSpaceSign.FirstNameFirstResult = objBadge.FNAME;
                        objconfinedSpaceSign.LasttNameFirstResult = objBadge.LNAME;
                        //objconfinedSpaceSign.EMETTEUR_BADGETYPE = objBadge.BADGETYPE;
                        objconfinedSpaceSign.SourceFirstResult = LenelSource;
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

            objconfinedSpaceSign = WPSign.GetConfinedMudSign(Convert.ToString(objconfinedSpace.ConfinedSpaceNumber));
           //if (objconfinedSpace.WorkPermitTypeName ==Com.Suncor.Olt.Common.Domain.WorkPermit.WorkPermitType.HOT.Name)
           // {

                olttblpnlHot.Visible = true;

            //}
            //else
            //{

            //    olttblpnlHot.Visible = false;
            //    oltTableLayoutPanel1.Location = olttblpnlHot.Location;
            //    this.Height = this.Height - olttblpnlHot.Height;
            //}

            if (objconfinedSpaceSign == null)
            {
                objconfinedSpaceSign = new ConfinedSpaceMudSign();
                objconfinedSpaceSign.ConfinedSpaceId = Convert.ToString(objconfinedSpace.ConfinedSpaceNumber);
                objOriginellconfinedSpaceSign = objconfinedSpaceSign.Clone() as ConfinedSpaceMudSign;
                return;
            }
            objOriginellconfinedSpaceSign = objconfinedSpaceSign.Clone() as ConfinedSpaceMudSign;
            if (objconfinedSpaceSign != null)
            {
               
                    //txtVerifier.Text = Convert.ToString(objconfinedSpaceSign.Verifier_FNAME) + " " +
                    //                   Convert.ToString(objconfinedSpaceSign.Verifier_LNAME);
                    //rdbVerifiertxt.Text = Convert.ToString(objconfinedSpaceSign.Verifier_BADGENUMBER);
                txtVerifier.Text = Convert.ToString(objconfinedSpaceSign.Verifier_FNAME) + " " + Convert.ToString(objconfinedSpaceSign.Verifier_LNAME);
                rdbVerifiertxt.Text = Convert.ToString(objconfinedSpaceSign.Verifier_BADGENUMBER);

                txtDETENTEUR.Text = Convert.ToString(objconfinedSpaceSign.DETENTEUR_FNAME) + " " + Convert.ToString(objconfinedSpaceSign.DETENTEUR_LNAME);
                rdbDETENTEURtxt.Text = Convert.ToString(objconfinedSpaceSign.DETENTEUR_BADGENUMBER);

                txtEMETTEUR.Text = Convert.ToString(objconfinedSpaceSign.EMETTEUR_FNAME) + " " + Convert.ToString(objconfinedSpaceSign.EMETTEUR_LNAME);
                rdbEMETTEURtxt.Text = Convert.ToString(objconfinedSpaceSign.EMETTEUR_BADGENUMBER);

                txtGasTest.Text = Convert.ToString(objconfinedSpaceSign.FirstNameFirstResult) + " " + Convert.ToString(objconfinedSpaceSign.LasttNameFirstResult);
                rdbGastTesttxt.Text = Convert.ToString(objconfinedSpaceSign.BadgeFirstResult);

                if (objconfinedSpaceSign.Verifier_SOURCE == null)
                {

                }
                else if (objconfinedSpaceSign.Verifier_SOURCE == LenelSource)
                {
                     rdbVerifierId.Checked = true;
                         

                }
                else if (objconfinedSpaceSign.Verifier_SOURCE == OLTSOURCE)
                {
                    rdbVerifierOLT.Checked = true;
                   
                }
                else
                {
                    rdbVerifierManual.Checked = true;
                    SkipForm = false;
                   
                }


                if (objconfinedSpaceSign.DETENTEUR_SOURCE == null)
                {

                }
                else if (objconfinedSpaceSign.DETENTEUR_SOURCE == LenelSource)
                {
                    rdbDETENTEURId.Checked = true;
                   
                }
                else if (objconfinedSpaceSign.DETENTEUR_SOURCE == OLTSOURCE)
                {
                    rdbDETENTEUROLT.Checked = true;

                }
                else
                {
                    rdbDETENTEURManual.Checked = true;
                    SkipForm = false;
                }

                if (objconfinedSpaceSign.EMETTEUR_SOURCE == null)
                {

                }
                else if (objconfinedSpaceSign.EMETTEUR_SOURCE == LenelSource)
                {
                    rdbEMETTEURId.Checked = true;
                  
                }
                else if (objconfinedSpaceSign.EMETTEUR_SOURCE == OLTSOURCE)
                {
                    rdbEMETTEUROLT.Checked = true;
                    
                }
                else
                {
                    rdbEMETTEURManual.Checked = true;
                    SkipForm = false;
                   
                }

                if (objconfinedSpaceSign.SourceFirstResult == null)
                {

                }
                else if (objconfinedSpaceSign.SourceFirstResult == LenelSource)
                {
                    rdbGasTestId.Checked = true;

                }
                else if (objconfinedSpaceSign.SourceFirstResult == OLTSOURCE)
                {
                    rdbGasTestOLT.Checked = true;

                }
                else
                {
                    rdbGasTestManual.Checked = true;
                    SkipForm = false;
                }
//if (objconfinedSpaceSign.EMETTEUR_LNAME != null)
//                {
//                    rdbEMETTEURId.Enabled = false;
//                    rdbEMETTEURManual.Enabled = false;
//                    rdbEMETTEUROLT.Enabled = false;

//                }
//                if (objconfinedSpaceSign.DETENTEUR_SOURCE != null)
//                {
//                    rdbDETENTEURId.Enabled = false;
//                    rdbDETENTEURManual.Enabled = false;
//                    rdbDETENTEUROLT.Enabled = false;

//                }
//                if (objconfinedSpaceSign.Verifier_SOURCE != null)
//                {
//                    rdbVerifierId.Enabled = false;
//                    rdbVerifierOLT.Enabled = false;
//                    rdbVerifierManual.Enabled = false;
//                }
//                if (objOriginellconfinedSpaceSign.SourceFirstResult != null || objOriginellconfinedSpaceSign.SourceSecondResult != null || objOriginellconfinedSpaceSign.SourceThirdResult !=null || objOriginellconfinedSpaceSign.SourceFourthResult !=null)
//                {
//                    rdbGasTestManual.Enabled = false;
//                    rdbGasTestId.Enabled = false;
//                    rdbGasTestOLT.Enabled = false;
//                }
             
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
            if (objconfinedSpaceSign != null)
            {
                if (!objconfinedSpaceSign.Equals(objOriginellconfinedSpaceSign))
                {
                    WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                    WPSign.SaveConfinedMudsSign(objconfinedSpaceSign);
                }
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSaveIssue_Click(object sender, EventArgs e)
        {
            if (SaveValidate() == false)
            {
                return;
            }
            if (objconfinedSpaceSign != null)
            {
                if (!objconfinedSpaceSign.Equals(objOriginellconfinedSpaceSign))
                {
                    WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                    WPSign.SaveConfinedMudsSign(objconfinedSpaceSign);
                }
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void oltBtnshowDetails_Click(object sender, EventArgs e)
        {
            PriorityPageWorkPermitMudsDetailsPresenter P = new PriorityPageWorkPermitMudsDetailsPresenter(objconfinedSpace.IdValue);
            // Control C = P.GetCOntrolForSign();
            // C.Controls.Find("toolStrip1", true)[0].Visible = false;
            // C.Controls.Find("toolStrip1", true)[1].Visible = false;
            P.Run(this);
            // oltTableLayoutPanel2.Controls.Add(C);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (objconfinedSpaceSign != null && objconfinedSpaceSign.ConfinedSpaceId != null)
            {
                objconfinedSpaceSign.Id = 1;
                EditConfinedSpaceSignHistoryPresenter EP = new EditConfinedSpaceSignHistoryPresenter(objconfinedSpaceSign);
                EP.Run(this);
            }
        }
    }
}
