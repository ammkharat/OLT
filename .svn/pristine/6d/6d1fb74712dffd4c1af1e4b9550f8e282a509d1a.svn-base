UPDATE WorkPermitCloseConfiguration SET RequiresLog = 0 where SiteId = 8
INSERT INTO WorkPermitCloseConfiguration (SiteId,StatusId,RequiresLog) VALUES (8,7,0)
INSERT INTO WorkPermitCloseConfiguration (SiteId,StatusId,RequiresLog) VALUES (8,8,0)

-- Insert close permissions for users who have Create Permissions in Edmonton
INSERT INTO RoleElementTemplate 
select 
	52, RoleId 
from 
	RoleElementTemplate
	inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
	inner join dbo.RoleElement ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
	where 
		dbo.[Role].SiteId = 8 and dbo.RoleElement.FunctionalArea = 'Work Permits'
		and dbo.RoleElement.Id = 23

		
CREATE TABLE [dbo].[LogWorkPermitEdmontonAssociation] (
[LogId] bigint NOT NULL,
[WorkPermitEdmontonId] bigint NOT NULL,
CONSTRAINT [PK_LogWorkPermitEdmontonAssociation]
PRIMARY KEY CLUSTERED ([LogId] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_LogWorkPermitEdmontonAssoc_WorkPermit]
FOREIGN KEY ([WorkPermitEdmontonId])
REFERENCES [dbo].[WorkPermitEdmonton] ( [Id] ),
CONSTRAINT [FK_LogWorkPermitEdmontonAssoc_Log]
FOREIGN KEY ([LogId])
REFERENCES [dbo].[Log] ( [Id] )
)
ON [PRIMARY];
GO
		


GO

