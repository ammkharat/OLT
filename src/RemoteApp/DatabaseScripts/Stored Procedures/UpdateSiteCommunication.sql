if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateSiteCommunication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateSiteCommunication]
GO

CREATE Procedure [dbo].[UpdateSiteCommunication]
    (
    @Id bigint,
    @Message varchar(300),
	@StartDateTime datetime,
	@EndDateTime datetime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
    )
AS

UPDATE SiteCommunication
SET
	Message = @Message,
    StartDateTime = @StartDateTime,    
    EndDateTime = @EndDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime
WHERE Id = @Id


GRANT EXEC ON [UpdateSiteCommunication] TO PUBLIC
GO
