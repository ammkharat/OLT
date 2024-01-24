INSERT INTO DropdownValue (
   [Key]
  ,[Value]
  ,Deleted
  ,DisplayOrder
  ,SiteId
) SELECT 
   'deviation_response_plant_state'
  ,'Shutdown/Turnaround'  
  ,0   AS Deleted                 
  ,1   AS DisplayOrder            
  ,3   AS SiteId                  

INSERT INTO DropdownValue (
   [Key]
  ,[Value]
  ,Deleted
  ,DisplayOrder
  ,SiteId
) SELECT 
   'deviation_response_plant_state'
  ,'Break In Maintenance'  
  ,0   AS Deleted                 
  ,2   AS DisplayOrder            
  ,3   AS SiteId                  

INSERT INTO DropdownValue (
   [Key]
  ,[Value]
  ,Deleted
  ,DisplayOrder
  ,SiteId
) SELECT 
   'deviation_response_plant_state'
  ,'Production Variant'  
  ,0   AS Deleted                 
  ,3   AS DisplayOrder            
  ,3   AS SiteId                  


ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] ADD [RestrictionLocationItemId] bigint NULL
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] ADD [PlantState] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment] 
ADD  CONSTRAINT [FK_DeviationAlert_RestrictionLocationItem]
FOREIGN KEY ([RestrictionLocationItemId])
REFERENCES [dbo].[RestrictionLocationItem] ( [Id] )
GO


GO

