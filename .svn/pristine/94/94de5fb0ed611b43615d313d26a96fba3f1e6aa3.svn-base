SET IDENTITY_INSERT TagGroup ON

DECLARE @SARNIA_SITE BIGINT;
SET @SARNIA_SITE = 1;

INSERT TagGroup([Id], [Name], [SiteId]) VALUES (1, 'Tag Info Group 1', @SARNIA_SITE);
SET IDENTITY_INSERT TagGroup OFF
GO

INSERT TagGroupAssociation (TagGroupId, TagId) SELECT 1, Id From Tag WHERE [Name] = '31TI111.PV' and SiteId = 1
INSERT TagGroupAssociation (TagGroupId, TagId) SELECT 1, Id From Tag WHERE [Name] = '04CF002.CV' and SiteId = 1
INSERT TagGroupAssociation (TagGroupId, TagId) SELECT 1, Id From Tag WHERE [Name] = '12TI732A.PV' and SiteId = 1
GO