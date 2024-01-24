update dbo.SiteConfiguration SET
  DefaultNumberOfCopiesForWorkPermits = 1
Where SiteId = 1


UPDATE UserPrintPreference
SET NumberOfCopies = 1
WHERE UserId IN
(
SELECT DISTINCT upp.UserId
FROM UserPrintPreference upp
INNER JOIN dbo.[User] u ON upp.UserId = u.Id 
INNER JOIN dbo.UserLoginHistory ulh ON ulh.UserId = upp.UserId 
INNER JOIN dbo.UserLoginHistoryFunctionalLocation ulhfl ON ulh.Id = ulhfl.UserLoginHistoryId 
INNER JOIN dbo.FunctionalLocation fl ON ulhfl.FunctionalLocationId = fl.Id 
WHERE fl.SiteId = 1 
AND upp.NumberOfCopies != 1
)


GO

