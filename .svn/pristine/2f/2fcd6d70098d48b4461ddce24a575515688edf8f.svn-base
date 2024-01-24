DELETE wafl
FROM
  WorkAssignmentFunctionalLocation wafl
  INNER JOIN WorkAssignment wa on wa.Id = wafl.WorkAssignmentId
where 
  wa.SiteId = 12
  

DELETE a
FROM
  FunctionalLocationAncestor a  
  INNER JOIN FunctionalLocation fl on a.Id = fl.Id
WHERE
  fl.SiteId = 12

DELETE m
FROM
  FunctionalLocationOperationalMode m
  INNER JOIN FunctionalLocation f on m.UnitId = f.Id
WHERE
  f.SiteId = 12
   
delete from FunctionalLocation where FullHierarchy != 'WBL' and siteId = 12

-- Drop the old proc if it exists
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP PROCEDURE [dbo].FunctionalLocationAddOrUndelete
	END
GO

CREATE Procedure [dbo].FunctionalLocationAddOrUndelete
  (
    @SiteId bigint,
    @Description VARCHAR(50),
    @FullHierarchy VARCHAR(90), 
    @PlantId bigint,
    @Level tinyint,
	@Culture VARCHAR(5) 
  )
AS

IF NOT EXISTS(SELECT * FROM FunctionalLocation
  where FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId)
  BEGIN
    INSERT INTO FunctionalLocation (
       SiteId, Description,FullHierarchy,OutOfService,Deleted
      ,[Level],PlantId,Culture,Source
    ) VALUES (
       @SiteId   -- SiteId - bigint
      ,@Description  -- Description - varchar(50)
      ,@FullHierarchy  -- FullHierarchy - varchar(90)
      ,0  -- OutOfService - bit
      ,0  -- Deleted - bit
      ,@Level   -- Level - tinyint
      ,@PlantId   -- PlantId - bigint
	  ,@Culture -- Culture VARCHAR(5)
	  ,2
    )

    -- attach children to the newly added floc	
    INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
  	SELECT 
  		c.id, a.id, a.[Level]
  		FROM FunctionalLocation a
  		INNER JOIN FunctionalLocation c 
  			ON c.siteid = a.siteid and 
  			c.[Level] > a.[Level] and
   			a.Fullhierarchy like c.fullhierarchy + '-%'
  	where
        a.Id = IDENT_CURRENT('FunctionalLocation')
  	  and
  	  NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
    )

    -- attach parents to the newly added floc
  	INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
  	SELECT 
  		c.id, a.id, a.[Level]
  		FROM FunctionalLocation a
  		INNER JOIN FunctionalLocation c 
  			ON c.siteid = a.siteid and 
  			c.[Level] > a.[Level] and
   			c.Fullhierarchy like a.fullhierarchy + '-%'
  		where
  			c.Id = IDENT_CURRENT('FunctionalLocation')
  			and
  			NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
    )

  END
  
  IF EXISTS(SELECT * FROM FunctionalLocation 
    where FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId AND DELETED = 1)
  BEGIN
    UPDATE FunctionalLocation
      SET 
      DELETED = 0,
      OutOfService = 0,
	  Description = @Description
    WHERE
      FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId AND DELETED = 1
  END
GO

EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Oilsands Laboratory',N'WBL-OSL',8888,2,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Upgrading 1',N'WBL-OSL-UPG1',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Upgrading 2',N'WBL-OSL-UPG2',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Upgrading 3',N'WBL-OSL-UPG3',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Upgrading 4',N'WBL-OSL-UPG4',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Water',N'WBL-OSL-WAT',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Extraction',N'WBL-OSL-EXT',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Gas Chromatograph',N'WBL-OSL-GC',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'ICP',N'WBL-OSL-ICP',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Project',N'WBL-OSL-PROJ',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Balance',N'WBL-OSL-BAL',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Miscellaneous',N'WBL-OSL-MISC',8888,3,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'ANTEK 9000 Sulfur/Nitrogen Analyzer',N'WBL-OSL-UPG1-20107675',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum pump',N'WBL-OSL-UPG1-20140271',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum pump for ANTEK 9000',N'WBL-OSL-UPG1-20156408',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum pump for ANTEK 9000',N'WBL-OSL-UPG1-20156409',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HORIBA XRF  Sulfur Analyzer #1',N'WBL-OSL-UPG1-20006685',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HORIBA XRF  Sulfur Analyzer #2 (SPARE)',N'WBL-OSL-UPG1-20006684',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HORIBA XRF  Sulfur Analyzer #3 (from FB)',N'WBL-OSL-UPG1-99105',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Horiba SLFA-2800 Sulfur Analyser #4',N'WBL-OSL-UPG1-99100',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sindie (ULSD) Sulfur Analyzer #1',N'WBL-OSL-UPG1-20010475',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sindie (ULSD) Sulfur Analyzer #2',N'WBL-OSL-UPG1-20094252',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'NSX-2100V VF-210 Vertical Furnace #1',N'WBL-OSL-UPG1-20177820',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Automatic Liquid Sampler',N'WBL-OSL-UPG1-20177824',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sulphur Detector',N'WBL-OSL-UPG1-20177822',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Nitrogen Detector',N'WBL-OSL-UPG1-20177823',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'NSX-2100V VF-210 Vertical Furnace  #2',N'WBL-OSL-UPG1-99106',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Automatic Liquid Sampler',N'WBL-OSL-UPG1-99111',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sulphur Detector',N'WBL-OSL-UPG1-99112',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Nitrogen Detector',N'WBL-OSL-UPG1-99113',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum pump for NSX-2100V #1',N'WBL-OSL-UPG1-20177821',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum pump for NSX-2100V #2',N'WBL-OSL-UPG1-99132',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Chemwell-T Analyzer',N'WBL-OSL-WAT-99128',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent 6890N GC SD1',N'WBL-OSL-GC-20006751',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent 6890N GC SD4',N'WBL-OSL-GC-20006746',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent 6890 GC C7- & Amine',N'WBL-OSL-GC-20006748',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent 7890 Refinery Gas Analyzer #3',N'WBL-OSL-GC-20147565',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Metrohm Ion Chromatograph #2',N'WBL-OSL-PROJ-20006715',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Metrohm Ion Chromatograph #1',N'WBL-OSL-PROJ-99107',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Metrohm Ion Chromatograph',N'WBL-OSL-PROJ-20158454',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'IC Autosampler',N'WBL-OSL-PROJ-99137',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'IC Autosampler',N'WBL-OSL-PROJ-20006753',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'IC Autosampler',N'WBL-OSL-PROJ-20006716',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent 7890A SD3',N'WBL-OSL-GC-20062856',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'863 compact autosampler',N'WBL-OSL-PROJ-20106984',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent 7890A GC SIMDIST Analyzer SD2',N'WBL-OSL-GC-20186643',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Agilent GC 7890A Refinery Gas Analyzer#2',N'WBL-OSL-GC-20186644',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler',N'WBL-OSL-GC-20006755',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD1F)',N'WBL-OSL-GC-99141',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD1B)',N'WBL-OSL-GC-99142',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD2F)',N'WBL-OSL-GC-99143',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD2B)',N'WBL-OSL-GC-99144',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD3B)',N'WBL-OSL-GC-99145',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD3F)',N'WBL-OSL-GC-99146',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD4B)',N'WBL-OSL-GC-99147',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (C7)',N'WBL-OSL-GC-99148',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD1)',N'WBL-OSL-GC-99166',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SD4)',N'WBL-OSL-GC-99167',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SPARE)',N'WBL-OSL-GC-99149',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'GC Autosampler (SPARE)',N'WBL-OSL-GC-99168',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Gas Chromatograph',N'WBL-OSL-GC-99150',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Universal Gas Flowmetre',N'WBL-OSL-GC-99140',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Perkin-Elmer Spectrum 100 FT-IR',N'WBL-OSL-PROJ-20010495',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Perkin-Elmer Spectrum 100 FT-IR',N'WBL-OSL-PROJ-20140272',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'ICP-Atomic Emission Spectrometer',N'WBL-OSL-ICP-20006687',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'ICP-AES (Perkin-Elmer) Autosampler',N'WBL-OSL-ICP-20006688',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Chiller/Recirculator for ICP-AES',N'WBL-OSL-ICP-20006689',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Libra Spectrophotometer #1 (SPARE)',N'WBL-OSL-WAT-20006767',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Libra Spectrophotometer #2',N'WBL-OSL-UPG4-20006768',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Spectronic 401 Spectrophotometer #1',N'WBL-OSL-WAT-20006773',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Spectronic 401 Spectrophotometer #2',N'WBL-OSL-WAT-20006774',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HACH Spectrophotometer #3',N'WBL-OSL-WAT-N/A',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HACH Spectrophotometer #4',N'WBL-OSL-WAT-20010469',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HACH Spectrophotometer #1',N'WBL-OSL-WAT-20004764',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'HACH Spectrophotometer #2',N'WBL-OSL-WAT-20006771',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'ICP-Atomic Emission Spectrometer',N'WBL-OSL-ICP-20147567',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'ICP-AES (Perkin-Elmer) Autosampler',N'WBL-OSL-ICP-20147568',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Chiller/Recirculator for ICP-AES',N'WBL-OSL-ICP-20147569',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'D86 Opti Dist',N'WBL-OSL-UPG2-20094503',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'D86 Opti Dist',N'WBL-OSL-UPG2-20120059',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'D86 Opti Dist',N'WBL-OSL-UPG2-20140273',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'D86 Opti Dist',N'WBL-OSL-UPG2-20140274',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Distillation Bath #2',N'WBL-OSL-WAT-20167601',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Distillation Bath #1',N'WBL-OSL-WAT-20167602',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Mettler DE-40 Density Meter Unit #2 (SPARE)',N'WBL-OSL-UPG1-20010479',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Mettler DE-40 Density Meter Unit #1',N'WBL-OSL-UPG1-20010496',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Mettler DE-40 Density Meter Unit #3',N'WBL-OSL-EXT-20120060',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SC-30 Autosampler #2',N'WBL-OSL-UPG1-20140275',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SC-30 Autosampler #1',N'WBL-OSL-UPG1-20106987',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SC-30 Autosampler #3 (SPARE)',N'WBL-OSL-UPG1-20156410',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'DMA 4500 #1',N'WBL-OSL-UPG1-20006735',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SP-3m Sample Changer',N'WBL-OSL-UPG1-99114',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'DMA 4500 #2',N'WBL-OSL-UPG1-99108',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SP-3m Sample Changer',N'WBL-OSL-UPG1-99115',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Automated Flash Point Analyzer #2',N'WBL-OSL-UPG3-20120061',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Automated Flash Point Analyzer #3',N'WBL-OSL-UPG3-20147566',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Automated Flash Point Analyzer #4',N'WBL-OSL-UPG3-99104',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Cloud Point Analyzer #2',N'WBL-OSL-UPG4-20010494',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Cloud Point Analyzer #3',N'WBL-OSL-UPG4-99134',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Autosampler for Cloud Point',N'WBL-OSL-UPG4-99135',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Aniline Point Tester',N'WBL-OSL-ICP-20004760',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'LTFT Cooling',N'WBL-OSL-ICP-20010508',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'LTFT Cooling',N'WBL-OSL-ICP-20010507',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Oil and Grease Machine (#2)',N'WBL-OSL-WAT-20006741',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Oil and Grease Machine (#1)',N'WBL-OSL-WAT-20006738',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Solvent trap recovery system (SPARE)',N'WBL-OSL-WAT-20006734',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Speed-vap 3 evaporator system',N'WBL-OSL-WAT-20006779',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Speed-vap 3 evaporator system',N'WBL-OSL-WAT-20147570',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SPE-DEX 3000',N'WBL-OSL-WAT-20067432',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SPE-DEX 3000',N'WBL-OSL-WAT-20006770',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SPE-DEX 3000 - Controller',N'WBL-OSL-WAT-20147571',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'SPE-DEX 3000 - Controller',N'WBL-OSL-WAT-20147572',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Digital Vacuum Regulator',N'WBL-OSL-WAT-20156407',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Micro Carbon Analyzer #1',N'WBL-OSL-UPG2 -20120062',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Micro Carbon Analyzer #2',N'WBL-OSL-UPG2 -20167615',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Micro Carbon Analyzer #3',N'WBL-OSL-UPG2 -99116',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'RVP Tester (#5)',N'WBL-OSL-UPG4-20120063',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Oil and Grease Machine (#3)',N'WBL-OSL-WAT-20120064',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Oil and Grease Machine (#4)',N'WBL-OSL-WAT-20123026',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Aniline Point Tester (unit #1)',N'WBL-OSL-ICP-20120065',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'RVP Tester #6',N'WBL-OSL-UPG4-20140989',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'RVP Tester #7',N'WBL-OSL-UPG4-20140988',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Catridge Module 303A-2 #1',N'WBL-OSL-WAT-20167611',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Catridge Module 303A-2 #2',N'WBL-OSL-WAT-20167612',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Catridge Module 303A-2 #3',N'WBL-OSL-WAT-99122',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Eracheck Model EC01',N'WBL-OSL-WAT-20182827',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Tecator Digestotr Auto 8 unit 1',N'WBL-OSL-WAT-20182828',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Tecator Lift unit 1',N'WBL-OSL-WAT-20182829',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Tecator Digestotr Auto 8 unit 2',N'WBL-OSL-WAT-20182830',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Tecator Lift unit 2',N'WBL-OSL-WAT-20182831',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Stabinger Viscometer SVM3000 #1',N'WBL-OSL-ICP-99109',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Stabinger Viscometer SVM3000 #2',N'WBL-OSL-ICP-99110',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6700 Analytical Balance  (UPG1)',N'WBL-OSL-BAL-20006700',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6701 Analytical Balance (UPG3)',N'WBL-OSL-BAL-20006701',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6702 Analytical Balance (WAT)',N'WBL-OSL-BAL-20006702',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6699 Analytical Balance (UPG2)',N'WBL-OSL-BAL-20006699',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6716 Analytical Balance (QA)',N'WBL-OSL-BAL-20006716',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6717 Top Loader (WAT)',N'WBL-OSL-BAL-20006717',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_0019 Analytical Balance (UPG3)',N'WBL-OSL-BAL-20030019',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_0020 Analytical Balance (PRO)',N'WBL-OSL-BAL-20030020',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_0003 Analytical Balance (PRO/EXT)',N'WBL-OSL-BAL-20103428',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6704 Top Loader (GC)',N'WBL-OSL-BAL-20006704',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6705 Top Loader (EXT)',N'WBL-OSL-BAL-20006705',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6706 Top Loader (UPG2)',N'WBL-OSL-BAL-20006706',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6707 Top Loader (EXT)',N'WBL-OSL-BAL-20006707',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6708 Top Loader (ICP)',N'WBL-OSL-BAL-20006708',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6709 Top Loader (EXT)',N'WBL-OSL-BAL-20006709',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6714 Top Loader (PRO)',N'WBL-OSL-BAL-20006714',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_3833 Top Loader (EXT)',N'WBL-OSL-BAL-20033833',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_3834 Top Loader (ICP)',N'WBL-OSL-BAL-20033834',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6697 Analytical Balance  (ICP)',N'WBL-OSL-BAL-20006697',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6694 Analytical Balance (WAT)',N'WBL-OSL-BAL-20006694',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_00079 Analytical Balance (WAT)',N'WBL-OSL-BAL-20140282',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_6712 Analytical Balance (ICP)',N'WBL-OSL-BAL-20006712',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_00075CX Analytical Balance (SPARE)',N'WBL-OSL-BAL-20140283',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_0300 Analytical Balance (EXT)',N'WBL-OSL-BAL-20140285',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_10483 Analytical Balance (PRO/EXT)',N'WBL-OSL-BAL-20147576',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'B_0004 Analytical Balance (UPG3)',N'WBL-OSL-BAL-20147575',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Conductivity Meter - Diesel (SPARE)',N'WBL-OSL-UPG4-20140286',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Conductivity Meter - Diesel',N'WBL-OSL-UPG4-20006783',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'MT pH Meter',N'WBL-OSL-WAT-20010471',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Metter Toledo pH meter',N'WBL-OSL-WAT-99102',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Rondolino auto sampler',N'WBL-OSL-WAT-99103',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Conductivity Meter',N'WBL-OSL-WAT-20006782',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Conductivity Meter (Diesel)',N'WBL-OSL-UPG4-20140288',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Digital Detector #1',N'WBL-OSL-WAT-20167595',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Digital Detector #2',N'WBL-OSL-WAT-20167596',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Digital Detector #3',N'WBL-OSL-WAT-99125',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Autosampler for DL77 #2  (SPARE)',N'WBL-OSL-UPG3-20010492',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Rondo Autosampler',N'WBL-OSL-UPG3-20137901',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Rondo Autosampler',N'WBL-OSL-UPG3-20137903',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Titrator #1',N'WBL-OSL-ICP-20010514',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Titrator #2',N'WBL-OSL-ICP-20106988',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Titrator C30 #1',N'WBL-OSL-ICP-20147573',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Titrator C30 #2',N'WBL-OSL-ICP-99139',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Mettler T90 Autotitrator #1',N'WBL-OSL-UPG3-20137902',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Mettler T90 Autotitrator #2',N'WBL-OSL-UPG3-99163',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Titrator V30 #1',N'WBL-OSL-EXT-99117',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Stromboli Oven #1',N'WBL-OSL-EXT-99118',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Titrator V30 #2',N'WBL-OSL-EXT-99119',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Karl Fisher Stromboli Oven #2',N'WBL-OSL-EXT-99120',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'COD DigiPrep Cube Reactor (SPARE)',N'WBL-OSL-WAT-20006858',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'COD HANNA Reactor  with Safety Shield',N'WBL-OSL-WAT-99127',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'COD  HANNA Reactor',N'WBL-OSL-WAT-99151',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Digital Reactor Block 200 #2',N'WBL-OSL-WAT-99126',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Milli-Q Intergral 15 Pure',N'WBL-OSL-WAT-20156406',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'IEC  Centrifuge',N'WBL-OSL-UPG4-20006722',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Centrofuge 3CI',N'WBL-OSL-EXT-20006725',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'L-K Industries Centrifuge #3',N'WBL-OSL-UPG4-20006727',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'L-K Industries Heated Centrifuge #2',N'WBL-OSL-UPG4-20167616',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'L-K Industries Centrifuge  #1',N'WBL-OSL-UPG4-20006726',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Centrofuge 3CI',N'WBL-OSL-EXT-20010497',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Centrifuge Tubes Heater',N'WBL-OSL-UPG4-20167609',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sorvall Legend Benchtop Centrifuge',N'WBL-OSL-EXT-99101',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sorvall Legend Centrifuge',N'WBL-OSL-EXT-99129',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Refrigerator (NORTH WALL)',N'WBL-OSL-MISC-20004763',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Refrigerator  (WAT)',N'WBL-OSL-MISC-20006861',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Refrigerator (SPARE)',N'WBL-OSL-MISC-20010512',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Refrigerator for Lagoon (SR)',N'WBL-OSL-MISC-20137873',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Refrigerator (NORTH WALL)',N'WBL-OSL-MISC-20006863',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Flammable Refrigerator (SR)',N'WBL-OSL-MISC-20004766',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Flammable Material Refrigerator (WAT)',N'WBL-OSL-MISC-20004761',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Julabo Chiller (EXT)',N'WBL-OSL-MISC-20006864',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Julabo Chiller (EXT)',N'WBL-OSL-MISC-20006865',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Julabo Chiller (BENCH MD)',N'WBL-OSL-MISC-20006866',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Julabo Chiller (BENCH MD)',N'WBL-OSL-MISC-20006859',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Recirculating Chiller (SPARE)',N'WBL-OSL-MISC-20010501',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Chiller (UPG2))',N'WBL-OSL-MISC-20120066',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Chiller (EXT)',N'WBL-OSL-MISC-20006857',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vented Storage Cabinet #1 (BOTTLE WASH)',N'WBL-OSL-MISC-99152',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vented Storage Cabinet #2 (BOTTLE WASH)',N'WBL-OSL-MISC-99153',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vented Storage Cabinet #3 (BOTTLE WASH)',N'WBL-OSL-MISC-20140990',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Mini Fridge (SPARE)',N'WBL-OSL-MISC-20140987',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Glycol Chiller (PRO)',N'WBL-OSL-MISC-99130',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Stirrer (SPARE)',N'WBL-OSL-MISC-20140290',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Stirrer (EXT)',N'WBL-OSL-MISC-20140291',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Jumbo Stirrer (SPARE)',N'WBL-OSL-MISC-99169',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Jumbo Stirrer (SPARE)',N'WBL-OSL-MISC-20062858',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Paint Shaker (EXT)',N'WBL-OSL-MISC-20123018',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Paint Shaker (EXT)',N'WBL-OSL-MISC-20123019',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Paint Shaker (EXT)',N'WBL-OSL-MISC-20123020',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Paint Shaker (EXT)',N'WBL-OSL-MISC-20123021',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Stirrer (EXT)',N'WBL-OSL-MISC-20140991',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Vacuum Pump',N'WBL-OSL-ICP-99158',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Veristaltic Pump',N'WBL-OSL-WAT-99131',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum Pump (SPARE)',N'WBL-OSL-WAT-20006714',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Vacuum Pump (SPARE)',N'WBL-OSL-WAT-20032989',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Dry Vacuum Pump',N'WBL-OSL-UPG1-99138',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'MicroPump 302D #1',N'WBL-OSL-WAT-20167597',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'MicroPump 302D #2',N'WBL-OSL-WAT-20167598',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'MicroPump 302D #3',N'WBL-OSL-WAT-99121',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Auxillary Pump #1',N'WBL-OSL-WAT-20167607',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Auxillary Pump #3',N'WBL-OSL-WAT-99123',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Auxillary Pump #4',N'WBL-OSL-WAT-99124',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Ashing Furnace (SPARE)',N'WBL-OSL-MISC-20010499',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Ashing Furnace (ICP)',N'WBL-OSL-MISC-20140294',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Laboratory Oven (BENCH MD)',N'WBL-OSL-MISC-20004768',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'OvenFISHER (BENCH MD)',N'WBL-OSL-MISC-20010500',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'BRIMSTONE TEMP CONTROLER (PRO)',N'WBL-OSL-MISC-20010488',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'BRIMSTONE TEMP CONTROLER (PRO)',N'WBL-OSL-MISC-99170',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Water Bath (SPARE)',N'WBL-OSL-MISC-20137904',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Despatch safety Oven (EXT)',N'WBL-OSL-MISC-20140295',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Laboratory Oven (WAT)',N'WBL-OSL-MISC-20094504',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Laboratory Oven (UPG2)',N'WBL-OSL-MISC-99161',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Constant Temp Visc Bath (ICP)',N'WBL-OSL-MISC-20140297',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Water Bath (UPG2)',N'WBL-OSL-MISC-20140298',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Isotemp Water Bath (UPG4)',N'WBL-OSL-MISC-20140985',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Jubalo Refridgerated Circulator (ICP)',N'WBL-OSL-MISC-20167610',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Criterion Water Bath Heater System (PRO)',N'WBL-OSL-MISC-20167613',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'L-K Oil Sample Heater # 1 (SPARE)',N'WBL-OSL-MISC-20174622',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'L-K Oil Sample Heater # 2 (UPG4)',N'WBL-OSL-MISC-20174623',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Gas Leak Detector (GC)',N'WBL-OSL-MISC-20006733',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Oil Bath (ICP)',N'WBL-OSL-MISC-20010510',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Bottle Washer',N'WBL-OSL-MISC-20140300',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Hydrocarbon Detector (SUP)',N'WBL-OSL-MISC-20006761',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Gas Leak Detector (GC)',N'WBL-OSL-MISC-20140302',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sentinel 16 Ch Gas Receiver',N'WBL-OSL-MISC-20167603',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Foss North American Scrubber 2501 #1 (WAT)',N'WBL-OSL-MISC-20182825',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Foss North American Scrubber 2501 #2 (WAT)',N'WBL-OSL-MISC-20182826',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-ICP-20006856',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-UPG4-99164',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-UPG4-99165',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-WAT-99160',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-UPG2-99159',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-UPG3-99162',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Portable Fumehood',N'WBL-OSL-ICP-99136',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Dilutors 312 #1',N'WBL-OSL-WAT-20167599',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Dilutors 312 #2',N'WBL-OSL-WAT-20167600',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Dilutors 312 #3',N'WBL-OSL-WAT-99133',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sampler 311, XYZ Dilutors #1',N'WBL-OSL-WAT-20167604',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sampler 311, XYZ Dilutors #2',N'WBL-OSL-WAT-20167606',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Sampler 311, XYZ Dilutors #3',N'WBL-OSL-WAT-99125B',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Hydrogen Gas Generator #1',N'WBL-OSL-GC-99154',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Hydrogen Gas Generator #2',N'WBL-OSL-GC-99155',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Zero Air Gas Generator #1',N'WBL-OSL-GC-99156',8888,4,'en';
EXEC dbo.FunctionalLocationAddOrUndelete 12, N'Zero Air Gas Generator #2',N'WBL-OSL-GC-99157',8888,4,'en';
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP PROCEDURE [dbo].FunctionalLocationAddOrUndelete
	END
GO


INSERT INTO FunctionalLocationOperationalMode
( UnitId, OperationalModeId, AvailabilityReasonId, LastModifiedDateTime)
(
    Select
        FunctionalLocation.Id,
        0,
        0,
        GETDATE()
    FROM
        FunctionalLocation
    WHERE
		Level = 3 and SiteId = 12
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id))
GO

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Oilsands Lab Administrator' and fl.FullHierarchy = 'WBL'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Extraction 1 Day Shift Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Extraction 1 Day Shift Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Extraction 1 Day Shift Lab Tech' and fl.FullHierarchy = 'WBL-OSL-EXT'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Extraction 2 Day Shift Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Extraction 2 Day Shift Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Extraction 2 Day Shift Lab Tech' and fl.FullHierarchy = 'WBL-OSL-EXT'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 1 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 1 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 1 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-UPG1'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 2 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 2 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 2 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-UPG2'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 3 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 3 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 3 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-UPG3'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 4 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 4 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Upgrading 4 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-UPG4'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Waters 1 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Waters 1 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Waters 1 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-WAT'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Waters 2 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Waters 2 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Waters 2 Lab Tech' and fl.FullHierarchy = 'WBL-OSL-WAT'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Projects Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Projects Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Projects Lab Tech' and fl.FullHierarchy = 'WBL-OSL-PROJ'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'GC Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'GC Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'GC Lab Tech' and fl.FullHierarchy = 'WBL-OSL-GC'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'ICP Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'ICP Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'ICP Lab Tech' and fl.FullHierarchy = 'WBL-OSL-ICP'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'QA Lab Tech' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'QA Lab Tech' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'QA Lab Tech' and fl.FullHierarchy = 'WBL-OSL-QA'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Extraction' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Extraction' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Extraction' and fl.FullHierarchy = 'WBL-OSL-EXT'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 1/3' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 1/3' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 1/3' and fl.FullHierarchy = 'WBL-OSL-UPG1'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 1/3' and fl.FullHierarchy = 'WBL-OSL-UPG3'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 2/4' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 2/4' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 2/4' and fl.FullHierarchy = 'WBL-OSL-UPG2'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Upgrading 2/4' and fl.FullHierarchy = 'WBL-OSL-UPG4'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Projects' and fl.FullHierarchy = 'WBL-OSL-BAL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Projects' and fl.FullHierarchy = 'WBL-OSL-MISC'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Night Shift Projects' and fl.FullHierarchy = 'WBL-OSL-PROJ'

INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Unit Leader' and fl.FullHierarchy = 'WBL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Lab Specialist' and fl.FullHierarchy = 'WBL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Lab Supervisor' and fl.FullHierarchy = 'WBL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Lab Manager' and fl.FullHierarchy = 'WBL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Lab System Analyst' and fl.FullHierarchy = 'WBL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'QA Staff' and fl.FullHierarchy = 'WBL'
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId,FunctionalLocationId) SELECT wa.Id, fl.Id FROM WorkAssignment wa, FunctionalLocation fl WHERE wa.SiteId = 12 and fl.SiteId = 12 and wa.[Name] = 'Read Only' and fl.FullHierarchy = 'WBL'
GO


GO

