  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateBusinessCategory')
	BEGIN
		DROP  Procedure  UpdateBusinessCategory
	END

GO

CREATE Procedure [dbo].[UpdateBusinessCategory]
	(
	@Id bigint,
	@Name varchar(100),
	@ShortName varchar(50),
	@IsSAPWorkOrderDefault bit,
	@IsSAPNotificationDefault bit,
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,
	@Deleted bit
	)
AS
UPDATE    [BusinessCategory]
SET       LastModifiedUserId = @LastModifiedUserId, 
          LastModifiedDateTime = @LastModifiedDateTime, 
          [Name] = @Name,       
		  [ShortName] = @ShortName,
		  [IsSAPWorkOrderDefault] = @IsSAPWorkOrderDefault,
		  [IsSAPNotificationDefault] = @IsSAPNotificationDefault,
		  [Deleted] = @Deleted
WHERE     (Id = @Id)
GO


GRANT EXEC ON UpdateBusinessCategory TO PUBLIC

GO


 