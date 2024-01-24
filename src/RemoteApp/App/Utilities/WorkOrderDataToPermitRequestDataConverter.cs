using System;
using log4net;
using System.Text;
using Com.Suncor.Olt.Common.Domain.Schedule;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Wcf;


namespace Com.Suncor.Olt.Remote.Utilities
{
    public abstract class WorkOrderDataToPermitRequestDataConverter<T> where T : BasePermitRequest
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<WorkOrderDataToPermitRequestDataConverter<T>>();

        protected readonly ITimeService timeService;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IPermitAttributeDao permitAttributeDao;
        private readonly ICraftOrTradeDao craftOrTradeDao;

        protected WorkOrderDataToPermitRequestDataConverter(ITimeService timeService, IFunctionalLocationDao functionalLocationDao, 
            IPermitAttributeDao permitAttributeDao, ICraftOrTradeDao craftOrTradeDao)
        {                        
            this.timeService = timeService;
            this.functionalLocationDao = functionalLocationDao;
            this.permitAttributeDao = permitAttributeDao;
            this.craftOrTradeDao = craftOrTradeDao;
        }

        public List<T> ConvertToPermitRequests(List<WorkOrderImportData> incomingWorkOrderDataList, User userThatInitiatedImport, Site site, out List<PermitRequestImportRejection> rejectList)
        {            
            List<T> permitRequests = new List<T>();
            rejectList = new List<PermitRequestImportRejection>();

            // Pull out any "unsuccessful" work orders
            List<WorkOrderImportData> importDataList = FilterOutWorkOrdersWithUnsuccessfulStatusAndAddToRejectList(incomingWorkOrderDataList, rejectList);

            foreach (WorkOrderImportData importDataItem in importDataList)
            {
                PermitRequestImportRejection rejection;

                try
                {
                    T permitRequest = BuildPermitRequest(importDataItem, userThatInitiatedImport, site, out rejection);

                    if (permitRequest != null)
                    {
                        permitRequests.Add(permitRequest);
                    }
                    else if (rejection != null)
                    {
                        rejectList.Add(rejection);
                    }
                }
                catch (Exception e)
                {
                    logger.Error("There was an unexpected error processing an operation.", e);
                    rejection = new PermitRequestImportRejection(StringResources.PermitRequestRejectionExceptionMessage, e);
                    rejectList.Add(rejection);
                }
                
            }
            
            return permitRequests;
        }

        private List<WorkOrderImportData> FilterOutWorkOrdersWithUnsuccessfulStatusAndAddToRejectList(IEnumerable<WorkOrderImportData> importDataList, List<PermitRequestImportRejection> rejectList)
        {
            List<WorkOrderImportData> successList = new List<WorkOrderImportData>();

            foreach (WorkOrderImportData importDataItem in importDataList)
            {
                  if (!string.Equals(importDataItem.ProcessStatus, WorkOrderImporter.SUCCESS_STATUS))
                  {
                        string workOrderNumber = importDataItem.WONumber.EmptyToNull();
                        string reason = workOrderNumber == null
                                            ? StringResources.PermitRequestImportValidationError_NonSuccessStatus
                                            : string.Format(StringResources.PermitRequestImportValidationError_NonSuccessStatusWithWONumber,
                                              workOrderNumber);

                        PermitRequestImportRejection rejectionDueToStatus = new PermitRequestImportRejection(reason);

                        rejectList.Add(rejectionDueToStatus);                        
                  } 
                  else
                  {
                      successList.Add(importDataItem);
                  }
            }

            return successList;
        }

        private T BuildPermitRequest(WorkOrderImportData importData, User importUser, Site site, out PermitRequestImportRejection rejection)
        {
            //mangesh- PRB0043938
            // We ignore these. In the future, these may be turned into Action Items.
            //if (SAPWorkCentre.IsInWorkCentreList(importData.WorkCenterName))
            //{
            //    rejection = null;
            //    return null;
            //}

            FunctionalLocation floc = functionalLocationDao.QueryByFullHierarchy(importData.FunctionalLocation, site.IdValue);

            DateTime? currentTimeAtSite = null;
            CraftOrTrade craftOrTrade = null;
            
            if (floc != null)
            {
                currentTimeAtSite = timeService.GetTime(floc.Site.TimeZone);
                craftOrTrade = craftOrTradeDao.QueryByWorkCentreCodeAndSiteId(importData.WorkCenterName, floc.Site.IdValue);
            }

            // note: On the message, WorkCenterName is what we might call the code. ie. BNP-541C. In our DB, it's the opposite.
            string trade = BuildTrade(craftOrTrade, importData.WorkCenterText, importData.WorkCenterName);
            string workCenterCode = importData.WorkCenterName;

            DateTime? startDateTime = GetDateTime(importData.EarliestStartDate, importData.EarliestStartTime);
            Date endDate = GetDate(importData.EarliestFinishDate);

            string workOrderNumber = importData.WONumber;
            string operationNumber = importData.OperationNumber.EmptyToNull();
            string subOperationNumber = importData.Suboperation.EmptyToNull();

            string descriptionFromSAP = BuildDescription(importData.LongText, importData.ShortText);
            if (descriptionFromSAP != null)
            {
                descriptionFromSAP = descriptionFromSAP.TrimWhitespace();
            }
            string description = descriptionFromSAP;
            string sapDescription = descriptionFromSAP;

            string company = null;
            string supervisor = null;
            
            DataSource dataSource = DataSource.SAP;
            User lastImportedByUser = importUser;
            DateTime? lastImportedDateTime = currentTimeAtSite;
            User lastSubmittedByUser = null;
            DateTime? lastSubmittedDateTime = null;
            User createdBy = importUser;
            DateTime createdDateTime = currentTimeAtSite.HasValue ? currentTimeAtSite.Value : DateTime.MinValue;
            User lastModifiedBy = importUser;
            DateTime lastModifiedDateTime = currentTimeAtSite.HasValue ? currentTimeAtSite.Value : DateTime.MinValue;

            //mangesh- PRB0043938
            //TODO check to implement for OPERATIO work center OR all waction item related work center
            if (importData.WorkCenterName.Equals(WorkCentreName.OPERATIO) && SAPWorkCentre.IsInWorkCentreList(importData.WorkCenterName))
            {
                WorkOrderToActionItemDefinition.BuildActionItemDefinition(importData, floc, logger, timeService);
                rejection = null;
                return null; 
            }

            T request = BuildPermitRequest(importData, floc, startDateTime, endDate, workOrderNumber,
                    operationNumber, subOperationNumber,
                    trade, workCenterCode, description, sapDescription, company, supervisor, dataSource,
                    lastImportedByUser, lastImportedDateTime,
                    lastSubmittedByUser, lastSubmittedDateTime, createdBy, createdDateTime, lastModifiedBy,
                    lastModifiedDateTime);

            rejection = Validate(request, importData);

            if (rejection == null)
            {
                return request;
            }    

            return null;                      
        }

        protected virtual string BuildTrade(CraftOrTrade craftOrTrade, string workCenterText, string workCentreCode)
        {
            return craftOrTrade != null ? craftOrTrade.Name : null;
        }

        protected abstract T BuildPermitRequest(WorkOrderImportData importData,
                                                                FunctionalLocation functionalLocation,
                                                                DateTime? startDateTime,
                                                                Date endDate,
                                                                string workOrderNumber,
                                                                string operationNumber,
                                                                string subOperationNumber,
                                                                string trade,
                                                                string workCenterCode,
                                                                string description,
                                                                string sapDescription,
                                                                string company,
                                                                string supervisor,
                                                                DataSource dataSource,
                                                                User lastImportedByUser,
                                                                DateTime? lastImportedDateTime,
                                                                User lastSubmittedByUser,
                                                                DateTime? lastSubmittedDateTime,
                                                                User createdBy,
                                                                DateTime createdDateTime,
                                                                User lastModifiedBy,
                                                                DateTime lastModifiedDateTime);
      

        private static Date GetDate(string dateString)
        {
            DateTime result;
            bool parsed = DateTime.TryParse(dateString, out result);

            return parsed ? new Date(result) : default(Date);
        }

        private static DateTime? GetDateTime(string dateString, string timeString)
        {
            DateTime result;

            // first try to parse both the date and time.
            if (dateString.HasValue() && timeString.HasValue())
            {
                bool parsed = DateTimeExtensions.TryParse(dateString, timeString, out result);
                if (parsed)
                {
                    return result;
                }
            }

            // if that fails, try to parse just the date.
            if (dateString.HasValue())
            {
                bool parsed = DateTimeExtensions.TryParse(dateString, Time.START_OF_DAY.ToString(), out result);
                if (parsed)
                {
                    return result;
                }
            }
            return default(DateTime?);
        }

        private PermitRequestImportRejection Validate(T request, WorkOrderImportData importData)
        {
            PermitRequestImportRejection rejection = null;
            
            if (request.HasNoFunctionalLocation() && !importData.FunctionalLocation.IsNullOrEmptyOrWhitespace())
            {
                string message = string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationNotFound, importData.FunctionalLocation);
                rejection = BuildRejection(message, importData);
            }
            else
            {
                List<string> missingImportFieldList = GetMissingImportFieldList(request);

                if (missingImportFieldList.Count > 0)
                {
                    string errorMessage = string.Format(StringResources.PermitRequestImportValidationError_FieldMissing, missingImportFieldList.BuildCommaSeparatedList());
                    rejection = BuildRejection(errorMessage, importData);
                }
                else if (request.HasAFunctionalLocationHigherThanLevel3())
                {
                    string message = string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationCannotBeLevel1Or2, request.FunctionalLocationNamesAsString);
                    rejection = BuildRejection(message, importData);
                }                
            }

            return rejection;
        }

        protected abstract List<string> GetMissingImportFieldList(T permitRequest);

        private static PermitRequestImportRejection BuildRejection(string reason, WorkOrderImportData importData)
        {
            return new PermitRequestImportRejection(
                reason, importData.FunctionalLocation, importData.OperationNumber, importData.Suboperation, importData.WONumber,
                importData.LongText, importData.ShortText, importData.EarliestStartDate, importData.EarliestFinishDate);            
        }

        protected virtual string BuildDescription(string longText, string shortText)
        {
            if (longText.IsNullOrEmptyOrWhitespace() && shortText.IsNullOrEmptyOrWhitespace())
            {
                return null;
            }

            return string.Format("{0}{1}{2}", longText.TrimWhitespace(), Environment.NewLine, shortText.TrimWhitespace());
        }

        protected List<PermitAttribute> GetAttributes(FunctionalLocation floc, string attributeString)
        {
            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(attributeString);

            if (attribs.Length == 0 || floc == null)
            {
                return new List<PermitAttribute>(0);
            }

            List<PermitAttribute> allAttributesForSite = permitAttributeDao.QueryBySiteId(floc.Site.IdValue);

            return allAttributesForSite.FindAll(pa => Array.Exists(attribs, attrib => attrib.Equals(pa.SapCode)));
        }

        protected List<string> CreateMissingImportFieldListForCommonFields(BasePermitRequest permitRequest)
        {
            List<string> fieldList = new List<string>();

            if (permitRequest.HasNoFunctionalLocation())
            {
                fieldList.Add(StringResources.PermitRequestFieldName_FunctionalLocation);
            }

            if (permitRequest.EndDate == null)
            {
                fieldList.Add(StringResources.PermitRequestFieldName_EndDate);
            }

            if (permitRequest.Description == null)
            {
                fieldList.Add(StringResources.PermitRequestFieldName_Description);
            }

            return fieldList;
        }

    }

    
}
