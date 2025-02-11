
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMuds')
	BEGIN
		DROP Procedure [dbo].InsertPermitRequestMuds
	END
GO

CREATE Procedure [dbo].[InsertPermitRequestMuds]  
    (  
    @Id bigint Output,  
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
 @SourceId int = NULL,  
 @LastImportedByUserId bigint = NULL,  
 @LastImportedDateTime datetime = NULL,   
 @LastSubmittedByUserId bigint = NULL,  
 @LastSubmittedDateTime datetime = NULL,  
 @CreatedByUserId bigint,  
 @CreatedDateTime datetime,  
 @LastModifiedByUserId bigint,  
 @LastModifiedDateTime datetime,  
 @IsModified bit,  
 @CompletionStatusId bigint  ,
 
 @NbTravail varchar(50),  
@FormationCheck bit,  
@NomsEnt varchar(50)  ,
@NomsEnt_1 varchar(50)  ,
@NomsEnt_2 varchar(50)  ,
@NomsEnt_3 varchar(50)  ,
@Surveilant varchar(50) ,
 @StartDateTime DateTime,      
 @EndDateTime DateTime,
 @Analyse_Attribute_CheckBox	bit ,
@Cadenassage_multiple_Attribute_CheckBox	bit ,
@Cadenassage_simple_Attribute_CheckBox	bit,
@Procédure_Attribute_CheckBox	bit ,
@Espace_clos_Attribute_CheckBox	bit
    )  
AS  
  
INSERT INTO PermitRequestMuds  
(  
 WorkPermitTypeId,  
    StartDate,  
 EndDate,  
 RequestedByGroupId,  
 WorkOrderNumber,  
 OperationNumber,  
 SubOperationNumber,  
 Trade,  
 Description,  
 SapDescription,  
 Company,  
Company_1, 
Company_2,
 Supervisor,  
 ExcavationNumber,  
 SourceId,  
 LastImportedByUserId,  
 LastImportedDateTime,   
 LastSubmittedByUserId,  
 LastSubmittedDateTime,  
 CreatedByUserId,  
 CreatedDateTime,  
 LastModifiedByUserId,  
 LastModifiedDateTime,  
 IsModified,  
 CompletionStatusId,  
 Deleted ,
  NbTravail ,  
 FormationCheck ,  
 NomsEnt  ,
 NomsEnt_1  ,
 NomsEnt_2  ,
 NomsEnt_3  ,
 Surveilant,
  StartDateTime,      
 EndDateTime,
Analyse_Attribute_CheckBox	 ,
Cadenassage_multiple_Attribute_CheckBox	 ,
Cadenassage_simple_Attribute_CheckBox	,
Procédure_Attribute_CheckBox	 ,
Espace_clos_Attribute_CheckBox	
)  
VALUES  
(   
 @WorkPermitTypeId,  
    @StartDate,  
 @EndDate,  
 @RequestedByGroupId,  
 @WorkOrderNumber,  
 @OperationNumber,  
 @SubOperationNumber,  
 @Trade,  
 @Description,  
 @SapDescription,  
 @Company,  
 @Company_1,  
 @Company_2,
 @Supervisor,  
 @ExcavationNumber,  
 @SourceId,  
 @LastImportedByUserId,  
 @LastImportedDateTime,   
 @LastSubmittedByUserId,  
 @LastSubmittedDateTime,  
 @CreatedByUserId,  
 @CreatedDateTime,  
 @LastModifiedByUserId,  
 @LastModifiedDateTime,  
 @IsModified,  
 @CompletionStatusId,  
 0 ,
 @NbTravail ,  
 @FormationCheck ,  
 @NomsEnt ,
@NomsEnt_1 ,
 @NomsEnt_2 ,
 @NomsEnt_3 ,
 @Surveilant ,
  @StartDateTime,      
 @EndDateTime ,
@Analyse_Attribute_CheckBox	 ,
@Cadenassage_multiple_Attribute_CheckBox	 ,
@Cadenassage_simple_Attribute_CheckBox	,
@Procédure_Attribute_CheckBox	 ,
@Espace_clos_Attribute_CheckBox
)  
SET @Id= SCOPE_IDENTITY()   
  
  
GRANT EXEC ON [InsertPermitRequestMuds] TO PUBLIC
GO
