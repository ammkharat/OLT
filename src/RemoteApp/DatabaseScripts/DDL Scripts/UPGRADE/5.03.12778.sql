If  EXISTS(SELECT * FROM RoleElement WHERE Name='Approved CSD(SELC)' and FunctionalArea='Forms')
BEGIN
Update RoleElement
Set
Name='Approved CSD(SELC & SARNIA)'
WHERE Name='Approved CSD(SELC)' and FunctionalArea='Forms'
END




GO

