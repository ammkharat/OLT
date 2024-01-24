  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateUser')
	BEGIN
		DROP  Procedure  UpdateUser
	END

GO

CREATE Procedure [dbo].[UpdateUser]
	(
	@Id bigint,
	@UserName varchar(30),
	@FirstName varchar(25),
	@LastName varchar(25),
	@SAPId char(8),
	@LastModifiedDateTime datetime	
	)
AS

UPDATE    [User]
SET              
	Username = @UserName,
	Firstname = @FirstName,
	Lastname = @LastName,
	SAPId = @SAPId,
	LastModifiedDateTime = @LastModifiedDateTime
WHERE     (Id = @Id)
GO


GRANT EXEC ON UpdateUser TO PUBLIC

GO
