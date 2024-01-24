alter table directive drop column ActiveFromTime;
GO

alter table directive alter column ActiveFromDate datetime not null;
GO

sp_RENAME 'Directive.ActiveFromDate' , 'ActiveFromDateTime', 'COLUMN'
GO

-- ---

alter table DirectiveHistory drop column ActiveFromTime;
GO

alter table DirectiveHistory alter column ActiveFromDate datetime not null;
GO

sp_RENAME 'DirectiveHistory.ActiveFromDate' , 'ActiveFromDateTime', 'COLUMN'
GO



GO

