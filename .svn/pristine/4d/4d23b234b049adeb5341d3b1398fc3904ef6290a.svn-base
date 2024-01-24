using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class PriorityPageOilsandsTrainingFormContext : OilsandsTrainingFormContext
    {
        private readonly FormOilsandsTraining form;

        public PriorityPageOilsandsTrainingFormContext(FormOilsandsTraining form, IFormOilsandsService formService, AbstractMultiGridPage page) : base(formService, page)
        {
            this.form = form;
        }

        protected override IList<FormOilsandsTrainingDTO> GetData(DtoFilters filters)
        {
            return new List<FormOilsandsTrainingDTO> { new FormOilsandsTrainingDTO(form) };
        }

        public override FormOilsandsTraining QueryById(long id)
        {
            return form;
        }
    }
}