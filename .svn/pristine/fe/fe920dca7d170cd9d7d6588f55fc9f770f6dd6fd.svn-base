
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitGasTestElementInfoMUDS]') AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[WorkPermitGasTestElementInfoMUDS](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitId] [bigint] NOT NULL,
	[GasTestElementInfoId] [bigint] NOT NULL,
	[FirstRequiredTest] [bit] NOT NULL,
	[FirstTestResult] [float] NULL,
	
	[SecondRequiredTest] [bit] NOT NULL,
	[SecondTestResult] [float] NULL,
	
	[ThirdRequiredTest] [bit] NOT NULL,
	[ThirdTestResult] [float] NULL,
	
	[FourthRequiredTest] [bit] NOT NULL,
	[FourthTestResult] [float] NULL,
	
)

END