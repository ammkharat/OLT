if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePermitRequestEdmonton]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdatePermitRequestEdmonton]
GO

CREATE Procedure [dbo].[UpdatePermitRequestEdmonton]            
    (            
  @Id bigint Output,            
  @EndDate datetime,            
  @PriorityId int,            
  @Description varchar(8000),            
  @SAPDescription varchar(8000) = NULL,            
  @Company varchar(50) = NULL,              
  @LastImportedByUserId int = NULL,            
  @LastImportedDateTime datetime = NULL,            
  @LastSubmittedByUserId int = NULL,            
  @LastSubmittedDateTime datetime = NULL,            
  @LastModifiedByUserId int,            
  @LastModifiedDateTime datetime,            
  @IsModified bit,            
  @CompletionStatusId int,            
  @WorkOrderNumber varchar(25) = NULL,            
  @IssuedToSuncor bit,            
  @Occupation varchar(50),            
  @NumberOfWorkers int = NULL,            
  @GroupId bigint,            
  @WorkPermitTypeId int,              
  @FunctionalLocationId int,            
  @Location varchar(100),            
  @AreaLabelId bigint,            
  @AlkylationEntryClassOfClothing varchar(25) = NULL,            
  @FlarePitEntryType varchar(25) = NULL,            
  @ConfinedSpaceCardNumber varchar(15) = NULL,            
  @ConfinedSpaceClass varchar(25) = NULL,            
  @RescuePlanFormNumber varchar(15) = NULL,            
  @VehicleEntryTotal int = NULL,            
  @VehicleEntryType varchar(30) = NULL,            
  @SpecialWorkFormNumber varchar(15) = NULL,            
  @SpecialWorkType int = NULL,            
  @FormGN59Id bigint = NULL,            
  @FormGN7Id bigint = NULL,            
  @FormGN24Id bigint = NULL,            
  @FormGN75AId bigint = NULL,            
  @FormGN1Id bigint = NULL,            
  @FormGN1TradeChecklistId bigint = NULL,            
  @FormGN1TradeChecklistDisplayNumber varchar(32) = NULL,            
  @FormGN6Id bigint = NULL,            
  @GN59 bit,            
  @GN7 bit,            
  @GN24 bit,            
  @GN75A bit,            
  @GN1 bit,            
  @GN6 bit,            
  @GN11 int,            
  @GN24_Deprecated int,            
  @GN6_Deprecated int,            
  @GN27 int,            
  @GN75_Deprecated int,              
  @AlkylationEntry bit,            
  @FlarePitEntry bit,            
  @ConfinedSpace bit,            
  @RescuePlan bit,            
  @VehicleEntry bit,            
  @SpecialWork bit,               
  @RequestedStartDate datetime,            
  @RequestedStartTimeDay datetime = NULL,            
  @RequestedStartTimeNight datetime = NULL,            
  @HazardsAndOrRequirements varchar(500) = NULL,            
  @OtherAreasAndOrUnitsAffectedArea varchar(50) = NULL,            
  @OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) = NULL,            
  @WorkersMinimumSafetyRequirementsSectionNotApplicableToJob bit,            
  @FaceShield bit,            
  @Goggles bit,            
  @RubberBoots bit,            
  @RubberGloves bit,            
  @RubberSuit bit,            
  @SafetyHarnessLifeline bit,            
  @HighVoltagePPE bit,              
  @Other1 varchar(30) = NULL,            
  @EquipmentGrounded bit,            
  @FireBlanket bit,            
  @FireExtinguisher bit,            
  @FireMonitorManned bit,            
  @FireWatch bit,            
  @SewersDrainsCovered bit,            
  @SteamHose bit,              
  @Other2 varchar(30) = NULL,            
  @AirPurifyingRespirator bit,            
  @BreathingAirApparatus bit,            
  @DustMask bit,            
  @LifeSupportSystem bit,            
  @SafetyWatch bit,            
  @ContinuousGasMonitor bit,              
  @WorkersMonitor bit,            
  @WorkersMonitorNumber varchar(10) = NULL,            
  @BumpTestMonitorPriorToUse bit,              
  @Other3 varchar(30) = NULL,            
  @AirMover bit,            
  @BarriersSigns bit,              
  @RadioChannel bit,            
  @RadioChannelNumber varchar(10) = NULL,            
  @AirHorn bit,            
  @MechVentilationComfortOnly bit,            
  @AsbestosMMCPrecautions bit,              
  @Other4 varchar(30) = NULL,            
              
  @RoadAccessOnPermit bit ,              
  @RoadAccessOnPermitFormNumber varchar(10) = NULL,              
  @RoadAccessOnPermitType varchar(50) = NULL ,          
            @SpecialWorkName VARCHAR(100)                   
               
  )            
AS            
          
-- Added new  for Special Work     
  
If (@SpecialWork = 0)         
Begin  
 Delete from SpecialWork Where PermitRequestID = @Id  
 Set @SpecialWorkName = Null  
End  
  
If Not Exists  (Select CompanyName from SpecialWork Where PermitRequestID = @Id)        
   Begin   
  If @SpecialWorkName IS NULL OR RTRIM(LTRIM(@SpecialWorkName)) = ''  
   Begin  
    SET @SpecialWorkType = Null  
   End  
        Else  
   Begin  
    INSERT INTO SpecialWork Values ( @SpecialWorkName, 8, Null, @Id)             
    SET @SpecialWorkType = SCOPE_IDENTITY()   
   End               
   End        
Else        
 Begin       
 Update  SpecialWork      
 Set CompanyName = @SpecialWorkName      
 Where PermitRequestID = @Id       
        
 Set @SpecialWorkType = (Select ID from SpecialWork Where PermitRequestID = @Id)        
End     
           
-- Till here                 
           
            
            
UPDATE PermitRequestEdmonton            
SET            
 EndDate = @EndDate,            
 TaskDescription = @Description,            
 SAPDescription = @SAPDescription,            
 Company = @Company,             
 PriorityId = @PriorityId,            
 LastImportedByUserId = @LastImportedByUserId,            
 LastImportedDateTime = @LastImportedDateTime,            
 LastSubmittedByUserId = @LastSubmittedByUserId,            
 LastSubmittedDateTime = @LastSubmittedDateTime,            
 LastModifiedByUserId = @LastModifiedByUserId,            
 LastModifiedDateTime = @LastModifiedDateTime,            
 IsModified = @IsModified,            
 CompletionStatusId = @CompletionStatusId,            
 WorkOrderNumber = @WorkOrderNumber,            
 IssuedToSuncor = @IssuedToSuncor,            
 Occupation = @Occupation,            
 NumberOfWorkers = @NumberOfWorkers,            
 GroupId = @GroupId,            
 WorkPermitTypeId = @WorkPermitTypeId,             
 FunctionalLocationId = @FunctionalLocationId,            
 Location = @Location,            
 AreaLabelId = @AreaLabelId,            
 AlkylationEntryClassOfClothing = @AlkylationEntryClassOfClothing,            
 FlarePitEntryType = @FlarePitEntryType,            
 ConfinedSpaceCardNumber = @ConfinedSpaceCardNumber,            
 ConfinedSpaceClass = @ConfinedSpaceClass,            
 RescuePlanFormNumber = @RescuePlanFormNumber,            
 VehicleEntryTotal = @VehicleEntryTotal,            
 VehicleEntryType = @VehicleEntryType,            
 SpecialWorkFormNumber = @SpecialWorkFormNumber,            
 SpecialWorkType = @SpecialWorkType,            
 FormGN59Id = @FormGN59Id,            
 FormGN7Id = @FormGN7Id,            
 FormGN24Id = @FormGN24Id,            
 FormGN75AId = @FormGN75AId,            
 FormGN1Id = @FormGN1Id,            
 FormGN1TradeChecklistId = @FormGN1TradeChecklistId,            
 FormGN1TradeChecklistDisplayNumber = @FormGN1TradeChecklistDisplayNumber,             
 FormGN6Id = @FormGN6Id,            
 GN59 = @GN59,            
 GN7 = @GN7,            
 GN24 = @GN24,            
 GN75A = @GN75A,            
 GN1 = @GN1,            
 GN6 = @GN6,            
 GN11 = @GN11,            
 GN24_Deprecated = @GN24_Deprecated,            
 GN6_Deprecated = @GN6_Deprecated,            
 GN27 = @GN27,            
 GN75_Deprecated = @GN75_Deprecated,            
 AlkylationEntry = @AlkylationEntry,            
 FlarePitEntry = @FlarePitEntry,            
 ConfinedSpace = @ConfinedSpace,            
 RescuePlan = @RescuePlan,            
 VehicleEntry = @VehicleEntry,            
 SpecialWork = @SpecialWork,               
 RequestedStartDate = @RequestedStartDate,            
 RequestedStartTimeDay = @RequestedStartTimeDay,            
 RequestedStartTimeNight = @RequestedStartTimeNight,            
 HazardsAndOrRequirements = @HazardsAndOrRequirements,            
 OtherAreasAndOrUnitsAffectedArea = @OtherAreasAndOrUnitsAffectedArea,            
 OtherAreasAndOrUnitsAffectedPersonNotified = @OtherAreasAndOrUnitsAffectedPersonNotified,            
 WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = @WorkersMinimumSafetyRequirementsSectionNotApplicableToJob,            
 FaceShield = @FaceShield,            
 Goggles = @Goggles,            
 RubberBoots = @RubberBoots,            
 RubberGloves = @RubberGloves,            
 RubberSuit = @RubberSuit,            
 SafetyHarnessLifeline = @SafetyHarnessLifeline,            
 HighVoltagePPE = @HighVoltagePPE,             
 Other1 = @Other1,            
 EquipmentGrounded = @EquipmentGrounded,            
 FireBlanket = @FireBlanket,            
 FireExtinguisher = @FireExtinguisher,            
 FireMonitorManned = @FireMonitorManned,            
 FireWatch = @FireWatch,            
 SewersDrainsCovered = @SewersDrainsCovered,            
 SteamHose = @SteamHose,             
 Other2 = @Other2,            
 AirPurifyingRespirator = @AirPurifyingRespirator,            
 BreathingAirApparatus = @BreathingAirApparatus,            
 DustMask = @DustMask,            
 LifeSupportSystem = @LifeSupportSystem,            
 SafetyWatch = @SafetyWatch,            
 ContinuousGasMonitor = @ContinuousGasMonitor,             
 WorkersMonitor = @WorkersMonitor,            
 WorkersMonitorNumber = @WorkersMonitorNumber,            
 BumpTestMonitorPriorToUse = @BumpTestMonitorPriorToUse,             
 Other3 = @Other3,            
 AirMover = @AirMover,            
 BarriersSigns = @BarriersSigns,             
 RadioChannel = @RadioChannel,            
RadioChannelNumber = @RadioChannelNumber,            
 AirHorn = @AirHorn,            
 MechVentilationComfortOnly = @MechVentilationComfortOnly,            
 AsbestosMMCPrecautions = @AsbestosMMCPrecautions,             
 Other4 = @Other4,            
 RoadAccessOnPermit1 = @RoadAccessOnPermit ,              
 RoadAccessOnPermitFormNumber1 = @RoadAccessOnPermitFormNumber,              
 RoadAccessOnPermitType1 = @RoadAccessOnPermitType             
WHERE Id = @Id      
GO


GRANT EXEC ON [UpdatePermitRequestEdmonton] TO PUBLIC
GO
