
If Exists (Select Name from Shift Where SiteId = 6 and Name = 'D')
Begin
	Update Shift
	Set StartTime= '06:00:00', EndTime = '18:00:00'
	Where SiteId = 6 And Name = 'D'
End

If Exists (Select Name from Shift Where SiteId = 6 and Name = 'N')
Begin
	Update Shift
	Set StartTime= '18:00:00', EndTime = '06:00:00'
	Where SiteId = 6 And Name = 'N'
End

