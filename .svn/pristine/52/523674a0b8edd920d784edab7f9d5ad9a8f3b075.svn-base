SET IDENTITY_INSERT QuestionnaireConfiguration ON
INSERT INTO QuestionnaireConfiguration([Id],[SiteId],[Type],[Name],[Version],[Deleted])VALUES
           (1001,3,'SafeWorkPermitAssessment','Hot Safe Work Permit Assessment',1,0)
SET IDENTITY_INSERT QuestionnaireConfiguration OFF
GO

SET IDENTITY_INSERT QuestionnaireSection ON
INSERT INTO QuestionnaireSection([Id],[QuestionnaireConfigurationId],[DisplayOrder],[PercentageWeighting],[Name])VALUES
           (2001,1001,1,25,'PTW: Job Coordinator')
SET IDENTITY_INSERT QuestionnaireSection OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3001,2001,1001,1,5,'Is location of work clearly identified?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3002,2001,1001,2,10,'Is there a clear description of the intended scope and Job completion time?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3003,2001,1001,3,10,'Have the appropriate work authorizations been gathered?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSection ON
INSERT INTO QuestionnaireSection([Id],[QuestionnaireConfigurationId],[DisplayOrder],[PercentageWeighting],[Name])VALUES
           (2002,1001,2,25,'PTW: Receiver')
SET IDENTITY_INSERT QuestionnaireSection OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3004,2002,1001,1,10,'Are safety precautions adequately identified?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
           
GO
SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3005,2002,1001,2,10,'Are control measures adequate to allow for the safe execution of work?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF

GO
SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3006,2002,1001,3,5,'Has the crew implemented the controls specified on the Permit and FLRA?')

SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSection ON
INSERT INTO QuestionnaireSection([Id],[QuestionnaireConfigurationId],[DisplayOrder],[PercentageWeighting],[Name])VALUES
           (2003,1001,3,25,'PTW: Issuer')
SET IDENTITY_INSERT QuestionnaireSection OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3007,2003,1001,1,10,'Was the standard for controlling hazardous engery applied or followed?')

SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3008,2003,1001,2,10,'Was the HEI checklist and lock box identified on the Permit?')

SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3009,2003,1001,3,5,'Has the permit been signed onto by the appropriate poeople?(Issuer/Area Authority and Receiver)')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSection ON
INSERT INTO QuestionnaireSection([Id],[QuestionnaireConfigurationId],[DisplayOrder],[PercentageWeighting],[Name])VALUES
           (2004,1001,4,25,'PTW: Area Authority')
SET IDENTITY_INSERT QuestionnaireSection OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3010,2004,1001,1,5,'Has the permit correctly identified the need for continuous or frequency of monitoring?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3011,2004,1001,2,5,'Was there a need for gas testing and if so, was it completed and documented on hour before or at time of issuance?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3012,2004,1001,3,5,'Did the tester sign the permit?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO

SET IDENTITY_INSERT QuestionnaireSectionQuestion ON
INSERT INTO QuestionnaireSectionQuestion([Id],[QuestionnaireSectionId],[QuestionnaireConfigurationId],[DisplayOrder],[Weight],[QuestionText])VALUES
           (3013,2004,1001,4,10,'Did the Area Authority do a site visit for the Hot Work Permit as per RGP0007A?')
SET IDENTITY_INSERT QuestionnaireSectionQuestion OFF
GO



GO

