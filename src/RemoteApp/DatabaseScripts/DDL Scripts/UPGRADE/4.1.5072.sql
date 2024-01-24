UPDATE FunctionalLocation set outofservice = 0 where siteid = 5
and fullhierarchy like 'FB1-P105%'

INSERT INTO ShiftFunctionalLocation (ShiftId, FunctionalLocationId)
select s.id, floc.id 
from functionallocation floc
cross join shift s
where s.SiteId = 5
and floc.FullHierarchy = 'FB1-P105' 


GO

