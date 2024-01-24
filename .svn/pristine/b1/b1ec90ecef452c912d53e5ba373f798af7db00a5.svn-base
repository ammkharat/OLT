  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkPermitArchivalProcessConfiguration')
	BEGIN
		DROP  Procedure UpdateWorkPermitArchivalProcessConfiguration
	END

GO

CREATE Procedure [dbo].[UpdateWorkPermitArchivalProcessConfiguration]
	(
		@SiteId BIGINT,
		@DaysBeforeArchivingClosedWorkPermits INT,
		@DaysBeforeDeletingPendingWorkPermits INT,
		@DaysBeforeClosingIssuedWorkPermits INT
	)
AS

UPDATE
	SiteConfiguration
SET 
	DaysBeforeArchivingClosedWorkPermits = @DaysBeforeArchivingClosedWorkPermits,
	DaysBeforeDeletingPendingWorkPermits = @DaysBeforeDeletingPendingWorkPermits,
	DaysBeforeClosingIssuedWorkPermits = @DaysBeforeClosingIssuedWorkPermits
WHERE
	SiteId = @SiteId
GO

GRANT EXEC ON UpdateWorkPermitArchivalProcessConfiguration TO PUBLIC

GO


 