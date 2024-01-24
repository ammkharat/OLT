CREATE TABLE [dbo].PermitAttribute (
	Id bigint IDENTITY(100, 1) not null,
	SiteId bigint not null,
	Name varchar(100) not null,
	SapCode varchar(2) null,
CONSTRAINT [PK_PermitAttribute]
PRIMARY KEY CLUSTERED ([Id] ) ON [PRIMARY]
)
ON [PRIMARY];
GO


ALTER TABLE [dbo].PermitAttribute
ADD  CONSTRAINT [FK_PermitAttribute_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])


go



GO
