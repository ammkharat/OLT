
SET IDENTITY_INSERT TrainingBlock ON;

insert into TrainingBlock (Id, Name, Code, Deleted)
values (1, 'Tie shoelaces', 'TIESHOES', 0)

declare @TrainingBlockId as bigint;
set @TrainingBlockId = scope_identity();

declare @FunctionalLocationId as bigint;
select @FunctionalLocationId = Id from FunctionalLocation where FullHierarchy = 'UP2-P057';

insert into TrainingBlockFunctionalLocation (TrainingBlockId, FunctionalLocationId)
values (@TrainingBlockId, @FunctionalLocationId)

-------------

insert into TrainingBlock (Id, Name, Code, Deleted)
values (2, 'Run computer', 'RUNCOMPY', 0)

set @TrainingBlockId = scope_identity();

select @FunctionalLocationId = Id from FunctionalLocation where FullHierarchy = 'UP2-P057';

insert into TrainingBlockFunctionalLocation (TrainingBlockId, FunctionalLocationId)
values (@TrainingBlockId, @FunctionalLocationId)

SET IDENTITY_INSERT TrainingBlock OFF;



