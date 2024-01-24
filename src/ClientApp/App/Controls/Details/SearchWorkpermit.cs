using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class SearchWorkpermit : AbstractDetails
    {
        public SearchWorkpermit()
        {
            InitializeComponent();
            foreach(Control C in this .Controls)
            {
                if (C.GetType() == typeof(OltControls.OltLabel))
                C.Font = new Font(C.Font, FontStyle.Bold);
            }
        }
        public SearchWorkpermit(SearchPermitdata searchPermitdata)
        {
            InitializeComponent();
          
            FormTypeLabelData.Text = StringResources.DomainObjectName_WorkPermit;
            StatusLabelData.Text = searchPermitdata.Status;
            CreatedbyLabelData.Text = searchPermitdata.CreadtedBy;
            NumberLabelData.Text = searchPermitdata.PermitNumber;
            PermitTypeLabelData.Text = searchPermitdata.PermitType;
        }

       
    }
}
