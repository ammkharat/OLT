if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAreaLabel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateAreaLabel]
GO

CREATE Procedure [dbo].[UpdateAreaLabel]
(
	@Id bigint,
	
	@Name varchar(40),
	@DisplayOrder int,
	@AllowManualSelection bit,
	@SAPPlannerGroup varchar(6) = NULL
)
AS

UPDATE AreaLabel
SET 
	Name = @Name,
	DisplayOrder = @DisplayOrder,
	AllowManualSelection = @AllowManualSelection,
	SAPPlannerGroup = @SAPPlannerGroup
WHERE
	Id = @Id

GO

GRANT EXEC ON UpdateAreaLabel TO PUBLIC
GO