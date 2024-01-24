SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[FormProcedureDeviationCauseDetermination] (
[FormProcedureDeviationId] bigint NOT NULL,
[CauseDeterminationTypeId] int NOT NULL,
CONSTRAINT [FK_FormProcedureDeviationCauseDetermination_FormProcedureDeviation]
FOREIGN KEY ([FormProcedureDeviationId])
REFERENCES [dbo].[FormProcedureDeviation] ( [Id] ),
PRIMARY KEY CLUSTERED ([FormProcedureDeviationId] ASC, [CauseDeterminationTypeId] ASC)
)
ON [PRIMARY]
WITH (DATA_COMPRESSION = NONE);
GO

ALTER TABLE [dbo].[FormProcedureDeviationCauseDetermination] SET (LOCK_ESCALATION = TABLE);
GO


GO

CREATE FUNCTION dbo.Temp_Level (@FullHierarchy VARCHAR(500))
RETURNS tinyint

AS

BEGIN
  declare @count tinyint = 1
  Declare @individual varchar(20) = null
  WHILE LEN(@FullHierarchy) > 0
  BEGIN
      IF PATINDEX('%-%',@FullHierarchy ) > 0
      BEGIN
          SET @individual = SUBSTRING(@FullHierarchy, 0, PATINDEX('%-%',@FullHierarchy))
          SET @count = @count + 1
          SET @FullHierarchy = SUBSTRING(@FullHierarchy, LEN(@individual + '-') + 1,
                                                       LEN(@FullHierarchy))
      END
      ELSE
      BEGIN
          SET @individual = @FullHierarchy
          SET @FullHierarchy = NULL
      END     
  END
  RETURN @count;
END   
 


GO

-- Delete the Temp_Level function after update functionallocation table

-- Create and insert data into Temp table
SELECT [level],
       dbo.Temp_Level(fullhierarchy) AS actuallevel,
       fullhierarchy,       id
INTO   #temp
FROM   dbo.functionallocation
WHERE  [level] != dbo.Temp_Level(fullhierarchy)

select * from #temp

--Update script (After applying Transaction kindly perform commit or rollback)
BEGIN TRAN
UPDATE dbo.functionallocation
SET    level = t2.actuallevel
FROM   functionallocation t1
       INNER JOIN #temp t2
               ON t1.id = t2.id

SELECT [level],
       dbo.Temp_Level(fullhierarchy) AS actuallevel,
       fullhierarchy,       id
FROM   dbo.functionallocation
WHERE  [level] != dbo.Temp_Level(fullhierarchy)

DROP TABLE #temp
commit






GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

ALTER TABLE [dbo].[FormProcedureDeviation] DROP COLUMN [WhyType1]
GO
ALTER TABLE [dbo].[FormProcedureDeviation] DROP COLUMN [WhyType1Category]
GO
ALTER TABLE [dbo].[FormProcedureDeviation] DROP COLUMN [CauseDeterminationWhy1Comments]
GO
ALTER TABLE [dbo].[FormProcedureDeviation] DROP COLUMN [CauseDeterminationWhy2Comments]
GO
ALTER TABLE [dbo].[FormProcedureDeviation] DROP COLUMN [CauseDeterminationWhy3Comments]
GO

ALTER TABLE [dbo].[FormProcedureDeviation] ADD [CauseDeterminationCategory] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [CauseDeterminationComments] varchar(255) NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviationHistory] DROP COLUMN [WhyType1]
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] DROP COLUMN [WhyType1Category]
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] DROP COLUMN [CauseDeterminationWhy1Comments]
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] DROP COLUMN [CauseDeterminationWhy2Comments]
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] DROP COLUMN [CauseDeterminationWhy3Comments]
GO


ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [CauseDeterminationCauses] varchar(MAX) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [CauseDeterminationCategory] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [CauseDeterminationComments] varchar(255) NULL
GO




GO




GO

