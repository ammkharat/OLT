CREATE TABLE [dbo].[PermitRequestHistory](
	Id bigint NOT NULL,
	WorkPermitTypeId int NOT NULL,
	FunctionalLocationId bigint NOT NULL,
	StartDateTime datetime NOT NULL,
	EndDateTime datetime NOT NULL,
	WorkOrderNumber varchar(12) NULL,
	Trade varchar(100) NOT NULL,
	Description varchar(400) NOT NULL,
	LastModifiedByUserId bigint NOT NULL,
	LastModifiedDateTime datetime NOT NULL
) ON [PRIMARY]

GO



CREATE NONCLUSTERED INDEX [IDX_PermitRequestHistory] ON [dbo].[PermitRequestHistory] 
(
	[Id] ASC
)


GO


GO
