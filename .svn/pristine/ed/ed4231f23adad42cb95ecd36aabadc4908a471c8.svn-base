
---Script to update/correct Teranova site information in site  table
IF  EXISTS (
select * from Site where Id =19
)
Begin
UPDATE site
SET Name='Terra Nova'
,TimeZone='Newfoundland Standard Time'
WHERE ID=19
END