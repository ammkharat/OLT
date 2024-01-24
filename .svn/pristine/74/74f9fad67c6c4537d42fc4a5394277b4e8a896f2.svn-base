-- Remove the option WorkAssignment::ShowEventExcursionsOnShiftHandoverReport 
update workassignment set ShowEventExcursionsOnShiftHandoverReport = 0 where roleid in (51,52,53,54,177,213,214,215,216)
go

-- Remove all permissions to "View Navigation - Events", "View Priorities" - "Events, and Respond to Excursion"
delete from RoleElementTemplate
where roleelementid in (264, 265, 266)
go



GO

