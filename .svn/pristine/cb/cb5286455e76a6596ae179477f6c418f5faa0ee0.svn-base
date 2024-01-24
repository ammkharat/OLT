IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CustomFieldWithRange')
	BEGIN
		DROP Table [dbo].CustomFieldWithRange
	END
GO

CREATE TABLE [dbo].[CustomFieldWithRange](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomFieldID] [bigint] NOT NULL,
	[GreaterThanValue] [decimal](18, 6) NULL,
	[LessThanValue] [decimal](18, 6) NULL,
	[RangeGreaterThanValue] [decimal](18, 6) NULL,
	[RangeLessThanValue] [decimal](18, 6) NULL,
	[IsActive] [bit] NULL,
	[ActiveFrom] [datetime] NULL,
	[ActiveTo] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





GO

