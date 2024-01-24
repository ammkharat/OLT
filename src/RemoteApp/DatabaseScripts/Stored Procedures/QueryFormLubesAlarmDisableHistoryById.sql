if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormLubesAlarmDisableHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormLubesAlarmDisableHistoryById]
GO

CREATE Procedure [dbo].[QueryFormLubesAlarmDisableHistoryById] (@Id bigint) AS
select f.* from FormLubesAlarmDisableHistory f where f.Id = @Id ORDER BY LastModifiedDateTime