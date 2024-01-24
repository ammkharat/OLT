alter table OpmExcursion add ToeLimitValue decimal(18,6) not null
alter table OpmToeDefinition add UnitOfMeasure nvarchar(15) not null
alter table OpmToeDefinition add OpmToeHistoryUrl nvarchar(400) not null
EXEC sp_RENAME 'dbo.OpmExcursion.ExcursionId' , 'OpmExcursionId', 'COLUMN'
EXEC sp_RENAME 'dbo.OpmExcursionResponse.ExcursionId' , 'OpmExcursionId', 'COLUMN'



GO

