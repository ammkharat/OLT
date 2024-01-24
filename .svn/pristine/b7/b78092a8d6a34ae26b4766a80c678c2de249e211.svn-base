if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormGN75A]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormGN75A]
GO

CREATE Procedure [dbo].[RemoveFormGN75A]
(
	@Id bigint
)
AS

UPDATE 
	FormGN75A
SET 
	Deleted = 1
WHERE
	Id = @Id

GRANT EXEC ON RemoveFormGN75A TO PUBLIC
GO