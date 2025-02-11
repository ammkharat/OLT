IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ConfinedSpaceMudsNumberSequence]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[ConfinedSpaceMudsNumberSequence](
	[SeqID] [bigint] IDENTITY(25000,1) NOT NULL,
	[SeqVal] [varchar](1) NULL,
 CONSTRAINT [PK_ConfinedSpaceMudsNumberSequence] PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


End

