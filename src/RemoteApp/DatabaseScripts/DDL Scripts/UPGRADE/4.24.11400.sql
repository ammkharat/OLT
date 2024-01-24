--// [WorkPermitEdmontonDetails]//----

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine1CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine1CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine1Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine1Oxygen	varchar(10)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine1ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine1ToxicGas	varchar(30)	
end

--

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine2CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine2CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine2Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine2Oxygen	varchar(10)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine2ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine2ToxicGas	varchar(30)	
end

--

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine3CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine3CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine3Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine3Oxygen	varchar(10)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine3ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine3ToxicGas	varchar(30)	
end
--

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine4CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine4CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine4Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine4Oxygen	varchar(10)	
end


IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'GasTestDataLine4ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonDetails] ALTER Column GasTestDataLine4ToxicGas	varchar(30)	
end

---
--// [WorkPermitEdmontonHistory]//----


IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine1CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine1CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine1Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine1Oxygen	varchar(10)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine1ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine1ToxicGas	varchar(30)	
end
--

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine2CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine2CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine2Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine2Oxygen	varchar(10)	
end


IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine2ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine2ToxicGas	varchar(30)	
end

--

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine3CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine3CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine3Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine3Oxygen	varchar(10)	
end


IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine3ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine3ToxicGas	varchar(30)	
end
--

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine4CombustibleGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine4CombustibleGas	varchar(30)	
end

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine4Oxygen'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine4Oxygen	varchar(10)	
end


IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'GasTestDataLine4ToxicGas'
)
begin
alter table [dbo].[WorkPermitEdmontonHistory] ALTER Column GasTestDataLine4ToxicGas	varchar(30)	
end

---
---









GO

