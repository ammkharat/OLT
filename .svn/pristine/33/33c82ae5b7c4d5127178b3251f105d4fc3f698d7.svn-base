using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditTrainingBlockFormPresenter : BaseFormPresenter<IAddEditTrainingBlockView>
    {
        private readonly TrainingBlock editObject;
        private readonly bool isEditMode;
        private readonly ITrainingBlockService trainingBlockService;

        public AddEditTrainingBlockFormPresenter(TrainingBlock editObject, bool isEditMode) : base(new AddEditTrainingBlockForm())
        {
            this.editObject = editObject;
            this.isEditMode = isEditMode;

            view.FormLoad += HandleFormLoad;
            view.SaveButtonClick += HandleSaveButtonClick;

            trainingBlockService = ClientServiceRegistry.Instance.GetService<ITrainingBlockService>();
        }

        private bool Validate()
        {
            bool hasErrors = false;

            if (view.TrainingBlockName == null)
            {
                view.ShowNameMustNotBeEmptyError();
                hasErrors = true;
            }

            if (view.FunctionalLocations.Count == 0)
            {
                view.ShowAtLeastOneFunctionalLocationIsNecessaryError();
                hasErrors = true;
            }

            if (trainingBlockService.CountOfTrainingBlocksWithName(view.TrainingBlockName, editObject.Id,ClientSession.GetUserContext().SiteId) != 0)          //ayman training block
            {
                view.ShowNameMustBeUniqueError();
                hasErrors = true;
            }

            return hasErrors;
        }

        private void HandleSaveButtonClick()
        {
            bool hasErrors = Validate();

            if (hasErrors)
            {
                return;
            }

            UpdateEditObjectFromView();

            if (isEditMode)
            {
                trainingBlockService.Update(editObject);
            }
            else
            {
                long id = trainingBlockService.Insert(editObject);
                editObject.Id = id;
            }

            view.DialogResult = DialogResult.OK;
            view.SaveSucceededMessage();
            view.Close();
        }

        private void UpdateEditObjectFromView()
        {
            editObject.Name = view.TrainingBlockName;
            editObject.Code = view.TrainingCode;
            editObject.FunctionalLocations.Clear();
            editObject.FunctionalLocations.AddRange(view.FunctionalLocations);
        }

        private void HandleFormLoad()
        {
            if (isEditMode)
            {
                view.FormTitle = StringResources.EditTrainingBlock;

                view.TrainingBlockName = editObject.Name;
                view.TrainingCode = editObject.Code;
                view.FunctionalLocations = editObject.FunctionalLocations;
            }
            else
            {
                view.FormTitle = StringResources.AddTrainingBlock;
            }
        }
    }
}
