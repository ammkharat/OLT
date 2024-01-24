if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormGN75B]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormGN75B]
GO

CREATE Procedure [dbo].[RemoveFormGN75B]
(
	@Id bigint
)
AS

UPDATE 
	FormGN75B
SET 
	Deleted = 1
WHERE
	Id = @Id

GRANT EXEC ON RemoveFormGN75B TO PUBLIC
GO