ALTER TABLE FormTemplate
  ALTER COLUMN [Name] VARCHAR(200) NULL

update FormTemplate 
Set 
  [Name] = 'GN-6 Lift Safe Work Plan: Section 5 -  Lift Using Two or More Cranes (Total Load Exceeds 75% of any Involved Crane Chart Capacity)'
WHERE TemplateKey = 'alotofcranes' and FormTypeId = 5
and [Name] = 'Section 5 - Lift Using Two or More Cranes'


GO

