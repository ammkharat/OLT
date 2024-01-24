if not exists(select 1 from DropdownValue where [key] = 'deviation_response_plant_state' and SiteId = 15)
begin
	insert into DropdownValue values
		('deviation_response_plant_state','Scheduled Maintenance/Shutdown/Turnaround',0,1,15),
		('deviation_response_plant_state','Break-In/Unscheduled Maintenance',0,2,15),
		('deviation_response_plant_state','Production Variant',0,3,15)
 end



GO

