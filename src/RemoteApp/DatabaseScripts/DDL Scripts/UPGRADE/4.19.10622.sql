-- Create the function
IF OBJECT_ID (N'dbo.GetDirectiveCreatedByRoleId', N'FN') IS NOT NULL
    DROP FUNCTION GetDirectiveCreatedByRoleId;
GO
CREATE FUNCTION dbo.GetDirectiveCreatedByRoleId(@DirectiveId bigint)
RETURNS bigint 
AS 
-- Returns the created by role id for the user and directive created date time.
BEGIN
  DECLARE @CreatedByUserId bigint;
  DECLARE @CreatedDate datetime;
  
  SELECT @CreatedByUserId = d.CreatedByUserId, @CreatedDate = d.CreatedDateTime
  FROM Directive d
  WHERE d.Id = @DirectiveId;

  DECLARE @CreatedByRoleId bigint;

  SELECT @CreatedByRoleId = 
  (
    SELECT TOP 1 wa.RoleId
    FROM UserLoginHistory lh
      INNER JOIN WorkAssignment wa ON wa.Id = lh.AssignmentId
    WHERE lh.UserId = @CreatedByUserId AND 
		(
			 -- login and create date are in the shift or up to 6 hours before the shift
			(lh.ShiftStartDateTime <= @CreatedDate OR DATEADD(hour,-6,lh.ShiftStartDateTime) <= @CreatedDate) AND 
      lh.ShiftEndDateTime >= @CreatedDate AND
      lh.LoginDateTime < @CreatedDate
		)
    ORDER BY lh.LoginDateTime DESC
  );
  
  RETURN @CreatedByRoleId;
END;
GO

-- Add the column initially empty
ALTER TABLE [Directive]
ADD CreatedByRoleId bigint NULL; 
GO

-- Update the created by role for all directives
UPDATE Directive
SET CreatedByRoleId = dbo.GetDirectiveCreatedByRoleId(Id)
WHERE CreatedByRoleId IS NULL;
GO

ALTER TABLE [Directive]
ADD CONSTRAINT FK_Directive_CreatedByRoleId FOREIGN KEY (CreatedByRoleId)
    REFERENCES Role([Id]);
GO

-- Drop the function
IF OBJECT_ID (N'dbo.GetDirectiveCreatedByRoleId', N'FN') IS NOT NULL
    DROP FUNCTION GetDirectiveCreatedByRoleId;
GO




GO

