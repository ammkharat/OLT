if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormGN75BSarnia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormGN75BSarnia]
GO

CREATE Procedure [dbo].[RemoveFormGN75BSarnia]
(
	@Id bigint
)
AS

UPDATE 
	FormGN75BSarnia
SET 
	Deleted = 1
WHERE
	Id = @Id

GRANT EXEC ON RemoveFormGN75BSarnia TO PUBLIC
GO