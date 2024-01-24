if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestLubesHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestLubesHistoryById]
GO

CREATE Procedure [dbo].[QueryPermitRequestLubesHistoryById] (@Id bigint)
AS

select * from PermitRequestLubesHistory h where h.Id = @Id ORDER BY h.LastModifiedDateTime

GO

GRANT EXEC ON QueryPermitRequestLubesHistoryById TO PUBLIC
GO