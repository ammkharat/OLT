insert into SummaryLogCustomFieldGroup select 'Extraction - Millennium';

insert into SummaryLogCustomFieldGroupFunctionalLocation select g.id, f.id from SummaryLogCustomFieldGroup g, functionallocation f where g.name = 'Extraction - Millennium' and f.fullhierarchy = 'EX1-P081';
insert into SummaryLogCustomFieldGroupFunctionalLocation select g.id, f.id from SummaryLogCustomFieldGroup g, functionallocation f where g.name = 'Extraction - Millennium' and f.fullhierarchy = 'EX1-P085';
insert into SummaryLogCustomFieldGroupFunctionalLocation select g.id, f.id from SummaryLogCustomFieldGroup g, functionallocation f where g.name = 'Extraction - Millennium' and f.fullhierarchy = 'EX1-P086';

insert into SummaryLogCustomField select g.id, 'OPP A', 0 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'OPP B', 1 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'OPP C', 2 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 12', 3 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 13', 4 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 14', 5 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 7 - Sep Cell', 6 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 7 - Sec. Banks', 7 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 7 - Tert. Banks', 8 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 8 - Sep Cell', 9 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 8 - Sec. Banks', 10 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';
insert into SummaryLogCustomField select g.id, 'Line 8 - Tert. Banks', 11 from SummaryLogCustomFieldGroup g where g.name = 'Extraction - Millennium';


go
GO
