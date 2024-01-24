if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormLubesCsdHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormLubesCsdHistoryById]
GO

CREATE Procedure [dbo].[QueryFormLubesCsdHistoryById] (@Id bigint) AS
select f.* from FormLubesCsdHistory f where f.Id = @Id ORDER BY LastModifiedDateTime