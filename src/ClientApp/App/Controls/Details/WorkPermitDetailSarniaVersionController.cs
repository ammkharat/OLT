﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class WorkPermitDetailSarniaVersionController : UserControl, IWorkPermitDetails
    {
        public event EventHandler Approve;
        public event EventHandler Reject;
        public event EventHandler CloseWorkPermit;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Comment;
        public event EventHandler Copy;
        public event EventHandler Clone;
        public event EventHandler Print;
        public event EventHandler PrintPreview;
        public event EventHandler ExportAll;
        public event Action ToggleShow;        
        public event EventHandler RefreshAll;
        public event EventHandler ViewEditHistory;
        public event EventHandler SetFilter;
        public event Action SaveGridLayout;
        //Added by ppanigrahi
        public event EventHandler Extension;
        public event EventHandler Revalidation;

        public event EventHandler MarkAsTemplate;
        public event EventHandler UnMarkTemplate;

        private IWorkPermitDetails currentDetails;

        public event EventHandler ViewAttachment; 

        public WorkPermitDetailSarniaVersionController()
        {
            InitializeComponent();

            workPermitDetails.Dock = DockStyle.Fill;
            workPermitDetails.Visible = true;
            workPermitDetails_v_3_2.Dock = DockStyle.Fill;
            workPermitDetails_v_3_2.Visible = false;

            Initialize(workPermitDetails);
            Initialize(workPermitDetails_v_3_2);
            currentDetails = workPermitDetails;
        }

        private void Initialize(IWorkPermitDetails detail)
        {
            detail.Approve += (o, args) => { if (Approve != null) Approve(o, args); };
            detail.Reject += (o, args) => { if (Reject != null) Reject(o, args); };
            detail.CloseWorkPermit += (o, args) => { if (CloseWorkPermit != null) CloseWorkPermit(o, args); };
            detail.Delete += (o, args) => { if (Delete != null) Delete(o, args); };
            detail.Edit += (o, args) => { if (Edit != null) Edit(o, args); };
            detail.Comment += (o, args) => { if (Comment != null) Comment(o, args); };
            detail.Copy += (o, args) => { if (Copy != null) Copy(o, args); };
            detail.Clone += (o, args) => { if (Clone != null) Clone(o, args); };
            detail.Print += (o, args) => { if (Print != null) Print(o, args); };
            detail.PrintPreview += (o, args) => { if (PrintPreview != null) PrintPreview(o, args); };
            detail.ExportAll += (o, args) => { if (ExportAll != null) ExportAll(o, args); };
            detail.ToggleShow += () => { if (ToggleShow != null) ToggleShow(); };
            detail.RefreshAll += (o, args) => { if (RefreshAll != null) RefreshAll(o, args); };
            detail.ViewEditHistory += (o, args) => { if (ViewEditHistory != null) ViewEditHistory(o, args); };
            detail.SetFilter += (o, args) => { if (SetFilter != null) SetFilter(o, args); };
            detail.SaveGridLayout += () => { if (SaveGridLayout != null) SaveGridLayout(); };

            detail.ViewAttachment += (o, args) => { if (ViewAttachment != null) ViewAttachment(o, args); };
            //Added by ppanigrahi
            detail.Revalidation += (o, args) => { if (Revalidation != null) Revalidation(o, args); };
            detail.Extension += (o, args) => { if (Extension != null) Extension(o, args); };

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            detail.MarkAsTemplate += (o, args) => { if (MarkAsTemplate != null) MarkAsTemplate(o, args); };

            detail.UnMarkTemplate += (o, args) => { if (UnMarkTemplate != null) UnMarkTemplate(o, args); };
        }

        public new void Hide()
        {
            workPermitDetails.HideDetailsPanel();
            workPermitDetails_v_3_2.HideDetailsPanel();
        }

        public new void Show()
        {
            workPermitDetails.ShowDetailsPanel();
            workPermitDetails_v_3_2.ShowDetailsPanel();
        }

        public Version WorkPermitVersion
        {
            set
            {
                if (value == Common.Utility.Constants.VERSION_3_2)
                {
                    currentDetails = workPermitDetails_v_3_2;
                    if (!workPermitDetails_v_3_2.Visible)
                    {
                        workPermitDetails_v_3_2.Visible = true;
                    }
                    workPermitDetails.Visible = false;
                }
                else
                {
                    currentDetails = workPermitDetails;
                    if (!workPermitDetails.Visible)
                    {
                        workPermitDetails.Visible = true;
                    }
                    workPermitDetails_v_3_2.Visible = false;
                }
            }
        }

        public IWorkPermitDetails BindingTarget
        {
            get { return currentDetails; }
        }

        public List<AcidClothingType> SpecialProtectiveClothingTypeAcidClothingTypeChoices
        {
            set
            {
                workPermitDetails.SpecialProtectiveClothingTypeAcidClothingTypeChoices = value;
                workPermitDetails_v_3_2.SpecialProtectiveClothingTypeAcidClothingTypeChoices = value;
            }
        }

        public void SetRequiredSpecialPrecautionsComments()
        {
            currentDetails.SetRequiredSpecialPrecautionsComments();
        }

        public List<GasTestElementResultDTO> GasTestElementResults
        {
            set { currentDetails.GasTestElementResults = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { currentDetails.DocumentLinks = value; }
        }

        public User Author
        {
            set { currentDetails.Author = value; }
        }

        public User Approver
        {
            set { currentDetails.Approver = value; }
        }

        public User LastModifier
        {
            set { currentDetails.LastModifier = value; }
        }

        public bool ApproveEnabled
        {
            set
            {
                workPermitDetails.ApproveEnabled = value;
                workPermitDetails_v_3_2.ApproveEnabled = value;
            }
        }

        public bool RejectEnabled
        {
            set
            {
                workPermitDetails.RejectEnabled = value;
                workPermitDetails_v_3_2.RejectEnabled = value;
            }
        }

        public bool CloseEnabled
        {
            set
            {
                workPermitDetails.CloseEnabled = value;
                workPermitDetails_v_3_2.CloseEnabled = value;
            }
        }

        public bool DeleteEnabled
        {
            set
            {
                workPermitDetails.DeleteEnabled = value;
                workPermitDetails_v_3_2.DeleteEnabled = value;
            }
        }

        public bool EditEnabled
        {
            set
            {
                workPermitDetails.EditEnabled = value;
                workPermitDetails_v_3_2.EditEnabled = value;
            }
        }

        public bool CommentEnabled
        {
            set
            {
                workPermitDetails.CommentEnabled = value;
                workPermitDetails_v_3_2.CommentEnabled = value;
            }
        }

        public bool CopyEnabled
        {
            set
            {
                workPermitDetails.CopyEnabled = value;
                workPermitDetails_v_3_2.CopyEnabled = value;
            }
        }

        public bool CloneEnabled
        {
            set
            {
                workPermitDetails.CloneEnabled = value;
                workPermitDetails_v_3_2.CloneEnabled = value;
            }
        }

        public bool PrintEnabled
        {
            set
            {
                workPermitDetails.PrintEnabled = value;
                workPermitDetails_v_3_2.PrintEnabled = value;
            }
        }

        public bool PrintPreviewEnabled
        {
            set
            {
                workPermitDetails.PrintPreviewEnabled = value;
                workPermitDetails_v_3_2.PrintPreviewEnabled = value;
            }
        }

        public bool ViewEditHistoryEnabled
        {
            set
            {
                workPermitDetails.ViewEditHistoryEnabled = value;
                workPermitDetails_v_3_2.ViewEditHistoryEnabled = value;
            }
        }

        public bool RefreshAllEnabled
        {
            set
            {
                workPermitDetails.RefreshAllEnabled = value;
                workPermitDetails_v_3_2.RefreshAllEnabled = value;
            }
        }

        public void CallDefaultButton()
        {
            currentDetails.CallDefaultButton();
        }

        public WidgetAppearance ShowButtonAppearance
        {
            get { return currentDetails.ShowButtonAppearance; }
            set
            {
                workPermitDetails.ShowButtonAppearance = value;
                workPermitDetails_v_3_2.ShowButtonAppearance = value;
            }
        }

        public bool EnableLayoutIsActiveIndicator
        {
            set { currentDetails.EnableLayoutIsActiveIndicator = value; }
        }

        public ToolStripButton SaveGridLayoutButton
        {
            get { return currentDetails.SaveGridLayoutButton; }
        }

        // DMND0010609-OLT -  Work permit Scan
        public void MakeSeachWindowRequiredButtonsvisibleonly()
        {
            workPermitDetails.MakeSeachWindowRequiredButtonsvisibleonly();

        }
        public bool ViewAttachEnabled { set { workPermitDetails.ViewAttachEnabled = value; } }

        public bool ViewScanEnabled { set { workPermitDetails.ViewScanEnabled = value; } }
        //Added by ppanigrahi
        public bool ExtensionEnable
        {
            set { workPermitDetails.ExtensionEnable = value; }
        }
        public bool RevalidationButtonEnable
        {
            set { workPermitDetails.RevalidationButtonEnable = value; }
        }
        public bool ToolStripEnabled
        {

            set { workPermitDetails.ToolStripEnabled = value; }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public bool MarkTemplateEnabled
        {
            set
            {
                workPermitDetails.MarkTemplateEnabled = value;
                workPermitDetails_v_3_2.MarkTemplateEnabled = value;
            }
        }

        public bool UnMarkTemplateEnabled
        {
            set
            {
                workPermitDetails.UnMarkTemplateEnabled = value;
                workPermitDetails_v_3_2.UnMarkTemplateEnabled = value;
            }
        }



        public bool DeleteVisible
        {
            set
            {
                workPermitDetails.DeleteVisible = value;
                workPermitDetails_v_3_2.DeleteVisible = value;
            }
        }

        public bool editVisible
        {
            set
            {
                workPermitDetails.editVisible = value;
                workPermitDetails_v_3_2.editVisible = value;
            }
        }

        public bool closeButtonVisible
        {
            set
            {
                workPermitDetails.closeButtonVisible = value;
                workPermitDetails_v_3_2.closeButtonVisible = value;
            }
        }

        public bool printButtonVisible
        {
            set
            {
                workPermitDetails.printButtonVisible = value;
                workPermitDetails_v_3_2.printButtonVisible = value;
            }
        }

        public bool printPreviewButtonVisible
        {
            set
            {
                workPermitDetails.printPreviewButtonVisible = value;
                workPermitDetails_v_3_2.printPreviewButtonVisible = value;
            }
        }

        public bool editHistoryButtonVisible
        {
            set
            {
                workPermitDetails.editHistoryButtonVisible = value;
                workPermitDetails_v_3_2.editHistoryButtonVisible = value;
            }
        }

        public bool approveButtonVisible
        {
            set
            {
                workPermitDetails.approveButtonVisible = value;
                workPermitDetails_v_3_2.approveButtonVisible = value;
            }
        }

        public bool ScanbuttonButtonVisible
        {
            get
            {
                return workPermitDetails.ScanbuttonButtonVisible;
                return workPermitDetails.ScanbuttonButtonVisible;
            }
            set
            {
                workPermitDetails.ScanbuttonButtonVisible = value;
                workPermitDetails_v_3_2.ScanbuttonButtonVisible = value;
            }
        }

        public bool rejectButtonVisible
        {
            set
            {
                workPermitDetails.rejectButtonVisible = value;
                workPermitDetails_v_3_2.rejectButtonVisible = value;
            }
        }

        public bool commentButtonVisible
        {
            set
            {
                workPermitDetails.commentButtonVisible = value;
                workPermitDetails_v_3_2.commentButtonVisible = value;
            }
        }

        public bool copyButtonVisible
        {
            set
            {
                workPermitDetails.copyButtonVisible = value;
                workPermitDetails_v_3_2.copyButtonVisible = value;
            }
        }

        public bool ExtensionButtonVisible
        {
            set
            {
                workPermitDetails.ExtensionButtonVisible = value;
                workPermitDetails_v_3_2.ExtensionButtonVisible = value;
            }
        }

        public bool revalidationButtonVisible
        {
            set
            {
                workPermitDetails.revalidationButtonVisible = value;
                workPermitDetails_v_3_2.revalidationButtonVisible = value;
            }
        }

        public bool viewAttachementbuttonVisible
        {
            set
            {
                workPermitDetails.viewAttachementbuttonVisible = value;
                workPermitDetails_v_3_2.viewAttachementbuttonVisible = value;
            }
        }

        
    }
}
