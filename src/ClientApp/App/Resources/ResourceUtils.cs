﻿using System.Drawing;
using ResourcesResx = Com.Suncor.Olt.Client.Properties.Resources;

namespace Com.Suncor.Olt.Client.Resources
{
    public class ResourceUtils
    {
        public static readonly Bitmap BLANK = ResourcesResx.blank;

        // These are typically for statuses of things like permits
        public static readonly Bitmap CANT_COMPLETE = ResourcesResx.cantComplete;
        public static readonly Bitmap NO_SHOW = ResourcesResx.cantComplete;
        public static readonly Bitmap NOT_RETURNED = ResourcesResx.cantComplete;
        public static readonly Bitmap RECURRING = ResourcesResx.recurring;
        public static readonly Bitmap SINGLE = ResourcesResx.blank;
        public static readonly Bitmap CURRENT = ResourcesResx.current;
        public static readonly Bitmap APPROVED = ResourcesResx.approved;
        public static readonly Bitmap IEFSUBMITTED = ResourcesResx.IeFSubmitted;//IEFSubmitted changes
        public static readonly Bitmap REJECTED = ResourcesResx.rejected; 
        public static readonly Bitmap VOID = ResourcesResx.voidX;
        public static readonly Bitmap MERGED = ResourcesResx.rejected;
        public static readonly Bitmap FOR_REVIEW = ResourcesResx.forReview;
        public static readonly Bitmap COMPLETION_UNKNOWN = ResourcesResx.yieldWithExclamation;
        public static readonly Bitmap ON_HOLD = ResourcesResx.StopSignWithWhiteHand;
        public static readonly Bitmap MISSING_INFORMATION = ResourcesResx.paper_with_blue_question_mark;
        public static readonly Bitmap EXPIRED = ResourcesResx.GrayDot;
        public static readonly Bitmap DRAFT = ResourcesResx.GrayDot;
        public static readonly Bitmap LATE = ResourcesResx.late;

        // These are typically for datasources
        public static readonly Bitmap MANUAL = ResourcesResx.manual;
        public static readonly Bitmap SAP = ResourcesResx.SAP;
        public static readonly Bitmap TARGET = ResourcesResx.target;
        public static readonly Bitmap EVENT = ResourcesResx._event;
        public static readonly Bitmap ACTION_ITEM = ResourcesResx.actionItem;
        public static readonly Bitmap PERMIT = ResourcesResx.permit;
        public static readonly Bitmap LAB_ALERT = ResourcesResx.lab_alert;
        public static readonly Bitmap PERMIT_REQUEST = ResourcesResx.permit_request;
        public static readonly Bitmap MERGE = ResourcesResx.merge_16;
        public static readonly Bitmap CLONE = ResourcesResx.clonePermit_16;

        public static readonly Bitmap Template = ResourcesResx.template_Clone;

        public static readonly Bitmap SCHEDULING = ResourcesResx.scheduling;
        public static readonly Bitmap HIGH_PRIORITY = ResourcesResx.HighPriority;
        public static readonly Bitmap ELEVATED_PRIORITY = ResourcesResx.ElevatedPriority;
        public static readonly Bitmap NORMAL_PRIORITY = ResourcesResx.NormalPriority;
        public static readonly Bitmap ACTIVE = ResourcesResx.active;
        public static readonly Bitmap INACTIVE = ResourcesResx.inactive;

        public static readonly Bitmap FLAG = ResourcesResx.Flag;
        public static readonly Bitmap NO_FLAG = ResourcesResx.blank;
        
        public static readonly Bitmap THREAD = ResourcesResx.thread;
        public static readonly Bitmap NOT_IN_THREAD = ResourcesResx.blank;
        
        public static readonly Bitmap ALERT = ResourcesResx.alert;
        public static readonly Bitmap NTE_ALERT = ResourcesResx.NTEAlert;
        public static readonly Bitmap ACKNOWLEDGED = ResourcesResx.acknowledged;
        public static readonly Bitmap LATE_ALERT = ResourcesResx.NTEAlert;
        public static readonly Bitmap RESPONDED = ResourcesResx.acknowledged;
        public static readonly Bitmap POSITIVE_DEVIATION = ResourcesResx.positive_deviation;
        public static readonly Bitmap ALERT_DATA_UNAVAILABLE = ResourcesResx.alert_data_unavailable;
        public static readonly Bitmap ALERT_DATA_UNAVAILABLE_LATE = ResourcesResx.alert_data_unavailable_late;
        
        public static readonly Bitmap PENDING = ResourcesResx.pending;
        public static readonly Bitmap WAITINGFORAPPROVAL = ResourcesResx.waitingforapproval;
        public static readonly Bitmap NON_OPERATIONS = ResourcesResx.NonOperations;
        public static readonly Bitmap COMPLETED_PERMIT = ResourcesResx.completedPermit;
        public static readonly Bitmap NOT_COMPLETED_PERMIT = ResourcesResx.rejected;
        public static readonly Bitmap ISSUED = ResourcesResx.issued;
        public static readonly Bitmap ARCHIVED = ResourcesResx.archived;
        public static readonly Bitmap HOT_PERMIT = ResourcesResx.hotPermit;
        public static readonly Bitmap COLD_PERMIT = ResourcesResx.coldPermit;
        public static readonly Bitmap INVALID_TAG = ResourcesResx.InvalidTag;
        public static readonly Icon NEEDS_APPROVAL = ResourcesResx.warning;
        public static readonly Bitmap WARNING = ResourcesResx.warningCommentsRequired;

        public static readonly Bitmap EYE_OPENED = ResourcesResx.Open_eye;
        public static readonly Bitmap EYE_CLOSED = ResourcesResx.Closed_eye;

        public static readonly Bitmap READ = ResourcesResx.read;
        public static readonly Bitmap UNREAD = ResourcesResx.unread;

        public static readonly Bitmap COLLAPSE = ResourcesResx.collapse;
        public static readonly Bitmap EXPAND = ResourcesResx.expand;

        public static readonly Bitmap FUTURE_DIRECTIVE = ResourcesResx.pending;
        public static readonly Bitmap ACTIVE_DIRECTIVE = ResourcesResx.approved;
        public static readonly Bitmap EXPIRED_DIRECTIVE = ResourcesResx.rejected;

        public static readonly Bitmap HIGH_SL = ResourcesResx.high_sl;
        public static readonly Bitmap HIGH_SOL = ResourcesResx.high_sol;
        public static readonly Bitmap HIGH_TARGET = ResourcesResx.high_target;
        public static readonly Bitmap LOW_SL = ResourcesResx.low_sl;
        public static readonly Bitmap LOW_SOL = ResourcesResx.low_sol;
        public static readonly Bitmap LOW_TARGET = ResourcesResx.low_target;
 
        public static readonly Bitmap HANDOVER_SMALL = ResourcesResx.shift_handover_16;
        public static readonly Bitmap HANDOVER_QUESTIONS = ResourcesResx.handover_questions;

        public static readonly Bitmap MAGNIFYING_GLASS = ResourcesResx.magnifying_glass_white_12;
        public static readonly Bitmap X = ResourcesResx.x;

        public static readonly Bitmap ONSITE = ResourcesResx.approved;
        public static readonly Bitmap OFFSITE = ResourcesResx.rejected;
        public static readonly Bitmap UNKNOWN = ResourcesResx.GrayDot;

        public static readonly Bitmap ACTIVE_CSD = ResourcesResx.active;
    }
}
