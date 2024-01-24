UPDATE UserPrintPreference set NumberOfCopies = 2 where UserId in
(
	select ulh.UserId from UserLoginHistory ulh 
	inner join Shift s on ulh.ShiftId = s.Id
	where s.SiteId = 8
);


GO

