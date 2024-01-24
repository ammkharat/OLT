if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75bById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75bById]
GO

CREATE Procedure [dbo].[QueryFormGN75bById] (@Id bigint)
AS
select f.* from FormGN75B f where f.Id = @Id

GRANT EXEC ON [QueryFormGN75bById] TO PUBLIC
GO