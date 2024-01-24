if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUser]
GO

CREATE Procedure [dbo].[InsertUser]
	(
	@Id bigint Output,
	@UserName varchar(30),
	@FirstName varchar(25),
	@LastName varchar(25),
	@SAPId char(8),
	@LastModifiedDateTime datetime	
	)
AS

INSERT INTO [User]
					(
						[Username], 
						[Firstname], 
                        [Lastname],
                        [SAPId],
						[Deleted],
						[LastModifiedDateTime]
					)
VALUES     
					(
					  @UserName,
					  @FirstName,
					  @LastName,
					  @SAPId,
					  0,
					  @LastModifiedDateTime
					)
SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertUser] TO PUBLIC
GO