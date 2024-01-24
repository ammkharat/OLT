using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Services
{
    public class FunctionalLocationLookup : IFunctionalLocationLookup
    {
        private IFunctionalLocationInfoService flocInfoService;

        public FunctionalLocationLookup()
        {
        }

        public FunctionalLocationLookup(IFunctionalLocationInfoService flocInfoService)
        {
            this.flocInfoService = flocInfoService;    
        }

        public List<FunctionalLocationInfo> GetChildrenFor(long siteId)
        {
            return FlocInfoService.QueryDivisionsBySiteId(siteId);
        }

        public List<FunctionalLocationInfo> GetChildrenFor(FunctionalLocation floc)
        {
            return
                FlocInfoService.QueryByParentFunctionalLocation(floc);
        }

        public List<FunctionalLocationInfo> GetUnitsFor(long siteId)
        {
            return FlocInfoService.QueryUnitsBySiteId(siteId);
        }

        // lazy load service instead of getting it in constructor so that designer will work
        private IFunctionalLocationInfoService FlocInfoService
        {
            get { return flocInfoService ?? (flocInfoService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>()); }
        }
    }

    public class AdminFunctionalLocationLookup : IFunctionalLocationLookup
    {
        private IFunctionalLocationInfoService flocInfoService;

        public AdminFunctionalLocationLookup()
        {
        }

        public List<FunctionalLocationInfo> GetChildrenFor(long siteId)
        {
            return FlocInfoService.QueryDivisionsBySiteIdForAdmin(siteId);
        }

        public List<FunctionalLocationInfo> GetChildrenFor(FunctionalLocation floc)
        {
            return
                FlocInfoService.QueryByParentFunctionalLocationForAdmin(floc);
        }

        public List<FunctionalLocationInfo> GetUnitsFor(long siteId)
        {
            return FlocInfoService.QueryUnitsBySiteIdForAdmin(siteId);
        }

        // lazy load service instead of getting it in constructor so that designer will work
        private IFunctionalLocationInfoService FlocInfoService
        {
            get { return flocInfoService ?? (flocInfoService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>()); }
        }
    }

}