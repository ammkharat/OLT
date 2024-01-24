IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUserLoginHistory')
	BEGIN
		DROP  Procedure  InsertUserLoginHistory
	END
GO

CREATE Procedure dbo.InsertUserLoginHistory
	(
		@Id bigint Output,
		@UserId BIGINT,
		@LoginDateTime datetime,
		@ShiftId bigint,
		@ShiftStartDateTime datetime,
		@ShiftEndDateTime datetime,
		@AssignmentId BIGINT = null,
		@ClientUri varchar(500),
		@ClientUpdatePath varchar(100),
		@MachineName varchar(20),
		@WindowsVersion VARCHAR(100),
		@DotNetVersion VARCHAR(100),
		@IsClickOnce bit
	)
AS
	INSERT INTO UserLoginHistory 
	( 
		UserId, 
		LoginDateTime,
		ShiftId,
		ShiftStartDateTime,
		ShiftEndDateTime,
		AssignmentId,
		ClientUri,
		ClientUpdatePath,
		MachineName,
		WindowsVersion,
		DotNetVersion,
		IsClickOnce
	)
	VALUES 
	(
		@UserId, 
		@LoginDateTime,
		@ShiftId,
		@ShiftStartDateTime,
		@ShiftEndDateTime,
		@AssignmentId,
		@ClientUri,
		@ClientUpdatePath,
		@MachineName,
		@WindowsVersion,
		@DotNetVersion,
		@IsClickOnce
	)

	SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertUserLoginHistory] TO PUBLIC
GO