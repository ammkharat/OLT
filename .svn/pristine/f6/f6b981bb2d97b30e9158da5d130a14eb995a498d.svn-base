alter table WorkAssignment add RoleId bigint null;

GO

update WorkAssignment set RoleId = 2;

GO

alter table WorkAssignment alter column RoleId bigint not null;

GO

ALTER TABLE [dbo].[WorkAssignment]
ADD CONSTRAINT [FK_WorkAssignment_Role] 
FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])

GO

GO
