
CREATE TABLE [dbo].[LabAlertResponse](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[LabAlertId] bigint NOT NULL,
	[LabAlertStatusId] bigint NOT NULL,
	[Comments] varchar(max) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL
 CONSTRAINT [PK_LabAlertResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)

GO

ALTER TABLE LabAlertResponse
ADD CONSTRAINT FK_LabAlertResponse_LabAlert
FOREIGN KEY(LabAlertId)
REFERENCES LabAlert ([Id])
GO

ALTER TABLE LabAlertResponse
ADD CONSTRAINT FK_LabAlertResponse_CreatedByUser
FOREIGN KEY(CreatedByUserId)
REFERENCES [User] ([Id])
GO
GO

GO
