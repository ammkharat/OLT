if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertBusinessCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertBusinessCategory]
GO

CREATE Procedure [dbo].[InsertBusinessCategory]
    (
    @Id bigint Output,    
	@Name varchar(100),
	@ShortName varchar(50),
	@IsSAPWorkOrderDefault bit,
	@IsSAPNotificationDefault bit,
	@LastModifiedUserId bigint,
    @LastModifiedDateTime DATETIME,
    @CreatedDateTime DATETIME,
    @SiteId bigint
    )
AS

INSERT INTO BusinessCategory
(
    [Name],
	[ShortName],
	[IsSAPWorkOrderDefault],
	[IsSAPNotificationDefault],
    [LastModifiedUserId],
	[LastModifiedDateTime],
	[CreatedDateTime],
	[SiteId],
	[Deleted]
)
VALUES
(
    @Name,
	@ShortName,
	@IsSAPWorkOrderDefault,
	@IsSAPNotificationDefault,
    @LastModifiedUserId,
	@LastModifiedDateTime,
	@CreatedDateTime,
	@SiteId,
	0
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertBusinessCategory TO PUBLIC
GO  