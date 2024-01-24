CREATE TABLE [dbo].[LogTemplate](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,		
	[Name] [varchar](128) NOT NULL,	
	[Text] [varchar](4000) NOT NULL,	
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,	
	CONSTRAINT [PK_LogTemplate] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[LogTemplate]
ADD CONSTRAINT [FK_LogTemplate_CreatedUser] 
FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[User] ([Id])

ALTER TABLE [dbo].[LogTemplate]
ADD CONSTRAINT [FK_LogTemplate_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO

CREATE TABLE [dbo].[LogTemplateFunctionalLocation](
	[LogTemplateId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL
)
GO

ALTER TABLE [dbo].[LogTemplateFunctionalLocation]
ADD CONSTRAINT [FK_LogTemplateFunctionalLocation_LogTemplate] 
FOREIGN KEY([LogTemplateId])
REFERENCES [dbo].[LogTemplate] ([Id])
GO

ALTER TABLE [dbo].[LogTemplateFunctionalLocation]
ADD CONSTRAINT [FK_LogTemplateFunctionalLocation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

-- ----------------------------------
-- Permissions
-- ----------------------------------

insert into roleelement
values (129, 'Edit Log Templates')

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 129, r.id, 1
from role r where r.name = 'Administrator'

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 129, r.id, 2
from role r where r.name = 'Administrator'

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 129, r.id, 3
from role r where r.name = 'Administrator'

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 129, r.id, 5
from role r where r.name = 'Administrator'

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 129, r.id, 6
from role r where r.name = 'Administrator'

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 129, r.id, 7
from role r where r.name = 'Administrator'





GO
