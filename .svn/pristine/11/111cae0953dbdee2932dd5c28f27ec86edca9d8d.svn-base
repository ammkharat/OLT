 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveTargetAlertOlderThan30days')
	BEGIN
		DROP  Procedure  RemoveTargetAlertOlderThan30days
	END

GO

CREATE Procedure [dbo].RemoveTargetAlertOlderThan30days
AS

UPDATE TargetAlert 
	SET [TargetAlertStatusID] = '4'
	WHERE DATEDIFF(day, [CreatedDateTime], GETDATE())> 30
GO


GRANT EXEC ON RemoveTargetAlertOlderThan30days TO PUBLIC

GO