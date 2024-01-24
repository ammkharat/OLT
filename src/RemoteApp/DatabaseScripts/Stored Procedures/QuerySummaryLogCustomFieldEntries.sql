IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldEntries')
    BEGIN
        DROP PROCEDURE [dbo].QuerySummaryLogCustomFieldEntries
    END
GO

CREATE Procedure [dbo].QuerySummaryLogCustomFieldEntries
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
  [SummaryLog].LastModifiedDateTime 
FROM 
  SummaryLogCustomFieldEntry cfe
  INNER JOIN CustomField cf on cf.Id = cfe.CustomFieldId
  INNER JOIN CustomField passedInCustomField on cf.OriginCustomFieldId = passedInCustomField.OriginCustomFieldId
  INNER JOIN dbo.[SummaryLog] ON cfe.SummaryLogId = dbo.[SummaryLog].Id
  INNER JOIN dbo.Shift ON dbo.[SummaryLog].CreationUserShiftPatternId = dbo.Shift.Id
WHERE
  ((@NumericType = 1 AND cfe.NumericFieldEntry IS NOT NULL) OR (@NumericType = 0 AND cfe.FieldEntry IS NOT NULL))
  and
  passedInCustomField.Id = @CustomFieldId
  and
  dbo.[SummaryLog].WorkAssignmentId = @WorkAssignmentId
  and
  dbo.[SummaryLog].LastModifiedDateTime >= @StartOfDateRange
  and
  dbo.[SummaryLog].LastModifiedDateTime <= @EndOfDateRange
  and
  dbo.Shift.SiteId = @SiteId
 GO
 
 GRANT EXEC on QuerySummaryLogCustomFieldEntries TO PUBLIC
GO