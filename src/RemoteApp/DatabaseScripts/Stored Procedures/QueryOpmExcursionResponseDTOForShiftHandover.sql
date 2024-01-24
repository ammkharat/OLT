
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmExcursionResponseDTOForShiftHandover')
	BEGIN
		DROP Procedure [dbo].QueryOpmExcursionResponseDTOForShiftHandover
	END
GO

CREATE Procedure [dbo].QueryOpmExcursionResponseDTOForShiftHandover
    (
		@CsvFlocIds varchar(MAX),
		@StartOfDateRange DateTime,
		@EndOfDateRange DateTime
    )
AS
select 
	ex.Id,
	ex.OpmExcursionId,
	ex.ToeName,
	ex.ToeType,
	ex.FunctionalLocation,
	ex.Status,
	ex.StartDateTime,
	ex.EndDateTime,
	ex.UnitOfMeasure,
	ex.Peak,
	ex.Average,
	ex.Duration,
	ex.ToeLimitValue,
	ex.IlpNumber,
	ex.EngineerComments,
	ex.ReasonCode,
	er.Response,
	er.LastModifiedByUserId,
	er.LastModifiedDateTime
	--er.Asset,
	--er.Code
from 
	OpmExcursion ex
	INNER JOIN FunctionalLocation fl ON ex.FunctionalLocationId = fl.Id
	 left outer join OpmExcursionResponse er on ex.Id = er.OltExcursionId
where 
	((ex.StartDateTime <= @EndOfDateRange 
	AND
    ex.StartDateTime >= @StartOfDateRange)
    OR
    (er.LastModifiedDateTime <= @EndOfDateRange 
	AND
    er.LastModifiedDateTime >= @StartOfDateRange))

AND
	(
    EXISTS
    (
      SELECT ids.Id
      FROM 
		IDSplitter(@CsvFlocIds) ids
      WHERE 
		ids.Id = fl.Id
    )
    OR
    EXISTS
    (
  		SELECT ids.Id
	  	FROM 
			IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor a ON a.Id = ids.Id
		WHERE 
			a.AncestorId = fl.Id
	  )   
    OR
    EXISTS
    (
  		SELECT ids.Id
	  	FROM 
			IDSplitter(@CsvFlocIds) ids 
			INNER JOIN FunctionalLocationAncestor fla ON fla.AncestorId = ids.Id
		WHERE 
			fla.Id = fl.Id
	  )
  )
OPTION (OPTIMIZE FOR UNKNOWN)  
GO