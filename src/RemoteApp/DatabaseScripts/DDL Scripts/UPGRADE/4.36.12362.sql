if not exists(select 1 from Contractor where siteid = 18)
begin
insert into Contractor (CompanyName,Siteid)
values 
('Acme Sanitation',18),
('Advanced Tank',18),
('Ardent',18),
('August Weed Services',18),
('Automatic Entrances',18),
('Barco Fence',18),
('Braconier Plumbing',18),
('CEI Roofing',18),
('CFS',18),
('Conam',18),
('Design Services',18),
('Door Specialties',18),
('Elkhorn',18),
('Energy Repair',18),
('Honeywell',18),
('Insultherm, Inc.',18),
('Jacobs',18),
('Johnson Controls',18),
('K&H',18),
('Key Energy',18),
('Miller Inspection',18),
('National Coating',18),
('Orkin',18),
('Paratex',18),
('Philip Services',18),
('Quadna',18),
('Railworks',18),
('Resource Environmental',18),
('Retec',18),
('Safeway',18),
('Securus',18),
('Sitewise',18),
('Sturgeon',18),
('Summit',18),
('Tanco',18),
('TEAM - Cooperheat',18),
('TEAM Industrial',18),
('TOLIN MECHANICAL',18),
('VECO',18),
('Velia (formally known as Onyx)',18),
('Wicks',18)
end




GO

if not exists(select 1 from CraftOrTrade where siteid = 18)
begin
insert into CraftOrTrade ([Name],WorkCenter,Siteid,Deleted)
values 
('Carpenter, Contract','CARP-C',18,0),
('Coordinator','COORD',18,0),
('Draftsperson, Contract','DWG-C',18,0),
('Electrician','ELE',18,0),
('Electrician, Contract','ELE-C',18,0),
('Engineer, Mechanical','ENGME',18,0),
('Engineer, Mechanical, Contract','ENGME-C',18,0),
('Engineer, Process','ENGPR',18,0),
('Engineer, Instrument, Contract','ENINST-C',18,0),
('Equipment Operator','EQOPR',18,0),
('Equipment Operator, Contract','EQOPR-C',18,0),
('Industrial Hygenist','IH',18,0),
('Insulator-Carpenter','INCARP',18,0),
('Inspector','INSP',18,0),
('Inspector, Contract','INSP-C',18,0),
('Instrument Tech, Analyzers','INSTA',18,0),
('Instrument Tech, Field','INSTF',18,0),
('Insulator, Contract','INSU-C',18,0),
('Laborer, Contract','LAB-C',18,0),
('Laborer, Safety, Contract','LABSAF-C',18,0),
('Mechanic, Automotive','MEA',18,0),
('Mechanic, Automotive, Contract','MEA-C',18,0),
('Millwright','MW',18,0),
('Laboratory Technician/Operator','OPRLAB',18,0),
('Operator, Process','OPRPR',18,0),
('Operator, Process, Team A','OPRPRA',18,0),
('Operator, Process, Team B','OPRPRB',18,0),
('Operator, Process, Team C','OPRPRC',18,0),
('Operator, Process, Team D','OPRPRD',18,0),
('Pipefitter Welder','PFW',18,0),
('Pipefitter Welder, Contract','PFW-C',18,0),
('Pipefitter Welder, East','PFWE',18,0),
('Pipefitter Welder, Steam','PFWS',18,0),
('Pipefitter Welder, West','PFWW',18,0),
('Painter, Contract','PNTR-C',18,0),
('Reliability Tech, Electrical','RTELE',18,0),
('Reliability Tech, Instrument','RTINST',18,0),
('Reliability Tech, Mechanical','RTME',18,0),
('Reliability Tech, Pipefitter','RTPF',18,0),
('Reliability Tech, Pipefitter, Steam','RTPFS',18,0),
('Reliability Tech, Rotating Equipment','RTROT',18,0),
('Scaffolder, Contract','SCF-C',18,0),
('Security','SEC',18,0)
end



GO

