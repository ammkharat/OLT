if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateRoleWorkAssignmentNotSelectedWarning]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateRoleWorkAssignmentNotSelectedWarning]
GO

CREATE Procedure [dbo].[UpdateRoleWorkAssignmentNotSelectedWarning]
    (
    @Id bigint,
	@WarnIfWorkAssignmentNotSelected bit
    )
AS

update Role
set WarnIfWorkAssignmentNotSelected = @WarnIfWorkAssignmentNotSelected
where Id = @Id

go

GRANT EXEC ON [UpdateRoleWorkAssignmentNotSelectedWarning] TO PUBLIC
GO
