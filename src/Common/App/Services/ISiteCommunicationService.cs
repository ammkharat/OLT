using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ISiteCommunicationService
    {
        [OperationContract]
        List<SiteCommunication> QueryBySiteId(long siteId);

        [OperationContract]
        void Update(SiteCommunication siteCommunication);

        [OperationContract]
        SiteCommunication Insert(SiteCommunication siteCommunication);

        [OperationContract]
        List<SiteCommunication> QueryAll();   //ayman site communication

        [OperationContract] //ayman site communication
        List<SiteCommunication> InsertAllSites(SiteCommunication siteCommunication);

        [OperationContract]
        void Remove(SiteCommunication siteCommunication);

        [OperationContract]
        List<SiteCommunicationDTO> QueryBySiteAndDateTime(long siteId, DateTime dateTime);
    }
}