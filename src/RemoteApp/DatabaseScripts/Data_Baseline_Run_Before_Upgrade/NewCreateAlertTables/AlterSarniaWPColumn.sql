IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'IsControlRoomContactedOrNot'
)
begin
ALTER TABLE WorkPermit ADD IsControlRoomContactedOrNot Bit
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'IsControlRoomContactedOrNot'
)
begin
ALTER TABLE WorkPermitHistory ADD IsControlRoomContactedOrNot Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ClonedFormDetailSarnia'
)
begin
ALTER TABLE WorkPermit ADD ClonedFormDetailSarnia varchar(100)
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ClonedFormDetailDenver'
)
begin
ALTER TABLE WorkPermit ADD ClonedFormDetailDenver varchar(100)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'PreExcavationAuthorization'
)
begin
ALTER TABLE WorkPermitHistory ADD PreExcavationAuthorization Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'PreExcavationAuthorization'
)
begin
ALTER TABLE WorkPermit ADD PreExcavationAuthorization Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'SuspendedWorkPlatform'
)
begin
ALTER TABLE WorkPermitHistory ADD SuspendedWorkPlatform Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'SuspendedWorkPlatform'
)
begin
ALTER TABLE WorkPermit ADD SuspendedWorkPlatform Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'HotTurnoverApproval'
)
begin
ALTER TABLE WorkPermitHistory ADD HotTurnoverApproval Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'HotTurnoverApproval'
)
begin
ALTER TABLE WorkPermit ADD HotTurnoverApproval Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'ConfinedSpaceEntryAuthorizationForm'
)
begin
ALTER TABLE WorkPermitHistory ADD ConfinedSpaceEntryAuthorizationForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ConfinedSpaceEntryAuthorizationForm'
)
begin
ALTER TABLE WorkPermit ADD ConfinedSpaceEntryAuthorizationForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'PreExcavationAuthorizationForm'
)
begin
ALTER TABLE WorkPermitHistory ADD PreExcavationAuthorizationForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'PreExcavationAuthorizationForm'
)
begin
ALTER TABLE WorkPermit ADD PreExcavationAuthorizationForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'SupplementalJobSiteSignInForm'
)
begin
ALTER TABLE WorkPermitHistory ADD SupplementalJobSiteSignInForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'SupplementalJobSiteSignInForm'
)
begin
ALTER TABLE WorkPermit ADD SupplementalJobSiteSignInForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'SystemEntryGasTestLogFrom'
)
begin
ALTER TABLE WorkPermitHistory ADD SystemEntryGasTestLogFrom Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'SystemEntryGasTestLogFrom'
)
begin
ALTER TABLE WorkPermit ADD SystemEntryGasTestLogFrom Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'HeatStressMonitoringForm'
)
begin
ALTER TABLE WorkPermitHistory ADD HeatStressMonitoringForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'HeatStressMonitoringForm'
)
begin
ALTER TABLE WorkPermit ADD HeatStressMonitoringForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'CriticalLiftApprovalForm'
)
begin
ALTER TABLE WorkPermitHistory ADD CriticalLiftApprovalForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'CriticalLiftApprovalForm'
)
begin
ALTER TABLE WorkPermit ADD CriticalLiftApprovalForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'PjsrSecondSection'
)
begin
ALTER TABLE WorkPermitHistory ADD PjsrSecondSection Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'PjsrSecondSection'
)
begin
ALTER TABLE WorkPermit ADD PjsrSecondSection Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'DeviationRequestForm'
)
begin
ALTER TABLE WorkPermitHistory ADD DeviationRequestForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'DeviationRequestForm'
)
begin
ALTER TABLE WorkPermit ADD DeviationRequestForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'RoadClosureform'
)
begin
ALTER TABLE WorkPermitHistory ADD RoadClosureform Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'RoadClosureform'
)
begin
ALTER TABLE WorkPermit ADD RoadClosureform Bit
end
Go
IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'RadiographyApprovalForm'
)
begin
ALTER TABLE WorkPermitHistory ADD RadiographyApprovalForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'RadiographyApprovalForm'
)
begin
ALTER TABLE WorkPermit ADD RadiographyApprovalForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'ConfinedSpaceEntryTrackingLog'
)
begin
ALTER TABLE WorkPermitHistory ADD ConfinedSpaceEntryTrackingLog Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ConfinedSpaceEntryTrackingLog'
)
begin
ALTER TABLE WorkPermit ADD ConfinedSpaceEntryTrackingLog Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'FlareLineChecklists'
)
begin
ALTER TABLE WorkPermitHistory ADD FlareLineChecklists Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'FlareLineChecklists'
)
begin
ALTER TABLE WorkPermit ADD FlareLineChecklists Bit
end
Go
IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'HotTurnoverApprovalForm'
)
begin
ALTER TABLE WorkPermitHistory ADD HotTurnoverApprovalForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'HotTurnoverApprovalForm'
)
begin
ALTER TABLE WorkPermit ADD HotTurnoverApprovalForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'IndustrialHygieneAreaRealTimeSamplingForm'
)
begin
ALTER TABLE WorkPermitHistory ADD IndustrialHygieneAreaRealTimeSamplingForm Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'IndustrialHygieneAreaRealTimeSamplingForm'
)
begin
ALTER TABLE WorkPermit ADD IndustrialHygieneAreaRealTimeSamplingForm Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'CraneSuspendedWorkPlatformChecklist'
)
begin
ALTER TABLE WorkPermitHistory ADD CraneSuspendedWorkPlatformChecklist Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'CraneSuspendedWorkPlatformChecklist'
)
begin
ALTER TABLE WorkPermit ADD CraneSuspendedWorkPlatformChecklist Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'ConfinedSpaceEntryAuthorizationFormSecondSection'
)
begin
ALTER TABLE WorkPermitHistory ADD ConfinedSpaceEntryAuthorizationFormSecondSection Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'ConfinedSpaceEntryAuthorizationFormSecondSection'
)
begin
ALTER TABLE WorkPermit ADD ConfinedSpaceEntryAuthorizationFormSecondSection Bit
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'NASecondSection'
)
begin
ALTER TABLE WorkPermitHistory ADD NASecondSection Bit 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'NASecondSection'
)
begin
ALTER TABLE WorkPermit ADD NASecondSection Bit
end
Go
