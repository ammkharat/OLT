IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveCraftOrTrade')
	BEGIN
		DROP  Procedure  RemoveCraftOrTrade
	END

GO

CREATE Procedure [dbo].RemoveCraftOrTrade
	(
		@Id BIGINT
	)
AS

UPDATE [dbo].[CraftOrTrade]
SET Deleted = 1
WHERE Id = @Id
GO

