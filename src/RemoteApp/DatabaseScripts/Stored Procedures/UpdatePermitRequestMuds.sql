
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdatePermitRequestMuds')
	BEGIN
		DROP Procedure [dbo].UpdatePermitRequestMuds
	END
GO

CREATE Procedure [dbo].[UpdatePermitRequestMuds]  
    (  
    @Id bigint,  
 @WorkPermitTypeId int,  
    @StartDate datetime,  
 @EndDate datetime,  
 @RequestedByGroupId varchar(50) = NULL,
 @WorkOrderNumber varchar(12) = NULL,  
 @OperationNumber varchar(4) = NULL,  
 @SubOperationNumber varchar(4) = NULL,  
 @Trade varchar(100),  
 @Description varchar(400),  
 @SapDescription varchar(400) = NULL,  
 @Company varchar(50) = NULL,  
 @Company_1 varchar(50) = NULL, 
 @Company_2 varchar(50) = NULL,
 @Supervisor varchar(100) = NULL,  
 @ExcavationNumber varchar(50) = NULL,  
 @LastImportedByUserId bigint = NULL,  
 @LastImportedDateTime datetime = NULL,   
 @LastSubmittedByUserId bigint = NULL,  
 @LastSubmittedDateTime datetime = NULL,  
 @LastModifiedByUserId bigint,  
 @LastModifiedDateTime datetime,  
 @IsModified bit,  
 @CompletionStatusId bigint ,
 
@NbTravail varchar(50),  
@FormationCheck bit,  
@NomsEnt varchar(50) ,
@NomsEnt_1 varchar(50) ,
@NomsEnt_2 varchar(50) ,
@NomsEnt_3 varchar(50) ,

@Surveilant varchar(50) ,
 @StartDateTime DateTime,      
 @EndDateTime DateTime ,
  @Analyse_Attribute_CheckBox	bit ,
@Cadenassage_multiple_Attribute_CheckBox	bit ,
@Cadenassage_simple_Attribute_CheckBox	bit,
@Procédure_Attribute_CheckBox	bit ,
@Espace_clos_Attribute_CheckBox	bit
    )  
AS  
  
UPDATE PermitRequestMuds  
SET  
 WorkPermitTypeId = @WorkPermitTypeId,  
    StartDate = @StartDate,  
 EndDate = @EndDate,  
 RequestedByGroupId = @RequestedByGroupId,  
 WorkOrderNumber = @WorkOrderNumber,  
 OperationNumber = @OperationNumber,  
 SubOperationNumber = @SubOperationNumber,  
 Trade = @Trade,  
 Description = @Description,  
 SapDescription = @SapDescription,  
 Company = @Company,  
Company_1 = @Company_1,  
 Company_2 = @Company_2, 
 Supervisor = @Supervisor,  
 ExcavationNumber = @ExcavationNumber,  
 LastImportedByUserId = @LastImportedByUserId,  
 LastImportedDateTime = @LastImportedDateTime,  
 LastSubmittedByUserId = @LastSubmittedByUserId,  
 LastSubmittedDateTime = @LastSubmittedDateTime,  
 LastModifiedByUserId = @LastModifiedByUserId,  
 LastModifiedDateTime = @LastModifiedDateTime,  
 IsModified = @IsModified,  
 CompletionStatusId = @CompletionStatusId  ,
 
NbTravail = @NbTravail ,
FormationCheck = @FormationCheck ,
NomsEnt = @NomsEnt ,
NomsEnt_1 = @NomsEnt_1 ,
NomsEnt_2 = @NomsEnt_2 ,
NomsEnt_3 = @NomsEnt_3 ,

Surveilant = @Surveilant,
 StartDateTime = @StartDateTime,
 
 EndDateTime = @EndDateTime ,

 Analyse_Attribute_CheckBox	 = @Analyse_Attribute_CheckBox ,
Cadenassage_multiple_Attribute_CheckBox	 = @Cadenassage_multiple_Attribute_CheckBox ,
Cadenassage_simple_Attribute_CheckBox	= @Cadenassage_simple_Attribute_CheckBox,
Procédure_Attribute_CheckBox=	@Procédure_Attribute_CheckBox ,
Espace_clos_Attribute_CheckBox = @Espace_clos_Attribute_CheckBox

WHERE Id = @Id
GO

GRANT EXEC ON UpdatePermitRequestMuds TO PUBLIC
GO

