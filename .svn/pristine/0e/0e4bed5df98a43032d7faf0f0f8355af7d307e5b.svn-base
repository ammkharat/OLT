using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.DTO;
using log4net;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ManageOpModeForUnitLevelFLOCForm : BaseForm, IManageOpModeForUnitLevelFLOCView
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ManageOpModeForUnitLevelFLOCForm));

        private ManageOpModeForUnitLevelFLOCFormPresenter presenter;
        private readonly DomainSummaryGrid<FunctionalLocationOperationalModeDTO> grid;

        private List<FunctionalLocationOperationalModeDTO> opModeDisplayList;

        public ManageOpModeForUnitLevelFLOCForm()
        {
            InitializeComponent();
            InitializePresenter();
           
            grid = new DomainSummaryGrid<FunctionalLocationOperationalModeDTO>(new ManageOpModeForUnitLevelGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty)
                       {Dock = DockStyle.Fill};

            gridPanel.Controls.Add(grid);
        }

        private void InitializePresenter()
        {
            presenter = new ManageOpModeForUnitLevelFLOCFormPresenter(this);
            Load += presenter.LoadPage;
            editButton.Click += presenter.HandleEditButtonClicked;
            saveButton.Click += presenter.HandleSaveButtonClicked;
            cancelButton.Click += presenter.HandleCancelButtonClicked;
        }
       
        public List<FunctionalLocationOperationalModeDTO> Items
        {
            set
            {
                opModeDisplayList = value;
                grid.Items = opModeDisplayList;
            }
        }

        string IManageOpModeForUnitLevelFLOCView.Site
        {
            set
            {
                siteDisplayLabel.Text = value;
            }
        }

        public FunctionalLocationOperationalModeDTO SelectedItem
        {
            get
            {
                return grid.SelectedItem;
            }
        }

        public void CloseForm()
        {
            Close();   
        }

        public void DisplayOKDialog(string message)
        {
            OltMessageBox.Show(message);
        }

        public FunctionalLocationOperationalModeDTO OpenEditOperationalModeDialog(FunctionalLocationOperationalModeDTO selectedItem)
        {
            var editForm = new EditFunctionalLocationOperationalModeForm(selectedItem);
            FunctionalLocationOperationalModeDTO changedOpModeDto = editForm.ShowDialogAndReturnChangedDTO(this);

            if (changedOpModeDto != null)
            {
                FunctionalLocationOperationalModeDTO foundDto = opModeDisplayList.Find(
                    dto => dto.FunctionalLocationId == changedOpModeDto.FunctionalLocationId);
                
                if (foundDto == null)
                {
                    logger.Warn("A Functional Location Operational Mode was edited but not found in the display list. " +
                            "The display will not be updated.");
                }
                else                
                {
                    int index = opModeDisplayList.IndexOf(foundDto);
                    opModeDisplayList.Remove(foundDto);
                    opModeDisplayList.Insert(index, changedOpModeDto);                    
                    grid.DataBind();
                    grid.SelectItem(changedOpModeDto);                  
                }                
            }

            return changedOpModeDto;
        }
        
        public static string CreateObjectLockKey()
        {
            return string.Format("Manage Operational Mode for site: {0}", ClientSession.GetUserContext().Site.Id);
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }
    }
}