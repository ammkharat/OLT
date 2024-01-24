
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ActionItemResponseTracker') 
begin

CREATE TABLE [dbo].[ActionItemResponseTracker](
		[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[ActionItemId] [bigint] NOT NULL,
	[ActionItemCustomFieldName] [varchar](40) NOT NULL,
	[FieldEntry] [varchar](100) NULL,
	[DisplayOrder] [int] NOT NULL,
	[TypeId] [tinyint] NULL,
	[CurrentNumericFieldEntry] [decimal](18, 6) NULL,
	[NewNumericFieldEntry] [decimal](18, 6) NULL,
	[CustomFieldId] [bigint] NOT NULL,
	[PHDLinkTypeId] [tinyint] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[BatchNumber] [bigint] NULL,
	[Comment] [varchar](max) NULL,
	[DisplayField] [varchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

end


