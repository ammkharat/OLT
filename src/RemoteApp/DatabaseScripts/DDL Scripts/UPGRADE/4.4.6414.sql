ALTER TABLE dbo.WorkPermitEdmonton ALTER COLUMN Location VARCHAR(50);
ALTER TABLE dbo.WorkPermitEdmontonDetails ALTER COLUMN OperatorGasDetectorNumber VARCHAR(30);


ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN Location VARCHAR(50);
ALTER TABLE dbo.WorkPermitEdmontonHistory ALTER COLUMN OperatorGasDetectorNumber VARCHAR(30);

ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN ConfinedSpaceCardNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN RescuePlanFormNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN VehicleEntryType VARCHAR(15);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN SpecialWorkFormNumber VARCHAR(10);

ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GN59FormNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GN7FormNumber VARCHAR(10);

ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN ZeroEnergyFormNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN LockBoxNumber VARCHAR(10);

ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine1CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine1Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine1ToxicGas VARCHAR(20);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine2CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine2Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine2ToxicGas VARCHAR(20);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine3CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine3Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine3ToxicGas VARCHAR(20);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine4CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine4Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN GasTestDataLine4ToxicGas VARCHAR(20);

ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN Other1 VARCHAR(15);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN Other2 VARCHAR(15);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN Other3 VARCHAR(15);
ALTER TABLE WorkPermitEdmontonHistory ALTER COLUMN Other4 VARCHAR(15);





GO

