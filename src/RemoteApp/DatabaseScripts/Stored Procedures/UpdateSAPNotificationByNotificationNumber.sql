  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSAPNotificationByNotificationNumber')
	BEGIN
		DROP  Procedure  UpdateSAPNotificationByNotificationNumber
	END

GO

CREATE Procedure [dbo].[UpdateSAPNotificationByNotificationNumber]
	(
	@Description VARCHAR(MAX),
	@Comments VARCHAR(MAX) = NULL,
	@NotificationType  char(2), 
	@NotificationNumber char(12), 
	@CreationDateTime [datetime], 
	@FunctionalLocationId  [bigint],
	@Processed [bit],
	@ShortText varchar(40) = null,
	@LongText VARCHAR(MAX) = null,
	@IncidentID varchar(20)= null 
	)
AS
 
 UPDATE    SAPNotification
 SET              Description = @Description, Comments = @Comments, NotificationType = @NotificationType, 
				CreationDateTime = @CreationDateTime, FunctionalLocationID = @FunctionalLocationId, Processed = @Processed,
				ShortText = @ShortText, LongText=@LongText, IncidentID=@IncidentID                        
                       WHERE  NotificationNumber = @NotificationNumber
        GO


GRANT EXEC ON UpdateSAPNotificationByNotificationNumber TO PUBLIC

GO