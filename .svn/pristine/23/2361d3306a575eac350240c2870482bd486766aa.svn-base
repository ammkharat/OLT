IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VDenverTargetBounds')
BEGIN
	DROP VIEW VDenverTargetBounds
	
END
GO

CREATE VIEW [dbo].[VDenverTargetBounds] WITH SCHEMABINDING
AS
select 
  TargetDefinition.Id as TargetDefinitionId,
  TargetDefinition.NeverToExceedMax,
  TargetDefinition.NeverToExceedMin,
  TargetDefinition.MaxValue,
  TargetDefinition.MinValue,
  TargetDefinition.TargetDefinitionValue as TargetValue,
  Tag.[Name] as TagName,
  CASE TargetDefinition.TargetValueTypeId
    WHEN 0 THEN 'SPECIFIED'
    WHEN 1 THEN 'MINIMIZE'
    WHEN 2 THEN 'MAXIMIZE'
  END as TargetValueType
from
  [dbo].[TargetDefinition]
  INNER JOIN dbo.Tag ON dbo.TargetDefinition.TagID = dbo.Tag.Id
where
  dbo.Tag.SiteId = 2
  and dbo.Tag.Deleted = 0
  and dbo.TargetDefinition.Deleted = 0
GO

CREATE UNIQUE CLUSTERED INDEX [IDX_VDenverTargetBounds]
ON [dbo].[VDenverTargetBounds]
([TagName] , [TargetDefinitionId])
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