CREATE TABLE [dbo].[BusinessCategoryFLOCAssociation](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,		
	[BusinessCategoryId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,	
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL	
		
	CONSTRAINT [PK_BusinessCategoryFLOCAssociation] PRIMARY KEY ([Id] ASC)	
)

GO

ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]
ADD CONSTRAINT [FK_BusinessCategoryFLOCAssociation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]
ADD CONSTRAINT [FK_BusinessCategoryFLOCAssociation_BusinessCategory] 
FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])

GO

ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation]
ADD CONSTRAINT [FK_BusinessCategoryFLOCAssociation_LastModifiedUser] 
FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])

GO

ALTER TABLE [dbo].[BusinessCategoryFLOCAssociation] ADD CONSTRAINT [BusinessCategoryFLOCAssociation_UniqueAssociation] UNIQUE NONCLUSTERED 
(
	[FunctionalLocationId] ASC,
	[BusinessCategoryId] ASC
)

GO

SET IDENTITY_INSERT BusinessCategory ON

-- {ts '2010-06-10 10:15:00'}

-- Unit Guideline / Process, Proc
insert into BusinessCategory (id, [Name], ShortName, [IsHSchedDefault], [IsSAPWorkOrderDefault], [IsSAPNotificationDefault], [IsSAPProductMovementDefault], LastModifiedUserId, LastModifiedDateTime, CreatedDateTime, deleted)
values (1, 'Unit Guideline / Process', 'Proc', 0, 0, 0, 0, -1, GetDate(), GetDate(), 0)

-- Environmental / Safety, Env
insert into BusinessCategory (id, [Name], ShortName, [IsHSchedDefault], [IsSAPWorkOrderDefault], [IsSAPNotificationDefault], [IsSAPProductMovementDefault], LastModifiedUserId, LastModifiedDateTime, CreatedDateTime, deleted)
values (2, 'Environmental / Safety', 'Env', 0, 0, 1, 0, -1, GetDate(), GetDate(), 0)

-- Production, Prod
insert into BusinessCategory (id, [Name], ShortName, [IsHSchedDefault], [IsSAPWorkOrderDefault], [IsSAPNotificationDefault], [IsSAPProductMovementDefault], LastModifiedUserId, LastModifiedDateTime, CreatedDateTime, deleted)
values (3, 'Production', 'Prod', 1, 0, 0, 1, -1, GetDate(), GetDate(), 0)

-- Equipment / Mechanical, Equip
insert into BusinessCategory (id, [Name], ShortName, [IsHSchedDefault], [IsSAPWorkOrderDefault], [IsSAPNotificationDefault], [IsSAPProductMovementDefault], LastModifiedUserId, LastModifiedDateTime, CreatedDateTime, deleted)
values (4, 'Equipment / Mechanical', 'Equip', 0, 1, 0, 0, -1, GetDate(), GetDate(), 0)

-- Routine Activity, Rtn
insert into BusinessCategory (id, [Name], ShortName, [IsHSchedDefault], [IsSAPWorkOrderDefault], [IsSAPNotificationDefault], [IsSAPProductMovementDefault], LastModifiedUserId, LastModifiedDateTime, CreatedDateTime, deleted)
values (5, 'Routine Activity', 'Rtn', 0, 0, 0, 0, -1, GetDate(), GetDate(), 0)

-- Regulatory, Reg
insert into BusinessCategory (id, [Name], ShortName, [IsHSchedDefault], [IsSAPWorkOrderDefault], [IsSAPNotificationDefault], [IsSAPProductMovementDefault], LastModifiedUserId, LastModifiedDateTime, CreatedDateTime, deleted)
values (6, 'Regulatory', 'Reg', 0, 0, 0, 0, -1, GetDate(), GetDate(), 0)

SET IDENTITY_INSERT BusinessCategory OFF

GO

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId, FunctionalLocationId, LastModifiedUserId, LastModifiedDateTime)
select bc.Id, floc.Id, -1, GetDate()
from FunctionalLocation floc cross join BusinessCategory bc
where [Level] = 1
and not exists (select * from BusinessCategoryFLOCAssociation where BusinessCategoryId = bc.Id and FunctionalLocationId = floc.Id);

GO

