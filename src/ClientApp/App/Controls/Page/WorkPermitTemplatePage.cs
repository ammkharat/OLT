using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public partial class WorkPermitTemplatePage : AbstractPage<WorkPermitDTO, IWorkPermitDetails>, IWorkPermitPage
    {


        public WorkPermitTemplatePage()
            : base(new DomainSummaryGrid<WorkPermitDTO>(
            new WorkPermitMarkedTemplateGrid(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "markedTemplate"),
                new WorkPermitFormsFactory().Build().DetailsForm()
            )
        {
        }

        


        
        public override PageKey PageKey
        {
            get { return PageKey.WORK_PERMIT_Template_PAGE; }
        }

        public void DisplayInvalidWorkPermitMessage(string message, string title)
        {
            
        }

        public bool DisplayOptionalInvalidWorkPermitMessage(string message, string title)
        {
            return false;
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            
        }

        public void DisplayInvalidActionMessage(string message, string title)
        {
            
        }

        public void DisplayCommentsForm(Common.Domain.WorkPermit.WorkPermit permit)
        {
            
        }

        public bool ShowYesNoDialog(string message, string title)
        {
            return false;
        }

        protected override bool IsCreatedByCurrentUser(WorkPermitDTO dto)
        {
            return false;
        }

        protected override bool IsUpdatedByCurrentUser(WorkPermitDTO dto)
        {
            return false; 
        }

        
    }
}
