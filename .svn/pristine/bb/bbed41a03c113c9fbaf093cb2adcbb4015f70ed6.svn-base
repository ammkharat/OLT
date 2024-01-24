CREATE TABLE dbo.ShiftHandoverEmailConfiguration(
	Id bigint IDENTITY(1,1) NOT NULL,
	ShiftId bigint NOT NULL,
	SendTime DateTime NOT NULL,
	EmailAddresses varchar(max) NOT NULL,
	SiteId bigint NOT NULL
 CONSTRAINT PK_ShiftHandoverEmailConfiguration PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ShiftHandoverEmailConfiguration] WITH CHECK ADD CONSTRAINT [FK_ShiftHandoverEmailConfiguration_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])

ALTER TABLE [dbo].[ShiftHandoverEmailConfiguration] WITH CHECK ADD CONSTRAINT [FK_ShiftHandoverEmailConfiguration_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id]);




GO

