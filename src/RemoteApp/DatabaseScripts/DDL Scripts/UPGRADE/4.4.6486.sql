
alter table [dbo].FormGN7Approval drop constraint FK_FormGN7Approval_FormGN7
go

alter table [dbo].FormGN7FunctionalLocation drop constraint FK_FormGN7FunctionalLocation_FormGN7
go

alter table [dbo].FormGN7 drop constraint PK_FormGN7
go

alter table [dbo].FormGN7 drop column Id;
go

alter table [dbo].FormGN7 add Id bigint NULL;
go

update [dbo].FormGN7
set Id = FormNumber
go

alter table [dbo].FormGN7 alter column Id bigint NOT NULL;
go

ALTER TABLE [dbo].FormGN7
ADD CONSTRAINT PK_FormGN7 PRIMARY KEY CLUSTERED ([Id] ASC)
go

ALTER TABLE [dbo].[FormGN7FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7FunctionalLocation_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO

ALTER TABLE [dbo].[FormGN7Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN7Approval_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO

alter table [dbo].FormGN7 drop column FormNumber
go

--------


alter table [dbo].FormGN59Approval drop constraint FK_FormGN59Approval_FormGN59
go

alter table [dbo].FormGN59FunctionalLocation drop constraint FK_FormGN59FunctionalLocation_FormGN59
go

alter table [dbo].FormGN59 drop constraint PK_FormGN59
go

alter table [dbo].FormGN59 drop column Id;
go

alter table [dbo].FormGN59 add Id bigint NULL;
go

update [dbo].FormGN59
set Id = FormNumber
go

alter table [dbo].FormGN59 alter column Id bigint NOT NULL;
go

ALTER TABLE [dbo].FormGN59
ADD CONSTRAINT PK_FormGN59 PRIMARY KEY CLUSTERED ([Id] ASC)
go

ALTER TABLE [dbo].[FormGN59FunctionalLocation]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59FunctionalLocation_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO

ALTER TABLE [dbo].[FormGN59Approval]  WITH CHECK ADD  CONSTRAINT [FK_FormGN59Approval_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO

alter table [dbo].FormGN59 drop column FormNumber
go


-----------------

sp_RENAME 'FormNumberSequence' , 'FormIdSequence';
GO





GO

