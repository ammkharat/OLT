IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits')
    BEGIN
        DROP PROCEDURE [dbo].QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits
    END
GO

CREATE Procedure [dbo].QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits
    (
		  @CsvFlocIds varchar(MAX),
			@FromDateTime DateTime
    )
AS
WITH OpmExcursion_Id_Cte (ExcursionId, FunctionalLocationId, FunctionalLocation, HistorianTag, ToeVersion, ToeName, ToeType, Status, StartDateTime, EndDateTime, LastUpdatedDateTime, HasResponse)
AS
(
  select 
    e1.Id, 
    e1.FunctionalLocationId,
    e1.FunctionalLocation,
    e1.HistorianTag, 
    e1.ToeVersion, 
    e1.ToeName, 
		e1.ToeType,
    e1.Status, 
    e1.StartDateTime,
    e1.EndDateTime,
		e1.LastUpdatedDateTime,
    (CASE WHEN (er.Response IS NULL) THEN 0 ELSE 1 END) AS HasResponse
  from OpmExcursion e1
	inner join FunctionalLocation fl 
	on 
	(e1.FunctionalLocationId = fl.Id
		AND
		(
			EXISTS
			(
				SELECT ids.Id
				FROM IDSplitter(@CsvFlocIds) ids
				WHERE ids.Id = fl.Id
			)
			OR
			EXISTS
			(
				SELECT ids.Id
				FROM IDSplitter(@CsvFlocIds) ids 
				INNER JOIN FunctionalLocationAncestor a ON a.Id = ids.Id
				WHERE a.AncestorId = fl.Id
			)   
			OR
			EXISTS
			(
				SELECT ids.Id
				FROM IDSplitter(@CsvFlocIds) ids 
				INNER JOIN FunctionalLocationAncestor fla ON fla.AncestorId = ids.Id
				WHERE fla.Id = fl.Id
			)
		)
	)
  left outer join OpmExcursionResponse er 
  on e1.Id = er.OltExcursionId
  where 
    (e1.Status = 1 and e1.EndDateTime IS NULL) 
)
select
  (select top 1 (e1.ExcursionId) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS ExcursionId,
	e.FunctionalLocationId,
  e.FunctionalLocation,
  e.HistorianTag,
	e.ToeVersion,
  (select top 1 (e1.ToeName) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS ToeName,
  (select top 1 (e1.ToeType) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS ToeType,
  (select top 1 (e1.Status) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS Status,
  (select top 1 (e1.StartDateTime) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS StartDateTime,
  (select top 1 (e1.EndDateTime) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS EndDateTime,
  (select top 1 (e1.LastUpdatedDateTime) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS LastUpdatedDateTime,
	(CASE WHEN ((select count(e1.HasResponse) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType and e1.HasResponse = 0) > 0) THEN 0 ELSE 1 END) AS HasResponse,
  (select COUNT(e1.ExcursionId) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType) AS ExcursionCount,
  stuff((select ',' + CAST(e1.ExcursionId as varchar(10))
     from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType
     for xml path('')),1,1,'') ExcursionIds,
  (select top 1 (e1.ExcursionId) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) AS MostRecentExcursionId
from OpmExcursion e
   inner join OpmExcursion_Id_Cte e1 
   on e1.ExcursionId = e.Id 
   and (select top 1 (e1.HasResponse) from OpmExcursion_Id_Cte e1 where e1.FunctionalLocationId = e.FunctionalLocationId and e1.HistorianTag = e.HistorianTag and e1.ToeVersion = e.ToeVersion and e1.ToeType = e.ToeType order by e1.StartDateTime desc) = 1
group by e.FunctionalLocationId, e.FunctionalLocation, e.HistorianTag, e.ToeVersion, e.ToeType
order by e.FunctionalLocationId, e.FunctionalLocation, e.HistorianTag, e.ToeVersion, e.ToeType 
OPTION (OPTIMIZE FOR UNKNOWN)  
GO

GRANT EXEC ON QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits TO PUBLIC
GO