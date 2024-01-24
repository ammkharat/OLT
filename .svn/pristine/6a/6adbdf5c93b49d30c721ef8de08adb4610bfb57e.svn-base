if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryTradeChecklistByFormGN1Id]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryTradeChecklistByFormGN1Id]
GO

CREATE Procedure [dbo].[QueryTradeChecklistByFormGN1Id] (@FormGN1Id bigint)
AS
select * from TradeChecklist where FormGN1Id = @FormGN1Id and Deleted = 0;

GRANT EXEC ON [QueryTradeChecklistByFormGN1Id] TO PUBLIC
GO