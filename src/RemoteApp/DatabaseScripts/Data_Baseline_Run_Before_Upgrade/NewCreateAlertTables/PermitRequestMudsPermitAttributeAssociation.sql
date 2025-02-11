IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsPermitAttributeAssociation]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[PermitRequestMudsPermitAttributeAssociation](
	[PermitRequestId] [bigint] NOT NULL,
	[PermitAttributeId] [bigint] NOT NULL,
 CONSTRAINT [PK_PermitRequestMudsPermitAttributeAssociation] PRIMARY KEY CLUSTERED 
(
	[PermitRequestId] ASC,
	[PermitAttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


End

