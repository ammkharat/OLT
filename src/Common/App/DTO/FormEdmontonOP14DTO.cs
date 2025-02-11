﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormEdmontonOP14DTO : FormEdmontonDTO
    {
       // private readonly IReportPrintManager<FormOP14> reportPrintManager;//Added by ppanigrahi
        public FormEdmontonOP14DTO(long id, List<string> functionalLocations, string criticalSystemDefeated,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals, long siteid)    //ayman sarnia
            : base(
                id, functionalLocations, EdmontonFormType.OP14, createdByUserId, createdByFullNameWithUserName,
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            CriticalSystemDefeated = criticalSystemDefeated;
            Siteid = siteid;        //ayman Sarnia RITM0162061
            FormNumber = id;  //Added by ppanigrahi
        }


        public override FormStatus Status
        {
            get
            {
                //ayman Sarnia RITM0162061 

                if (Siteid == 1)

                {
                    var temp = base.Status;

                    if ((base.Status == FormStatus.Approved || base.Status == FormStatus.Draft || base.Status == FormStatus.WaitingForApproval) && (Clock.Now > base.ValidTo)) return FormStatus.Expired;

                    if (temp == FormStatus.Closed && ClosedDateTime != null)
                    {
                        return FormStatus.Closed;
                    }

                    //CSD Approval logic chaged:-Vibhor
                    if (base.Status != FormStatus.Draft)
                    {
                        if (RemainingApprovals.Count == 5)
                            return FormStatus.WaitingForApproval;

                        if (RemainingApprovals.Any(apr => apr.ToString().ToLower().Contains("shift supervisor")) && Clock.Now <= base.ValidTo)
                            return FormStatus.WaitingForApproval;

                        if (RemainingApprovals.Any(apr => apr.ToString().ToLower().Contains("Operations Manager/Delegate")) &&
                            (Clock.Now >= base.ValidFrom.AddDays(3) && Clock.Now <= base.ValidTo))
                            return FormStatus.WaitingForApproval;
                        

                        if (RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) && (Clock.Now >= base.ValidFrom.AddDays(9) && Clock.Now <= base.ValidTo))
                            return FormStatus.WaitingForApproval;

                        if (RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) && (Clock.Now >= base.ValidFrom.AddDays(29) && Clock.Now <= base.ValidTo))
                            return FormStatus.WaitingForApproval;


                        if (RemainingApprovals.Any(apr => apr.ToString().ToLower().Contains("Operations Manager/Delegate")) && (Clock.Now < base.ValidFrom.AddDays(3) && Clock.Now <= base.ValidTo) && base.Status != FormStatus.Closed)
                            return FormStatus.Approved;

                        if (RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) && (Clock.Now < base.ValidFrom.AddDays(9) && Clock.Now <= base.ValidTo) && base.Status != FormStatus.Closed)
                            return FormStatus.Approved;

                        if (RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) && (Clock.Now < base.ValidFrom.AddDays(29) && Clock.Now <= base.ValidTo) && base.Status != FormStatus.Closed)
                            return FormStatus.Approved;
                        //if ((RemainingApprovals.Any(apr => apr.ToString().ToLower().Equals("operations manager")) && RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) && RemainingApprovals.Any(apr => apr.ToString().Contains("> 30"))) &&
                        //    (Clock.Now >= base.ValidFrom.AddDays(3) && Clock.Now <= base.ValidTo))
                        //    return FormStatus.WaitingForApproval;

                        //if ((RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) && RemainingApprovals.Any(apr => apr.ToString().Contains("> 30"))) &&
                        //    (Clock.Now >= base.ValidFrom.AddDays(9) && Clock.Now <= base.ValidTo))
                        //    return FormStatus.WaitingForApproval;

                        //if ((RemainingApprovals.Any(apr => apr.ToString().Contains("> 30"))) &&
                        //    (Clock.Now >= base.ValidFrom.AddDays(29) && Clock.Now <= base.ValidTo))
                        //    return FormStatus.WaitingForApproval;

                        //// 

                        //if (((RemainingApprovals.Any(apr => apr.ToString().ToLower().Equals("Operations Manager")) &&
                        //    Clock.Now < base.ValidFrom.AddDays(3) && Clock.Now <= base.ValidTo) && base.RemainingApprovals.Count == 4)
                        //    && base.Status != FormStatus.Closed)  // INC0426316 : Added by Vibhor to fix CSD form status while closing the form
                        //    return FormStatus.Approved;

                        //if (((RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) || RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) &&
                        //    Clock.Now < base.ValidFrom.AddDays(10) && Clock.Now <= base.ValidTo) && base.RemainingApprovals.Count == 3)
                        //    && base.Status != FormStatus.Closed)  
                        //    return FormStatus.Approved;
                        //if (((RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) &&
                        //   Clock.Now < base.ValidFrom.AddDays(30) && Clock.Now <= base.ValidTo) && base.RemainingApprovals.Count == 2)
                        //   && base.Status != FormStatus.Closed)  
                        //    return FormStatus.Approved;
                    }
                    return base.Status;
                }
                else
                {
                    if ((base.Status == FormStatus.Approved || base.Status == FormStatus.Draft ||
                         base.Status == FormStatus.WaitingForApproval) && //ayman waiting for approval fix
                        (Clock.Now > base.ValidTo))
                        return FormStatus.Expired;
                    return base.Status;
                }
                return base.Status;
            }
        }


        public string CriticalSystemDefeated { get; private set; }

        [IncludeInSearch]
        public long FormNumber { get; private set; }

        //ayman sarnia RITM0162061
        public long Siteid { get; private set; }

        private static List<string> GetApprovers(FormOP14 formOp14)
        {
            return formOp14.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    formOp14.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }

        private void sentmail(long formId)
        {
            

        }

        public bool MarkAsReadCSD { get; set; } //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD
    }
}