  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteLogTemplate')
	BEGIN
		DROP  Procedure  DeleteLogTemplate
	END

GO

CREATE Procedure dbo.DeleteLogTemplate
	(	
	@Id bigint
	)
AS

update WorkAssignment set AutoInsertLogTemplateId = null where AutoInsertLogTemplateId = @Id
delete LogTemplate where Id = @Id

RETURN

GO    