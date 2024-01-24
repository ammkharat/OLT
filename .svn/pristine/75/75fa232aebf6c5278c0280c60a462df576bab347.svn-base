

alter table FormOilsandsTraining add WorkAssignmentId bigint null;
go

ALTER TABLE [dbo].[FormOilsandsTraining]  WITH CHECK ADD  CONSTRAINT [FK_FormOilsandsTraining_WorkAssignment] FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO

ALTER TABLE [dbo].[FormOilsandsTraining] CHECK CONSTRAINT [FK_FormOilsandsTraining_WorkAssignment]
GO

------------------------------

alter table FormOilsandsTraining add EarliestTrainingDate datetime not null;
alter table FormOilsandsTraining add LatestTrainingDate datetime not null;
go





GO

