IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[MudsFormIdSequence]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[MudsFormIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT NULL,
	[SeqVal] [varchar](1) NULL
) ON [PRIMARY]


End
