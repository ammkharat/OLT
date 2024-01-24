IF EXISTS(SELECT * FROM information_schema.tables WHERE table_name = 'OrganizationalUnitAssignmentFunctionalLocation')
BEGIN
	exec sp_rename 'dbo.OrganizationalUnitAssignmentFunctionalLocation.OrganizationalUnitAssignmentId', 'WorkAssignmentId', 'COLUMN';

	ALTER TABLE dbo.OrganizationalUnitAssignmentFunctionalLocation
	DROP CONSTRAINT FK_OrganizationalUnitAssignment;

	ALTER TABLE dbo.OrganizationalUnitAssignmentFunctionalLocation  
	ADD CONSTRAINT FK_WorkAssignment FOREIGN KEY(WorkAssignmentId)
	REFERENCES dbo.OrganizationalUnitAssignment (Id)

	exec sp_rename 'dbo.OrganizationalUnitAssignmentFunctionalLocation.PK_OrganizationalUnitAssignmentFunctionalLocation', 'PK_WorkAssignmentFunctionalLocation', 'INDEX';

	exec sp_rename 'dbo.OrganizationalUnitAssignmentFunctionalLocation', 'WorkAssignmentFunctionalLocation';
END

GO

IF EXISTS(SELECT * FROM information_schema.tables WHERE table_name = 'OrganizationalUnitAssignment')
BEGIN

	exec sp_rename 'dbo.OrganizationalUnitAssignment.PK_OrganizationalUnitAssignment', 'PK_WorkAssignment', 'INDEX';

	ALTER TABLE dbo.OrganizationalUnitAssignment DROP CONSTRAINT DF_OrganizationalUnitAssignment_Deleted_As_False

	exec sp_rename 'dbo.OrganizationalUnitAssignment', 'WorkAssignment';

	ALTER TABLE dbo.WorkAssignment ADD  DEFAULT ((0)) FOR [Deleted]

END


GO


