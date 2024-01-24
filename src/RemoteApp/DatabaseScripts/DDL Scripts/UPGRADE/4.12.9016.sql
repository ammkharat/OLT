alter table Directive alter column ActiveFromDateTime Date NOT NULL;
alter table Directive alter column ActiveToDateTime Date NOT NULL;

alter table Directive add ActiveFromTime Time NULL;

GO

sp_RENAME 'Directive.ActiveToDateTime' , 'ActiveToDate', 'COLUMN';
GO

sp_RENAME 'Directive.ActiveFromDateTime' , 'ActiveFromDate', 'COLUMN';




GO

