if not exists(select 1 from GasTestElementInfo where siteid = 18 and standard=1)
begin
insert into GasTestElementInfo values 
('Oxygen',NULL,1,18,1,1,1,21,19.5,21,19.5,21,19.5,1,0,1,0),
('LEL',NULL,1,18,2,1,0,0,0,0,0,0,0,0,0,2,0),
('H2S',NULL,1,18,3,2,0,10,0,10,0,10,0,10,0,2,0),
('SO2',NULL,1,18,4,2,0,2,0,2,0,2,0,2,0,2,0),
('CO',NULL,1,18,5,2,0,25,0,25,0,25,0,25,0,2,0),
('Benzene',NULL,1,18,6,2,0,0.5,0,0.5,0,0.5,0,0.5,0,2,1),
('Toluene',NULL,1,18,7,2,0,50,0,50,0,50,0,50,0,2,1),
('Xylene',NULL,1,18,8,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,2,1),
('Ammonia',NULL,1,18,9,2,0,25,0,25,0,25,0,25,0,2,1),
('PID',NULL,1,18,6,2,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,2,0)
end







GO




GO

