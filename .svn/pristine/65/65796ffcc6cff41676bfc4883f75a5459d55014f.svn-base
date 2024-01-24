IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetMaxTradeChecklistSequenceNumberForFormGN1Id')
	BEGIN
		DROP PROCEDURE [dbo].GetMaxTradeChecklistSequenceNumberForFormGN1Id
	END
GO

CREATE Procedure [dbo].GetMaxTradeChecklistSequenceNumberForFormGN1Id(@FormGN1Id bigint)
AS

select MAX(SequenceNumber) as MaxSequenceNumber from TradeChecklist where FormGN1Id = @FormGN1Id
GO

GRANT EXEC ON GetMaxTradeChecklistSequenceNumberForFormGN1Id TO PUBLIC
GO

