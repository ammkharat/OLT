if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryTradeChecklistHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryTradeChecklistHistoryById]
GO

CREATE Procedure [dbo].[QueryTradeChecklistHistoryById] (@Id bigint)
AS
select f.* from TradeChecklistHistory f where f.Id = @Id ORDER BY LastModifiedDateTime
