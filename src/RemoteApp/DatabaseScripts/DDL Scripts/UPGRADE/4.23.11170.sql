SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomFieldWithRange](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomFieldID] [bigint] NOT NULL,
	[Deleted] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[GreaterThanValue] [decimal](18, 6) NULL,
	[LessThanValue] [decimal](18, 6) NULL,
	[RangeGreaterThanValue] [decimal](18, 6) NULL,
	[RangeLessThanValue] [decimal](18, 6) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





GO

