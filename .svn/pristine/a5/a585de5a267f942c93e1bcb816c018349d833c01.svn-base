-- Create new RoleElement "Delete Form - Document Suggestion"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (279, 'Delete Form - Document Suggestion', 'Forms')
GO

-- Assign role elements to all WoodBuffalo region sites. Sites include: Firebag (SiteId: 5), MacKay (SiteId: 7), Oilsands (SiteId: 3), Pipelines (SELC) (SiteId: 13), Site Wide Services (SiteId: 6), Voyageur (a.k.a. East Tank Farm) (SiteId: 11), Wood Buffalo Labs (SiteId: 12)

-- Assign Delete Form - Document Suggestion to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  279, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Reset Oilsands role elements for Delete Form
DELETE FROM RoleElementTemplate 
WHERE 
	RoleElementId = 198 and RoleId in 
(
  select r.Id 
  from RoleElementTemplate rt 
  join RoleElement re on re.Id = rt.RoleElementId
  join Role r on r.Id = rt.RoleId
  where
  re.Id = 198 and r.SiteId = 3
)

-- Assign "Delete Form" to the following Oilsands roles:
-- 'super', 'upgsuper', 'extsuper', 'ulead', 'upgulead', 'extulead', 'upgstud', 'oper', 'upgoper', 'extoper'
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  198, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 AND
  r.Id in 
	(
		select r.Id from Role r where r.SiteId = 3 
		and alias in ('super', 'upgsuper', 'extsuper', 'ulead', 'upgulead', 'extulead', 'upgstud', 'oper', 'upgoper', 'extoper')
	)
GO




GO

