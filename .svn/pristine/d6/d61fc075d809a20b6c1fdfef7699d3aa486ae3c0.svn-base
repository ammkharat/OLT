CREATE TABLE [dbo].[SiteConfigurationDefaults](
	[SiteId] [bigint] NOT NULL,
	[CopyTargetAlertResponseToLog] [bit],	
	CONSTRAINT [UQ_SiteConfigurationDefaults] UNIQUE NONCLUSTERED ([SiteId] ASC) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]


ALTER TABLE [dbo].[SiteConfigurationDefaults] WITH CHECK ADD CONSTRAINT [FK_SiteConfigurationDefaults_Site] FOREIGN KEY([SiteId]) REFERENCES [dbo].[Site] ([Id]);

ALTER TABLE dbo.SiteConfigurationDefaults ALTER COLUMN CopyTargetAlertResponseToLog bit NOT NULL;

ALTER TABLE dbo.SiteConfiguration DROP COLUMN CopyTargetAlertResponseToLog;

GO

insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (1, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (2, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (3, 0);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (5, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (6, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (7, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (8, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (9, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (10, 1);
insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog) values (11, 1);


GO

