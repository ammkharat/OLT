using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigGasTestElementInfoFormPresenter
    {
        private readonly IConfigGasTestElementInfoFormView view;
        private readonly IGasTestElementInfoService gasTestElementInfoService;
        private readonly IEditHistoryService editHistoryService;

        private readonly Site site;

        public ConfigGasTestElementInfoFormPresenter(IConfigGasTestElementInfoFormView view, Site site) : this(
            view,
            site,
            ClientServiceRegistry.Instance.GetService<IGasTestElementInfoService>(),
            ClientServiceRegistry.Instance.GetService<IEditHistoryService>())
        {
        }

        public ConfigGasTestElementInfoFormPresenter(
            IConfigGasTestElementInfoFormView view,
            Site site,
            IGasTestElementInfoService gasTestElementInfoService,
            IEditHistoryService editHistoryService)
        {
            this.view = view;
            this.site = site;
            this.gasTestElementInfoService = gasTestElementInfoService;
            this.editHistoryService = editHistoryService;
        }

        public void HandleFormLoad(object sender, EventArgs args)
        {
            view.Site = site;
            view.StandardGasTestElementInfoDTOList = gasTestElementInfoService.QueryStandardElementInfoDTOsBySiteId(site.IdValue);
        }

        public void HandleSaveButtonClick(object sender, EventArgs args)
        {
            List<GasTestElementInfoDTO> infoDTOList = view.StandardGasTestElementInfoDTOList;
            view.ClearErrorMessage();
            if (IsValid(infoDTOList))
            {
                gasTestElementInfoService.UpdateGasTestElementInfoDTOList(infoDTOList);
                editHistoryService.TakeSnapshot(infoDTOList, Clock.Now, ClientSession.GetUserContext().User, site.IdValue);
                view.SaveSucceededMessage();
                view.Close();
            }
        }

        public void HandleViewEditHistory(object sender, EventArgs e)
        {
            EditGasTestElementInfoConfigurationHistoryFormPresenter presenter = new EditGasTestElementInfoConfigurationHistoryFormPresenter(ClientSession.GetUserContext().Site);
            presenter.Run(view);
        }

        private bool IsValid(IEnumerable<GasTestElementInfoDTO> infoDTOList)
        {
            bool ret = true;

            foreach (GasTestElementInfoDTO dto in infoDTOList)
            {
                if (IsValidDTO(dto) == false)
                    ret = false;
            }
            return ret;
        }

        private static bool IsValidGasLimit(GasLimitUnit unit, bool isRangedLimit, string strLimit, out string errorMessage)
        {
            bool ret = false;
            if (GasLimitRange.IsValid(strLimit, isRangedLimit, out errorMessage))
            {
                GasLimitRange limitRange = GasLimitRange.FromString(strLimit);
                if (unit.IsWithinRange(limitRange, out errorMessage))
                {
                    ret = true;
                }
            }
            return ret;
        }

        private bool IsValidDTO(GasTestElementInfoDTO dto)
        {
            string errorMessage;

            GasLimitUnit unit = GasLimitUnit.QueryByName(dto.UnitName);

            bool isValidUnit = (
                                   dto.ColdLimit.IsNullOrEmptyOrWhitespace() &&
                                   dto.HotLimit.IsNullOrEmptyOrWhitespace() &&
                                   dto.CSELimit.IsNullOrEmptyOrWhitespace() &&
                                   dto.InertCSELimit.IsNullOrEmptyOrWhitespace()
                               ) ||
                               unit.Equals(GasLimitUnit.UNKNOWN) == false;

            if ( isValidUnit == false)
                view.SetUnitErrorMessage(dto, StringResources.GasLimitUnitMissing);

            bool isColdLimitValid = IsValidGasLimit(unit, dto.IsRangedLimit, dto.ColdLimit, out errorMessage);
            if ( isColdLimitValid == false)
                view.SetColdLimitErrorMessage(dto, errorMessage);

            bool isHotLimitValid = IsValidGasLimit(unit, dto.IsRangedLimit, dto.HotLimit, out errorMessage);
            if ( isHotLimitValid == false)
                view.SetHotLimitErrorMessage(dto, errorMessage);

            bool isCSELimitValid = IsValidGasLimit(unit, dto.IsRangedLimit, dto.CSELimit, out errorMessage);
            if ( isCSELimitValid == false)
                view.SetCSELimitErrorMessage(dto, errorMessage);

            bool isInertCSELimitValid = IsValidGasLimit(unit, dto.IsRangedLimit, dto.InertCSELimit, out errorMessage);
            if (isInertCSELimitValid == false)
                view.SetInertCSELimitErrorMessage(dto, errorMessage);

            return isValidUnit &&
                   isColdLimitValid &&
                   isHotLimitValid &&
                   isCSELimitValid &&
                   isInertCSELimitValid;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "ConfigGasTEstElementInfoDialog SiteId: " + site.Id;
        }
    } 
}
