sp_rename 'PermitRequestEdmontonRawImportData', 'PermitRequestEdmontonSAPImportData';

GO

alter table PermitRequestEdmontonSAPImportData drop constraint FK_PermitRequestEdmontonRawImportData_LastImportedByUser;
alter table PermitRequestEdmontonSAPImportData drop column LastImportedByUserId;

alter table PermitRequestEdmontonSAPImportData drop column LastImportedDateTime;
alter table PermitRequestEdmontonSAPImportData drop column LastSubmittedDateTime;
alter table PermitRequestEdmontonSAPImportData drop column CreatedDateTime;

alter table PermitRequestEdmontonSAPImportData drop constraint FK_PermitRequestEdmontonRawImportData_CreatedByUser;
alter table PermitRequestEdmontonSAPImportData drop column CreatedByUserId;

alter table PermitRequestEdmontonSAPImportData drop constraint FK_PermitRequestEdmontonRawImportData_LastModifiedByUser;
alter table PermitRequestEdmontonSAPImportData drop column LastModifiedByUserId;
alter table PermitRequestEdmontonSAPImportData drop column LastModifiedDateTime;

alter table PermitRequestEdmontonSAPImportData drop column IsModified;

alter table PermitRequestEdmontonSAPImportData drop column RequestedStartTimeDay;
alter table PermitRequestEdmontonSAPImportData drop column RequestedStartTimeNight;

alter table PermitRequestEdmontonSAPImportData drop column Deleted;
alter table PermitRequestEdmontonSAPImportData drop column IssuedToSuncor;




--	@IsModified bit,
--	@IsComplete bit,

--	LastImportedByUserId,
--	LastImportedDateTime,
--	LastSubmittedByUserId,
--	LastSubmittedDateTime,
--	CreatedByUserId,
--	CreatedDateTime,
--	LastModifiedByUserId,
--	LastModifiedDateTime,





GO

