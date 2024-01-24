using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormMudsTemporaryInstallationsReportAdapter : FormReportAdapter
    {
        private readonly TemporaryInstallationsMUDS form;

        public FormMudsTemporaryInstallationsReportAdapter(TemporaryInstallationsMUDS form)
            : base(form)
        {
            this.form = form;
        }

        public string CreatedByLabel
        {
            get { return "Crée par:"; }
        }

        public string CreatedDateTimeLabel
        {
            get { return "Date/heure de création:"; }
        }

        public string LastModifiedByLabel
        {
            get { return "Modifié par:"; }
        }

        public string LastModifiedDateTimeLabel
        {
            get { return "Dernière date/heure de modification:"; }
        }

        public string ClosedByLabel
        {
            get { return "Fermé par:"; }
        }

        public string ClosedBy
        {
            get
            {
                return
                    form.ClosedDateTime != null ? form.LastModifiedBy.FullNameWithUserName : string.Empty;
            }
        }

        public string ClosedDateTimeLabel
        {
            get { return "Date/heure de fermeture:"; }
        }

        public string ClosedByDateTime
        {
            get
            {
                return form.ClosedDateTime != null ? form.ClosedDateTime.Value.ToLongDateAndTimeString() : string.Empty;
            }
        }

        public string FunctionalLocationLabel
        {
            get { return "Postes techniques:"; }
        }

        public override string ReturnedBackToService
        {
            get
            {
                return form.ClosedDateTime != null ? form.ClosedDateTime.Value.ToLongDateAndTimeString() : string.Empty;
            }
        }

        public override string Status
        {
            get
            {
                if ((base.Status == FormStatus.Approved.GetName() || base.Status == FormStatus.Draft.GetName()) &&
                    (Clock.Now > DateTime.Parse(base.ValidTo)))
                    return FormStatus.Expired.GetName();
                return base.Status;
            }
        }

        public string SafetyValveLabel
        {
            get { return "Soupape de sureté:"; }
        }

        public bool? IsCriticalSystemsDefeatedForSafeyValueYes
        {
            get { return form.IsTheCSDForAPressureSafetyValve; }
        }

        public bool? IsCriticalSystemsDefeatedForSafeyValueNo
        {
            get { return !form.IsTheCSDForAPressureSafetyValve; }
        }

        public string CriticalSystemDefeatedLabel
        {
            get { return "Équipement hors service:"; }
        }

        public string CriticalSystemDefeated
        {
            get { return form.CriticalSystemDefeated; }
        }

        public string CriticalSystemDefeatedReasonLabel
        {
            get { return "But de l'installation temporaire :"; }
        }

        public string CriticalSystemDefeatedReason
        {
            get { return form.CsdReason; }
        }

        public override string ValidFromLabel
        {
            get { return "Date de mise hors service:"; }
        }

        public override string ValidToLabel
        {
            get { return "Date de remise en service prévue:"; }
        }

        public override string CommentsAsRtf
        {
            get { return form.Content; }
        }

        public override List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    form.FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }

        public string CriticalSystemDefeatCommunicatedLabel
        {
            get { return "Est-ce que la dérivation a été communiquée à tous les employés concernés:"; }
        }

        public bool? CriticalSystemDefeatCommunicatedYes
        {
            get { return form.HasBeenCommunicated; }
        }

        public bool? CriticalSystemDefeatCommunicatedNo
        {
            get { return !form.HasBeenCommunicated; }
        }

        public string HasAttachementsLabel
        {
            get { return "Est-ce que les pièces jointes sont incluses au rapport (Liens du document):"; }
        }

        public bool? HasAttachmentsYes
        {
            get { return form.HasAttachments; }
        }

        public bool? HasAttachmentsNo
        {
            get { return !form.HasAttachments; }
        }
    }
}