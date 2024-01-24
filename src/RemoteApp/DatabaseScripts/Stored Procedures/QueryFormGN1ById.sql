if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN1ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN1ById]
GO

CREATE Procedure [dbo].[QueryFormGN1ById] (@Id bigint)
AS
select f.* from FormGN1 f where f.Id = @Id

GRANT EXEC ON [QueryFormGN1ById] TO PUBLIC
GO