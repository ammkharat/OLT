
ALTER TABLE FormGN1 add TradeChecklistNames varchar(max) null;
GO
-- popuplate TradeCheckListNames for existing FormGN1 rows that haven't been updated by the DAO layer
UPDATE
dbo.FormGN1
SET
TradeChecklistNames = 
(SELECT
   DISTINCT  
    stuff((
        SELECT ', ' + tc.Trade
        FROM TradeChecklist tc
        WHERE tc.Trade = Trade AND tc.FormGN1Id = dbo.FormGN1.Id
        ORDER BY tc.Trade
        FOR xml PATH('')
    ),1,1,'')
FROM dbo.TradeChecklist
GROUP BY Trade)
WHERE TradeChecklistNames IS NULL 
GO



GO

