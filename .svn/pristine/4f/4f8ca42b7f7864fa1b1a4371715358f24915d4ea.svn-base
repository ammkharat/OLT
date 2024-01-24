if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormMontrealCsdHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormMontrealCsdHistoryById]
GO

CREATE Procedure [dbo].[QueryFormMontrealCsdHistoryById] (@Id bigint) AS
select f.* from FormMontrealCsdHistory f where f.Id = @Id ORDER BY LastModifiedDateTime