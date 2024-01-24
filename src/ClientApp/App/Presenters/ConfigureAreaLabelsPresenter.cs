using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureAreaLabelsPresenter : BaseFormPresenter<IConfigureAreaLabelsView>
    {
        private readonly IAreaLabelService areaLabelService;
        private List<AreaLabel> areaLabels;
        private List<AreaLabel> originalAreaLabels;

        public ConfigureAreaLabelsPresenter(IConfigureAreaLabelsView view) : base(view)
        {
            areaLabelService = ClientServiceRegistry.Instance.GetService<IAreaLabelService>();

            view.Load += HandleViewLoad;
            view.AddAreaLabel += HandleAddAreaLabel;
            view.EditAreaLabel += HandleEditAreaLabel;
            view.DeleteAreaLabel += HandleDeleteAreaLabel;
            view.SaveAndClose += HandleSaveAndClose;
            view.MoveUp += HandleMoveUp;
            view.MoveDown += HandleMoveDown;
        }

        private void HandleSaveAndClose()
        {
            List<AreaLabel> deletedAreaLabels = new List<AreaLabel>();

            foreach (AreaLabel oldAreaLabel in originalAreaLabels)
            {
                if (oldAreaLabel.IsInDatabase() && !areaLabels.ExistsById(oldAreaLabel))
                {
                    deletedAreaLabels.Add(oldAreaLabel);
                }
            }

            areaLabelService.Update(areaLabels, deletedAreaLabels);

            view.Close();
        }

        private void HandleDeleteAreaLabel()
        {
            AreaLabel areaLabel = view.SelectedAreaLabel;
            if (areaLabel != null && view.UserIsSureTheyWantToDelete())
            {
                areaLabels.Remove(areaLabel);
                SortAndSetValuesOnGrid();
                view.SelectFirstValue();
            }            
        }

        private void HandleViewLoad(object sender, EventArgs e)
        {
            areaLabels = areaLabelService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            originalAreaLabels = new List<AreaLabel>(areaLabels);

            view.AreaLabels = areaLabels;
            view.SelectFirstValue();
        }

        private void HandleAddAreaLabel()
        {
            AddEditAreaLabelForm addEditAreaLabelForm = new AddEditAreaLabelForm(ClientSession.GetUserContext().SiteId, OtherSapPlannerGroups(null));
            DialogResult dialogResult = addEditAreaLabelForm.ShowDialog();

            if (dialogResult != DialogResult.Cancel)
            {
                AreaLabel newAreaLabel = addEditAreaLabelForm.AreaLabel;

                newAreaLabel.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(areaLabels) + 1;
                areaLabels.Add(newAreaLabel);
                SortAndSetValuesOnGrid();
                view.SelectedAreaLabel = newAreaLabel;
            }

            addEditAreaLabelForm.Dispose();
        }

        private void HandleEditAreaLabel()
        {
            AreaLabel selectedAreaLabel = view.SelectedAreaLabel;

            AddEditAreaLabelForm addEditAreaLabelForm = new AddEditAreaLabelForm(selectedAreaLabel, ClientSession.GetUserContext().SiteId, OtherSapPlannerGroups(selectedAreaLabel));
            DialogResult dialogResult = addEditAreaLabelForm.ShowDialog();

            if (dialogResult != DialogResult.Cancel)
            {
                SortAndSetValuesOnGrid();
                view.SelectedAreaLabel = selectedAreaLabel;
            }

            addEditAreaLabelForm.Dispose();
        }

        private void HandleMoveUp()
        {
            if (areaLabels.Count == 0)
            {
                return;
            }

            AreaLabel areaLabel = view.SelectedAreaLabel;

            int index = areaLabels.IndexOf(areaLabel);

            if (index == 0)
            {
                return;
            }

            areaLabels.Remove(areaLabel);
            areaLabels.Insert(index - 1, areaLabel);

            DisplayOrderHelper.ResetDisplayValues(areaLabels);
            SortAndSetValuesOnGrid();

            view.SelectedAreaLabel = areaLabel;

        }

        private void HandleMoveDown()
        {
            if (areaLabels.Count == 0)
            {
                return;
            }

            AreaLabel areaLabel = view.SelectedAreaLabel;

            int index = areaLabels.IndexOf(areaLabel);

            if (index == areaLabels.Count - 1)
            {
                return;
            }

            areaLabels.Remove(areaLabel);
            areaLabels.Insert(index + 1, areaLabel);

            DisplayOrderHelper.ResetDisplayValues(areaLabels);
            SortAndSetValuesOnGrid();

            view.SelectedAreaLabel = areaLabel;
        }

        private void SortAndSetValuesOnGrid()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(areaLabels);
            view.AreaLabels = areaLabels;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return String.Format("Configure Area Labels - {0}", site.IdValue);
        }

        private List<string> OtherSapPlannerGroups(AreaLabel areaLabel)
        {
            List<string> sapPlannerGroups = areaLabels.ConvertAll(label => label == areaLabel ? null : label.SapPlannerGroup);
            sapPlannerGroups.RemoveAll(groupName => groupName == null);
            return sapPlannerGroups;
        }
    }
}
