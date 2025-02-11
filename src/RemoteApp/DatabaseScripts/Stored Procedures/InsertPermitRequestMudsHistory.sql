
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMudsHistory')
	BEGIN
		DROP Procedure [dbo].InsertPermitRequestMudsHistory
	END
GO

CREATE Procedure [dbo].[InsertPermitRequestMudsHistory]  
    (  
    @Id bigint,  
 @WorkPermitTypeId int,  
    @FunctionalLocations varchar(max),  
    @StartDate datetime,  
 @EndDate datetime,  
 @WorkOrderNumber varchar(12) = NULL,  
 @OperationNumber varchar(4) = NULL,  
 @Trade varchar(100) = NULL,  
 @Description varchar(400),  
 @SapDescription varchar(400) = NULL,  
 @Company varchar(50) = NULL,  
@Company_1 varchar(50) = NULL,  
 @Company_2 varchar(50) = NULL,
 @Supervisor varchar(100) = NULL,  
 @ExcavationNumber varchar(50) = NULL,  
 @Attributes varchar(max) = NULL,  
 @LastImportedByUserId bigint = NULL,  
 @LastImportedDateTime datetime = NULL,   
 @LastSubmittedByUserId bigint = NULL,  
 @LastSubmittedDateTime datetime = NULL,  
 @LastModifiedByUserId bigint,  
 @LastModifiedDateTime datetime,  
 @DocumentLinks varchar(max) = NULL,  
 @RequestedByGroup varchar(100) = NULL,  
 @CompletionStatusId bigint,  
 @SourceId int  ,
  @StartDateTime DateTime,      
 @EndDateTime DateTime 
    )  
AS  
  
INSERT INTO PermitRequestMudsHistory  
(  
 Id,  
 WorkPermitTypeId,  
 FunctionalLocations,  
    StartDate,  
 EndDate,  
 WorkOrderNumber,  
 OperationNumber,  
 Trade,  
 Description,  
 SapDescription,  
 Company,  
Company_1,  
 Company_2, 
 Supervisor,  
 ExcavationNumber,  
 Attributes,  
 LastImportedByUserId,  
 LastImportedDateTime,   
 LastSubmittedByUserId,  
 LastSubmittedDateTime,  
 LastModifiedByUserId,  
 LastModifiedDateTime,  
 DocumentLinks,  
 RequestedByGroup,  
 CompletionStatusId,  
 SourceId  ,
 StartDateTime ,
 EndDateTime 
)  
VALUES  
(   
 @Id,  
 @WorkPermitTypeId,  
 @FunctionalLocations,  
    @StartDate,  
 @EndDate,  
 @WorkOrderNumber,  
 @OperationNumber,  
 @Trade,  
 @Description,  
 @SapDescription,  
 @Company,  
@Company_1,  
 @Company_2, 
 @Supervisor,  
 @ExcavationNumber,  
 @Attributes,  
 @LastImportedByUserId,  
 @LastImportedDateTime,   
 @LastSubmittedByUserId,  
 @LastSubmittedDateTime,  
 @LastModifiedByUserId,  
 @LastModifiedDateTime,  
 @DocumentLinks,  
 @RequestedByGroup,  
 @CompletionStatusId,  
 @SourceId  ,
  @StartDateTime ,
 @EndDateTime
)  
SET @Id= SCOPE_IDENTITY()   
  
  
GRANT EXEC ON [InsertPermitRequestMudsHistory] TO PUBLIC
GO
