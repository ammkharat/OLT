ALTER TABLE WorkAssignment ADD UseWorkAssignmentForActionItemHandoverDisplay bit NULL;

GO

UPDATE WorkAssignment SET UseWorkAssignmentForActionItemHandoverDisplay = 1;

GO

ALTER TABLE WorkAssignment ALTER COLUMN UseWorkAssignmentForActionItemHandoverDisplay bit NOT NULL;

GO

update WorkAssignment set UseWorkAssignmentForActionItemHandoverDisplay = 0 where RoleId in (122, 129);








GO

