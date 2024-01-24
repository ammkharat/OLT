IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ConfinedSpaceMudssign]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[ConfinedSpaceMudssign](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ConfinedSpaceId] [varchar](100) NULL,
	[Verifier_FNAME] [nvarchar](500) NULL,
	[Verifier_LNAME] [nvarchar](500) NULL,
	[Verifier_BADGENUMBER] [nvarchar](100) NULL,
	[Verifier_BADGETYPE] [varchar](100) NULL,
	[Verifier_SOURCE] [varchar](100) NULL,
	[DETENTEUR_FNAME] [nvarchar](500) NULL,
	[DETENTEUR_LNAME] [nvarchar](500) NULL,
	[DETENTEUR_BADGENUMBER] [nvarchar](100) NULL,
	[DETENTEUR_BADGETYPE] [varchar](100) NULL,
	[DETENTEUR_SOURCE] [varchar](100) NULL,
	[EMETTEUR_FNAME] [nvarchar](500) NULL,
	[EMETTEUR_LNAME] [nvarchar](500) NULL,
	[EMETTEUR_BADGENUMBER] [nvarchar](100) NULL,
	[EMETTEUR_BADGETYPE] [varchar](100) NULL,
	[EMETTEUR_SOURCE] [varchar](100) NULL,
	[Deleted] [bit] NULL,
	[UpdatedBy] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[SiteId] [int] NULL,
	[FirstNameFirstResult] [nvarchar](100) NULL,
	[LasttNameFirstResult] [nvarchar](100) NULL,
	[SourceFirstResult] [nvarchar](100) NULL,
	[BadgeFirstResult] [nvarchar](100) NULL,
	[FirstNameSecondResult] [nvarchar](100) NULL,
	[LasttNameSecondResult] [nvarchar](100) NULL,
	[SourceSecondResult] [nvarchar](100) NULL,
	[BadgeSecondResult] [nvarchar](100) NULL,
	[FirstNameThirdResult] [nvarchar](100) NULL,
	[LasttNameThirdResult] [nvarchar](100) NULL,
	[SourceThirdResult] [nvarchar](100) NULL,
	[BadgeThirdResult] [nvarchar](100) NULL,
	[FirstNameFourthResult] [nvarchar](100) NULL,
	[LasttNameFourthResult] [nvarchar](100) NULL,
	[SourceFourthResult] [nvarchar](100) NULL,
	[BadgeFourthResult] [nvarchar](100) NULL
) ON [PRIMARY]
End

