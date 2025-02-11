IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsRequestDetails]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMudsRequestDetails](
	[Id] [bigint] NOT NULL,
	[RequestedDateTime] [datetime] NULL,
	[RequestedByUserId] [bigint] NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[ExcavationNumber] [varchar](50) NULL,
 CONSTRAINT [PK_WorkPermitMudsRequestDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--ALTER TABLE [dbo].[WorkPermitMudsRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsRequestDetails_Id] FOREIGN KEY([Id])
--REFERENCES [dbo].[WorkPermitMuds] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsRequestDetails] CHECK CONSTRAINT [FK_WorkPermitMudsRequestDetails_Id]

--ALTER TABLE [dbo].[WorkPermitMudsRequestDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMudsRequestDetails_RequestedByUser] FOREIGN KEY([RequestedByUserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[WorkPermitMudsRequestDetails] CHECK CONSTRAINT [FK_WorkPermitMudsRequestDetails_RequestedByUser]

End

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsRequestDetails]') AND name = 'Company_1'
)
begin
ALTER TABLE WorkPermitMudsRequestDetails ADD Company_1 varchar(50)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsRequestDetails]') AND name = 'Company_2'
)
begin
ALTER TABLE WorkPermitMudsRequestDetails ADD Company_2 varchar(50)
end
Go