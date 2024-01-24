using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Presenters
{
    class GasTestMudsFormPresenter
    {
        public List<GasTestElementInfo> standardGasTestElementInfoList;
        private readonly IGasTestElementInfoService gasTestElementInfoService;
        private readonly IDictionary<GasTestElementDetailsMuds, GasTestElement> detailsToGasTestElementTable;
        private readonly IWorkPermitMudsService service;
        WorkPermitMuds workPermit;
        public  GasTestMudsFormPresenter(long WorkPermitId)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            gasTestElementInfoService = clientServiceRegistry.GetService<IGasTestElementInfoService>();
            detailsToGasTestElementTable = new Dictionary<GasTestElementDetailsMuds, GasTestElement>();
             service = clientServiceRegistry.GetService<IWorkPermitMudsService>();
             workPermit = service.QueryById(WorkPermitId);
        }

        //Gas test Added
   
        private void QueryStandardGasTestElementInfoList()
        {

            standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(ClientSession.GetUserContext().SiteId);
        }

       public void SavePermitandGastest(GasTestElementLayoutPanelMuds contr)
       {
           if (workPermit != null)
           {
               SaveWorkItemGasTests(contr, workPermit.GasTests);
               service.Update(workPermit);
           }

       }
       
        public void SaveWorkItemGasTests( GasTestElementLayoutPanelMuds contr, WorkPermitGasTests gasTests)
        {
            
            gasTests.GasTestFirstResultTime =contr.ImmediateAreaTime;

            gasTests.GasTestSecondResultTime = contr.ConfinedSpaceTime;

            gasTests.GasTestThirdResultTime = contr.ThirdResultTime;

            gasTests.GasTestFourthResultTime = contr.FourthResultTime;

            List<GasTestElementDetailsMuds> gasTestElementDetailsList = contr.GasTestElementDetailsList;
            // gasTests= new WorkPermitGasTests();
            foreach (GasTestElementDetailsMuds details in gasTestElementDetailsList)
            {
                GasTestElement element;
                if (detailsToGasTestElementTable.Keys.Contains(details) == false)
                {
                    GasTestElementInfo info;
                    if (details.IsStandard)
                    {
                        long? detailElementInfoId = details.GasTestElementInfoId;
                        info = FindStandardGasTestElementInfoById(detailElementInfoId);
                    }
                    else
                    {
                        Site site = ClientSession.GetUserContext().Site;
                        info = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                        //info = GasTestElementInfo.CreateOtherGasTestElementInfo_Other(site);
                    }
                    element = GasTestElement.CreateGasTestElement(info);
                    detailsToGasTestElementTable.Add(details, element);
                }
                else
                {
                    element = detailsToGasTestElementTable[details];
                }

                SaveGasTestElement(details, element);
                if (element.HasData() && gasTests.Elements.Contains(element) == false)
                {
                    gasTests.Elements.Add(element);
                }
                else if (element.HasData() == false && gasTests.Elements.Contains(element))
                {
                    gasTests.Elements.Remove(element);
                }
                gasTests.Elements.Add(element);
            }
        }

        private static void SaveGasTestElement(GasTestElementDetailsMuds details, GasTestElement element)
        {
            element.ImmediateAreaTestResult = details.ImmediateAreaTestResult;
            element.ImmediateAreaTestRequired = details.ImmediateAreaTestRequired;
            element.ConfinedSpaceTestResult = details.ConfinedSpaceTestResult;
            element.ConfinedSpaceTestRequired = details.ConfinedSpaceTestRequired;
            element.SystemEntryTestResult = details.SystemEntryTestResult;
            element.SystemEntryTestNotApplicable = details.SystemEntryTestNotApplicable;
            
            element.ThirdTestRequired = details.ThirdTestRequired;
            element.ThirdTestResult = details.ThirdTestResult;

            element.FourthTestRequired = details.FourthTestRequired;
            element.FourthTestResult = details.FourthTestResult;

            if (element.ElementInfo.IsStandard == false)
            {
                element.ElementInfo.OtherLimits = details.Limits;
                element.ElementInfo.Name = details.ElementName;
                element.ElementInfo.Name = details.ElementNameOther;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

            }
        }

        private GasTestElementInfo FindStandardGasTestElementInfoById(long? elementInfoId)
        {
            foreach (GasTestElementInfo standardInfo in standardGasTestElementInfoList)
            {
                if (standardInfo.Id == elementInfoId)
                {
                    return standardInfo;
                }
            }
            throw new ApplicationException("Invalid Standard Gas Test Element Info Id : " + elementInfoId);
        }


        #region Load WorkItem - GasTests

        public void LoadWorkItemGasTests( GasTestElementLayoutPanelMuds contrl)
        {
            // view.GasTestEventsEnabled = false;
            if (workPermit.GasTests.GasTestFirstResultTime != null)
                contrl.ImmediateAreaTime = workPermit.GasTests.GasTestFirstResultTime;

            if (workPermit.GasTests.GasTestSecondResultTime != null)
                contrl.ConfinedSpaceTime = workPermit.GasTests.GasTestSecondResultTime;

            if (workPermit.GasTests.GasTestThirdResultTime != null)
                contrl.ThirdResultTime = workPermit.GasTests.GasTestThirdResultTime;

            if (workPermit.GasTests.GasTestFourthResultTime != null)
                contrl.FourthResultTime = workPermit.GasTests.GasTestFourthResultTime;

            WorkPermitGasTests gasTests = workPermit.GasTests;
            detailsToGasTestElementTable.Clear();
          
            foreach (GasTestElementDetailsMuds details in contrl.GasTestElementDetailsList)
            {


                GasTestElement element = FindOrCreateGasTestElementForDetails(gasTests.Elements, details);
                LoadGasTestElement(details, element, workPermit);
                detailsToGasTestElementTable.Add(details, element);
            }

            // view.GasTestEventsEnabled = true;
        }

        private readonly List<string> _listElement = new List<string>();
        private bool has = false;

        private GasTestElement FindOrCreateGasTestElementForDetails(IEnumerable<GasTestElement> elementList, GasTestElementDetailsMuds gasTestElementDetails)
        {
            long? gasTestElementInfoId = gasTestElementDetails.GasTestElementInfoId;

            foreach (GasTestElement element in elementList)
            {

                if (gasTestElementDetails.IsStandard)
                {
                    if (element.ElementInfo.Id == gasTestElementInfoId)
                    {
                        return element;
                    }
                }
                else if (element.ElementInfo.Id == null ||
                        (element.ElementInfo.IsStandard == false && gasTestElementInfoId == null) ||
                        element.ElementInfo.Id == gasTestElementInfoId)
                {
                    //return element;
                    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                    if (_listElement.Count == 0)
                    {
                        _listElement.Add(Convert.ToString(element.ElementInfo.Name));
                        return element;
                    }

                    has = _listElement.Any(s => s == Convert.ToString(element.ElementInfo.Name));
                    if (!has) return element;


                }
            }

            if (gasTestElementInfoId == null)
            {
                Site site = ClientSession.GetUserContext().Site;
                GasTestElementInfo otherInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                return GasTestElement.CreateGasTestElement(otherInfo);
            }
            GasTestElementInfo info = FindStandardGasTestElementInfoById(gasTestElementInfoId);
            return GasTestElement.CreateGasTestElement(info);
        }

        private static void LoadGasTestElement(GasTestElementDetailsMuds details, GasTestElement element, WorkPermitMuds workPermit)
        {

            details.ElementName = element.ElementInfo.Name;
            details.ElementNameOther = element.ElementInfo.Name;
          
            details.Limits = element.ElementInfo.HotLimit.ToLimitStringWithUnit(element.ElementInfo.IsRangedLimit, element.ElementInfo.DecimalPlaceCount, element.ElementInfo.Unit);
            details.GasTestElementInfoId = element.ElementInfo.Id;
            details.IsStandard = element.ElementInfo.IsStandard;
            details.ImmediateAreaTestResult = element.ImmediateAreaTestResult;
            details.ImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
            details.ConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
            details.ConfinedSpaceTestResult = element.ConfinedSpaceTestResult;
            details.ThirdTestRequired = element.ThirdTestRequired;
            details.ThirdTestResult = element.ThirdTestResult;

            details.FourthTestRequired = element.FourthTestRequired;
            details.FourthTestResult = element.FourthTestResult;
        }

        #endregion Load Work Item - Gas Tests


        public bool ValidateGasTest(GasTestElementLayoutPanelMuds contrl)
        {
            bool result = true;

            List<GasTestElementDetailsMuds> lst = contrl.GasTestElementDetailsList;
            foreach (GasTestElementDetailsMuds Contrl in lst)
            {
                Contrl.ClearWarningMessages();
                if (Contrl.ImmediateAreaTestRequired && Contrl.ImmediateAreaTestResult.HasValue)
                {
                    GasTestElementInfo info = standardGasTestElementInfoList.FindById(Contrl.GasTestElementInfoId);
                    GasLimitRange range = info.GetLimitRange(WorkPermitType.HOT, new WorkPermitAttributes());
                    if (Contrl.ImmediateAreaTestResult.OutsideOf(range))
                    {
                        Contrl.SetImmediateAreaResultAlertMessage("Outside Range");
                        result = false;
                    }
                }

            }

            // bool returnResult = result || resultError;

            return result;
        }

    }
}
