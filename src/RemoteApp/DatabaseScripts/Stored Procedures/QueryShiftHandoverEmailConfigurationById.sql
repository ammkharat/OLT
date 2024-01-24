IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverEmailConfigurationById')
	BEGIN
		DROP PROCEDURE dbo.QueryShiftHandoverEmailConfigurationById
	END
GO

CREATE Procedure dbo.QueryShiftHandoverEmailConfigurationById(@Id bigint)
AS

select * From ShiftHandoverEmailConfiguration where Id = @Id

GO

GRANT EXEC ON QueryShiftHandoverEmailConfigurationById TO PUBLIC
GO