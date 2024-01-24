if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75AById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75AById]
GO

CREATE Procedure [dbo].[QueryFormGN75AById] (@Id bigint)
AS
select f.* from FormGN75A f where f.Id = @Id

GRANT EXEC ON [QueryFormGN75AById] TO PUBLIC
GO