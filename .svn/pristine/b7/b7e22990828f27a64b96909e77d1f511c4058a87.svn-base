
--RITM0195885- to rename " Deviation form" to "Letter of Exception" 

If Exists (Select Name from GenericTemplateEFormHeader Where FormTypeID = 1002 and SiteID = 8)
Begin
	Update GenericTemplateEFormHeader
	Set Name = 'Letter of Exception'
	Where FormTypeID = 1002 and SiteID = 8
End

If Exists (Select Name from RoleElement Where Id = 303 and Name = 'View Deviation')
Begin
	Update RoleElement Set Name = 'View Letter of Exception' Where Id = 303	
End

If Exists (Select Name from RoleElement Where Id = 304 and Name = 'Approve/Close Deviation')
Begin
	Update RoleElement Set Name = 'Approve/Close Letter of Exception' Where Id = 304	
End

If Exists (Select Name from RoleElement Where Id = 305 and Name = 'Create Deviation')
Begin
	Update RoleElement Set Name = 'Create Letter of Exception' Where Id = 305	
End

If Exists (Select Name from RoleElement Where Id = 306 and Name = 'Edit Deviation')
Begin
	Update RoleElement Set Name = 'Edit Letter of Exception' Where Id = 306	
End

If Exists (Select Name from RoleElement Where Id = 307 and Name = 'Delete Deviation')
Begin
	Update RoleElement Set Name = 'Delete Letter of Exception' Where Id = 307
End

--------------------------------------------------------------------------------------------------------

-- RITM0195190 - Re-title "Hazard Assessment" form to HO68 Plant 12 Minor HF Leak

If Exists (Select Name from GenericTemplateEFormHeader Where FormTypeID = 1006 and SiteID = 8)
Begin
	Update GenericTemplateEFormHeader
	Set Name = 'HO68 Plant 12 Minor HF Leak'
	Where FormTypeID = 1006 and SiteID = 8
End



If Exists (Select Name from RoleElement Where Id = 323 and Name = 'View Hazard assessment')
Begin
	Update RoleElement Set Name = 'View HO68 Plant 12 Minor HF Leak' Where Id = 323	
End

If Exists (Select Name from RoleElement Where Id = 324 and Name = 'Approve/Close Hazard assessment')
Begin
	Update RoleElement Set Name = 'Approve/Close HO68 Plant 12 Minor HF Leak' Where Id = 324	
End

If Exists (Select Name from RoleElement Where Id = 325 and Name = 'Create Hazard assessment')
Begin
	Update RoleElement Set Name = 'Create HO68 Plant 12 Minor HF Leak' Where Id = 325	
End

If Exists (Select Name from RoleElement Where Id = 326 and Name = 'Edit Hazard assessment')
Begin
	Update RoleElement Set Name = 'Edit HO68 Plant 12 Minor HF Leak' Where Id = 326	
End

If Exists (Select Name from RoleElement Where Id = 327 and Name = 'Delete Hazard assessment')
Begin
	Update RoleElement Set Name = 'Delete HO68 Plant 12 Minor HF Leak' Where Id = 327
End


