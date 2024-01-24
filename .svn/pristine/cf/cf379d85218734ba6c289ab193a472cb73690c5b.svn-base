using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TargetAssociationFormPresenter
    {
        private readonly ITargetDefinitionService targetDefinitionService;
        private readonly ITargetAssociationSelectionView view;
        private readonly TargetDefinition parentTargetDefinition;

        public TargetAssociationFormPresenter(ITargetAssociationSelectionView view,
                                              ITargetDefinitionService targetService,
                                              TargetDefinition targetDefinition)
        {
            this.view = view;
            targetDefinitionService = targetService;
            parentTargetDefinition = targetDefinition;
        }

        public void ListViewSelectedItemChanged(object sender, DomainEventArgs<TargetDefinitionDTO> e)
        {
            List<TargetDefinitionDTO> selectedTargets = view.SelectedTargets;
            view.AddButtonEnabled = (selectedTargets != null && selectedTargets.Count > 0);
        }

        public void AssociatedListSelectedItemChanged(object sender, DomainEventArgs<TargetDefinitionDTO> e)
        {
            List<TargetDefinitionDTO> selectedAssociatedTargets = view.SelectedAssociatedTargets;
            view.RemoveButtonEnabled = (selectedAssociatedTargets != null && selectedAssociatedTargets.Count > 0);
        }

        public void SearchButtonClickEvent(object sender, EventArgs eventArgs)
        {
            long siteId = ClientSession.GetUserContext().SiteId;
            string searchText = view.SearchText.Trim();
            List<TargetDefinition> result = targetDefinitionService.QueryActiveByName(siteId, searchText);

            view.Targets =
                result.ConvertAll(targetDef => new TargetDefinitionDTO(targetDef));
        }


        public void AddTargetAssociations(object sender, EventArgs eventArgs)
        {
            List<TargetDefinitionDTO> associatedTargets = view.AssociatedTargets;

            view.SelectedTargets
                .FindAll(selected => associatedTargets.DoesNotContain(selected))
                .ForEach(associatedTargets.Add);

            view.AssociatedTargets = associatedTargets;
        }

        public void RemoveTargetAssociations(object sender, EventArgs eventArgs)
        {
            List<TargetDefinitionDTO> associatedTargets = view.AssociatedTargets;

            view.SelectedAssociatedTargets.ForEach(s => associatedTargets.Remove(s));

            view.AssociatedTargets = associatedTargets;

            view.RemoveButtonEnabled = (associatedTargets != null && associatedTargets.Count > 0);
        }

        public void CancelAssociations(object sender, EventArgs eventArgs)
        {
            // don't persist the changes to the Target
            view.CloseForm();
        }

        public void SaveAssociations(object sender, EventArgs eventArgs)
        {
            if (parentTargetDefinition != null)
            {
                SaveTargetToTargetAssociation();
            }
            else
            {
                view.CloseForm();
            }
        }

        private void SaveTargetToTargetAssociation()
        {
            // Only do the circular check for Targets that are being edited.
            if (parentTargetDefinition.Id.HasValue)
            {
                var newTargetDefinition = parentTargetDefinition.Clone() as TargetDefinition;
                if (newTargetDefinition != null)
                {
                    newTargetDefinition.AssociatedTargetDTOs =
                        view.AssociatedTargets;

                    try
                    {
                        targetDefinitionService.CheckCircularDependencyCreated(newTargetDefinition);
                        view.CloseForm();
                    }
                    catch (LinkedTargetCircularReferenceException ex)
                    {
                        view.SetError(StringResources.TargetAssociationCircularDependencyError + ex.CircularTarget.Name);
                    }
                }
            }
            else
            {
                view.CloseForm();
            }
        }
    }
}