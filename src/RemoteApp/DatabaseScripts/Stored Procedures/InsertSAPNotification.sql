  if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertSAPNotification]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertSAPNotification]
GO

CREATE Procedure [dbo].[InsertSAPNotification]
	(
	@Id bigint Output,
	@Description VARCHAR(MAX),
	@Comments VARCHAR(MAX) = NULL,
	@NotificationType  varchar(2), 
	@NotificationNumber varchar(15), 
	@CreationDateTime [datetime], 
	@FunctionalLocationId  [bigint],
	@Processed [bit],
	@ShortText varchar(40) = null,
	@LongText VARCHAR(MAX) = null,
	@IncidentID varchar(20)= null
	)
AS

INSERT INTO [dbo].[SAPNotification](
	Description, 
	Comments,
	NotificationType, 
	CreationDateTime, 
	FunctionalLocationID, 
	Processed, 
	NotificationNumber,
	ShortText,
	LongText,
	IncidentID)
values (
	@Description, 
	@Comments,
	@NotificationType, 
	@CreationDateTime, 
	@FunctionalLocationId, 
	@Processed, 
	@NotificationNumber,
	@ShortText,
	@LongText,
	@IncidentID)

SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON [InsertSAPNotification] TO PUBLIC
GO