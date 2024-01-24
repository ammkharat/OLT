
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryReadingBySite')
	BEGIN
		DROP Procedure [dbo].QueryReadingBySite
	END
GO
Create Procedure [dbo].[QueryReadingBySite]  
 (  
  @SiteId bigint,  
  @StartDate Date,  
  @EndDate Date  
 )  
AS  
  
  
  
select aid.* from ActionItemDefinition aid inner join ActionItemDefinitionCustomFieldGroup aidcfg   
on aid.Id = aidcfg.ActionItemDefinitionId and aidcfg.Reading = 1 and aid.Deleted = 0  
inner join BusinessCategory bc on aid.BusinessCategoryId = bc.id and bc.SiteId = @SiteId  
where  exists(Select TimeStamp  from ActionItemResponseTracker A where ActionItemDefinitionId=aid.Id and TimeStamp between @StartDate and DATEADD(day,1,@EndDate) )
--aid.LastModifiedDateTime between @StartDate and DATEADD(day,1,@EndDate)  
order by aid.Name  



  
  