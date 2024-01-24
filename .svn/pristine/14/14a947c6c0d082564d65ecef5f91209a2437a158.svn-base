IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitsLessThanAndEqualToRequestDateTimeBySiteAndStatus')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitsLessThanAndEqualToRequestDateTimeBySiteAndStatus
	END
GO

CREATE Procedure [dbo].[QueryAllWorkPermitsLessThanAndEqualToRequestDateTimeBySiteAndStatus]
	(
		@RequestedDateTime datetime,
		@SiteId int,
		@WorkPermitStatusId int
	)
AS

if (@SiteId = 18)
begin
	SELECT     
		wp.*
	FROM       
		WorkPermitUSPipeline wp 
		INNER JOIN FunctionalLocation fl ON wp.FunctionalLocationId = fl.[Id]
	WHERE     
		wp.WorkPermitStatusId = @WorkPermitStatusId
		AND wp.Deleted = 0
		AND wp.LastModifiedDate <= @RequestedDateTime
		AND fl.SiteId = @SiteId
	ORDER BY wp.[id]
end

else

begin

	SELECT     
		wp.*
	FROM       
		WorkPermit wp 
		INNER JOIN FunctionalLocation fl ON wp.FunctionalLocationId = fl.[Id]
	WHERE     
		wp.WorkPermitStatusId = @WorkPermitStatusId
		AND wp.Deleted = 0
		AND wp.LastModifiedDate <= @RequestedDateTime
		AND fl.SiteId = @SiteId
	ORDER BY wp.[id]
end


GRANT EXEC ON QueryAllWorkPermitsLessThanAndEqualToRequestDateTimeBySiteAndStatus TO PUBLIC
GO