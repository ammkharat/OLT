IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsFunctionalLocation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[PermitRequestMudsFunctionalLocation](
	[PermitRequestMudsId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_PermitRequestMudsFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[PermitRequestMudsId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


End
