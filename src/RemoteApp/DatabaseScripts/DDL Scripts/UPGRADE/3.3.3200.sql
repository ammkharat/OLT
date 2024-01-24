-- ---------------------------------------------------------------------------------
alter table WorkPermit
add EquipmentIsHazardousEnergyIsolationRequiredNotApplicable bit null;

alter table WorkPermit
add EquipmentIsHazardousEnergyIsolationRequired bit null;

alter table WorkPermit
add EquipmentLockOutMethodId bigint null;

alter table WorkPermit
add EquipmentLockOutMethodComments varchar(600) null;

alter table WorkPermit
add EquipmentEnergyIsolationPlanNumber varchar(100) null;

alter table WorkPermit
add EquipmentConditionsOfEIPSatisfied bit null;

alter table WorkPermit
add EquipmentConditionsOfEIPNotSatisfiedComments varchar(400) null;

alter table WorkPermit
add AsbestosHazardsConsideredNotApplicable bit null;

alter table WorkPermit
add AsbestosHazardsConsidered bit null;

go

update WorkPermit set EquipmentIsHazardousEnergyIsolationRequiredNotApplicable = 1;
go
update WorkPermit set AsbestosHazardsConsideredNotApplicable = 1;
go

go

alter table WorkPermit
alter column EquipmentIsHazardousEnergyIsolationRequiredNotApplicable bit not null;

alter table WorkPermit
alter column AsbestosHazardsConsideredNotApplicable bit not null;

go



-- ---------------------------------------------------------------------------------
alter table WorkPermitHistory
add EquipmentIsHazardousEnergyIsolationRequiredNotApplicable bit null;

alter table WorkPermitHistory
add EquipmentIsHazardousEnergyIsolationRequired bit null;

alter table WorkPermitHistory
add EquipmentLockOutMethodId bigint null;

alter table WorkPermitHistory
add EquipmentLockOutMethodComments varchar(600) null;

alter table WorkPermitHistory
add EquipmentEnergyIsolationPlanNumber varchar(100) null;

alter table WorkPermitHistory
add EquipmentConditionsOfEIPSatisfied bit null;

alter table WorkPermitHistory
add EquipmentConditionsOfEIPNotSatisfiedComments varchar(400) null;

alter table WorkPermitHistory
add AsbestosHazardsConsideredNotApplicable bit null;

alter table WorkPermitHistory
add AsbestosHazardsConsidered bit null;

go
--
--update WorkPermitHistory set EquipmentIsHazardousEnergyIsolationRequiredNotApplicable = 1;
--go
--update WorkPermitHistory set AsbestosHazardsConsideredNotApplicable = 1;
--go
--
--go
--
--alter table WorkPermitHistory
--alter column EquipmentIsHazardousEnergyIsolationRequiredNotApplicable bit not null;
--
--alter table WorkPermitHistory
--alter column AsbestosHazardsConsideredNotApplicable bit not null;

go


GO
