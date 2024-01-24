insert into RoleElement values (155, 'Edit log created by a Process Engineer');
insert into RoleElement values (156, 'Delete log created by a Process Engineer');
insert into RoleElement values (157, 'Cancel log created by a Process Engineer');

insert into RoleElement values (158, 'Edit log created by a Placeholder 1');
insert into RoleElement values (159, 'Delete log created by a Placeholder 1');
insert into RoleElement values (160, 'Cancel log created by a Placeholder 1');

insert into RoleElement values (161, 'Edit log created by a Placeholder 2');
insert into RoleElement values (162, 'Delete log created by a Placeholder 2');
insert into RoleElement values (163, 'Cancel log created by a Placeholder 2');

insert into RoleElement values (164, 'Edit log created by a Placeholder 3');
insert into RoleElement values (165, 'Delete log created by a Placeholder 3');
insert into RoleElement values (166, 'Cancel log created by a Placeholder 3');

insert into RoleElement values (167, 'Edit log created by a Placeholder 4');
insert into RoleElement values (168, 'Delete log created by a Placeholder 4');
insert into RoleElement values (169, 'Cancel log created by a Placeholder 4');

insert into RoleElement values (170, 'Edit log created by a Placeholder 5');
insert into RoleElement values (171, 'Delete log created by a Placeholder 5');
insert into RoleElement values (172, 'Cancel log created by a Placeholder 5');

SET IDENTITY_INSERT dbo.[RoleGroup] ON;

INSERT INTO dbo.RoleGroup (
   [Id],
   [Name]
) VALUES (
   7,
   'Process Enginer'
)

INSERT INTO dbo.RoleGroup (
   [Id],
   [Name]
) VALUES (
   8,
   'Placeholder 1'
)
INSERT INTO dbo.RoleGroup (
   [Id],
   [Name]
) VALUES (
   9,
   'Placeholder 2'
)
INSERT INTO dbo.RoleGroup (
   [Id],
   [Name]
) VALUES (
   10,
   'Placeholder 3'
)
INSERT INTO dbo.RoleGroup (
   [Id],
   [Name]
) VALUES (
   11,
   'Placeholder 4'
)
INSERT INTO dbo.RoleGroup (
   [Id],
   [Name]
) VALUES (
   12,
   'Placeholder 5'
)

SET IDENTITY_INSERT dbo.[RoleGroup] OFF;
GO

UPDATE [Role] 
  SET RoleGroupId = 7
WHERE
  [Name] = 'Process Engineer Target Admin'
  or [Name] = 'Process Engineer'
GO