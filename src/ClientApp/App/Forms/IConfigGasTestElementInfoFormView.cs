using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigGasTestElementInfoFormView : IBaseForm
    {
        List<GasTestElementInfoDTO> StandardGasTestElementInfoDTOList { set; get; }
        Site Site { set; }

        void ClearErrorMessage();

        void SetColdLimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage);
        void SetHotLimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage);
        void SetCSELimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage);
        void SetInertCSELimitErrorMessage(GasTestElementInfoDTO dto, string errorMessage);
        void SetUnitErrorMessage(GasTestElementInfoDTO dto, string errorMessage);
    }
}
