CREATE TABLE dbo.SapAutoImportConfiguration(	
	SiteId bigint NOT NULL,
	ScheduleId bigint NULL,		
 CONSTRAINT PK_SapAutoImportConfiguration PRIMARY KEY CLUSTERED ([SiteId] ASC) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SapAutoImportConfiguration] WITH CHECK ADD CONSTRAINT [FK_SapAutoImportConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id]);
GO

ALTER TABLE [dbo].[SapAutoImportConfiguration] WITH CHECK ADD CONSTRAINT [FK_SapAutoImportConfiguration_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([Id]);
GO

insert into SapAutoImportConfiguration (SiteId, ScheduleId) values (10, null);


GO

