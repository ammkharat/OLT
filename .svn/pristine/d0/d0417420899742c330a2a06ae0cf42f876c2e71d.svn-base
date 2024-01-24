
Alter Table FormPermitAssessment Add [SiteId] [bigint] NOT NULL
GO	
Alter Table FormPermitAssessment drop column Trade
GO
Alter Table FormPermitAssessment Add [CraftOrTradeId] [bigint] NOT NULL	
GO	
Alter Table FormPermitAssessment Add [PermitNumber] varchar(10) NOT NULL	
GO	

ALTER TABLE [dbo].[FormPermitAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FormPermitAssessment_SiteId] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO

ALTER TABLE [dbo].[FormPermitAssessment] CHECK CONSTRAINT [FK_FormPermitAssessment_SiteId]
GO

ALTER TABLE [dbo].[FormPermitAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FormPermitAssessment_CraftOrTradeId] FOREIGN KEY([CraftOrTradeId])
REFERENCES [dbo].[CraftOrTrade] ([Id])
GO

ALTER TABLE [dbo].[FormPermitAssessment] CHECK CONSTRAINT [FK_FormPermitAssessment_CraftOrTradeId]
GO

alter table [dbo].DocumentLink add FormOilsandsPermitAssessmentId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormPermitAssessment] FOREIGN KEY([FormOilsandsPermitAssessmentId])
REFERENCES [dbo].[FormPermitAssessment] ([Id])
go



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormPermitAssessmentFunctionalLocation](
	[FormPermitAssessmentId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_FormPermitAssessmentFunctionalLocation] PRIMARY KEY CLUSTERED 
(
	[FormPermitAssessmentId] ASC,
	[FunctionalLocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormPermitAssessmentFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormPermitAssessmentFunctionalLocation_FormPermitAssessment] FOREIGN KEY([FormPermitAssessmentId])
REFERENCES [dbo].[FormPermitAssessment] ([Id])
GO

ALTER TABLE [dbo].[FormPermitAssessmentFunctionalLocation] CHECK CONSTRAINT [FK_FormPermitAssessmentFunctionalLocation_FormPermitAssessment]
GO

ALTER TABLE [dbo].[FormPermitAssessmentFunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormPermitAssessmentFunctionalLocation_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[FormPermitAssessmentFunctionalLocation] CHECK CONSTRAINT [FK_FormPermitAssessmentFunctionalLocation_FunctionalLocation]
GO





GO

