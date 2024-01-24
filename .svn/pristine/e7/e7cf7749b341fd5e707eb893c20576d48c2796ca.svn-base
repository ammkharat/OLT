IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShift')
	BEGIN
		DROP  Procedure  InsertShift
	END

GO

CREATE Procedure [dbo].InsertShift
(
	@Id bigint Output,
	@name varchar(4),
	@startTime datetime,
	@endTime datetime,
	@siteId bigint,
	@createdDateTime datetime
)
AS
INSERT INTO Shift
	(
		[Name], 
		StartTime, 
		EndTime,
		SiteId,
		CreatedDateTime
	)
	VALUES
	(
		@name,
		@startTime,
		@endTime,
		@siteId,
		@createdDateTime
	)

SET @Id= SCOPE_IDENTITY()	

GO

GRANT EXEC ON InsertShift TO PUBLIC

GO


