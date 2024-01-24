  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteTradeChecklistsByFormGN1Id')
	BEGIN
		DROP Procedure DeleteTradeChecklistsByFormGN1Id
	END

GO

CREATE Procedure dbo.DeleteTradeChecklistsByFormGN1Id(@FormGN1Id bigint)
AS
-- not deleting soft deleted items is weird, but we need to for tradechecklists. We made some decisions so caching played nicely.
DELETE FROM TradeChecklist WHERE FormGN1Id = @FormGN1Id and Deleted = 0;

RETURN

GO   