if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75AHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75AHistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN75AHistoryById] (@Id bigint)
AS
select f.* from FormGN75AHistory f where f.Id = @Id ORDER BY LastModifiedDateTime
