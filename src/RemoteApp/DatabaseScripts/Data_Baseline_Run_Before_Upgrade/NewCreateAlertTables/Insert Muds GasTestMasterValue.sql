IF(NOT EXISTS(SELECT * FROM GasTestElementInfo where SiteId=16))
Begin
INSERT GasTestElementInfo(Name,SiteId,DisplayOrder,RangedLimit,DecimalPlaceCount,Standard)
SELECT 'Combustible (LIE)',16,2,1,1,1 UNION
SELECT 'Oxyg�ne (20.9%)',16,3,1,1,1 UNION

SELECT 'Sulfure d�Hydrog�ne (H2S)',16,4,1,1,1 UNION

SELECT 'Dioxyde de soufre (SO2)',16,6,1,1,1 UNION

SELECT 'Monoxyde de carbone (CO)',16,7,1,1,1 UNION

SELECT 'Ammoniaque (NH3)',16,8,1,1,1 UNION

SELECT '#D�tecteur de gaz',16,29,1,1,1

END


