IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSAPShift')
	BEGIN
		DROP  Procedure  InsertSAPShift
	END

GO

CREATE Procedure [dbo].InsertSAPShift
(
	@Id char(2) Output,
	@name varchar(4),
	@startTime datetime,
	@endTime datetime
)
AS
	INSERT INTO SAPShift
	(
		[Id],
		[Name], 
		StartDateTime, 
		EndDateTime
	)
	VALUES
	(
		@Id,
		@name,
		@startTime,
		@endTime
	)
GO

GRANT EXEC ON InsertSAPShift TO PUBLIC
GO

