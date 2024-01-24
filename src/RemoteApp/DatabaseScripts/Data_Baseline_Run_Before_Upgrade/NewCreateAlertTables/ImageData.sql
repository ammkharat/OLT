IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ImageData]') AND type in (N'U'))

Begin 

CREATE TABLE [dbo].ImageData(
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ItemID] [bigint] NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](150) NULL,
	[ImagePath] [varchar](150) NULL,
	[CreatedDate] [datetime] NULL,
	[Createdby] [int] NULL,
	[Updateddate] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[RecordType] [int] NULL,
	[RecordFor] [int] NULL DEFAULT ((0))
) 

END