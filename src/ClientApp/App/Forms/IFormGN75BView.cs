﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGN75BView : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action HistoryButtonClicked;
        event Action AddIsolationButtonClicked;
        event Action RemoveIsolationButtonClicked;
        event Action BrowseFunctionalLocationButtonClicked;
        event Action BrowseSchematicButtonClicked;
        event Action DocumentLinkOpened;
        event Action DocumentLinkAdded;

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
        string EquipmentType { get; set; }
        string LockBoxNumber { get; set; }
        string LockBoxLocation { get; set; }
        
        List<FormGN75BIsolationItemDisplayAdapter> IsolationItems { get; set; }
        List<string> IsolationItemsDropdownList { set; }
        List<string> EquipmentTypesDropdownList { set; }

        bool RemoveButtonEnabled { set; }
        bool SaveButtonEnable { set; } //RITM0468037:EN50:OLT::Edmonton::GN75B changes:Aarti
        bool PreEditEnable { set; } //RITM0468037:EN50:OLT::Edmonton::GN75B changes:Aarti
        bool EditPrintEnable { set; } //RITM0468037:EN50:OLT::Edmonton::GN75B changes:Aarti

        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector();
        
        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForNoBlindsSelected();
        void MakeIsolationGridValidationIconsShowOrDisappear();
        void AddIsolationItem(FormGN75BIsolationItemDisplayAdapter item);
        void RemoveSelectedIsolationItem();
        void SetErrorForIsolationGrid();//Aarti INC0548411 

        event Action ClearSchematicButtonClicked;
        event Action ViewSchemeticButtonClicked;
        void ClearSchematic();
        event Action InsertIsolationButtonClicked;
        void InsertIsolationBeforeSelectedItem(FormGN75BIsolationItemDisplayAdapter item);
        void SetErrorForNoLocationOfWork();
        void SetErrorForNoEquipmentType();
        void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();        //ayman Sarnia eip
        event Action PreEditButtonClicked; ////RITM0468037:EN50:OLT::Edmonton::GN75B changes:Aarti
        event Action EditPrintButtonClicked; ////RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
    }
}