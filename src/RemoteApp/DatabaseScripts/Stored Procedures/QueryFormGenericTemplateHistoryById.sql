if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGenericTemplateHistoryById]
GO


CREATE Procedure [dbo].[QueryFormGenericTemplateHistoryById] (@Id bigint) AS
select f.* from FormGenericTemplateHistory f where f.Id = @Id ORDER BY LastModifiedDateTime



GO

GRANT EXEC ON QueryFormGenericTemplateHistoryById TO PUBLIC
GO