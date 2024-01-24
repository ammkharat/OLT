if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateWorkPermitEdmonton]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateWorkPermitEdmonton]
GO

CREATE  Procedure [dbo].[UpdateWorkPermitEdmonton]                  
(                  
 @Id bigint,                   
 @PermitNumber bigint Output,                  
                  
 @ShouldCreatePermitNumber bit,                  
                      
 @WorkPermitStatusId int,                  
 @PriorityId int,                  
                   
 @WorkPermitTypeId int,                  
 @DurationPermit bit,                  
                   
 @IssuedToSuncor bit,                  
 @IssuedToCompany bit,                  
 @Company varchar(50) = NULL,                  
 @Occupation varchar(50),                  
 @GroupId bigint,                  
 @NumberOfWorkers int = NULL,                  
 @FunctionalLocationId bigint,                  
 @Location varchar(35),                  
 @AreaLabelId bigint,                  
 @IssuedByUserId bigint = NULL,                  
                    
 @RequestedStartDateTime datetime,                  
 @IssuedDateTime datetime = NULL,                  
 @ExpiredDateTime datetime,                  
 @WorkOrderNumber varchar(12) = NULL,                  
 @OperationNumber varchar(max) = NULL,                  
 @SubOperationNumber varchar(max) = NULL,                  
 @TaskDescription varchar(8000) = NULL,                  
 @HazardsAndOrRequirements varchar(2000) = NULL,                     
 @LastModifiedByUserId bigint,                  
 @LastModifiedDateTime datetime,                    
                  
 @UsePreviousPermitAnswered bit,                  
                    
 @AlkylationEntry bit,                  
 @AlkylationEntryClassOfClothing varchar(25) = NULL,                  
 @FlarePitEntry bit,                  
 @FlarePitEntryType varchar(25) = NULL,                  
 @ConfinedSpace bit,                  
 @ConfinedSpaceCardNumber varchar(10) = NULL,                  
 @ConfinedSpaceClass varchar(25) = NULL,                  
 @RescuePlan bit,                  
 @RescuePlanFormNumber varchar(10) = NULL,                  
    @VehicleEntry bit,                   
 @VehicleEntryTotal int = NULL,                  
 @VehicleEntryType varchar(30) = NULL,                   
 @SpecialWork bit,                  
 @SpecialWorkFormNumber varchar(10) = NULL,                  
 @SpecialWorkType int = NULL,                  
 @GN59 bit,                  
 @FormGN59Id bigint = NULL,                   
 @GN7 bit,                  
 @FormGN7Id bigint = NULL,                  
 @GN24 bit,                  
 @FormGN24Id bigint = NULL,                  
 @GN6 int,                  
 @FormGN6Id bigint = NULL,                  
 @GN75A int,                  
 @FormGN75AId bigint = NULL,                  
 @GN27 int,                  
 @GN11 int,                  
 @GN75_Deprecated int,                  
 @GN24_Deprecated int,                  
 @GN6_Deprecated int,                  
                  
 @GN1 bit,                  
 @FormGN1Id bigint = NULL,                  
 @FormGN1TradeChecklistId bigint = NULL,                  
 @FormGN1TradeChecklistDisplayNumber varchar(32) = NULL,                   
                    
 @OtherAreasAndOrUnitsAffected bit,                  
 @OtherAreasAndOrUnitsAffectedArea varchar(50) = NULL,                  
 @OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) = NULL,                  
                   
 @StatusOfPipingEquipmentSectionNotApplicableToJob bit,                  
 @ProductNormallyInPipingEquipment varchar(50) = NULL,                  
 @IsolationValvesLocked bit = NULL,                  
 @DepressuredDrained bit = NULL,                  
 @Ventilated bit = NULL,                  
 @Purged bit = NULL,                  
 @BlindedAndTagged bit = NULL,                  
 @DoubleBlockAndBleed bit = NULL,                  
 @ElectricalLockout bit = NULL,                  
 @MechanicalLockout bit = NULL,                  
 @BlindSchematicAvailable bit = NULL,                  
                   
 @ZeroEnergyFormNumber varchar(10) = NULL,                  
 @LockBoxNumber varchar(10) = NULL,            
 @JobsiteEquipmentInspected bit,                  
 @ConfinedSpaceWorkSectionNotApplicableToJob bit,                   
 @QuestionOneResponse bit,                  
 @QuestionTwoResponse bit = NULL,                  
 @QuestionTwoAResponse bit,                  
 @QuestionTwoBResponse bit,                  
 @QuestionThreeResponse bit,                  
 @QuestionFourResponse bit = NULL,                 
                   
 @GasTestsSectionNotApplicableToJob bit,                  
 @WorkerToProvideGasTestData bit,                  
 @OperatorGasDetectorNumber varchar(50) = NULL,                  
 @GasTestDataLine1CombustibleGas varchar(30) = NULL,                  
 @GasTestDataLine1Oxygen varchar(10) = NULL,                  
 @GasTestDataLine1ToxicGas varchar(30) = NULL,                  
 @GasTestDataLine1Time datetime = NULL,             
 @GasTestDataLine2CombustibleGas varchar(30) = NULL,                  
 @GasTestDataLine2Oxygen varchar(10) = NULL,                  
 @GasTestDataLine2ToxicGas varchar(30) = NULL,                  
 @GasTestDataLine2Time datetime = NULL,         @GasTestDataLine3CombustibleGas varchar(30) = NULL,                  
 @GasTestDataLine3Oxygen varchar(10) = NULL,                  
 @GasTestDataLine3ToxicGas varchar(30) = NULL,                  
 @GasTestDataLine3Time datetime = NULL,                  
 @GasTestDataLine4CombustibleGas varchar(30) = NULL,                  
 @GasTestDataLine4Oxygen varchar(10) = NULL,                  
 @GasTestDataLine4ToxicGas varchar(30) = NULL,                  
 @GasTestDataLine4Time datetime = NULL,                  
 @WorkersMinimumSafetyRequirementsSectionNotApplicableToJob bit,                  
                   
 @FaceShield bit,                  
 @Goggles bit,                  
 @RubberBoots bit,                  
 @RubberGloves bit,                   
 @RubberSuit bit,                  
                   
 @SafetyHarnessLifeline bit,                  
 @HighVoltagePPE bit,                  
 @Other1Checked bit,                  
 @Other1 varchar(15) = NULL,                  
 @EquipmentGrounded bit,                  
                   
 @FireBlanket bit,                  
 @FireExtinguisher bit,                  
 @FireMonitorManned bit,                  
 @FireWatch bit,                  
 @SewersDrainsCovered bit,                  
                   
 @SteamHose bit,                  
 @Other2Checked bit,                  
 @Other2 varchar(15) = NULL,                  
 @AirPurifyingRespirator bit,                  
 @BreathingAirApparatus bit,                  
                   
 @DustMask bit,                  
 @LifeSupportSystem bit,                  
 @SafetyWatch bit,                  
 @ContinuousGasMonitor bit,                  
 @WorkersMonitor bit,                  
 @WorkersMonitorNumber varchar(10) = NULL,                  
                   
 @BumpTestMonitorPriorToUse bit,                  
 @Other3Checked bit,                  
 @Other3 varchar(15) = NULL,                  
 @AirMover bit,                  
 @BarriersSigns bit,                  
                   
 @RadioChannel bit,                  
 @RadioChannelNumber varchar(10) = NULL,                  
 @AirHorn bit,                  
 @MechVentilationComfortOnly bit,                  
 @AsbestosMMCPrecautions bit,                  
 @Other4Checked bit,                  
 @Other4 varchar(15) = NULL,                  
                   
 @PermitAcceptor varchar(30) = NULL,                  
 @ShiftSupervisor varchar(30) = NULL,                   
                   
 @UseCurrentPermitNumberForZeroEnergyFormNumber bit ,            
             
 @RoadAccessOnPermit bit ,              
 @RoadAccessOnPermitFormNumber varchar(10) = NULL,              
 @RoadAccessOnPermitType varchar(50) = NULL,          
           
 @SpecialWorkName VARCHAR(100)                 
)                  
AS                  
          
          
                  
IF @ShouldCreatePermitNumber = 1                  
 BEGIN                  
  EXEC @PermitNumber = GetNewSeqVal_WorkPermitEdmontonPermitNumberSequence                  
 END                  
ELSE                  
 BEGIN                  
  SET @PermitNumber = (select PermitNumber from WorkPermitEdmonton WHERE Id = @Id)                  
 END                  
                   
IF @ShouldCreatePermitNumber = 1 AND @UseCurrentPermitNumberForZeroEnergyFormNumber = 1                  
 BEGIN                  
  SELECT @ZeroEnergyFormNumber = CAST(@PermitNumber as varchar(10))                  
 END                  
                  
UPDATE WorkPermitEdmonton                  
 SET                   
     WorkPermitTypeId = @WorkPermitTypeId,                  
  DurationPermit = @DurationPermit,                  
  PermitNumber = @PermitNumber,                     
  WorkPermitStatusId = @WorkPermitStatusId,                  
  PriorityId = @PriorityId,                  
  IssuedToSuncor = @IssuedToSuncor,                  
  IssuedToCompany = @IssuedToCompany,                  
  Company = @Company,                  
  Occupation = @Occupation,                  
  GroupId = @GroupId,                  
  NumberOfWorkers = @NumberOfWorkers,                  
  FunctionalLocationId = @FunctionalLocationId,                  
  Location = @Location,               
  AreaLabelId = @AreaLabelId,                  
  IssuedByUserId = @IssuedByUserId,                  
  RequestedStartDateTime = @RequestedStartDateTime,                  
  IssuedDateTime = @IssuedDateTime,                  
  ExpiredDateTime = @ExpiredDateTime,                  
  WorkOrderNumber = @WorkOrderNumber,                  
  OperationNumber = @OperationNumber,                  
  SubOperationNumber = @SubOperationNumber,                  
  TaskDescription = @TaskDescription,                  
  HazardsAndOrRequirements = @HazardsAndOrRequirements,                  
  LastModifiedByUserId = @LastModifiedByUserId,                  
  LastModifiedDateTime = @LastModifiedDateTime,                  
  UsePreviousPermitAnswered = @UsePreviousPermitAnswered                  
 WHERE                  
  Id = @Id;                  
          
          
-- Added new  for Special Work    
  
  
If (@SpecialWork = 0)         
Begin  
 Delete from SpecialWork Where WorkPermitID = @Id  
 Set @SpecialWorkName = Null  
End          
  
If Not Exists  (Select CompanyName from SpecialWork Where WorkPermitID = @Id)        
   Begin   
  If @SpecialWorkName IS NULL OR RTRIM(LTRIM(@SpecialWorkName)) = ''  
   Begin  
    SET @SpecialWorkType = Null  
   End  
        Else  
   Begin  
    INSERT INTO SpecialWork Values ( @SpecialWorkName, 8, @Id, Null)             
    SET @SpecialWorkType = SCOPE_IDENTITY()   
   End               
   End        
Else        
 Begin       
 Update  SpecialWork      
 Set CompanyName = @SpecialWorkName      
 Where WorkPermitID = @Id       
        
 Set @SpecialWorkType = (Select ID from SpecialWork Where WorkPermitID = @Id)        
End     
           
-- Till here                 
          
                    
update WorkPermitEdmontonDetails set                  
  AlkylationEntry = @AlkylationEntry,                  
  AlkylationEntryClassOfClothing = @AlkylationEntryClassOfClothing,                  
FlarePitEntry = @FlarePitEntry,                  
  FlarePitEntryType = @FlarePitEntryType,                  
  ConfinedSpace = @ConfinedSpace,                  
  ConfinedSpaceCardNumber = @ConfinedSpaceCardNumber,                  
  ConfinedSpaceClass = @ConfinedSpaceClass,                  
  RescuePlan = @RescuePlan,                  
  RescuePlanFormNumber = @RescuePlanFormNumber,                  
        VehicleEntry = @VehicleEntry,                    
  VehicleEntryTotal = @VehicleEntryTotal,                  
  VehicleEntryType = @VehicleEntryType,                   
  SpecialWork = @SpecialWork,                  
  SpecialWorkFormNumber = @SpecialWorkFormNumber,                  
  SpecialWorkType = @SpecialWorkType,                   
  GN59 = @GN59,                  
  FormGN59Id = @FormGN59Id,                   
  GN7 = @GN7,                  
  FormGN7Id = @FormGN7Id,                  
  GN24 = @GN24,                  
  FormGN24Id = @FormGN24Id,                  
  GN6 = @GN6,                  
  FormGN6Id = @FormGN6Id,                  
  GN75A = @GN75A,                  
  FormGN75AId = @FormGN75AId,                  
  GN27 = @GN27,                  
  GN11 = @GN11,                  
  GN75_Deprecated = @GN75_Deprecated,                  
  GN24_Deprecated = @GN24_Deprecated,                  
  GN6_Deprecated = @GN6_Deprecated,                  
                    
  GN1 = @GN1,                  
  FormGN1Id = @FormGN1Id,                  
  FormGN1TradeChecklistId = @FormGN1TradeChecklistId,                  
  FormGN1TradeChecklistDisplayNumber = @FormGN1TradeChecklistDisplayNumber,           
                    
  OtherAreasAndOrUnitsAffected = @OtherAreasAndOrUnitsAffected,                  
  OtherAreasAndOrUnitsAffectedArea = @OtherAreasAndOrUnitsAffectedArea,                  
  OtherAreasAndOrUnitsAffectedPersonNotified = @OtherAreasAndOrUnitsAffectedPersonNotified,                  
  StatusOfPipingEquipmentSectionNotApplicableToJob = @StatusOfPipingEquipmentSectionNotApplicableToJob,                  
  ProductNormallyInPipingEquipment = @ProductNormallyInPipingEquipment,                  
  IsolationValvesLocked = @IsolationValvesLocked,                  
  DepressuredDrained = @DepressuredDrained,                  
  Ventilated = @Ventilated,                  
  Purged = @Purged,                  
  BlindedAndTagged = @BlindedAndTagged,                  
  DoubleBlockAndBleed = @DoubleBlockAndBleed,                  
  ElectricalLockout = @ElectricalLockout,                  
  MechanicalLockout = @MechanicalLockout,                  
  BlindSchematicAvailable = @BlindSchematicAvailable,                  
  ZeroEnergyFormNumber = @ZeroEnergyFormNumber,                  
  LockBoxNumber = @LockBoxNumber,                  
  JobsiteEquipmentInspected = @JobsiteEquipmentInspected,                  
  ConfinedSpaceWorkSectionNotApplicableToJob = @ConfinedSpaceWorkSectionNotApplicableToJob,                  
  QuestionOneResponse = @QuestionOneResponse,                  
  QuestionTwoResponse = @QuestionTwoResponse,                  
  QuestionTwoAResponse = @QuestionTwoAResponse,                  
  QuestionTwoBResponse = @QuestionTwoBResponse,                  
  QuestionThreeResponse = @QuestionThreeResponse,                  
  QuestionFourResponse = @QuestionFourResponse,                  
  GasTestsSectionNotApplicableToJob = @GasTestsSectionNotApplicableToJob,                  
  WorkerToProvideGasTestData = @WorkerToProvideGasTestData,                  
  OperatorGasDetectorNumber = @OperatorGasDetectorNumber,                  
  GasTestDataLine1CombustibleGas = @GasTestDataLine1CombustibleGas,                  
  GasTestDataLine1Oxygen = @GasTestDataLine1Oxygen,                  
  GasTestDataLine1ToxicGas = @GasTestDataLine1ToxicGas,                  
  GasTestDataLine1Time = @GasTestDataLine1Time,                  
  GasTestDataLine2CombustibleGas = @GasTestDataLine2CombustibleGas,                  
  GasTestDataLine2Oxygen = @GasTestDataLine2Oxygen,                  
  GasTestDataLine2ToxicGas = @GasTestDataLine2ToxicGas,                  
  GasTestDataLine2Time = @GasTestDataLine2Time,                  
  GasTestDataLine3CombustibleGas = @GasTestDataLine3CombustibleGas,                  
  GasTestDataLine3Oxygen = @GasTestDataLine3Oxygen,                  
  GasTestDataLine3ToxicGas = @GasTestDataLine3ToxicGas,                  
  GasTestDataLine3Time = @GasTestDataLine3Time,                  
  GasTestDataLine4CombustibleGas = @GasTestDataLine4CombustibleGas,                  
  GasTestDataLine4Oxygen = @GasTestDataLine4Oxygen,                  
  GasTestDataLine4ToxicGas = @GasTestDataLine4ToxicGas,                  
  GasTestDataLine4Time = @GasTestDataLine4Time,                  
  WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = @WorkersMinimumSafetyRequirementsSectionNotApplicableToJob,                  
  FaceShield = @FaceShield,                  
  Goggles = @Goggles,                  
  RubberBoots = @RubberBoots,                  
  RubberGloves = @RubberGloves,                  
  RubberSuit = @RubberSuit,                  
  SafetyHarnessLifeline = @SafetyHarnessLifeline,                  
  HighVoltagePPE = @HighVoltagePPE,                  
  Other1Checked = @Other1Checked,                  
  Other1 = @Other1,                  
  EquipmentGrounded = @EquipmentGrounded,                  
  FireBlanket = @FireBlanket,                  
  FireExtinguisher = @FireExtinguisher,                  
  FireMonitorManned = @FireMonitorManned,                  
  FireWatch = @FireWatch,                  
  SewersDrainsCovered = @SewersDrainsCovered,                  
  SteamHose = @SteamHose,                  
  Other2Checked = @Other2Checked,        
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
  Other3Checked = @Other3Checked,                  
  Other3 = @Other3,                  
  AirMover = @AirMover,                  
  BarriersSigns = @BarriersSigns,                  
  RadioChannel = @RadioChannel,                  
  RadioChannelNumber = @RadioChannelNumber,                  
  AirHorn = @AirHorn,                  
  MechVentilationComfortOnly = @MechVentilationComfortOnly,                  
  AsbestosMMCPrecautions = @AsbestosMMCPrecautions,                  
  Other4Checked = @Other4Checked,                  
  Other4 = @Other4,                  
  PermitAcceptor = @PermitAcceptor,                  
  ShiftSupervisor = @ShiftSupervisor,                  
  UseCurrentPermitNumberForZeroEnergyFormNumber = @UseCurrentPermitNumberForZeroEnergyFormNumber,            
              
  RoadAccessOnPermit1 = @RoadAccessOnPermit ,              
  RoadAccessOnPermitFormNumber1 = @RoadAccessOnPermitFormNumber,              
  RoadAccessOnPermitType1 = @RoadAccessOnPermitType                  
 WHERE                  
  WorkPermitEdmontonId = @Id; 
GO   
    
    
    
GRANT EXEC ON UpdateWorkPermitEdmonton TO PUBLIC 
GO