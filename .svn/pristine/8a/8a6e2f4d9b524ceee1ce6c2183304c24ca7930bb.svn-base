CREATE TABLE [dbo].PermitRequest(
	Id bigint IDENTITY(100,1) NOT NULL,
	WorkPermitTypeId int NOT NULL,
	FunctionalLocationId bigint NOT NULL,
	StartDateTime datetime NOT NULL,
	EndDateTime datetime NOT NULL,
	WorkOrderNumber varchar(12) NULL,
	Trade varchar(100) NOT NULL,
	Description varchar(400) NOT NULL,
	CreatedByUserId bigint NOT NULL,
	CreatedDateTime datetime NOT NULL,
	LastModifiedByUserId bigint NOT NULL,
	LastModifiedDateTime datetime NOT NULL,
	Deleted bit NOT NULL,
CONSTRAINT PK_PermitRequest PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
GO

ALTER TABLE PermitRequest
ADD CONSTRAINT FK_PermitRequest_FunctionalLocation FOREIGN KEY(FunctionalLocationId)
REFERENCES FunctionalLocation (Id)
GO

ALTER TABLE PermitRequest
ADD CONSTRAINT FK_PermitRequest_CreatedByUser FOREIGN KEY(CreatedByUserId)
REFERENCES [User] (Id)
GO

ALTER TABLE PermitRequest
ADD CONSTRAINT FK_PermitRequest_LastModifiedByUser FOREIGN KEY(LastModifiedByUserId)
REFERENCES [User] (Id)
GO