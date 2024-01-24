ALTER TABLE dbo.LiveLinkDocumentLink 
  ALTER COLUMN Link VARCHAR(MAX)
  
CREATE TABLE dbo.UncRoot (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,	
	[SiteId] BIGINT NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[UncPath] VARCHAR(200) NOT NULL
)

INSERT INTO RoleElement VALUES(142, 'Configure Unc Paths for Links')

insert into roleelementtemplate
select distinct 142,  roleid, siteid
from roleelementtemplate
where roleid = 37;

GO
