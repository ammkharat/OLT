-- #1572 - Move Montreal work permit drop down lists to the database

CREATE TABLE [dbo].[WorkPermitMontrealDropdownValue] (
[Id] bigint IDENTITY(100, 1) NOT NULL,
[Key] varchar(100) NOT NULL,
[Value] varchar(100) NOT NULL,
[Deleted] bit NOT NULL
CONSTRAINT [PK_WorkPermitMontrealDropdownValue]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

BEGIN TRANSACTION
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'VO/GA', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Demi jetable N-100', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Demi P-100', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Demi multi gaz', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Demi P-100 + multi gaz', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Complet multi gaz', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Complet P-100', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Complet P-100 + multi gaz', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'GVP P-100', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'GVP P-100 + multi gaz', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'protection_respiratoire', N'Masque pour amiante', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Bottes de caoutchouc', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Couvre-botte en Tyvex', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Couvre-tout en Tyvex', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Gants caoutchouc', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Gants/Bottes caoutchouc', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Gants haute température', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Gants nitrile', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Gants PVC', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Habit anti-arc (40 calories)', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Manchons', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Vêtements anti-corrosif', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'habits', N'Vêtement de pluie', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autre_protection', N'Manchon', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_equipement_dincendie', N'Boyau à vapeur', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_equipement_dincendie', N'Boyau d''incendie', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_equipement_dincendie', N'Hydrant', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'corrosif', N'Acide sulfurique', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'corrosif', N'Acide phosphorique', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'corrosif', N'Benfield', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'corrosif', N'Chlorure ferreux', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'corrosif', N'Soude caustique', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'Benzène', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'Toluène', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'Xylène', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'Orthoxylène', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'BTX', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'Extract', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'aromatique', N'Sulfolane', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Air', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Asphalte', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Catalyseur', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Eau', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Electricité', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Gaz de carneau', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Gaz de carneau+catalyseur', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Huile', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Hydrogène', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Mercaptan', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Soude caustique', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Sulfure de fer', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_substances', N'Vapeur', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_conditions', N'Autre flamme nue', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autres_conditions', N'Travail de meulage', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'surveillant', N'Espace clos', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'surveillant', N'Nacelle', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'surveillant', N'Excavation', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'surveillant', N'Déplacement de véhicule', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'surveillant', N'Excavation et déplacement', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'surveillant', N'Adduct. d''air et déplacement', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'detection_continue_des_gaz', N'3 Gaz', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'detection_continue_des_gaz', N'4 Gaz', 0);

INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autre_securite', N'Cabane anti-étincelle', 0);
INSERT INTO [dbo].[WorkPermitMontrealDropdownValue] ([Key], Value, Deleted) VALUES (N'autre_securite', N'Extraction à la source', 0);

COMMIT TRANSACTION
GO




GO

