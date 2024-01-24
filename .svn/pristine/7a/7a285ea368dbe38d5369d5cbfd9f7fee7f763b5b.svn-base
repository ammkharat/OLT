if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOP14HistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOP14HistoryById]
GO

CREATE Procedure [dbo].[QueryFormOP14HistoryById] (@Id bigint) AS
select f.* from FormOP14History f where f.Id = @Id ORDER BY LastModifiedDateTime