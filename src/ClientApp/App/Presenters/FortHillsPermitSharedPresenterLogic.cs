using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FortHillsPermitSharedPresenterLogic
    {
        public static void UpdateFieldsAfterSelectingFormGN1(IWorkPermitFortHillsSharedView view)
        {
            
            //if (view.GN1) // this is redundant since this method should only be called if GN1 is checked. I left it here to be safe.
            //{                
            //    view.ConfinedSpace = true;
            //    view.RescuePlan = false;
            //    DisableConfinedSpaceAndRescuePlanFields(view);

            //    if (view.FormGN1 != null)
            //    {
            //        view.ConfinedSpaceClass = view.FormGN1.CSELevel;
            //        view.ConfinedSpaceCardNumber = view.FormGN1TradeChecklistNumber;

            //        if (WorkPermitFortHills.ConfinedSpaceLevel1.Equals(view.ConfinedSpaceClass) || WorkPermitFortHills.ConfinedSpaceLevel2.Equals(view.ConfinedSpaceClass))
            //        {
            //            view.RescuePlan = true;
            //            view.RescuePlanFormNumber = view.FormGN1TradeChecklistNumber;
            //        }
            //        else if (WorkPermitFortHills.ConfinedSpaceLevel3.Equals(view.ConfinedSpaceClass))
            //        {
            //            view.RescuePlan = false;                        
            //            view.RescuePlanFormNumber = null;
            //        }

            //        view.RescuePlanFormNumberEnabled = false;
            //        view.RescuePlanCheckBoxEnabled = false;
            //    }               
            //}            
        }

        //public static void DisableConfinedSpaceAndRescuePlanFields(IWorkPermitFortHillsSharedView view)
        //{
        //    DisableConfinedSpaceFields(view);
        //    view.RescuePlanFormNumberEnabled = false;
        //    view.RescuePlanCheckBoxEnabled = false;
        //}

        //public static void DisableConfinedSpaceFields(IWorkPermitFortHillsSharedView view)
        //{
        //    view.ConfinedSpaceCheckBoxEnabled = true;
        //    view.ConfinedSpaceClassEnabled = true;
        //    view.ConfinedSpaceCardNumberEnabled = true;
        //}

        public static void AddInNewDocumentLinks(IWorkPermitFortHillsSharedView view, List<DocumentLink> newDocumentLinksFromForm)
        {
            if (newDocumentLinksFromForm == null || newDocumentLinksFromForm.Count == 0)
            {
                return;
            }

            List<DocumentLink> newLinks = newDocumentLinksFromForm.ConvertAll(l => l.CloneWithoutId());
            List<DocumentLink> linksFromView = new List<DocumentLink>(view.DocumentLinks ?? new List<DocumentLink>());
            linksFromView.AddRange(newLinks);
            view.DocumentLinks = linksFromView;           
        }

        //public static void HandleFormGN1CheckBoxChanged(IWorkPermitFortHillsSharedView view)
        //{
        //    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950321828 - 12-Sep-2018 start
        //    //if (!view.GN1)
        //    //{
        //    //    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = true;
        //    //    view.ConfinedSpaceWorkSectionNotApplicableToJob = true;
        //    //}
        //    //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950321828 - 12-Sep-2018 end

        //    if (view.GN1)
        //    {
        //        if (view.FormGN1 == null)
        //        {                    
        //            view.ConfinedSpace = true;
        //            view.ConfinedSpaceClass = null;
        //            view.ConfinedSpaceCardNumber = null;
                   
        //            view.RescuePlan = false;
        //            view.RescuePlanFormNumber = null;
        //            DisableConfinedSpaceAndRescuePlanFields(view);
        //        }
        //        else
        //        {
        //            UpdateFieldsAfterSelectingFormGN1(view);
        //        }
        //    }
        //    else
        //    {
        //        view.ConfinedSpaceCheckBoxEnabled = true;
        //        view.ConfinedSpace = false;
        //        view.ConfinedSpaceClass = null;
        //        view.ConfinedSpaceCardNumberEnabled = false;
        //        view.ConfinedSpaceCardNumber = null;

                
        //        view.RescuePlan = false;
        //        view.RescuePlanCheckBoxEnabled = true;
        //        view.RescuePlanFormNumber = null;
        //        view.RescuePlanFormNumberEnabled = false;
        //    }
        //}
    }
}
