using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigurePreApprovedTargetRangesFormPresenter
    {
        private readonly IConfigurePreApprovedTargetRangesView view;
        private readonly IAuthorized authorized;
        private readonly TargetDefinition targetDefinition;
        
        public ConfigurePreApprovedTargetRangesFormPresenter(IConfigurePreApprovedTargetRangesView view, TargetDefinition targetDefinition) :
            this(view, new Authorized(), targetDefinition)
        {
        }

        public ConfigurePreApprovedTargetRangesFormPresenter(IConfigurePreApprovedTargetRangesView view, 
                                                             IAuthorized authorized, 
                                                             TargetDefinition targetDefinition)
        {
            this.view = view;
            this.authorized = authorized;
            this.targetDefinition = targetDefinition;

            AddEventHooks();
        }

        private void AddEventHooks()
        {
            view.FormLoad += HandleFormLoad;
            view.Save += HandleSave;
            view.Cancel += HandleCancel;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.WritableMode = authorized.ToConfigurePreApprovedTargetRanges(ClientSession.GetUserContext().UserRoleElements);
            view.TargetDefinitionName = targetDefinition.Name;
            view.PreApprovedNeverToExceedMin = targetDefinition.PreApprovedNeverToExceedMinimum;
            view.PreApprovedNeverToExceedMax = targetDefinition.PreApprovedNeverToExceedMaximum;
            view.PreApprovedMin = targetDefinition.PreApprovedMinValue;
            view.PreApprovedMax = targetDefinition.PreApprovedMaxValue;

            TagInfo tagInfo = targetDefinition.TagInfo;
            view.TagUnit = tagInfo != null ? tagInfo.Units : string.Empty;

            view.NeverToExceedMinEnabled = targetDefinition.PreApprovedNeverToExceedMinimum.HasValue;
            view.NeverToExceedMaxEnabled = targetDefinition.PreApprovedNeverToExceedMaximum.HasValue;
            view.MinEnabled = targetDefinition.PreApprovedMinValue.HasValue;
            view.MaxEnabled = targetDefinition.PreApprovedMaxValue.HasValue;
        }

        public void HandleSave(object sender, EventArgs e)
        {
            view.Close();
        }

        public void HandleCancel(object sender, EventArgs e)
        {
            view.Close();
        }

        public TargetDefinition BuildTargetDefinition()
        {
            targetDefinition.PreApprovedNeverToExceedMinimum = view.PreApprovedNeverToExceedMin;
            targetDefinition.PreApprovedNeverToExceedMaximum = view.PreApprovedNeverToExceedMax;
            targetDefinition.PreApprovedMinValue = view.PreApprovedMin;
            targetDefinition.PreApprovedMaxValue = view.PreApprovedMax;

            return targetDefinition;
        }
    }
}