
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestionnaire]') 
         AND name in ('FlexiShiftStartDate','FlexiShiftEndDate','IsFlexible')
)
begin
ALTER TABLE dbo.ShiftHandoverQuestionnaire ADD FlexiShiftStartDate DATETIME NULL, FlexiShiftEndDate DATETIME NULL ;
ALTER TABLE dbo.ShiftHandoverQuestionnaire ADD IsFlexible BIT NOT NULL DEFAULT(0)
end

