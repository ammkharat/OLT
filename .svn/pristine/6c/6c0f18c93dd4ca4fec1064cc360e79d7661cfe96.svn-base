CREATE VIEW [dbo].[VWorkPermit_Floc] WITH SCHEMABINDING
 AS 
  SELECT
    [dbo].[WorkPermit].[FunctionalLocationId] as FunctionalLocationId,  
    count_big(*) as CountOfFlocId 
  FROM  
    [dbo].[WorkPermit]  
  GROUP BY
    [dbo].[WorkPermit].[FunctionalLocationId]  
GO

CREATE UNIQUE CLUSTERED INDEX [IDX_VWorkPermit_Floc] ON [dbo].[VWorkPermit_Floc] 
(
	[FunctionalLocationId] ASC
)WITH 
  (SORT_IN_TEMPDB = OFF, 
  IGNORE_DUP_KEY = OFF, 
  DROP_EXISTING = OFF, 
  ONLINE = OFF) 
ON [PRIMARY]
GO


GO
