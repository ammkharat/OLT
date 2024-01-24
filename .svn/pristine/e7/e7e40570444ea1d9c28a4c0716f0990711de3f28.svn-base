alter table ActionItemDefinition drop constraint FK_ActionItemDefinition_Status;
drop table ActionItemDefinitionStatus;

alter table ActionItem drop constraint FK_ActionItem_ActionItemStatus;
alter table ActionItem drop constraint fk_ActionItem_PreviousActionItemStatus;
drop table ActionItemStatus;

alter table FunctionalLocationOperationalMode drop constraint FK_FunctionalLocationOperationalMode_AvailabilityReason;
alter table FunctionalLocationOperationalModeHistory drop constraint FK_FunctionalLocationOperationalModeHistory_AvailabilityReason;
drop table AvailabilityReason;

drop table HSched;

alter table FunctionalLocationOperationalMode drop constraint FK_FunctionalLocationOperationalMode_OperationalMode;
alter table FunctionalLocationOperationalModeHistory drop constraint FK_FunctionalLocationOperationalModeHistory_OperationalMode;
drop table OperationalMode;

alter table ActionItem drop constraint FK_ActionItem_Priority;
alter table TargetAlert drop constraint FK_TargetAlert_Priority;
drop table Priority;

drop table ProtectiveClothingTypeAcidClothingType;

alter table RestrictionDefinition drop constraint FK_RestrictionDefinition_RestrictionDefinitionStatus;
drop table RestrictionDefinitionStatus;

alter table ActionItem drop constraint FK_ActionItem_ScheduleType;
alter table Schedule drop constraint FK_Schedule_ScheduleType;
alter table TargetAlert drop constraint FK_TargetAlert_ScheduleType;
drop table ScheduleType;

drop table TagDirection;

alter table TargetAlert drop constraint FK_TargetAlert_TargetAlertStatus;
drop table TargetAlertStatus;

alter table TargetDefinition drop constraint FK_TargetDefinition_TargetCategoryId;
alter table TargetAlert drop constraint FK_TargetAlert_TargetCategoryId;
drop table TargetCategory;

alter table TargetDefinition drop constraint FK_TargetDefinition_TargetDefinitionStatus;
drop table TargetDefinitionStatus;

alter table TargetAlertResponse drop constraint FK_TargetAlertResponse_TargetGapReason;
drop table TargetGapReason;

alter table TargetAlert drop constraint FK_TargetAlert_TargetMode;
alter table TargetDefinition drop constraint FK_TargetDefinition_TargetMode;
alter table TargetAlert drop column TargetModeId;
alter table TargetDefinition drop column TargetModeId;
drop table TargetMode;

alter table TargetAlert drop constraint FK_TargetAlert_TargetValueType;
alter table TargetDefinition drop constraint FK_TargetDefinition_TargetValueType;
drop table TargetValueType;

alter table WorkPermit drop constraint FK_WorkPermit_WorkPermitStatusId;
drop table WorkPermitStatus;

alter table WorkPermit drop constraint FK_WorkPermit_WorkPermitTypeId;
drop table WorkPermitType;

alter table WorkPermit drop constraint FK_WorkPermit_WorkPermitTypeClassificationId;
drop table WorkPermitTypeClassification;





GO
