using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.Office.Utils;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraRichEdit.API.Word;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageSarniaEipIssueDetailsPresenter : MultiGridEdmontonFormPagePresenter
    {
        private readonly IGridAndDetailsView view;

        public PriorityPageSarniaEipIssueDetailsPresenter(GridAndDetailsForm gridAndDetailsForm, MultiGridFormPage page, List<IMultiGridContext> contexts)
            : base(page, contexts)
        {
            view = gridAndDetailsForm;
            view.Title = contexts[0].Key.Name; // "Eip Issue";
        }

        //ayman Sarnia eip DMND0008992
        public void Run(IWin32Window parent,object dto)
        {
            DoInitialDataLoad();

            FormEdmontonGN75BDetails details = (FormEdmontonGN75BDetails)page.CurrentGridContext.Details;
            view.Details = details;
            details.MakeAllButtonsInvisible();
            details.PrintButtonVisible = true;

            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.Details = page.CurrentGridContext.Details;
            FormEdmontonGN75BDetails details = (FormEdmontonGN75BDetails)page.CurrentGridContext.Details;
            view.Details = details;
            details.MakeAllButtonsInvisible();
            details.PrintButtonVisible = true;
            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

        protected override IMultiGridContext GetInitialGridContext()
        {
            if (view.Title.Equals("EIP Template"))
            {
                return page.GetContext(EdmontonFormType.GN75BTemplate);              //ayman Sarnia eip DMND0008992
            }
            else
            {
                return page.GetContext(EdmontonFormType.GN75BSarniaEIP);    
            }
            
        }
    }
}
