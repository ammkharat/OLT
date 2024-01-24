if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormGN75BTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormGN75BTemplate]
GO

create Procedure [dbo].[RemoveFormGN75BTemplate]
(
	@Id bigint
)
AS

UPDATE 
	FormGN75BTemplate
SET 
	Deleted = 1
WHERE
	Id = @Id

GRANT EXEC ON RemoveFormGN75BTemplate TO PUBLIC
go
