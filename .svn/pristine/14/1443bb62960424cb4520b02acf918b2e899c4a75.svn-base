using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TrainingBlockConfigurationFormPresenter : BaseFormPresenter<ITrainingBlockConfigurationView>
    {
        private readonly ITrainingBlockService trainingBlockService;

        public TrainingBlockConfigurationFormPresenter() : base(new TrainingBlockConfigurationForm())
        {
            view.NewButtonClick += HandleNewButtonClick;
            view.EditButtonClick += HandleEditButtonClick;
            view.DeleteButtonClick += HandleDeleteButtonClick;
            view.FormLoad += HandleFormLoad;
            view.SelectedTrainingBlockChanged += HandleSelectedTrainingBlockChanged;

            trainingBlockService = ClientServiceRegistry.Instance.GetService<ITrainingBlockService>();
        }

        private void HandleSelectedTrainingBlockChanged(TrainingBlock trainingBlock)
        {
            if (trainingBlock != null)
            {
                view.FunctionalLocations = trainingBlock.FunctionalLocations;
            }
        }

        private void HandleFormLoad()
        {
            List<TrainingBlock> trainingBlocks = trainingBlockService.QueryAll(ClientSession.GetUserContext().SiteId);

            if (trainingBlocks.IsEmpty())
            {
                view.EditButtonEnabled = false;
                view.DeleteButtonEnabled = false;
            }
            else
            {
                view.TrainingBlocks = trainingBlocks;
                view.SelectFirstTrainingBlock();
            }
        }

        private void HandleNewButtonClick()
        {
            TrainingBlock trainingBlock = new TrainingBlock(null, string.Empty, string.Empty,ClientSession.GetUserContext().SiteId, new List<FunctionalLocation>());    //ayman training block
            AddEditTrainingBlockFormPresenter presenter = new AddEditTrainingBlockFormPresenter(trainingBlock, false);
            DialogResult dialogResult = presenter.Run(view);

            if (dialogResult == DialogResult.OK)
            {
                view.AddTrainingBlock(trainingBlock);
                view.SelectedTrainingBlock = trainingBlock;

                view.EditButtonEnabled = true;
                view.DeleteButtonEnabled = true;
            }
        }

        private void HandleEditButtonClick()
        {
            TrainingBlock trainingBlock = view.SelectedTrainingBlock;
            AddEditTrainingBlockFormPresenter presenter = new AddEditTrainingBlockFormPresenter(trainingBlock, true);
            DialogResult dialogResult = presenter.Run(view);

            if (dialogResult == DialogResult.OK)
            {
                view.RefreshTrainingBlocks();
                view.SelectedTrainingBlock = trainingBlock;
            }
        }

        private void HandleDeleteButtonClick()
        {
            TrainingBlock trainingBlock = view.SelectedTrainingBlock;

            if (UIUtils.ConfirmDeleteDialog())
            {
                view.RemoveTrainingBlock(trainingBlock);
                trainingBlockService.Remove(trainingBlock);

                if (view.TrainingBlocks.Count == 0)
                {
                    view.EditButtonEnabled = false;
                    view.DeleteButtonEnabled = false;
                }
                else
                {
                    view.SelectFirstTrainingBlock();
                }
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Training Block Configuration Form - {0}", site.Id);
        }
    }
}
