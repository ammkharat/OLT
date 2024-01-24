

ALTER TABLE dbo.WorkPermitMontreal ADD UsePreviousPermitAnswered bit NULL;
GO
UPDATE dbo.WorkPermitMontreal SET UsePreviousPermitAnswered = 0
ALTER TABLE dbo.WorkPermitMontreal ALTER COLUMN UsePreviousPermitAnswered bit NOT NULL;
GO



GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MontrealFormIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LubesFormIdSequence](
	[SeqID] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SeqVal] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


GO

if exists(select * from sys.columns 
            where Name = N'DepartmentId' and Object_ID = Object_ID(N'FormLubesAlarmDisable'))
begin
	alter table FormLubesAlarmDisable
	drop column DepartmentId
end
go


if exists(select * from sys.columns 
            where Name = N'DepartmentId' and Object_ID = Object_ID(N'FormLubesAlarmDisableHistory'))
begin
	alter table FormLubesAlarmDisableHistory
	drop column DepartmentId
end
go





GO

