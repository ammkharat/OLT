IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemCustomFieldEntries')
    BEGIN
        DROP PROCEDURE [dbo].QueryActionItemCustomFieldEntries
    END
GO

CREATE Procedure [dbo].[QueryActionItemCustomFieldEntries]
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
  [ActionItem].LastModifiedDateTime 
FROM 
  ActionItemCustomFieldEntry cfe
  INNER JOIN CustomField cf on cf.Id = cfe.CustomFieldId
  INNER JOIN CustomField passedInCustomField on cf.OriginCustomFieldId = passedInCustomField.OriginCustomFieldId
  INNER JOIN dbo.[ActionItem] ON cfe.ActionItemId = dbo.[ActionItem].Id
--  INNER JOIN dbo.Shift ON dbo.[ActionItem].CreationUserShiftPatternId = dbo.Shift.Id
WHERE
  ((@NumericType = 1 AND cfe.NumericFieldEntry IS NOT NULL) OR (@NumericType = 0 AND cfe.FieldEntry IS NOT NULL))
  and
  passedInCustomField.Id = @CustomFieldId
  and
  dbo.[ActionItem].WorkAssignmentId = @WorkAssignmentId
  and
  dbo.[ActionItem].LastModifiedDateTime >= @StartOfDateRange
  and
  dbo.[ActionItem].LastModifiedDateTime <= @EndOfDateRange
  --and
  --dbo.Shift.SiteId = @SiteId
