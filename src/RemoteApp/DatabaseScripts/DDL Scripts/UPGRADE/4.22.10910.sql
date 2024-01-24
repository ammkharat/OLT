SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee1Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee1Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee2Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee2Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee3Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee3Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee4Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAttendee4Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAnswer1] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAnswer2] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAnswer3] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAnswer4] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentAnswer5] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [RiskAssessmentComments] varchar(255) NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover1Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover1Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover1Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover1ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover1ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover2Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover2Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover2Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover2ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [ImmediateApprovalsApprover2ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover1Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover1Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover1Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover1ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover1ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover2Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover2Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover2Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover2ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviation] ADD [TemporaryApprovalsApprover2ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee1Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee1Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee2Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee2Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee3Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee3Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee4Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAttendee4Name] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAnswer1] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAnswer2] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAnswer3] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAnswer4] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentAnswer5] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [RiskAssessmentComments] varchar(255) NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover1Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover1Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover1Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover1ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover1ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover2Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover2Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover2Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover2ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [ImmediateApprovalsApprover2ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover1Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover1Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover1Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover1ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover1ApprovedDateTime] datetime NULL
GO

ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover2Type] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover2Title] varchar(100) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover2Name] varchar(255) NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover2ObtainedVia] int NULL
GO
ALTER TABLE [dbo].[FormProcedureDeviationHistory] ADD [TemporaryApprovalsApprover2ApprovedDateTime] datetime NULL
GO




GO

