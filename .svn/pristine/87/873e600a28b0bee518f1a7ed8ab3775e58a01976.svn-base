

alter table WorkPermit 
add SpecialFallOtherDescription varchar(50) null,
SpecialFallRestraint bit null,
SpecialFallSelfRetractingDevice bit null,
SpecialFallTieoffRequired bit null;
go

update WorkPermit set SpecialFallRestraint = 0, SpecialFallSelfRetractingDevice = 0;
go

alter table WorkPermit alter column SpecialFallRestraint bit not null;
alter table WorkPermit alter column SpecialFallSelfRetractingDevice bit not null;
go

------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[WorkPermitHistory_Extension] (
	[Id] [bigint] NOT NULL,
	LastModifiedDate [datetime] NOT NULL,
	SpecialFallOtherDescription varchar(50) null,
	SpecialFallRestraint bit not null,
	SpecialFallSelfRetractingDevice bit not null,
	SpecialFallTieoffRequired bit null
)

go



