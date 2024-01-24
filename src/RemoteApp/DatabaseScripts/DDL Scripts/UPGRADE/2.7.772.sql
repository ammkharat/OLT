SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestrictionReasonCodeFLOCAssociation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[RestrictionReasonCodeId] [bigint] NOT NULL,
	[Limit] int NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,	
 CONSTRAINT [PK_RestrictionReasonCodeFLOCAssociation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RestrictionReasonCodeFLOCAssociation]  WITH NOCHECK ADD  CONSTRAINT [FK_RestrictionReasonCodeFLOCAssociation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

ALTER TABLE [dbo].[RestrictionReasonCodeFLOCAssociation]  WITH NOCHECK ADD  CONSTRAINT [FK_RestrictionReasonCodeFLOCAssociation_RestrictionReasonCode] FOREIGN KEY([RestrictionReasonCodeId])
REFERENCES [dbo].[RestrictionReasonCode] ([Id])

GO

ALTER TABLE RestrictionReasonCodeFLOCAssociation
ADD CONSTRAINT RestrictionReasonCodeFLOCAssociation_UniqueAssociation
UNIQUE (FunctionalLocationId, RestrictionReasonCodeId)

GO
