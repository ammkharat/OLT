using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Controls
{

    public partial class GasTestElementDetailsconfinedSpaceSignMuds : UserControl
    {
        public ConfinedSpaceMudSign confinedSpaceSign;
        string permitId;
        public enum Source
        {
            OLT = 0,
            Cart = 1,
            Manual = 2
        }

        public GasTestElementDetailsconfinedSpaceSignMuds()
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


                        confinedSpaceSign.BadgeFirstResult = txtNextLvl.Text;
                        confinedSpaceSign.FirstNameFirstResult = objBadge.FNAME;
                        confinedSpaceSign.LasttNameFirstResult = objBadge.LNAME;
                        txtName1.Text = objBadge.FNAME + " " + objBadge.LNAME;
                        break;

                    case "BadgeIdtxt2":

                        confinedSpaceSign.BadgeSecondResult = txtNextLvl.Text;
                        confinedSpaceSign.FirstNameSecondResult = objBadge.FNAME;
                        confinedSpaceSign.LasttNameSecondResult = objBadge.LNAME;
                        txtName2.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;
                    case "BadgeIdtxt3":

                        confinedSpaceSign.BadgeThirdResult = txtNextLvl.Text;
                        confinedSpaceSign.FirstNameThirdResult = objBadge.FNAME;
                        confinedSpaceSign.LasttNameThirdResult = objBadge.LNAME;
                        txtName3.Text = objBadge.FNAME + " " + objBadge.LNAME;

                        break;

                    case "BadgeIdtxt4":

                        confinedSpaceSign.BadgeFourthResult = txtNextLvl.Text;
                        confinedSpaceSign.FirstNameFourthResult = objBadge.FNAME;
                        confinedSpaceSign.LasttNameFourthResult = objBadge.LNAME;
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
        public void SetValue(string confinedspaceId)
        {
            WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();

            confinedSpaceSign = WPSign.GetConfinedMudSign(confinedspaceId);
            confinedSpaceSign = confinedSpaceSign == null ? new ConfinedSpaceMudSign() : confinedSpaceSign;
            confinedSpaceSign.ConfinedSpaceId = confinedspaceId;

          if( confinedSpaceSign.SourceFirstResult=="LENEL")
          {
              rdbLenel1.Checked = true;
          }
          else if (confinedSpaceSign.SourceFirstResult=="OLT")
          {
              rdbOLT1.Checked = true;
          }
            else
          {
              rdbManual1.Checked = true;
          }
          if (confinedSpaceSign.SourceSecondResult == "LENEL")
          {
              rdbLenel2.Checked = true;
          }
          else if (confinedSpaceSign.SourceSecondResult == "OLT")
          {
              rdbOLT2.Checked = true;
          }
          else
          {
              rdbManual2.Checked = true;
          }

          if (confinedSpaceSign.SourceThirdResult == "LENEL")
          {
              rdbLenel3.Checked = true;
          }
          else if (confinedSpaceSign.SourceThirdResult == "OLT")
          {
              rdbOLT3.Checked = true;
          }
          else
          {
              rdbManual3.Checked = true;
          }
          if (confinedSpaceSign.SourceFourthResult == "LENEL")
          {
              rdbLenel4.Checked = true;
          }
          else if (confinedSpaceSign.SourceFourthResult == "OLT")
          {
              rdbOLT4.Checked = true;
          }
          else
          {
              rdbManual4.Checked = true;

          }
           

            txtName1.Text = confinedSpaceSign.FirstNameFirstResult + " " + confinedSpaceSign.LasttNameFirstResult;
            txtName2.Text = confinedSpaceSign.FirstNameSecondResult + " " + confinedSpaceSign.LasttNameSecondResult;
            txtName3.Text = confinedSpaceSign.FirstNameThirdResult + " " + confinedSpaceSign.LasttNameThirdResult;
            txtName4.Text = confinedSpaceSign.FirstNameFourthResult + " " + confinedSpaceSign.LasttNameFourthResult;
            BadgeIdtxt1.Text = confinedSpaceSign.BadgeFirstResult;
            BadgeIdtxt2.Text = confinedSpaceSign.BadgeSecondResult;
            BadgeIdtxt3.Text = confinedSpaceSign.BadgeThirdResult;
            BadgeIdtxt4.Text = confinedSpaceSign.BadgeFourthResult;

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
            if (confinedSpaceSign == null)
            {
                return;
            }
            OltRadioButton control = sender as OltRadioButton;
                    if (control.Name == "rdbOLT1")
                    {
                        confinedSpaceSign.FirstNameFirstResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        confinedSpaceSign.LasttNameFirstResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        confinedSpaceSign.SourceFirstResult = "OLT";
                        txtName1.Text = confinedSpaceSign.FirstNameFirstResult + " " + confinedSpaceSign.LasttNameFirstResult;
                        BadgeIdtxt1.Text = "";
                        confinedSpaceSign.BadgeFirstResult = "";
                    }
                    else if (control.Name == "rdbLenel1")
                    {
                        txtName1.Text = "";
                        BadgeIdtxt1.Focus();
                        confinedSpaceSign.SourceFirstResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual1")
                    {
                        confinedSpaceSign.FirstNameFirstResult = "";
                        confinedSpaceSign.LasttNameFirstResult = "";
                        confinedSpaceSign.SourceFirstResult = "Manual";
                        txtName1.Text = "";
                        BadgeIdtxt1.Text = "";
                        confinedSpaceSign.BadgeFirstResult = "";
                    }
                    

               
                    if (control.Name == "rdbOLT2")
                    {
                        confinedSpaceSign.FirstNameSecondResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        confinedSpaceSign.LasttNameSecondResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        txtName2.Text = confinedSpaceSign.FirstNameSecondResult + " " + confinedSpaceSign.LasttNameSecondResult;
                        confinedSpaceSign.SourceSecondResult = "OLT";

                        BadgeIdtxt2.Text = "";
                        confinedSpaceSign.BadgeSecondResult = "";

                    }
                    else if (control.Name == "rdbLenel2")
                    {
                        txtName2.Text = "";
                        BadgeIdtxt2.Focus();
                        confinedSpaceSign.SourceSecondResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual2")
                    {
                        confinedSpaceSign.FirstNameSecondResult = "";
                        confinedSpaceSign.LasttNameSecondResult = "";
                        txtName2.Text = "";
                        confinedSpaceSign.SourceSecondResult = "Manual";
                        BadgeIdtxt2.Text = "";
                        confinedSpaceSign.BadgeSecondResult = "";
                    }
                   

               
                    if (control.Name == "rdbOLT3")
                    {
                        confinedSpaceSign.FirstNameThirdResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        confinedSpaceSign.LasttNameThirdResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        txtName3.Text = confinedSpaceSign.FirstNameThirdResult + " " + confinedSpaceSign.LasttNameThirdResult;
                        confinedSpaceSign.SourceThirdResult = "OLT";
                        BadgeIdtxt3.Text = "";
                        confinedSpaceSign.BadgeThirdResult = "";

                    }
                    else if (control.Name == "rdbLenel3")
                    {
                        txtName3.Text = "";
                        BadgeIdtxt3.Focus();
                        confinedSpaceSign.SourceThirdResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual3")
                    {
                        confinedSpaceSign.FirstNameThirdResult = "";
                        confinedSpaceSign.LasttNameThirdResult = "";
                        txtName3.Text = "";
                        confinedSpaceSign.SourceThirdResult = "Manual";
                        BadgeIdtxt3.Text = "";
                        confinedSpaceSign.BadgeThirdResult = "";
                    }
                  

              

                    if (control.Name == "rdbOLT4")
                    {
                        confinedSpaceSign.FirstNameFourthResult = ClientSession.GetUserContext().User.FirstName.ToUpper();
                        confinedSpaceSign.LasttNameFourthResult = ClientSession.GetUserContext().User.LastName.ToUpper();
                        txtName4.Text = confinedSpaceSign.FirstNameFourthResult + " " + confinedSpaceSign.LasttNameFourthResult;
                        confinedSpaceSign.SourceFourthResult = "OLT";
                        BadgeIdtxt4.Text = "";
                        confinedSpaceSign.BadgeFourthResult = "";

                    }
                    else if (control.Name == "rdbLenel4")
                    {
                        txtName4.Text = "";
                        BadgeIdtxt4.Focus();
                        confinedSpaceSign.SourceFourthResult = "LENEL";
                    }
                    else if (control.Name == "rdbManual4")
                    {
                        confinedSpaceSign.FirstNameFourthResult = "";
                        confinedSpaceSign.LasttNameFourthResult = "";
                        txtName4.Text = "";
                        confinedSpaceSign.SourceFourthResult = "Manual";
                        BadgeIdtxt4.Text = "";
                        confinedSpaceSign.BadgeFourthResult = "";
                    }
                   
            
        }
    }
}