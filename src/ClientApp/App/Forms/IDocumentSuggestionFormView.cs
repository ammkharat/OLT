using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IDocumentSuggestionFormView : IFormView
    {
        event Action HistoryClicked;
        event EventHandler NotApprovedButtonClicked;
        event Action SaveAndEmailButtonClicked;
        event Action ExpandClicked;
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action NewOrExistingDocumentChanged;
        event Action RecommendedToBeArchivedCheckedChanged;

        DocumentSuggestion DocumentSuggestion { set; }

        string LocationEquipmentNumber { get; set; }

        string FormStatus { set; }
        bool EnableSuggestedCompletionDateTime { set; }
        bool EnableScheduledCompletionDateTime { set; }
        DateTime? ScheduledCompletionDateTime { get; set; }

        int NumberOfExtensions { set; }
        List<Comment> ReasonForExtensions { set; }

        bool ExistingDocument { get; set; }
        bool NewDocument { get; set; }

        string DocumentOwner { get; set; }
        string DocumentNumber { get; set; }
        string DocumentTitle { get; set; }

        bool OriginalMarkedUp { get; set; }
        string HardCopySubmittedTo { get; set; }

        bool EnableRecommendedToBeArchived { set; }
        bool RecommendedToBeArchived { get; set; }

        bool EnableNotApprovedButton { set; }
        bool EnableSaveAndEmailButton { set; }
        string SaveAndEmailButtonText { set; }
        bool EnableSaveAndCloseButton { set; }

        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForLocationEquipmentNumberNotSet();
        void SetErrorForScheduledCompletionMustBeBeforeValidTo();
        void SetErrorForScheduledCompletionNotSet();
        void SetErrorForValidToIsInThePast();
        void SetErrorForScheduledCompletionIsInThePast();
        void SetErrorForExistingDocumentNotSelected();
        void SetErrorForNewDocumentNotSelected();
        void SetErrorForDocumentOwnerNotSet();
        void SetErrorForDocumentNumberNotSet();
        void SetErrorForDocumentTitleNotSet();
        void SetErrorForDocumentNumberNotValid();
        void SetErrorForDocumentTitleNotValid();
        void SetErrorForHardCopySubmittedToNotSet();
        void SetErrorForDescriptionNotSet();
    }
}