﻿using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageDocumentSuggestionDetailsPresenter : MultiGridEdmontonFormPagePresenter
    {
        private readonly IGridAndDetailsView view;

        public PriorityPageDocumentSuggestionDetailsPresenter(GridAndDetailsForm gridAndDetailsForm, MultiGridFormPage page, List<IMultiGridContext> contexts)
            : base(page, contexts)
        {
            view = gridAndDetailsForm;
            view.Title = StringResources.DomainObjectName_DocumentSuggestionForm;
        }

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.Details = page.CurrentGridContext.Details;

            FormDocumentSuggestionDetails details = (FormDocumentSuggestionDetails)page.CurrentGridContext.Details;
            view.Details = details;
            details.MakeAllButtonsInvisible();
            details.PrintButtonVisible = true;

            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

        protected override IMultiGridContext GetInitialGridContext()
        {
            return page.GetContext(EdmontonFormType.DocumentSuggestion);
        }
    }
}