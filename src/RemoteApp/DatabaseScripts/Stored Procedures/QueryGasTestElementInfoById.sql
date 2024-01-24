IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryGasTestElementInfoById')
	BEGIN
		DROP PROCEDURE [dbo].QueryGasTestElementInfoById
	END
GO

CREATE Procedure dbo.QueryGasTestElementInfoById
(
    @Id bigint
)
AS
SELECT * FROM GasTestElementInfo WHERE Id = @Id
GO

GRANT EXEC ON [QueryGasTestElementInfoById] TO PUBLIC
GO