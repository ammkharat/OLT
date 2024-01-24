if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOvertimeFormHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOvertimeFormHistoryById]
GO

CREATE Procedure [dbo].[QueryFormOvertimeFormHistoryById] (@Id bigint)
AS
select f.* from FormOvertimeFormHistory f where f.Id = @Id ORDER BY LastModifiedDateTime
