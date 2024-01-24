


CREATE TABLE [dbo].[AreaLabel](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL DEFAULT ((0))
 CONSTRAINT [PK_AreaLabel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AreaLabel]  WITH CHECK ADD  CONSTRAINT [FK_AreaLabel_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])

GO

alter table WorkPermitEdmonton add AreaLabelId bigint null;
alter table PermitRequestEdmonton add AreaLabelId bigint null;

alter table WorkPermitEdmontonHistory add AreaLabel varchar(40) null;
alter table PermitRequestEdmontonHistory add AreaLabel varchar(40) null;

go





GO

