
--- drop old stored procs that are being renamed

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestPermitAttributeAssociation')
BEGIN
	drop procedure [dbo].DeletePermitRequestPermitAttributeAssociation
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequest')
BEGIN
	drop procedure [dbo].InsertPermitRequest
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestHistory')
BEGIN
	drop procedure [dbo].InsertPermitRequestHistory
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestPermitAttributeAssociation')
BEGIN
	drop procedure [dbo].InsertPermitRequestPermitAttributeAssociation
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAttributesByPermitRequestId')
BEGIN
	drop procedure [dbo].QueryPermitAttributesByPermitRequestId
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestById')
BEGIN
	drop procedure [dbo].QueryPermitRequestById
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestByWorkOrderNumberAndOperationAndSource')
BEGIN
	drop procedure [dbo].QueryPermitRequestByWorkOrderNumberAndOperationAndSource
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestDTOsByFlocUnitAndBelow')
BEGIN
	drop procedure [dbo].QueryPermitRequestDTOsByFlocUnitAndBelow
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestHistoriesById')
BEGIN
	drop procedure [dbo].QueryPermitRequestHistoriesById
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLastImportDateTime')
BEGIN
	drop procedure [dbo].QueryPermitRequestLastImportDateTime
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemovePermitRequest')
BEGIN
	drop procedure [dbo].RemovePermitRequest
END

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdatePermitRequest')
BEGIN
	drop procedure [dbo].UpdatePermitRequest
END

go

--- main table

sp_rename 'PermitRequest', 'PermitRequestMontreal'
go

sp_rename 'PK_PermitRequest', 'PK_PermitRequestMontreal'
go

sp_rename 'FK_PermitRequest_FunctionalLocation', 'FK_PermitRequestMontreal_FunctionalLocation'
go
sp_rename 'FK_PermitRequest_CreatedByUser', 'FK_PermitRequestMontreal_CreatedByUser'
go
sp_rename 'FK_PermitRequest_LastModifiedByUser', 'FK_PermitRequestMontreal_LastModifiedByUser'
go

--- history

sp_rename 'PermitRequestHistory', 'PermitRequestMontrealHistory'
go

sp_rename 'PermitRequestMontrealHistory.IDX_PermitRequestHistory', 'PermitRequestMontrealHistory.IDX_PermitRequestMontrealHistory', 'INDEX'
go

--- attribute association

sp_rename 'PermitRequestPermitAttributeAssociation', 'PermitRequestMontrealPermitAttributeAssociation'
go

sp_rename 'PermitRequestMontrealPermitAttributeAssociation.IDX_PermitRequestPermitAttributeAssociation', 'PermitRequestMontrealPermitAttributeAssociation.IDX_PermitRequestMontrealPermitAttributeAssociation', 'INDEX'
go

sp_rename 'FK_PermitRequestPermitAttributeAssociation_PermitRequest', 'FK_PermitRequestMontrealPermitAttributeAssociation_PermitRequestMontreal'
go

sp_rename 'FK_PermitRequestPermitAttributeAssociation_PermitAttribute', 'FK_PermitRequestMontrealPermitAttributeAssociation_PermitAttribute'
go






GO

