IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionCustomFieldEntries')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogDefinitionCustomFieldEntries
    END
GO

CREATE Procedure [dbo].QueryLogDefinitionCustomFieldEntries
    (
        @SiteId tinyint,
		@WorkAssignmentId bigint,
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CustomFieldId bigint,
		@NumericType bit
    )
AS

SELECT 
  cfe.Id,
  cfe.NumericFieldEntry,
  cfe.FieldEntry,
  [LogDefinition].LastModifiedDateTime 
FROM 
  LogDefinitionCustomFieldEntry cfe
  INNER JOIN CustomField cf on cf.Id = cfe.CustomFieldId
  INNER JOIN CustomField passedInCustomField on passedInCustomField.Id = @CustomFieldId
  INNER JOIN dbo.[LogDefinition] ON cfe.LogDefinitionId = dbo.[LogDefinition].Id
  INNER JOIN dbo.Role ON dbo.[LogDefinition].CreatedByRoleId = dbo.Role.Id
WHERE
  ((@NumericType = 1 AND cfe.NumericFieldEntry IS NOT NULL) OR (@NumericType = 0 AND cfe.FieldEntry IS NOT NULL))
  and
  cf.OriginCustomFieldId = passedInCustomField.OriginCustomFieldId
  and
  dbo.[LogDefinition].WorkAssignmentId = @WorkAssignmentId
  and
  dbo.[LogDefinition].LastModifiedDateTime >= @StartOfDateRange
  and
  dbo.[LogDefinition].LastModifiedDateTime <= @EndOfDateRange
  and
  dbo.role.SiteId = @SiteId
 GO
 
 GRANT EXEC on QueryLogDefinitionCustomFieldEntries TO PUBLIC
GO