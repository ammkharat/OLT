IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateCraftOrTrade')
	BEGIN
		DROP  Procedure  UpdateCraftOrTrade
	END

GO

CREATE Procedure [dbo].UpdateCraftOrTrade
	(
		@Id BIGINT,
		@Name VARCHAR(50),
		@WorkCenter VARCHAR(10) = null
	)

AS
UPDATE [dbo].[CraftOrTrade] 
	SET 
	    [Name] = @Name, 
	    WorkCenter = @WorkCenter 
	WHERE Id = @Id

GO

