
delete from FormOilsandsTrainingHistory;
delete from FormOilsandsTrainingApproval;
delete from FormOilsandsTrainingFunctionalLocation;
delete from FormOilsandsTrainingItem;
delete from FormOilsandsTraining;
go


alter table FormOilsandsTraining add GeneralComments varchar(max) null;
alter table FormOilsandsTraining add TrainingDate date not null;
alter table FormOilsandsTraining add ShiftId bigint not null;
alter table FormOilsandsTraining add TotalHours decimal(8,2) not null;
go

ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_Shift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO

alter table FormOilsandsTraining drop column EarliestTrainingDate;
alter table FormOilsandsTraining drop column LatestTrainingDate;
go

alter table FormOilsandsTrainingItem drop column TrainingDate;
alter table FormOilsandsTrainingItem drop column ShiftPatternId;
go

alter table FormOilsandsTrainingHistory add GeneralComments varchar(max) null;
alter table FormOilsandsTrainingHistory add TrainingDate date not null;
alter table FormOilsandsTrainingHistory add ShiftName varchar(50) not null;
alter table FormOilsandsTrainingHistory add TotalHours decimal(8,2) not null;
go

alter table FormOilsandsTrainingHistory drop column EarliestTrainingDate;
alter table FormOilsandsTrainingHistory drop column LatestTrainingDate;
go




GO

