                  
 
  
IF OBJECT_ID('InsertPermitRequestFortHillsHistory', 'P') IS NOT NULL
DROP PROC InsertPermitRequestFortHillsHistory
GO               
                    
CREATE Procedure [dbo].InsertPermitRequestFortHillsHistory                                
    (                                
@Id bigint ,                   
@IssuedToSuncor bit,                  
@IssuedToCompany bit,                  
@Company varchar(50) =   NULL,                  
@Occupation varchar(50),                  
@NumberOfWorkers int =  NULL,                  
@GroupId NVARCHAR(50) ,                          
@WorkOrderNumber varchar(25) =  NULL,                  
@WorkPermitTypeId int ,                  
@PriorityId int ,                   
@FunctionalLocation NVARCHAR (200) ,                  
@Location varchar(100) ,                  
@RequestedStartDate datetime ,      
@RequestedEndDate datetime ,                                     
@EquipmentNo  int =  NULL,                  
--@Craft varchar(25) =  NULL,                  
--@CrewSize int =  NULL,                  
@JobCoordinator varchar(25) =  NULL,                  
@CoOrdContactNumber varchar(10) =  NULL,                  
--@EmergencyAssemblyArea varchar(25) =  NULL,                  
--@EmergencyMeetingPoint  varchar(25) =  NULL,                  
--@EmergencyContactNumber  varchar(10) =  NULL,                  
--@Locknumber  varchar(10) =  NULL,     
--@IsolationNumber  varchar(10) =  NULL,    
@LockBoxnumberChecked BIT,                   
@Description varchar(max) =  NULL,                  
@SAPDescription varchar(max) =  NULL,                  
@FlameResistantWorkWear bit,                  
@ChemicalSuit bit,                  
@FireWatch bit,                  
@FireBlanket bit,                  
@SuppliedBreathingAir bit,                  
@AirMover bit,                  
@PersonalFlotationDevice bit,                  
@HearingProtection bit,                  
@Other1 varchar(30) =  NULL,                  
@MonoGoggles bit ,                  
@ConfinedSpaceMoniter bit ,                  
@FireExtinguisher bit ,                  
@SparkContainment bit ,                  
@BottleWatch bit ,                  
@StandbyPerson bit ,                  
@WorkingAlone bit ,                  
@SafetyGloves bit ,                  
@Other2 varchar(30) =  NULL,                  
@FaceShield bit ,                  
@FallProtection bit ,                  
@ChargedFireHouse bit ,          
@CoveredSewer  bit,                
@SingalPerson bit ,           
@AirPurifyingRespirator bit,          
@CommunicationDevice bit ,                  
@ReflectiveStrips bit ,                  
@Other3 varchar(30) =  NULL,                  
@HazardsAndOrRequirements varchar(max) =  NULL,                  
@ConfinedSpace bit ,                  
@ConfinedSpaceClass varchar(25) =  NULL,                  
@GoundDisturbance bit ,                  
@FireProtectionAuthorization bit ,                  
@CriticalOrSeriousLifts bit ,                  
@VehicleEntry bit ,                  
@IndustrialRadiography bit ,                  
@ElectricalEncroachment bit ,                  
@MSDS bit ,                  
@OthersPartE varchar(30) =  NULL,                  
@MechanicallyIsolated bit ,                  
@BlindedOrBlanked bit ,                  
@DoubleBlockedandBled bit ,                  
@DrainedAndDepressurised bit ,                  
@PurgedorNeutralised bit ,                  
@ElectricallyIsolated bit ,                  
@TestBumped bit ,                  
@NuclearSource bit ,                  
@ReceiverStafingRequirements bit ,                  
@SAPWorkCentre varchar(40) =  NULL,                       
@CompletionStatusId int ,                  
@LastImportedByUserId bigint =  NULL,                  
@LastImportedDateTime datetime =  NULL,                  
@LastSubmittedByUserId bigint =  NULL,                  
@LastSubmittedDateTime datetime =  NULL,                         
@LastModifiedByUserId bigint ,                  
@LastModifiedDateTime datetime                             
 )                                
AS                                
                                     
                       
INSERT INTO PermitRequestFortHillsHistory                                
(        
Id,                                
IssuedToSuncor,                    
IssuedToCompany,                   
Company,                  
Occupation,                    
NumberOfWorkers,                  
[Group],                   
WorkOrderNumber,             
WorkPermitType,                  
PriorityId,                  
FunctionalLocation,                  
Location,                   
RequestedStartDate,      
RequestedEndDate,                          
EquipmentNo,                  
--Craft,                  
--CrewSize,                  
JobCoordinator,                  
CoOrdContactNumber,                  
--EmergencyAssemblyArea,                  
--EmergencyMeetingPoint,                  
--EmergencyContactNumber,                  
--Locknumber,                  
--IsolationNumber,      
LockBoxnumberChecked,                
TaskDescription,                  
SAPDescription,                   
FlameResistantWorkWear,                   
ChemicalSuit,                    
FireWatch,                    
FireBlanket,                    
SuppliedBreathingAir,                    
AirMover,                    
PersonalFlotationDevice,                  
HearingProtection,                    
Other1,                  
MonoGoggles,                    
ConfinedSpaceMoniter,                    
FireExtinguisher,                    
SparkContainment,                    
BottleWatch,                    
StandbyPerson,                    
WorkingAlone,                    
SafetyGloves,                    
Other2,                  
FaceShield,                    
FallProtection,                    
ChargedFireHouse,           
CoveredSewer,                   
SingalPerson,          
AirPurifyingRespirator,                   
CommunicationDevice,                    
ReflectiveStrips,                    
Other3,                  
HazardsAndOrRequirements,                  
ConfinedSpace,                  
ConfinedSpaceClass,                  
GoundDisturbance,                  
FireProtectionAuthorization,                    
CriticalOrSeriousLifts,                  
VehicleEntry,                    
IndustrialRadiography,                    
ElectricalEncroachment,                  
MSDS,                    
OthersPartE,                  
MechanicallyIsolated,                    
BlindedOrBlanked,                    
DoubleBlockedandBled,                    
DrainedAndDepressurised,                    
PurgedorNeutralised,                    
ElectricallyIsolated,                    
TestBumped,                    
NuclearSource,                    
ReceiverStafingRequirements,                    
SAPWorkCentre,                        
CompletionStatusId,                   
LastImportedByUserId,                  
LastImportedDateTime,                  
LastSubmittedByUserId,                  
LastSubmittedDateTime,                  
LastModifiedByUserId,                  
LastModifiedDateTime                        
)                                
VALUES                                
(         
@Id,                              
@IssuedToSuncor,                    
@IssuedToCompany ,                   
@Company,                  
@Occupation,                    
@NumberOfWorkers,                  
@GroupId,                   
@WorkOrderNumber,                          
@WorkPermitTypeId,                  
@PriorityId,                  
@FunctionalLocation,                  
@Location,                   
@RequestedStartDate,      
@RequestedEndDate,                                        
@EquipmentNo,                  
--@Craft,                  
--@CrewSize,                  
@JobCoordinator,                  
@CoOrdContactNumber,                  
--@EmergencyAssemblyArea,                  
--@EmergencyMeetingPoint,                  
--@EmergencyContactNumber,                  
--@Locknumber,                  
--@IsolationNumber,      
@LockBoxnumberChecked,                
@Description,                  
@SAPDescription,      
@FlameResistantWorkWear,                   
@ChemicalSuit,                    
@FireWatch,                    
@FireBlanket,                    
@SuppliedBreathingAir,                    
@AirMover,                    
@PersonalFlotationDevice,                  
@HearingProtection,                    
@Other1,                  
@MonoGoggles,                    
@ConfinedSpaceMoniter,                    
@FireExtinguisher,                
@SparkContainment,                    
@BottleWatch,                    
@StandbyPerson,                    
@WorkingAlone,                    
@SafetyGloves,                    
@Other2,                  
@FaceShield,                    
@FallProtection,                    
@ChargedFireHouse,           
@CoveredSewer,                   
@SingalPerson,          
@AirPurifyingRespirator,                    
@CommunicationDevice,                    
@ReflectiveStrips,                    
@Other3,                  
@HazardsAndOrRequirements,                  
@ConfinedSpace,                  
@ConfinedSpaceClass,                  
@GoundDisturbance,                  
@FireProtectionAuthorization,                    
@CriticalOrSeriousLifts,                  
@VehicleEntry,                    
@IndustrialRadiography,                    
@ElectricalEncroachment,                  
@MSDS,                    
@OthersPartE,                  
@MechanicallyIsolated,                    
@BlindedOrBlanked,                    
@DoubleBlockedandBled,                    
@DrainedAndDepressurised,                    
@PurgedorNeutralised,                    
@ElectricallyIsolated,                    
@TestBumped,                    
@NuclearSource,                    
@ReceiverStafingRequirements,                    
@SAPWorkCentre,                          
@CompletionStatusId,                   
@LastImportedByUserId,                  
@LastImportedDateTime,                  
@LastSubmittedByUserId,                  
@LastSubmittedDateTime,                          
@LastModifiedByUserId,                  
@LastModifiedDateTime                           
)                                
SET @Id= SCOPE_IDENTITY()                             
                           
                                
GRANT EXEC ON InsertPermitRequestFortHillsHistory TO PUBLIC   