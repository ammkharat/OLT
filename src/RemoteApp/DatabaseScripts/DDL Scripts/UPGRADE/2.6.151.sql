-----------------------
--- Add Descriptions to Additional Forms options on Work Permits
-----------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'AdditionalCSEAssessmentOrAuthorizationDescription')
BEGIN
ALTER TABLE [dbo].[WorkPermit]
	ADD 
		AdditionalCSEAssessmentOrAuthorizationDescription VARCHAR(50) NULL,
		AdditionalBurnOrOpenFlameAssessmentDescription VARCHAR(50) NULL,
		AdditionalElectricalDescription VARCHAR(50) NULL,
		AdditionalAsbestosHandlingDescription VARCHAR(50) NULL,
		AdditionalCriticalLiftDescription VARCHAR(50) NULL,
		AdditionalWaiverOrDeviationDescription VARCHAR(50) NULL,
		AdditionalExcavationDescription VARCHAR(50) NULL
		
ALTER TABLE [dbo].[WorkPermitHistory]
	ADD
		AdditionalCSEAssessmentOrAuthorizationDescription VARCHAR(50) NULL,
		AdditionalBurnOrOpenFlameAssessmentDescription VARCHAR(50) NULL,
		AdditionalElectricalDescription VARCHAR(50) NULL,
		AdditionalAsbestosHandlingDescription VARCHAR(50) NULL,
		AdditionalCriticalLiftDescription VARCHAR(50) NULL,
		AdditionalWaiverOrDeviationDescription VARCHAR(50) NULL,
		AdditionalExcavationDescription VARCHAR(50) NULL
END		



GO
