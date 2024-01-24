if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75BHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75BHistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN75BHistoryById] (@Id bigint,@SiteId int)
AS
select f.* from FormGN75BHistory f where f.Id = @Id and f.SiteId=@SiteId ORDER BY LastModifiedDateTime
