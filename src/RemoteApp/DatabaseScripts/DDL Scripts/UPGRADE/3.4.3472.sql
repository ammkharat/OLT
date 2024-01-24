select *
from siteconfiguration

update siteconfiguration
set HideDORCommentEntry = 1
where siteid in (1, 2, 5, 6, 7);

go
GO
