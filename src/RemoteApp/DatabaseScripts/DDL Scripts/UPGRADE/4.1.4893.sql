CREATE TABLE [dbo].[WorkPermitMontrealRequestDetails] (
	[Id] bigint NOT NULL,
	RequestedDateTime datetime null,
	RequestedByUserId bigint null,
	Company varchar(50) null,
	Supervisor varchar(100) null,
	ExcavationNumber varchar(50) null,
CONSTRAINT [PK_WorkPermitMontrealRequestDetails]
PRIMARY KEY CLUSTERED ([Id] ) ON [PRIMARY]
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[WorkPermitMontrealRequestDetails]
ADD  CONSTRAINT [FK_WorkPermitMontrealRequestDetails_Id]
FOREIGN KEY ([Id])
REFERENCES [dbo].[WorkPermitMontreal] ( [Id] )
GO

alter table WorkPermitMontrealRequestDetails
ADD  CONSTRAINT FK_WorkPermitMontrealRequestDetails_RequestedByUser
FOREIGN KEY(RequestedByUserId)
REFERENCES [User] ([Id]);

go

GO
