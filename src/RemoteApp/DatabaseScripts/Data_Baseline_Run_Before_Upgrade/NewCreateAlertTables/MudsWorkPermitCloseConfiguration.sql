
IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 4 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 4, 0)
End

IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 5 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 5, 0)
End


IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 6 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 6, 0)
End


IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 7 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 7, 0)
End


IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 8 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 8, 0)
End


IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 9 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 9, 0)
End


IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 11 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 11, 0)
End


IF not EXISTS (select * from WorkPermitCloseConfiguration where  StatusId = 12 and SiteId = 16)
Begin
Insert into WorkPermitCloseConfiguration (SiteId, StatusId,RequiresLog) VALUES (16, 12, 0)
End
