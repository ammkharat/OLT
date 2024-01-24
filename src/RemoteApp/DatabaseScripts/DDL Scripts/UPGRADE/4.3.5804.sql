CREATE TABLE [dbo].[WorkPermitCloseConfiguration] (
[SiteId] bigint NOT NULL,
[StatusId] tinyint NOT NULL,
[RequiresLog] bit NOT NULL)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[WorkPermitCloseConfiguration]
ADD  CONSTRAINT [FK_WorkPermitCloseConfiguration_SiteId]
FOREIGN KEY ([SiteId])
REFERENCES [dbo].[Site] ( [Id] )
GO

-- Firebag configuration
INSERT INTO dbo.WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) VALUES (5, 4, 0)
INSERT INTO dbo.WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) VALUES (5, 6, 1)

-- Edmonton configuration
INSERT INTO dbo.WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) VALUES (8, 4, 0)
INSERT INTO dbo.WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) VALUES (8, 5, 1)
INSERT INTO dbo.WorkPermitCloseConfiguration (SiteId, StatusId, RequiresLog) VALUES (8, 6, 1)




GO

