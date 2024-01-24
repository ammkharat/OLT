IF EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'JobSitePreparationDocumentationSignageNotApplicable')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	DROP CONSTRAINT
		[DF_WorkPermit_JobSitePreparationDocumentationSignageNotApplicable],
		[DF_WorkPermit_JobSitePreparationDocumentationSignageBlankOrBlindList],
		[DF_WorkPermit_JobSitePreparationDocumentationSignageCSEPermit],
		[DF_WorkPermit_JobSitePreparationDocumentationSignageVesselPreparedForOpening],
		[DF_WorkPermit_JobSitePreparationDocumentationSignageRestrictedEntry]

ALTER TABLE [dbo].[WorkPermit] 
	DROP COLUMN
		[JobSitePreparationDocumentationSignageNotApplicable],
		[JobSitePreparationDocumentationSignageBlankOrBlindList],
		[JobSitePreparationDocumentationSignageCSEPermit],
		[JobSitePreparationDocumentationSignageVesselPreparedForOpening],
		[JobSitePreparationDocumentationSignageRestrictedEntry],
		[JobSitePreparationDocumentationSignageOtherDescription]
		

ALTER TABLE [dbo].[WorkPermitHistory]
	DROP CONSTRAINT
		[DF_WorkPermitHistory_JobSitePreparationDocumentationSignageNotApplicable],
		[DF_WorkPermitHistory_JobSitePreparationDocumentationSignageBlankOrBlindList],
		[DF_WorkPermitHistory_JobSitePreparationDocumentationSignageCSEPermit],
		[DF_WorkPermitHistory_JobSitePreparationDocumentationSignageVesselPreparedForOpening],
		[DF_WorkPermitHistory_JobSitePreparationDocumentationSignageRestrictedEntry]

ALTER TABLE [dbo].[WorkPermitHistory] 
	DROP COLUMN
		[JobSitePreparationDocumentationSignageNotApplicable],
		[JobSitePreparationDocumentationSignageBlankOrBlindList],
		[JobSitePreparationDocumentationSignageCSEPermit],
		[JobSitePreparationDocumentationSignageVesselPreparedForOpening],
		[JobSitePreparationDocumentationSignageRestrictedEntry],
		[JobSitePreparationDocumentationSignageOtherDescription]
END
GO
