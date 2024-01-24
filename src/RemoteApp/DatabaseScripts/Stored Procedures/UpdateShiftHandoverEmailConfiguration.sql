IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateShiftHandoverEmailConfiguration')
	BEGIN
		DROP  Procedure  UpdateShiftHandoverEmailConfiguration
	END

GO

CREATE Procedure [dbo].UpdateShiftHandoverEmailConfiguration
	(
		@Id bigint,
		@ShiftId bigint,
		@EmailAddresses varchar(max)		
	)

AS
UPDATE 
	ShiftHandoverEmailConfiguration 
SET 
	ShiftId = @ShiftId, 
	EmailAddresses = @EmailAddresses
WHERE
	Id = @Id
GO
 