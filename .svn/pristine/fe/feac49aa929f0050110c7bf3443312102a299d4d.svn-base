if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitLubesHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitLubesHistoryById]
GO

CREATE Procedure [dbo].[QueryWorkPermitLubesHistoryById] (@Id bigint)
AS

select * from WorkPermitLubesHistory h where h.Id = @Id ORDER BY h.LastModifiedDateTime

GO

GRANT EXEC ON QueryWorkPermitLubesHistoryById TO PUBLIC
GO