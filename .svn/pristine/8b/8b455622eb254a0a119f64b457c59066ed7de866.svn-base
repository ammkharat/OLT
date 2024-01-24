IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogCustomFieldEntries')
    BEGIN
        DROP PROCEDURE [dbo].QueryLogCustomFieldEntries
    END
GO

CREATE Procedure [dbo].QueryLogCustomFieldEntries
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
  [Log].LastModifiedDateTime
FROM 
  LogCustomFieldEntry cfe
  INNER JOIN CustomField cf on cf.Id = cfe.CustomFieldId
  INNER JOIN CustomField passedInCustomField on   cf.OriginCustomFieldId = passedInCustomField.OriginCustomFieldId
  INNER JOIN dbo.[Log] ON cfe.LogId = dbo.[Log].Id
  INNER JOIN dbo.Shift ON dbo.[Log].CreationUserShiftPatternId = dbo.Shift.Id
WHERE
  passedInCustomField.Id = @CustomFieldId
  and
  ((@NumericType = 1 AND cfe.NumericFieldEntry IS NOT NULL) OR (@NumericType = 0 AND cfe.FieldEntry IS NOT NULL))
  and
  dbo.[Log].WorkAssignmentId = @WorkAssignmentId
  and
  dbo.[Log].LastModifiedDateTime >= @StartOfDateRange
  and
  dbo.[Log].LastModifiedDateTime <= @EndOfDateRange
  and
  dbo.Shift.SiteId = @SiteId
 GO
 
 GRANT EXEC on QueryLogCustomFieldEntries TO PUBLIC
GO