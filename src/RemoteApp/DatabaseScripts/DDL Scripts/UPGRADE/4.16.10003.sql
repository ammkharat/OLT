INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'Heavy Oils'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,0 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO

INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'Light Oils'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,1 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO

INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'Syncrude'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,2 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO

INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'Unionfining'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,3 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO

INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'Utilities'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,4 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO

INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'P&S'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,5 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO

INSERT INTO DropdownValue (
  [Key]
  ,Value
  ,Deleted
  ,DisplayOrder
  ,SiteId
) VALUES (
  'edm_form_primary_locations'  -- Key - varchar(100)
  ,'OTC'  -- Value - varchar(100)
  ,0 -- Deleted - bit
  ,6 -- DisplayOrder - int
  ,8 -- SiteId - bigint
)
GO






GO

INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   251   -- Id - bigint
  ,'Configure Form Dropdowns'  -- Name - varchar(60)
  ,'Admin - Forms'  -- FunctionalArea - varchar(100)
)
GO

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  251, r.Id FROM [Role] r
WHERE 
  r.SiteId = 8 and r.[Name] IN ('Administrator')
GO






GO

