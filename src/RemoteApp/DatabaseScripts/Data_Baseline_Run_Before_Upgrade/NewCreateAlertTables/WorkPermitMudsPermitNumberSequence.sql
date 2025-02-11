IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMudsPermitNumberSequence]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMudsPermitNumberSequence](
	[SeqID] [bigint] IDENTITY(600000,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


End

