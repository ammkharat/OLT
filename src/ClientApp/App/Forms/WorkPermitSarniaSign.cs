﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters.History;
namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitSarniaSign : BaseForm
    {
        WorkPermitDTO objworkPermit;
        WorkPermitSign objWorkPermitSign;
        WorkPermitSign objOriginellWorkPermitSign;
        string LenelSource = "LENEL";
        string OLTSOURCE = "OLT";
        string ManualSource = "Manual";
        bool SkipForm = true;
        public WorkPermitSarniaSign()
        {
            InitializeComponent();

            //Added By Vibhor : RITM0574875 - We need to Limit who can sign as a next level permit issuer by Supervisor access only.
            if (!ClientSession.GetUserContext().UserRoleElements.Role.Name.Contains("Supervisor"))
            {
                rdbNextLvlIssuerManual.Enabled = false;
                rdbNextLvlIssuerOLT.Enabled = false;
                rdbNextLvlIssuerId.Enabled = false;
            }
        }
        public WorkPermitSarniaSign(WorkPermitDTO workPermit)
        {
            InitializeComponent();

            //Logic To add Workpermit details Control
            objworkPermit = workPermit;

            this.Text = this.Text + " Permit Number:-" + objworkPermit.PermitNumber;
            //Load Data
            LoadData();

            //Added By Vibhor : RITM0574875 - We need to Limit who can sign as a next level permit issuer by Supervisor access only.
            if (!ClientSession.GetUserContext().UserRoleElements.Role.Name.Contains("Supervisor"))
            {
                rdbNextLvlIssuerManual.Enabled = false;
                rdbNextLvlIssuerOLT.Enabled = false;
                rdbNextLvlIssuerId.Enabled = false;
            }


        }
        private void WorkPermitSarniaSign_Load(object sender, EventArgs e)
        {

        }

        private void rdbNextLvlIssuerId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNextLvlIssuerId.Checked)
            {
                rdbNextLvlIssuertxt.Text = "";
                txtNextLvlIssuer.Text = "";
                rdbNextLvlIssuertxt.Enabled = true;
                rdbNextLvlIssuertxt.ReadOnly = true;
                //  rdbNextLvlIssuertxt.BackColor = Color.White;
                rdbNextLvlIssuertxt.Focus();
            }

        }

        private void rdbReceiverId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReceiverId.Checked)
            {
                rdbReceivertxt.Text = "";
                txtReceiver.Text = "";
                rdbReceivertxt.Enabled = true;
                rdbReceivertxt.ReadOnly = true;
                //  rdbReceivertxt.BackColor = Color.White;
                rdbReceivertxt.Focus();
            }

        }

        private void rdbCrossZoneAuthId_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbCrossZoneAuthId.Checked)
            {
                rdbCrossZoneAuthtxt.Text = "";
                txtCrossZoneAuth.Text = "";
                rdbCrossZoneAuthtxt.Enabled = true;
                rdbCrossZoneAuthtxt.ReadOnly = true;
                // rdbCrossZoneAuthtxt.BackColor = Color.White;
                rdbCrossZoneAuthtxt.Focus();
            }

        }

        int i = 0;
        private void txtNextLvlIssuer_KeyDown(object sender, KeyEventArgs e)
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

                    case "rdbNextLvlIssuertxt":

                        if (objBadge.FNAME == null)
                        {
                            MessageBox.Show("Badge Info Not Found");
                            txtNextLvlIssuer.Text = "";
                            return;
                        }

                        objWorkPermitSign.NEXT_LVL_ISSUER_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.NEXT_LVL_ISSUER_FNAME = objBadge.FNAME;
                        objWorkPermitSign.NEXT_LVL_ISSUER_LNAME = objBadge.LNAME;
                        objWorkPermitSign.NEXT_LVL_ISSUER_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE = LenelSource;
                        txtNextLvlIssuer.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;

                    case "rdbReceivertxt":

                        objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.PERMIT_RECEIVER_FNAME = objBadge.FNAME;
                        objWorkPermitSign.PERMIT_RECEIVER_LNAME = objBadge.LNAME;
                        objWorkPermitSign.PERMIT_RECEIVER_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.PERMIT_RECEIVER_SOURCE = LenelSource;
                        txtReceiver.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;

                    case "rdbCrossZoneAuthtxt":

                        objWorkPermitSign.CROSS_ZONE_AUTHO_BADGENuMBER = txtNextLvl.Text;
                        objWorkPermitSign.CROSS_ZONE_AUTHO_FNAME = objBadge.FNAME;
                        objWorkPermitSign.CROSS_ZONE_AUTHO_LNAME = objBadge.LNAME;
                        objWorkPermitSign.CROSS_ZONE_AUTHO_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE = LenelSource;
                        txtCrossZoneAuth.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;


                    case "rdbimmediateAreatxt":
                        objWorkPermitSign.IMMIDIATE_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.IMMIDIATE_FNAME = objBadge.FNAME;
                        objWorkPermitSign.IMMIDIATE_LNAME = objBadge.LNAME;
                        objWorkPermitSign.IMMIDIATE_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.IMMIDIATE_SOURCE = LenelSource;
                        txtImmediateArea.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;


                    case "rdbConfinedSpacetxt":

                        objWorkPermitSign.CONFINED_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.CONFINED_FNAME = objBadge.FNAME;
                        objWorkPermitSign.CONFINED_LNAME = objBadge.LNAME;
                        objWorkPermitSign.CONFINED_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.CONFINED_SOURCE = LenelSource;
                        txtConfinedSpace.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;


                    case "rdbissuetxt":

                        objWorkPermitSign.ISSUER_BADGENUMBER = txtNextLvl.Text;
                        objWorkPermitSign.ISSUER_FNAME = objBadge.FNAME;
                        objWorkPermitSign.ISSUER_LNAME = objBadge.LNAME;
                        objWorkPermitSign.ISSUER_BADGETYPE = objBadge.BADGETYPE;
                        objWorkPermitSign.ISSUER_SOURCE = LenelSource;
                        txtIssuer.Text = objBadge.FNAME + " " + objBadge.LNAME;
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

        private DomainListView<GasTestElementResultDTO> gasTestElementResultsGrid;
        private void LoadData()
        {
            WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();

            objWorkPermitSign = WPSign.GetSign(objworkPermit.PermitNumber);

            bool? IsCoauthorizationRequired;
            Time ConfinedSpaceTestTime;
            Time ImmediateAreaTestTime;
            List<GasTestElementResultDTO> lst = WPSign.LoadWorkItemGasTests(objworkPermit.IdValue, out IsCoauthorizationRequired, out ConfinedSpaceTestTime, out ImmediateAreaTestTime);
            if (objWorkPermitSign == null)
            {
                objWorkPermitSign = new WorkPermitSign();
                objWorkPermitSign.WorkPermitId = objworkPermit.PermitNumber;

            }
            objOriginellWorkPermitSign = objWorkPermitSign.Clone() as WorkPermitSign;
            if (objWorkPermitSign != null)
            {
                txtIssuer.Text = Convert.ToString(objWorkPermitSign.ISSUER_FNAME) + " " + Convert.ToString(objWorkPermitSign.ISSUER_LNAME);
                rdbissuetxt.Text = Convert.ToString(objWorkPermitSign.ISSUER_BADGENUMBER);

                txtNextLvlIssuer.Text = Convert.ToString(objWorkPermitSign.NEXT_LVL_ISSUER_FNAME) + " " + Convert.ToString(objWorkPermitSign.NEXT_LVL_ISSUER_LNAME);
                rdbNextLvlIssuertxt.Text = Convert.ToString(objWorkPermitSign.NEXT_LVL_ISSUER_BADGENUMBER);

                txtReceiver.Text = Convert.ToString(objWorkPermitSign.PERMIT_RECEIVER_FNAME) + " " + Convert.ToString(objWorkPermitSign.PERMIT_RECEIVER_LNAME);
                rdbReceivertxt.Text = Convert.ToString(objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER);

                txtCrossZoneAuth.Text = Convert.ToString(objWorkPermitSign.CROSS_ZONE_AUTHO_FNAME) + " " + Convert.ToString(objWorkPermitSign.CROSS_ZONE_AUTHO_LNAME);
                rdbCrossZoneAuthtxt.Text = Convert.ToString(objWorkPermitSign.CROSS_ZONE_AUTHO_BADGENuMBER);

                if (objWorkPermitSign.ISSUER_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.ISSUER_SOURCE == LenelSource)
                {
                    rdbIssuerId.Checked = true;

                }
                else if (objWorkPermitSign.ISSUER_SOURCE == OLTSOURCE)
                {
                    rdbissueOLT.Checked = true;

                }
                else
                {
                    rdbissueManual.Checked = true;
                    SkipForm = false;
                }


                if (objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE == LenelSource)
                {
                    rdbNextLvlIssuerId.Checked = true;

                }
                else if (objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE == OLTSOURCE)
                {
                    rdbNextLvlIssuerOLT.Checked = true;

                }
                else
                {
                    rdbNextLvlIssuerManual.Checked = true;
                    SkipForm = false;
                }

                if (objWorkPermitSign.PERMIT_RECEIVER_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.PERMIT_RECEIVER_SOURCE == LenelSource)
                {
                    rdbReceiverId.Checked = true;

                }
                else if (objWorkPermitSign.PERMIT_RECEIVER_SOURCE == OLTSOURCE)
                {
                    rdbReceiverOLT.Checked = true;

                }
                else
                {
                    rdbReceiverManual.Checked = true;
                    SkipForm = false;
                }


                if (objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE == LenelSource)
                {

                    rdbCrossZoneAuthId.Checked = true;
                }
                else if (objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE == OLTSOURCE)
                {

                    rdbCrossZoneAuthOLT.Checked = true;
                }
                else
                {
                    if (IsCoauthorizationRequired != null && IsCoauthorizationRequired == true)
                    {
                        SkipForm = false;
                    }
                    rdbCrossZoneAuthManual.Checked = true;
                }
            }


            //Set Gas Test Inforamtion
            gasTestElementResultsGrid = new DomainListView<GasTestElementResultDTO>(new GasTestElementResulDTOListViewRenderer(), false) { Dock = DockStyle.Fill };
            gasTestElementResultsPanel.Controls.Add(gasTestElementResultsGrid);
            gasTestElementResultsGrid.ItemList = lst;

            confinedSpaceTestTimeEditor.Value = ConfinedSpaceTestTime;
            immediateAreaTestTimeEditor.Value = ImmediateAreaTestTime;

            if (gasTestElementResultsGrid.ItemList.Count == 0)
            {
                this.Height = this.Height - gasTestTestResultsGroupBox.Height;
                oltExplorerBar1.Height -= (gasTestTestResultsGroupBox.Height - 45);
                gasTestTestResultsGroupBox.Height = 0;
                gasTestTestResultsGroupBox.Visible = false;
                oltExplorerBar1.Groups[2].Visible = false;



            }
            else
            {
                if (ConfinedSpaceTestTime == null)
                {
                    olttblLayoutGasTest.RowStyles[1].Height = 0;

                }
                if (ImmediateAreaTestTime == null)
                {

                    olttblLayoutGasTest.RowStyles[0].Height = 0;

                }

                txtImmediateArea.Text = Convert.ToString(objWorkPermitSign.IMMIDIATE_FNAME) + " " + Convert.ToString(objWorkPermitSign.IMMIDIATE_LNAME);
                rdbimmediateAreatxt.Text = Convert.ToString(objWorkPermitSign.IMMIDIATE_BADGENUMBER);


                txtConfinedSpace.Text = Convert.ToString(objWorkPermitSign.CONFINED_FNAME) + " " + Convert.ToString(objWorkPermitSign.CONFINED_LNAME);
                rdbConfinedSpacetxt.Text = Convert.ToString(objWorkPermitSign.CONFINED_BADGENUMBER);

                if (objWorkPermitSign.IMMIDIATE_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.IMMIDIATE_SOURCE == LenelSource)
                {
                    rdbimmediateAreaId.Checked = true;
                }
                else if (objWorkPermitSign.IMMIDIATE_SOURCE == OLTSOURCE)
                {
                    rdbimmediateAreaOLT.Checked = true;
                }

                else
                {
                    if (ImmediateAreaTestTime != null)
                    {
                        SkipForm = false;
                    }

                    rdbimmediateAreaManual.Checked = true;
                }

                if (objWorkPermitSign.CONFINED_SOURCE == null)
                {

                }
                else if (objWorkPermitSign.CONFINED_SOURCE == LenelSource)
                {
                    rdbConfinedSpaceId.Checked = true;
                }
                else if (objWorkPermitSign.CONFINED_SOURCE == OLTSOURCE)
                {
                    rdbConfinedSpaceOLT.Checked = true;
                }

                else
                {
                    if (ConfinedSpaceTestTime != null)
                    {
                        SkipForm = false;
                    }
                    rdbConfinedSpaceManual.Checked = true;
                }

            }
            if (IsCoauthorizationRequired == null || IsCoauthorizationRequired == false)
            {
                this.Height = this.Height - olttblpnlCrossAutho.Height;
                oltExplorerBar1.Height -= olttblpnlCrossAutho.Height;

                // olttblpnlCrossAutho.Height = 0;
                olttblpnlCrossAutho.Visible = false;
                oltExplorerBar1.Groups[1].Visible = false;


            }


        }
        private bool Validate()
        {
            errorProvider1.Clear();


            if (rdbIssuerId.Checked == false && rdbissueManual.Checked == false && rdbissueOLT.Checked == false)
            {
                errorProvider1.SetError(rdbissuetxt, "Please select signature option");
                return false;
            }

            if (rdbReceiverId.Checked == false && rdbReceiverManual.Checked == false && rdbReceiverOLT.Checked == false)
            {
                errorProvider1.SetError(rdbReceivertxt, "Please select signature option");
                return false;
            }

            if (rdbNextLvlIssuerId.Checked == false && rdbNextLvlIssuerManual.Checked == false && rdbNextLvlIssuerOLT.Checked == false)
            {
                errorProvider1.SetError(rdbNextLvlIssuertxt, "Please select signature option");
                return false;
            }
            if (rdbCrossZoneAuthId.Checked == false && rdbCrossZoneAuthManual.Checked == false && rdbCrossZoneAuthOLT.Checked == false && olttblpnlCrossAutho.Visible == true)
            {
                errorProvider1.SetError(rdbCrossZoneAuthtxt, "Please select signature option");
                return false;
            }
            if (rdbConfinedSpaceId.Checked == false && rdbConfinedSpaceManual.Checked == false && rdbConfinedSpaceOLT.Checked == false && olttblLayoutGasTest.RowStyles[1].Height != 0 && olttblLayoutGasTest.Visible)
            {
                errorProvider1.SetError(rdbConfinedSpacetxt, "Please select signature option");
                return false;
            }
            if (rdbimmediateAreaId.Checked == false && rdbimmediateAreaManual.Checked == false && rdbimmediateAreaOLT.Checked == false && olttblLayoutGasTest.RowStyles[0].Height != 0 && olttblLayoutGasTest.Visible)
            {
                errorProvider1.SetError(rdbimmediateAreatxt, "Please select signature option");
                return false;
            }





            if (rdbReceiverId.Checked == true && rdbReceivertxt.Text == "")
            {
                errorProvider1.SetError(rdbReceivertxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbConfinedSpaceId.Checked == true && rdbConfinedSpacetxt.Text == "")
            {
                errorProvider1.SetError(rdbConfinedSpacetxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbNextLvlIssuerId.Checked == true && rdbNextLvlIssuertxt.Text == "")
            {
                errorProvider1.SetError(rdbNextLvlIssuertxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbCrossZoneAuthId.Checked == true && rdbCrossZoneAuthtxt.Text == "")
            {
                errorProvider1.SetError(rdbCrossZoneAuthtxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbimmediateAreaId.Checked == true && rdbimmediateAreatxt.Text == "")
            {
                errorProvider1.SetError(rdbimmediateAreatxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            return true;
        }
        private bool SaveValidate()
        {
            errorProvider1.Clear();


            if (rdbReceiverId.Checked == true && rdbReceivertxt.Text == "")
            {
                errorProvider1.SetError(rdbReceivertxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbConfinedSpaceId.Checked == true && rdbConfinedSpacetxt.Text == "")
            {
                errorProvider1.SetError(rdbConfinedSpacetxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbNextLvlIssuerId.Checked == true && rdbNextLvlIssuertxt.Text == "")
            {
                errorProvider1.SetError(rdbNextLvlIssuertxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbCrossZoneAuthId.Checked == true && rdbCrossZoneAuthtxt.Text == "")
            {
                errorProvider1.SetError(rdbCrossZoneAuthtxt, "Please Scan  Badge or Select Manual option");
                return false;
            }
            if (rdbimmediateAreaId.Checked == true && rdbimmediateAreatxt.Text == "")
            {
                errorProvider1.SetError(rdbimmediateAreatxt, "Please Scan  Badge or Select Manual option");
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
                    WPSign.SaveSign(objWorkPermitSign);
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
            if (Validate() == false)
            {
                return;
            }
            if (objWorkPermitSign != null)
            {
                if (!objWorkPermitSign.Equals(objOriginellWorkPermitSign))
                {
                    WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
                    WPSign.SaveSign(objWorkPermitSign);
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
            SearchSarniaWorkpemitPresenter P = new SearchSarniaWorkpemitPresenter(objworkPermit.IdValue, true);
            Control C = P.GetCOntrolForSign();
            C.Controls.Find("toolStrip1", true)[0].Visible = false;
            C.Controls.Find("toolStrip1", true)[1].Visible = false;
            P.Run(this);
            // oltTableLayoutPanel2.Controls.Add(C);
        }

        private void rdbimmediateAreaId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbimmediateAreaId.Checked)
            {
                txtImmediateArea.Text = "";
                rdbimmediateAreatxt.Text = "";
                rdbimmediateAreatxt.Enabled = true;
                rdbimmediateAreatxt.ReadOnly = true;
                // rdbimmediateAreatxt.BackColor = Color.White;
                rdbimmediateAreatxt.Focus();
            }

        }

        private void rdbConfinedSpaceId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbConfinedSpaceId.Checked)
            {
                txtConfinedSpace.Text = "";
                rdbConfinedSpacetxt.Text = "";
                rdbConfinedSpacetxt.Enabled = true;
                rdbConfinedSpacetxt.ReadOnly = true;
                // rdbConfinedSpacetxt.BackColor = Color.White;
                rdbConfinedSpacetxt.Focus();
            }

        }

        private void rdbCrossZoneAuthId_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbCrossZoneAuthId.Checked)
            {
                txtCrossZoneAuth.Text = "";
                rdbCrossZoneAuthtxt.Text = "";
                rdbCrossZoneAuthtxt.Enabled = true;
                rdbCrossZoneAuthtxt.ReadOnly = true;
                //rdbCrossZoneAuthtxt.BackColor = Color.White;
                rdbCrossZoneAuthtxt.Focus();
            }

        }

        private void rdbissueOLT_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton txtNextLvl = sender as RadioButton;
            var User = Client.ClientSession.GetUserContext().User;
            switch (txtNextLvl.Name)
            {

                case "rdbNextLvlIssuerOLT":

                    objWorkPermitSign.NEXT_LVL_ISSUER_BADGENUMBER = "";
                    objWorkPermitSign.NEXT_LVL_ISSUER_BADGETYPE = "";

                    objWorkPermitSign.NEXT_LVL_ISSUER_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.NEXT_LVL_ISSUER_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE = OLTSOURCE; ;
                    txtNextLvlIssuer.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbNextLvlIssuertxt.Text = "";
                    rdbNextLvlIssuertxt.Enabled = false;
                    // rdbNextLvlIssuertxt.BackColor = Color.Empty;

                    break;

                case "rdbReceiverOLT":
                    objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER = "";
                    objWorkPermitSign.PERMIT_RECEIVER_BADGETYPE = "";

                    objWorkPermitSign.PERMIT_RECEIVER_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.PERMIT_RECEIVER_LNAME = Convert.ToString(User.LastName).ToUpper();
                    objWorkPermitSign.PERMIT_RECEIVER_SOURCE = OLTSOURCE;
                    txtReceiver.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbReceivertxt.Text = "";
                    rdbReceivertxt.Enabled = false;
                    // rdbReceivertxt.BackColor = Color.Empty;

                    break;

                case "rdbCrossZoneAuthOLT":

                    objWorkPermitSign.CROSS_ZONE_AUTHO_BADGENuMBER = "";
                    objWorkPermitSign.CROSS_ZONE_AUTHO_BADGETYPE = "";

                    objWorkPermitSign.CROSS_ZONE_AUTHO_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.CROSS_ZONE_AUTHO_LNAME = Convert.ToString(User.LastName).ToUpper();

                    objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE = OLTSOURCE;
                    txtCrossZoneAuth.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbCrossZoneAuthtxt.Text = "";
                    rdbCrossZoneAuthtxt.Enabled = false;
                    // rdbCrossZoneAuthtxt.BackColor = Color.Empty;
                    break;


                case "rdbimmediateAreaOLT":

                    objWorkPermitSign.IMMIDIATE_BADGENUMBER = "";
                    objWorkPermitSign.IMMIDIATE_BADGETYPE = "";
                    objWorkPermitSign.IMMIDIATE_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.IMMIDIATE_LNAME = Convert.ToString(User.LastName).ToUpper();

                    objWorkPermitSign.IMMIDIATE_SOURCE = OLTSOURCE;
                    txtImmediateArea.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbimmediateAreatxt.Text = "";
                    rdbimmediateAreatxt.Enabled = false;
                    // rdbimmediateAreatxt.BackColor = Color.Empty;
                    break;


                case "rdbConfinedSpaceOLT":

                    objWorkPermitSign.CONFINED_BADGENUMBER = "";
                    objWorkPermitSign.CONFINED_BADGETYPE = "";

                    objWorkPermitSign.CONFINED_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.CONFINED_LNAME = Convert.ToString(User.LastName).ToUpper();

                    objWorkPermitSign.CONFINED_SOURCE = OLTSOURCE;
                    txtConfinedSpace.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbConfinedSpacetxt.Text = "";
                    rdbConfinedSpacetxt.Enabled = false;
                    // rdbConfinedSpacetxt.BackColor = Color.Empty;

                    break;


                case "rdbissueOLT":

                    objWorkPermitSign.ISSUER_BADGENUMBER = "";
                    objWorkPermitSign.ISSUER_BADGETYPE = "";

                    objWorkPermitSign.ISSUER_FNAME = Convert.ToString(User.FirstName).ToUpper();
                    objWorkPermitSign.ISSUER_LNAME = Convert.ToString(User.LastName).ToUpper();

                    objWorkPermitSign.ISSUER_SOURCE = OLTSOURCE;
                    txtIssuer.Text = Convert.ToString(User.FirstName).ToUpper() + " " + Convert.ToString(User.LastName).ToUpper();
                    rdbissuetxt.Text = "";
                    rdbissuetxt.Enabled = false;
                    // rdbissuetxt.BackColor = Color.Empty;
                    break;

            }
        }

        private void rdbIssuerId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIssuerId.Checked)
            {
                txtIssuer.Text = "";
                rdbissuetxt.Text = "";
                rdbissuetxt.Enabled = true;

                //  rdbissuetxt.BackColor = Color.White;
                rdbissuetxt.ReadOnly = true;
                rdbissuetxt.Focus();
            }

        }

        private void rdbissueManual_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton txtNextLvl = sender as RadioButton;

            switch (txtNextLvl.Name)
            {

                case "rdbNextLvlIssuerManual":


                    txtNextLvlIssuer.Text = "";
                    rdbNextLvlIssuertxt.Text = "";
                    rdbNextLvlIssuertxt.Enabled = false;
                    // rdbNextLvlIssuertxt.BackColor = Color.Empty;
                    objWorkPermitSign.NEXT_LVL_ISSUER_BADGENUMBER = null;
                    objWorkPermitSign.NEXT_LVL_ISSUER_BADGETYPE = null;
                    objWorkPermitSign.NEXT_LVL_ISSUER_FNAME = null;
                    objWorkPermitSign.NEXT_LVL_ISSUER_LNAME = null;
                    objWorkPermitSign.NEXT_LVL_ISSUER_SOURCE = ManualSource;

                    break;

                case "rdbReceiverManual":

                    rdbReceivertxt.Text = "";
                    rdbReceivertxt.Enabled = false;
                    // rdbReceivertxt.BackColor = Color.Empty;
                    txtReceiver.Text = "";
                    objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER = null;
                    objWorkPermitSign.PERMIT_RECEIVER_BADGETYPE = null;
                    objWorkPermitSign.PERMIT_RECEIVER_FNAME = null;
                    objWorkPermitSign.PERMIT_RECEIVER_LNAME = null;
                    objWorkPermitSign.PERMIT_RECEIVER_SOURCE = ManualSource;


                    break;

                case "rdbCrossZoneAuthManual":


                    rdbCrossZoneAuthtxt.Text = "";
                    rdbCrossZoneAuthtxt.Enabled = false;
                    // rdbCrossZoneAuthtxt.BackColor = Color.Empty;
                    txtCrossZoneAuth.Text = "";

                    objWorkPermitSign.CROSS_ZONE_AUTHO_FNAME = null;
                    objWorkPermitSign.CROSS_ZONE_AUTHO_LNAME = null;
                    objWorkPermitSign.CROSS_ZONE_AUTHO_BADGENuMBER = null;
                    objWorkPermitSign.CROSS_ZONE_AUTHO_BADGETYPE = null;
                    objWorkPermitSign.CROSS_ZONE_AUTHO_SOURCE = ManualSource;

                    break;


                case "rdbimmediateAreaManual":

                    rdbimmediateAreatxt.Text = "";
                    rdbimmediateAreatxt.Enabled = false;
                    // rdbimmediateAreatxt.BackColor = Color.Empty;
                    txtImmediateArea.Text = "";

                    objWorkPermitSign.IMMIDIATE_FNAME = null;
                    objWorkPermitSign.IMMIDIATE_LNAME = null;
                    objWorkPermitSign.IMMIDIATE_BADGENUMBER = null;
                    objWorkPermitSign.IMMIDIATE_BADGETYPE = null;

                    objWorkPermitSign.IMMIDIATE_SOURCE = ManualSource;

                    break;


                case "rdbConfinedSpaceManual":


                    rdbConfinedSpacetxt.Text = "";
                    // rdbConfinedSpacetxt.BackColor = Color.Empty;
                    rdbConfinedSpacetxt.Enabled = false;
                    txtConfinedSpace.Text = "";

                    objWorkPermitSign.CONFINED_FNAME = null;
                    objWorkPermitSign.CONFINED_LNAME = null;
                    objWorkPermitSign.CONFINED_BADGENUMBER = null;
                    objWorkPermitSign.CONFINED_BADGETYPE = null;

                    objWorkPermitSign.CONFINED_SOURCE = ManualSource;

                    break;


                case "rdbissueManual":


                    rdbissuetxt.Text = "";
                    // rdbissuetxt.BackColor = Color.Empty;
                    rdbissuetxt.Enabled = false;
                    txtIssuer.Text = "";

                    objWorkPermitSign.ISSUER_FNAME = null;
                    objWorkPermitSign.ISSUER_LNAME = null;
                    objWorkPermitSign.ISSUER_BADGENUMBER = null;
                    objWorkPermitSign.ISSUER_BADGETYPE = null;

                    objWorkPermitSign.ISSUER_SOURCE = ManualSource;

                    break;

            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (objWorkPermitSign != null && objWorkPermitSign.WorkPermitId != null)
            {
                objWorkPermitSign.Id = 1;
                EditWorkPermitSignHistoryPresenter EP = new EditWorkPermitSignHistoryPresenter(objWorkPermitSign);
                EP.Run(this);
            }
        }
    }
}
