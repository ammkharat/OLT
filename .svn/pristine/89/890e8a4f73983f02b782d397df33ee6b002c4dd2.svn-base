alter table WorkPermitEdmonton add HasBeenIssued bit null;
GO

update WorkPermitEdmonton set HasBeenIssued = 0;
GO

update WorkPermitEdmonton set HasBeenIssued = 1 where WorkPermitStatusId = 3;
GO

alter table WorkPermitEdmonton alter column HasBeenIssued bit not null;




GO

