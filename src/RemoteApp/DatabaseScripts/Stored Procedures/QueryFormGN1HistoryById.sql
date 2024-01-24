if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN1HistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN1HistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN1HistoryById] (@Id bigint)
AS
select f.* from FormGN1History f where f.Id = @Id ORDER BY LastModifiedDateTime
