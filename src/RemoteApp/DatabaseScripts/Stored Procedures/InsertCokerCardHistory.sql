 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCokerCardHistory')
	BEGIN
		DROP  Procedure  InsertCokerCardHistory
	END

GO

CREATE Procedure [dbo].[InsertCokerCardHistory]
	(
	@Id bigint Output,
	@CokerCardId bigint, 
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime
	)
AS

INSERT INTO 
	[CokerCardHistory]
	(
	[CokerCardId],
	[LastModifiedUserId], 	
	[LastModifiedDateTime]
	)
VALUES
	(
	@CokerCardId,
	@LastModifiedUserId, 
	@LastModifiedDateTime
	)
	
SET @Id= SCOPE_IDENTITY() 
GO

