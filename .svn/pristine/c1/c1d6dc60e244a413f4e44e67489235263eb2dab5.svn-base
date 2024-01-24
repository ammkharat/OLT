alter table WorkAssignment add UseForWorkPermitAutoAssignment bit null;

GO

update WorkAssignment set UseForWorkPermitAutoAssignment = 0;

GO

alter table WorkAssignment alter column UseForWorkPermitAutoAssignment bit not null;

GO

GO
