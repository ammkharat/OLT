
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




GO


IF not EXISTS (
select * from RoleElement where  Name like N'Create Flexible Shift Handover Questionnaire' and FunctionalArea = N'Shift Handovers'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (330, 'Create Flexible Shift Handover Questionnaire', 'Shift Handovers')
End






GO

