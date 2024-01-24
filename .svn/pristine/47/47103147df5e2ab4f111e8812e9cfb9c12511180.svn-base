CREATE VIEW dbo.[VLogFunctionalLocationAncestor]
WITH SCHEMABINDING
AS
(
	SELECT 
		dbo.LogFunctionalLocation.LogId, dbo.FunctionalLocationAncestor.Id as FunctionalLocationId, dbo.FunctionalLocationAncestor.AncestorId
	FROM dbo.LogFunctionalLocation
	INNER JOIN dbo.FunctionalLocationAncestor ON dbo.LogFunctionalLocation.FunctionalLocationId = dbo.FunctionalLocationAncestor.Id
)
GO

CREATE UNIQUE CLUSTERED INDEX [IDX_VLogFunctionalLocationAncestor]
ON [dbo].[VLogFunctionalLocationAncestor]
([AncestorId] , [LogId] , [FunctionalLocationId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO