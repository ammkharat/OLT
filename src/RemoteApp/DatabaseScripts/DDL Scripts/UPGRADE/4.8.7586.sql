

delete from LogCustomFieldEntry where (FieldEntry is null or FieldEntry = '') and (NumericFieldEntry is null)
delete from LogDefinitionCustomFieldEntry where (FieldEntry is null or FieldEntry = '') and (NumericFieldEntry is null)
delete from SummaryLogCustomFieldEntry where (FieldEntry is null or FieldEntry = '') and (NumericFieldEntry is null)





GO

