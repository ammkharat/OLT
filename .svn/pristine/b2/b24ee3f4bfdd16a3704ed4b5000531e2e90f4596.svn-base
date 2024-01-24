
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormWorkPermitMudsId'
)
begin
alter table [dbo].[DocumentLink] Add FormWorkPermitMudsId bigint 
end
Go


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'PermitRequestMudsId'
)
begin
alter table [dbo].[DocumentLink] Add PermitRequestMudsId bigint 
end
Go





GO

IF not EXISTS (select * from PermitAttribute where  Name like N'Cadenassage multiple' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Cadenassage multiple', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Cadenassage simple' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Cadenassage simple', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Espace clos' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Espace clos', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'�chafaud' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, '�chafaud', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'�chelle s�curis�e/Escabeau' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, '�chelle s�curis�e/Escabeau', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Harnais 2 liens de retenue' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Harnais 2 liens de retenue', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Nacelle' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Nacelle', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Excavation' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Excavation', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Levage - Grue' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Levage - Grue', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Unit� SBS' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Unit� SBS', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Travaux �lectrique' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Travaux �lectrique', Null,0)
End


IF not EXISTS (select * from PermitAttribute where  Name like N'Utilisation d�un moteur � combustion interne (v�hicules ou outil)' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Utilisation d�un moteur � combustion interne (v�hicules ou outil)', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Nettoyage au jet de sable mouill� ou au jet d�eau' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Nettoyage au jet de sable mouill� ou au jet d�eau', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Utilisation d�outils �lectriques non intrins�que (batteries/�lectrique)' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Utilisation d�outils �lectriques non intrins�que (batteries/�lectrique)', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Radiographie' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Radiographie', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'TUtilisation d�outils pneumatiques' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Utilisation d�outils pneumatiques', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Utilisation d�un �quipement avec moteur �lectrique non intrins�que' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Utilisation d�un �quipement avec moteur �lectrique non intrins�que', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Soudage & coupage' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Soudage & coupage', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Meulage' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Meulage', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Traitement thermique' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Traitement thermique', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Cuissons de r�fractaires' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Cuissons de r�fractaires', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Per�age ou piquage � vif' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Per�age ou piquage � vif', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Chaufferette avec une flamme nue' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Chaufferette avec une flamme nue', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Nettoyage au jet de sable conventionnel' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Nettoyage au jet de sable conventionnel', Null,0)
End

IF not EXISTS (select * from PermitAttribute where  Name like N'Travaux dans la zone permissive' and SiteId = 16)
Begin
Insert into PermitAttribute (SiteId, Name,SapCode, Deleted) VALUES (16, 'Travaux dans la zone permissive', Null,0)
End





GO


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



GO

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_electronicvolt_risques' and Value = N'120 V' and SiteId = 16)
Begin
Insert into DropdownValue ([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_electronicvolt_risques', N'120 V', 0, 0, 16) 
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_electronicvolt_risques' and Value = N'208 V' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_electronicvolt_risques', N'208 V', 0, 1, 16) 
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_electronicvolt_risques' and Value = N'240 V' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_electronicvolt_risques', N'240 V', 0, 2, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_electronicvolt_risques' and Value = N'600 V' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_electronicvolt_risques', N'600 V', 0, 3, 16) 
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_electronicvolt_risques' and Value = N'25 000 V' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_electronicvolt_risques', N'25 000 V', 0, 4, 16)
End
--
IF not EXISTS (select * from DropdownValue where [Key] = N'muds_autres_risques' and Value = N'Surface chaude' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_autres_risques', N'Surface chaude', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_autres_risques' and Value = N'Arc flash' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_autres_risques', N'Arc flash', 0, 1, 16)
End

--
IF not EXISTS (select * from DropdownValue where [Key] = N'muds_gants_equipement_protection' and Value = N'Caoutchouc' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_gants_equipement_protection', N'Caoutchouc', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_gants_equipement_protection' and Value = N'Anti-coupure' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_gants_equipement_protection', N'Anti-coupure', 0, 1, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_gants_equipement_protection' and Value = N'Long manchon' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_gants_equipement_protection', N'Long manchon', 0, 2, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_gants_equipement_protection' and Value = N'Haute temp�rature' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_gants_equipement_protection', N'Haute temp�rature', 0, 3, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_gants_equipement_protection' and Value = N'Nitrile' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_gants_equipement_protection', N'Nitrile', 0, 4, 16)
End
--

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_protecteur_equipement_protection' and Value = N'Demi P-100' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_protecteur_equipement_protection', N'Demi P-100', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_protecteur_equipement_protection' and Value = N'Demi P-100+Multi Gaz' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_protecteur_equipement_protection', N'Demi P-100+Multi Gaz', 0, 1, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_protecteur_equipement_protection' and Value = N'Plein P-100' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_protecteur_equipement_protection', N'Plein P-100', 0, 2, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_protecteur_equipement_protection' and Value = N'Plein P-100+Multi Gaz' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_protecteur_equipement_protection', N'Plein P-100+Multi Gaz', 0, 3, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_protecteur_equipement_protection' and Value = N'Adduction d-air' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_protecteur_equipement_protection', N'Adduction d-air', 0, 4, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_protecteur_equipement_protection' and Value = N'APRIA' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_protecteur_equipement_protection', N'APRIA', 0, 5, 16)
End

--

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_epiantiarc_protecteur_equipement_protection' and Value = '0' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_epiantiarc_protecteur_equipement_protection', '0', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_epiantiarc_protecteur_equipement_protection' and Value = '1' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_epiantiarc_protecteur_equipement_protection', '1', 0, 1, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_epiantiarc_protecteur_equipement_protection' and Value = '2' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_epiantiarc_protecteur_equipement_protection', '2', 0, 2, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_epiantiarc_protecteur_equipement_protection' and Value = '4' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_epiantiarc_protecteur_equipement_protection', '4', 0, 3, 16)
End

--
IF not EXISTS (select * from DropdownValue where [Key] = N'muds_habit_protecteur_equipement_protection' and Value = N'Couvre-tout jetable' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_habit_protecteur_equipement_protection', N'Couvre-tout jetable', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_habit_protecteur_equipement_protection' and Value = N'Couvre-tout chimique jetable' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_habit_protecteur_equipement_protection', N'Couvre-tout chimique jetable', 0, 1, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_habit_protecteur_equipement_protection' and Value = N'Habits complet anti-�claboussure' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_habit_protecteur_equipement_protection', N'Habits complet anti-�claboussure', 0, 2, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_habit_protecteur_equipement_protection' and Value = N'Manteau anti-�claboussure' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_habit_protecteur_equipement_protection', N'Manteau anti-�claboussure', 0, 3, 16)
End

--
IF not EXISTS (select * from DropdownValue where [Key] = N'muds_autres_equipement_prevention' and Value = N'MX6' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_autres_equipement_prevention', N'MX6', 0, 0, 16)
End

--
IF not EXISTS (select * from DropdownValue where [Key] = N'muds_outil_equipement_prevention' and Value = N'Tire-fort' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_outil_equipement_prevention', N'Tire-fort', 0, 0, 16)
End


IF not EXISTS (select * from DropdownValue where [Key] = N'muds_outil_equipement_prevention' and Value = N'Cl�f' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_outil_equipement_prevention', N'Cl�f', 0, 1, 16)
End

--

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_perimetre_equipement_prevention' and Value = N'Cl�f' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_perimetre_equipement_prevention', N'Cl�f', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_perimetre_equipement_prevention' and Value = N'Rouge' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_perimetre_equipement_prevention', N'Rouge', 0, 1, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_perimetre_equipement_prevention' and Value = N'Radiographie' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_perimetre_equipement_prevention', N'Radiographie', 0, 2, 16)
End

--

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Utilis� souvent' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Utilis� souvent', 0, 0, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Charriot �l�vateur' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Charriot �l�vateur', 0, 1, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Nacelle' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Nacelle', 0, 2, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Grue' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Grue', 0, 3, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Soudeuse' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Soudeuse', 0, 4, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Appareil de chauffage' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Appareil de chauffage', 0, 5, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Camion lavage haute pression' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Camion lavage haute pression', 0, 6, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Camion � d�pression (vacuum)' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Camion � d�pression (vacuum)', 0, 7, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Camion' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Camion', 0, 8, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'�pandeuse' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'�pandeuse', 0, 9, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Tracteur' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Tracteur', 0, 10, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Scie' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Scie', 0, 11, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Compresseur' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Compresseur', 0, 12, 16)
End

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_appareil_equipement_prevention' and Value = N'Balai de rue' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_appareil_equipement_prevention', N'Balai de rue', 0, 13, 16)
End

--

IF not EXISTS (select * from DropdownValue where [Key] = N'muds_autres_travaux' and Value = N'zone �lectrique de class 1 zone 1' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_autres_travaux', N'zone �lectrique de class 1 zone 1', 0, 0, 16)
End


IF not EXISTS (select * from DropdownValue where [Key] = N'muds_autres_travaux' and Value = N'zone �lectrique de class 1 zone 0' and SiteId = 16)
Begin
INSERT INTO DropdownValue([Key],Value,Deleted, DisplayOrder, SiteId)VALUES( N'muds_autres_travaux', N'zone �lectrique de class 1 zone 0', 0, 1, 16)
End



GO

