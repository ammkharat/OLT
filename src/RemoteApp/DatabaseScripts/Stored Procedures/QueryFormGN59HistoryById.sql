if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN59HistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN59HistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN59HistoryById] (@Id bigint) AS
select f.* from FormGN59History f where f.Id = @Id ORDER BY LastModifiedDateTime