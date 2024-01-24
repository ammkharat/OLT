CREATE TABLE [dbo].[SiteFunctionalArea] (
[SiteId] bigint NOT NULL,
[FunctionalArea] bigint NOT NULL,
FOREIGN KEY ([SiteId])
REFERENCES [dbo].[Site] ( [Id] )
)
ON [PRIMARY];
GO


-- Sarnia
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,2)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,6)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,7)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (1,11)

-- Denver
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,2)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,6)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,7)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (2,11)


-- Oil Sands
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,2)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,7)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,8)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,9)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,10)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (3,11)

-- Firebag
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (5,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (5,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (5,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (5,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (5,7)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (5,11)

-- SWS
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (6,11)

-- MacKay River
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (7,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (7,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (7,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (7,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (7,7)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (7,11)

-- Edmonton 
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (8,1)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (8,3)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (8,4)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (8,5)
INSERT INTO dbo.SiteFunctionalArea (SiteId,FunctionalArea) VALUES (8,7)


GO
