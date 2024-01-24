IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRestrictionReasonCode')
	BEGIN
		DROP  Procedure  InsertRestrictionReasonCode
	END

GO

CREATE Procedure [dbo].[InsertRestrictionReasonCode]
	(
	@Id bigint Output,
	@Name varchar(150),
	@LastModifiedUserId bigint,
	@LastModifiedDateTime datetime,
	@SiteID bigint
	)
AS
							
INSERT INTO 
	[RestrictionReasonCode]
	(
	[Name],
	[LastModifiedUserId],
	[LastModifiedDateTime],
	[Deleted],
	[SiteId]
	)
VALUES
	(	
	@Name,
	@LastModifiedUserId,
	@LastModifiedDateTime,
	0,
	@SiteID
	)
	
SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertRestrictionReasonCode] TO PUBLIC
GO