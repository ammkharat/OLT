 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertDTOsByFLOCIdsAndDateRange')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertDTOsByFLOCIdsAndDateRange
	END
GO
Create Procedure [dbo].QueryDeviationAlertDTOsByFLOCIdsAndDateRange  
(  
    @Ids varchar(MAX),  
 @FromDate datetime,  
 @ToDate datetime  
)  
AS  
  
SELECT  
    da.Id,   
    da.DeviationAlertResponseId,  
 da.RestrictionDefinitionName,  
 da.RestrictionDefinitionDescription,  
 da.RestrictionDefinitionId,  
    da.LastModifiedUserId,      
    floc.FullHierarchy AS FunctionalLocationName,  
 da.ProductionTargetValue,  
 da.MeasurementValue,  
 da.StartDateTime,  
 da.EndDateTime,  
 da.FunctionalLocationId,  
 da.LastModifiedUserId,   
 da.LastModifiedDateTime,  
 da.CreatedDateTime,  
 ptvtag.Name as ProductionTargetValueTagName,  
 ptvtag.Units as ProductionTargetValueTagUnit,  
 mvtag.Name as MeasurementValueTagName,  
 mvtag.Units as MeasurementValueTagUnit  ,
 
 --Added by Mukesh for RITM0219490
ISNULL(da.ToleranceValue,0) as ToleranceValue  
FROM  
    DeviationAlert da  
    INNER JOIN FunctionalLocation floc ON floc.Id = da.FunctionalLocationID     
 INNER JOIN Tag mvtag ON mvtag.Id = da.MeasurementValueTagId  
    LEFT OUTER JOIN Tag ptvtag ON ptvtag.Id = da.ProductionTargetValueTagId  
WHERE  
 da.IsOnlyVisibleOnReports = 0 AND  
 EXISTS  
 (  
  -- Floc of deviation alert matches one of the passed in flocs  
  select ids.Id  
  from IDSplitter(@Ids) ids  
  where ids.Id = floc.Id  
    
  UNION ALL  
    
  -- Floc of deviation alert is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
  select ids.Id  
  from FunctionalLocationAncestor a  
  inner join IDSplitter(@Ids) ids on ids.Id = a.AncestorId  
  where a.Id = floc.Id  
 )   
 AND da.StartDateTime between @FromDate and @ToDate  
ORDER BY  
    FunctionalLocationId  
OPTION (OPTIMIZE FOR UNKNOWN)  

 GRANT EXEC ON QueryDeviationAlertDTOsByFLOCIdsAndDateRange TO PUBLIC