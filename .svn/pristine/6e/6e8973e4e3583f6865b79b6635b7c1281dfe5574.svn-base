using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class WorkOrderDataToPermitRequestLubesDataConverter : WorkOrderDataToPermitRequestDataConverter<PermitRequestLubes>
    {
        private readonly IWorkPermitLubesGroupDao groupDao;
        private readonly Site site;

        public WorkOrderDataToPermitRequestLubesDataConverter(ITimeService timeService, IFunctionalLocationDao functionalLocationDao, IPermitAttributeDao permitAttributeDao,
                                                                 ICraftOrTradeDao craftOrTradeDao, IWorkPermitLubesGroupDao groupDao, Site site) :
                                                                     base(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao)
        {
            this.groupDao = groupDao;
            this.site = site;
        }
                           
        protected override PermitRequestLubes BuildPermitRequest(WorkOrderImportData importData, FunctionalLocation floc,
                                                                DateTime? startDateTime, Date endDate, string workOrderNumber,
                                                                string operationNumber, string subOperationNumber, string trade, string workCenterCode, string description,
                                                                string sapDescription, string company, string supervisor, DataSource dataSource,
                                                                User lastImportedByUser, DateTime? lastImportedDateTime, User lastSubmittedByUser,
                                                                DateTime? lastSubmittedDateTime, User createdBy, DateTime createdDateTime,
                                                                User lastModifiedBy, DateTime lastModifiedDateTime)
        {                        
            PermitRequestLubes request = new PermitRequestLubes(null, endDate, description, sapDescription, company, DataSource.SAP, lastImportedByUser, lastImportedDateTime,
                lastSubmittedByUser, lastSubmittedDateTime, createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime, null);
            
            request.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);

            WorkOrderWorkPermitLubesTypeConverter.SetWorkPermitTypeInformation(importData.WorkPermitType, request);

            request.FunctionalLocation = floc;
            request.Location = floc != null ? floc.Description : null;
            request.Trade = trade;
            request.SAPWorkCentre = workCenterCode;

            WorkPermitLubesGroup group = GetGroup(importData);
            request.RequestedByGroup = group;            

            if (startDateTime != null)
            {                
                if (group.IsConstructionOrTurnaround)
                {
                    request.RequestedStartTimeDay = PermitRequestLubes.DefaultStartTimeForConstructionOrTurnaround;
                }
                else
                {
                    Time time = new Time(startDateTime.Value);
                    if (WorkPermitLubes.IsDayShift(time))
                    {
                        request.RequestedStartTimeDay = time;
                    }
                    else
                    {
                        request.RequestedStartTimeNight = time;
                    }                    
                }

                request.RequestedStartDate = new Date(startDateTime.Value);
            }

            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(importData.WorkPermitAttrib);
           
            PermitRequestLubesAttributes attributes = new PermitRequestLubesAttributes(attribs);
            attributes.SetAttributesOnPermitRequest(request);

            request.SpecificRequirementsSectionNotApplicableToJob = !request.AtLeastOneAttributeInTheSpecificRequirementsSectionIsSelected();
                       
            return request;           
        }

        private WorkPermitLubesGroup GetGroup(WorkOrderImportData importData)
        {
            List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
            
            if (!importData.PlannerGroup.IsNullOrEmptyOrWhitespace())
            {
                WorkPermitLubesGroup matchingGroup = WorkPermitLubesGroup.FindByPlannerGroup(importData.PlannerGroup, groups);

                if (matchingGroup != null)
                {
                    return matchingGroup;
                }
            }

            if (!importData.Priority.IsNullOrEmptyOrWhitespace())
            {
                WorkPermitLubesGroup matchingGroup = WorkPermitLubesGroup.FindByPriority(importData.Priority, groups);

                if (matchingGroup != null)
                {
                    return matchingGroup;
                }
            }

            return null;
        }

        protected override string BuildDescription(string longText, string shortText)
        {
            if (longText.IsNullOrEmptyOrWhitespace() && shortText.IsNullOrEmptyOrWhitespace())
            {
                return null;
            }

            return string.Format("{0}{1}{2}", shortText, Environment.NewLine, longText);
        }

        protected override string BuildTrade(CraftOrTrade craftOrTrade, string workCenterText, string workCenterCode)
        {
            if (craftOrTrade != null)
            {
                return craftOrTrade.ListDisplayText;
            }

            CraftOrTrade temp = new CraftOrTrade(workCenterText, workCenterCode, Site.LUBES_ID);
            return temp.ListDisplayText;
        }

        protected override List<string> GetMissingImportFieldList(PermitRequestLubes permitRequest)
        {
            DateTime dateTimeInLubes = timeService.GetTime(site.TimeZone);

            PermitRequestLubesValidator validator = new PermitRequestLubesValidator(new PermitRequestLubesValidationDomainAdapter(permitRequest));
            validator.Validate(dateTimeInLubes);
            return validator.MissingImportFieldList;
        }       
    }
}
    