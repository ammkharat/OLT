if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertSiteCommunication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertSiteCommunication]
GO

CREATE Procedure [dbo].[InsertSiteCommunication]
    (
    @Id bigint Output,
	@SiteId bigint,
    @Message varchar(300),
	@StartDateTime datetime,
	@EndDateTime datetime,
	@CreatedByUserId bigint,
	@CreatedDateTime datetime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
    )
AS

INSERT INTO SiteCommunication
(
	SiteId,
    Message,
	StartDateTime,
	EndDateTime,
	CreatedByUserId,
	CreatedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted
)
VALUES
(
    @SiteId,
	@Message,
    @StartDateTime,    
    @EndDateTime,
	@CreatedByUserId,
	@CreatedDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertSiteCommunication] TO PUBLIC
GO
