using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Controls
{

    public partial class GasTestElementDetailsSignrMuds : UserControl
    {
        public WorkPermitMudSign objWorkPermitSign;
        string permitId;
        public enum Source
        {
            OLT = 0,
            Cart = 1,
            Manual = 2
        }

        public GasTestElementDetailsSignrMuds()
        {
            InitializeComponent();
            //oltComboSource1.DataSource = Enum.GetValues(typeof(Source));
            //oltComboSource2.DataSource = Enum.GetValues(typeof(Source));
            //oltComboSource3.DataSource = Enum.GetValues(typeof(Source));
            //oltComboSource4.DataSource = Enum.GetValues(typeof(Source));
        }

      
        public bool showonlyFirstColum
        {
            set
            {
                oltTableLayoutPanel0.Visible = !value;
                oltTableLayoutPanel1.Visible = !value;
                oltTableLayoutPanel2.Visible = !value;
                oltTableLayoutPanel3.Visible = !value;

            }


        }
        public bool FirstSignEnabled
        {
            set
            {
                oltGroupBoxFirstSign.Enabled = value;

            }


        }

        //public string FirstNameFirstResult
        //{
        //    get;
        //    set;
        //}
        //public string LasttNameFirstResult
        //{
        //    get;
        //    set;
        //}
        //public string SourceFirstResult
        //{
        //    get;
        //    set;
        //}

        //public string BadgeFirstResult
        //{
        //    get;
        //    set;
        //}

        //public string FirstNameSecondResult
        //{
        //    get;
        //    set;
        //}
        //public string LasttNameSecondResult
        //{
        //    get;
        //    set;
        //}
        //public string SourceSecondResult
        //{
        //    get;
        //    set;
        //}

        //public string BadgeSecondResult
        //{
        //    get;
        //    set;
        //}

        //public string FirstNameThirdResult
        //{
        //    get;
        //    set;
        //}
        //public string LasttNameThirdResult
        //{
        //    get;
        //    set;
        //}
        //public string SourceThirdResult
        //{
        //    get;
        //    set;
        //}

        //public string BadgeThirdResult
        //{
        //    get;
        //    set;
        //}




        //public string FirstNameFourthResult
        //{
        //    get;
        //    set;
        //}
        //public string LasttNameFourthResult
        //{
        //    get;
        //    set;
        //}
        //public string SourceFourthResult
        //{
        //    get;
        //    set;
        //}

        //public string BadgeFourthResult
        //{
        //    get;
        //    set;
        //}


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

                    case "BadgeIdtxt1":


                        objWorkPermitSign.BadgeFirstResult = txtNextLvl.Text;
                        objWorkPermitSign.FirstNameFirstResult = objBadge.FNAME;
                        objWorkPermitSign.LasttNameFirstResult = objBadge.LNAME;
                        txtName1.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;

                    case "BadgeIdtxt2":

                        objWorkPermitSign.BadgeSecondResult = txtNextLvl.Text;
                        objWorkPermitSign.FirstNameSecondResult = objBadge.FNAME;
                        objWorkPermitSign.LasttNameSecondResult = objBadge.LNAME;
                        txtName2.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;
                    case "BadgeIdtxt3":

                        objWorkPermitSign.BadgeThirdResult = txtNextLvl.Text;
                        objWorkPermitSign.FirstNameThirdResult = objBadge.FNAME;
                        objWorkPermitSign.LasttNameThirdResult = objBadge.LNAME;
                        txtName3.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;

                    case "BadgeIdtxt4":

                        objWorkPermitSign.BadgeFourthResult = txtNextLvl.Text;
                        objWorkPermitSign.FirstNameFourthResult = objBadge.FNAME;
                        objWorkPermitSign.LasttNameFourthResult = objBadge.LNAME;
                        txtName4.Text = objBadge.FNAME + " " + objBadge.LNAME;

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
        public void SetValue(string permitId)
        {
            WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();

            objWorkPermitSign = WPSign.GetMudSign(permitId);
            objWorkPermitSign = objWorkPermitSign == null ? new WorkPermitMudSign() : objWorkPermitSign;
            objWorkPermitSign.WorkPermitId = permitId;

          if( objWorkPermitSign.SourceFirstResult=="LENEL")
          {
              rdbLenel1.Checked = true;
          }
          else if (objWorkPermitSign.SourceFirstResult=="OLT")
          {
              rdbOLT1.Checked = true;
          }
            else
          {
              rdbManual1.Checked = true;
          }
          if (objWorkPermitSign.SourceSecondResult == "LENEL")
          {
              rdbLenel2.Checked = true;
          }
          else if (objWorkPermitSign.SourceSecondResult == "OLT")
          {
              rdbOLT2.Checked = true;
          }
          else
          {
              rdbManual2.Checked = true;
          }

          if (objWorkPermitSign.SourceThirdResult == "LENEL")
          {
              rdbLenel3.Checked = true;
          }
          else if (objWorkPermitSign.SourceThirdResult == "OLT")
          {
              rdbOLT3.Checked = true;
          }
          else
          {
              rdbManual3.Checked = true;
          }
          if (objWorkPermitSign.SourceFourthResult == "LENEL")
          {
              rdbLenel4.Checked = true;
          }
          else if (objWorkPermitSign.SourceFourthResult == "OLT")
          {
              rdbOLT4.Checked = true;
          }
          else
          {
              rdbManual4.Checked = true;

          }
           

            txtName1.Text = objWorkPermitSign.FirstNameFirstResult + " " + objWorkPermitSign.LasttNameFirstResult;
            txtName2.Text = objWorkPermitSign.FirstNameSecondResult + " " + objWorkPermitSign.LasttNameSecondResult;
            txtName3.Text = objWorkPermitSign.FirstNameThirdResult + " " + objWorkPermitSign.LasttNameThirdResult;
            txtName4.Text = objWorkPermitSign.FirstNameFourthResult + " " + objWorkPermitSign.LasttNameFourthResult;
            BadgeIdtxt1.Text = objWorkPermitSign.BadgeFirstResult;
            BadgeIdtxt2.Text = objWorkPermitSign.BadgeSecondResult;
            BadgeIdtxt3.Text = objWorkPermitSign.BadgeThirdResult;
            BadgeIdtxt4.Text = objWorkPermitSign.BadgeFourthResult;

        }

        public bool Validate()
        {
            firstResultWarningProvider.Clear();
            if (rdbLenel1.Checked)
            {
                if (txtName1.Text == "")
                {
                    firstResultWarningProvider.SetError(txtName1, "Name can not be Bbank!");
                    return false;
                }
            }
            if (rdbLenel2.Checked)
            {
                if (txtName2.Text == "")
                {
                    firstResultWarningProvider.SetError(txtName2, "Name can not be Bbank!");
                    return false;
                }
            }

            if (rdbLenel3.Checked)
            {
                if (txtName3.Text == "")
                {
                    firstResultWarningProvider.SetError(txtName3, "Name can not be Bbank!");
                    return false;
                }
            }
            if (rdbLenel4.Checked)
            {
                if (txtName4.Text == "")
                {
                    firstResultWarningProvider.SetError(txtName4, "Name can not be Bbank!");
                    return false;
                }
            }
            return true;

        }


        private void GasTestElementDetailsSignrMuds_Load(object sender, EventArgs e)
        {


        }

        private void rdbManual1_Click(object sender, EventArgs e)
        {
            if (objWorkPermitSign == null)
            {
                return;
            }
            OltRadioButton control = sender as OltRadioButton;
                    if (control.Name == "rdbOLT1")
                    {
                        objWorkPermitSign.FirstNameFirstResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        objWorkPermitSign.LasttNameFirstResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        objWorkPermitSign.SourceFirstResult = "OLT";
                        txtName1.Text = objWorkPermitSign.FirstNameFirstResult + " " + objWorkPermitSign.LasttNameFirstResult;
                        BadgeIdtxt1.Text = "";
                        objWorkPermitSign.BadgeFirstResult = "";
                    }
                    else if (control.Name == "rdbLenel1")
                    {
                        txtName1.Text = "";
                        BadgeIdtxt1.Focus();
                        objWorkPermitSign.SourceFirstResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual1")
                    {
                        objWorkPermitSign.FirstNameFirstResult = "";
                        objWorkPermitSign.LasttNameFirstResult = "";
                        objWorkPermitSign.SourceFirstResult = "Manual";
                        txtName1.Text = "";
                        BadgeIdtxt1.Text = "";
                        objWorkPermitSign.BadgeFirstResult = "";
                    }
                    

               
                    if (control.Name == "rdbOLT2")
                    {
                        objWorkPermitSign.FirstNameSecondResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        objWorkPermitSign.LasttNameSecondResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        txtName2.Text = objWorkPermitSign.FirstNameSecondResult + " " + objWorkPermitSign.LasttNameSecondResult;
                        objWorkPermitSign.SourceSecondResult = "OLT";

                        BadgeIdtxt2.Text = "";
                        objWorkPermitSign.BadgeSecondResult = "";

                    }
                    else if (control.Name == "rdbLenel2")
                    {
                        txtName2.Text = "";
                        BadgeIdtxt2.Focus();
                        objWorkPermitSign.SourceSecondResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual2")
                    {
                        objWorkPermitSign.FirstNameSecondResult = "";
                        objWorkPermitSign.LasttNameSecondResult = "";
                        txtName2.Text = "";
                        objWorkPermitSign.SourceSecondResult = "Manual";
                        BadgeIdtxt2.Text = "";
                        objWorkPermitSign.BadgeSecondResult = "";
                    }
                   

               
                    if (control.Name == "rdbOLT3")
                    {
                        objWorkPermitSign.FirstNameThirdResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        objWorkPermitSign.LasttNameThirdResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        txtName3.Text = objWorkPermitSign.FirstNameThirdResult + " " + objWorkPermitSign.LasttNameThirdResult;
                        objWorkPermitSign.SourceThirdResult = "OLT";
                        BadgeIdtxt3.Text = "";
                        objWorkPermitSign.BadgeThirdResult = "";

                    }
                    else if (control.Name == "rdbLenel3")
                    {
                        txtName3.Text = "";
                        BadgeIdtxt3.Focus();
                        objWorkPermitSign.SourceThirdResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual3")
                    {
                        objWorkPermitSign.FirstNameThirdResult = "";
                        objWorkPermitSign.LasttNameThirdResult = "";
                        txtName3.Text = "";
                        objWorkPermitSign.SourceThirdResult = "Manual";
                        BadgeIdtxt3.Text = "";
                        objWorkPermitSign.BadgeThirdResult = "";
                    }
                  

              

                    if (control.Name == "rdbOLT4")
                    {
                        objWorkPermitSign.FirstNameFourthResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        objWorkPermitSign.LasttNameFourthResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        txtName4.Text = objWorkPermitSign.FirstNameFourthResult + " " + objWorkPermitSign.LasttNameFourthResult;
                        objWorkPermitSign.SourceFourthResult = "OLT";
                        BadgeIdtxt4.Text = "";
                        objWorkPermitSign.BadgeFourthResult = "";

                    }
                    else if (control.Name == "rdbLenel4")
                    {
                        txtName4.Text = "";
                        BadgeIdtxt4.Focus();
                        objWorkPermitSign.SourceFourthResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual4")
                    {
                        objWorkPermitSign.FirstNameFourthResult = "";
                        objWorkPermitSign.LasttNameFourthResult = "";
                        txtName4.Text = "";
                        objWorkPermitSign.SourceFourthResult = "Manual";
                        BadgeIdtxt4.Text = "";
                        objWorkPermitSign.BadgeFourthResult = "";
                    }
                   
            
        }
    }
}