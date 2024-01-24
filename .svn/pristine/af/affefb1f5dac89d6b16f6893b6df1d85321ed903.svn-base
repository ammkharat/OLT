  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRestrictionReasonCode')
	BEGIN
		DROP  Procedure  UpdateRestrictionReasonCode
	END

GO

CREATE Procedure [dbo].[UpdateRestrictionReasonCode]
	(
	@Id bigint,
	@Name varchar(150),
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,
	@SiteID bigint
	)
AS
UPDATE    [RestrictionReasonCode]
SET       LastModifiedUserId = @LastModifiedUserId, 
          LastModifiedDateTime = @LastModifiedDateTime, 
          [Name] = @Name          
WHERE     (Id = @Id and SiteId = @SiteID)
GO


GRANT EXEC ON UpdateRestrictionReasonCode TO PUBLIC

GO


 