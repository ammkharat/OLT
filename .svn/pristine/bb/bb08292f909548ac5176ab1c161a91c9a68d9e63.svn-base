if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveTradeChecklist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveTradeChecklist]
GO

CREATE Procedure [dbo].[RemoveTradeChecklist]
(
	@Id bigint
)
AS

UPDATE 
	TradeChecklist
SET 
	Deleted = 1
WHERE
	Id = @Id

GRANT EXEC ON RemoveTradeChecklist TO PUBLIC
GO