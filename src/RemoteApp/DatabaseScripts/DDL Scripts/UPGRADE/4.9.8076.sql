

insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,'July 15 2013  8:53AM','July 15 2013  8:53AM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,'July 15 2013  8:53AM','July 15 2013  8:53AM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,'July 15 2013  8:53AM','July 15 2013  8:53AM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,'July 15 2013  8:53AM','July 15 2013  8:53AM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,'July 15 2013  8:53AM','July 15 2013  8:53AM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Sampling','Smpl',0,0,-1,'July 15 2013  1:50PM','July 15 2013  1:50PM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Shutdown / Turnaround','TA',0,0,-1,'July 15 2013  1:31PM','July 15 2013  1:31PM',0,6
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1,'July 15 2013  8:53AM','July 15 2013  8:53AM',0,6
go

insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime 
from BusinessCategory bc, FunctionalLocation f 
where f.siteid = 6 and f.FullHierarchy = 'OS1' and bc.SiteId = 6 and bc.Deleted = 0
go




GO

