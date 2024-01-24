  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateShiftHandoverConfiguration')
	BEGIN
		DROP  Procedure  UpdateShiftHandoverConfiguration
	END

GO

CREATE Procedure [dbo].[UpdateShiftHandoverConfiguration]
	(
	@Id bigint,
	@Name varchar(50)	
	)
AS

UPDATE [ShiftHandoverConfiguration]
SET              
	Name = @Name	
WHERE     (Id = @Id)
GO


GRANT EXEC ON UpdateShiftHandoverConfiguration TO PUBLIC

GO
