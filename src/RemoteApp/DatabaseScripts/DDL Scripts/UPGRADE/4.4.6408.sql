ALTER TABLE WorkPermitEdmonton ALTER COLUMN Location VARCHAR(35);

ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN ConfinedSpaceCardNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN RescuePlanFormNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN VehicleEntryType VARCHAR(15);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN SpecialWorkFormNumber VARCHAR(10);

ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GN59FormNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GN7FormNumber VARCHAR(10);

ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN ZeroEnergyFormNumber VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN LockBoxNumber VARCHAR(10);

ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine1CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine1Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine1ToxicGas VARCHAR(20);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine2CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine2Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine2ToxicGas VARCHAR(20);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine3CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine3Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine3ToxicGas VARCHAR(20);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine4CombustibleGas VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine4Oxygen VARCHAR(10);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN GasTestDataLine4ToxicGas VARCHAR(20);

ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN Other1 VARCHAR(15);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN Other2 VARCHAR(15);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN Other3 VARCHAR(15);
ALTER TABLE WorkPermitEdmontonDetails ALTER COLUMN Other4 VARCHAR(15);



GO

