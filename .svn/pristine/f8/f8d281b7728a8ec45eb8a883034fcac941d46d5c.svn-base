using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITrainingBlockConfigurationView : IBaseForm
    {
        event Action NewButtonClick;
        event Action EditButtonClick;
        event Action DeleteButtonClick;
        event Action FormLoad;
        event Action<TrainingBlock> SelectedTrainingBlockChanged;

        List<TrainingBlock> TrainingBlocks { set; get; }
        IList<FunctionalLocation> FunctionalLocations { set; get; }
        TrainingBlock SelectedTrainingBlock { get; set; }
        bool EditButtonEnabled { set; }
        bool DeleteButtonEnabled { set; }
        void SelectFirstTrainingBlock();
        void AddTrainingBlock(TrainingBlock trainingBlock);
        void RefreshTrainingBlocks();
        void RemoveTrainingBlock(TrainingBlock trainingBlock);
    }
}
