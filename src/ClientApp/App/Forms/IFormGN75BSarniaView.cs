﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGN75BSarniaView : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action HistoryButtonClicked;
        event Action selectFormGN75BTemplateButtonClicked;
        event Action AddIsolationButtonClicked;
        event Action RemoveIsolationButtonClicked;
        event Action BrowseFunctionalLocationButtonClicked;
        event Action BrowseSchematicButtonClicked;
        event Action DocumentLinkOpened;
        event Action DocumentLinkAdded;
        event Action ViewGN75BFormButtonClicked;             //ayman Sarnia eip DMND0008992
        event Action RemoveGN75BButtonClicked;            //ayman Sarnia eip DMND0008992
        event Action GeneralWorkTextChanged;             //ayman Sarnia eip DMND0008992


        List<DocumentLink> DocumentLinks { get; set; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }

        bool HistoryButtonEnabled { set; }
        FunctionalLocation SelectedFunctionalLocation { get; set; }
        string LocationOfWork { get; set; }
        Image Schematic { set; }
        bool? BlindsRequired { get; set; }

        bool? DeadLeg { get; set; }                   //ayman Sarnia eip DMND0008992
        string SpecialPrecautions { get; set; }       //ayman Sarnia eip DMND0008992
        bool? DeadLegRisk { get; set; }               //ayman Sarnia eip - 2
        string EquipmentType { get; set; }
        //string LockBoxNumber { get; set; }
        //string LockBoxLocation { get; set; }
        long? formgn75bTemplateId { get; set; }    //ayman Sarnia eip DMND0008992
        string flocs { get; set; }                  //ayman Sarnia eip DMND0008992
        string FlocDesc { get; set; }              //ayman Sarnia eip DMND0008992
        string GeneralWorkText { get; set; }       //ayman Sarnia eip DMND0008992
        bool ApprovalsChecked { get; set; }       //ayman Sarnia eip DMND0008992
        List<FormGN75BIsolationItemDisplayAdapter> IsolationItems { get; set; }
        List<string> IsolationItemsDropdownList { set; }
        List<string> DevicePositionItemsDropdownList { set; } //ayman Sarnia eip DMND0008992
        List<string> EquipmentTypesDropdownList { set; }

        bool RemoveButtonEnabled { set; }
        
        List<FormApproval> Approvals { get; set; }          //ayman Sarnia eip DMND0008992



        //ayman Sarnia eip DMND0008992
        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;

        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector();
        DialogResult ShowFormWillNeedReapprovalQuestion();          //ayman Sarnia eip DMND0008992

        //DialogResultAndOutput<FormGN75B> ShowFormGN75BTemplates();            //ayman Sarnia eip DMND0008992

        void SetErrorForIsolationGrid(); //Aarti INC0548411 
        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForNoBlindsSelected();
        void SetErrorForNoDeadLegSelected();                               //ayman Sarnia eip
        void SetErrorForNoDeadLegRiskSelected();                           //ayman Sarnia eip
        void MakeIsolationGridValidationIconsShowOrDisappear();
        void AddIsolationItem(FormGN75BIsolationItemDisplayAdapter item);
        void RemoveSelectedIsolationItem();
        void ApprovalGridEnabled(bool enabled);

        event Action ClearSchematicButtonClicked;
        event Action ViewSchemeticButtonClicked;
        void ClearSchematic();
        event Action InsertIsolationButtonClicked;
        void InsertIsolationBeforeSelectedItem(FormGN75BIsolationItemDisplayAdapter item);
        void SetErrorForNoLocationOfWork();
        void SetErrorForNoEquipmentType();
        
        void DisplayDuplicateGN75BMessage(string message);    //ayman Sarnia eip DMND0008992
        void DisableAllControls();                         //ayman Sarnia eip DMND0008992
        void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();   //ayman Sarnia eip DMND0008992
        void Makecheckboxesnochoice();                          //ayman Sarnia eip
    }
}
