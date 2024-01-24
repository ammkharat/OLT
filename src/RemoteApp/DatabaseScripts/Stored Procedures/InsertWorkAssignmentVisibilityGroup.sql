if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkAssignmentVisibilityGroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertWorkAssignmentVisibilityGroup]
GO

CREATE Procedure [dbo].[InsertWorkAssignmentVisibilityGroup]
	(
	@Id bigint Output,
	@GroupId bigint,
	@WorkAssignmentId bigint,
	@VisibilityType tinyint
	)
AS

INSERT INTO WorkAssignmentVisibilityGroup (VisibilityGroupId, WorkAssignmentId, VisibilityType)
VALUES (@GroupId, @WorkAssignmentId, @VisibilityType)

SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON InsertWorkAssignmentVisibilityGroup TO PUBLIC
GO
