﻿
-------- Document Link -------
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormMudsTemporaryInstallationId'
)
begin
alter table [dbo].[DocumentLink] Add FormMudsTemporaryInstallationId bigint 
end
Go
------------ FormTemplate ---------

If not Exists(
		Select * from FormTemplate Where siteid = 16 and FormTypeId = 16 and Deleted = 0
)
Begin
INSERT [dbo].[FormTemplate] ([FormTypeId], [Template], [Deleted], [CreatedByUserId], [CreatedDateTime], [TemplateKey], [Name], [siteid]) 
	VALUES (16, N'{\rtf1\deff0{\fonttbl{\f0 Calibri;}{\f1 Tahoma;}{\f2 Times New Roman;}}{\colortbl ;\red0\green0\blue255 ;\red217\green217\blue217 ;\red0\green0\blue0 ;}{\*\defchp \fs22}{\*\listoverridetable}{\stylesheet {\ql\fs22 Normal;}{\*\cs1\fs22 Default Paragraph Font;}{\*\cs2\sbasedon1\fs22 Line Number;}{\*\cs3\ul\fs22\cf1 Hyperlink;}{\*\ts4\tsrowd\fs22\ql\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\fs22\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trbrdrh\brdrs\brdrw10\trbrdrv\brdrs\brdrw10\trautofit1\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql\f1\fs18\par\trowd\irow0\irowband-1\trleft0\trrh249\trftsWidth3\trwWidth10650\trautofit1\tbllkhdrcols\tbllkhdrrows\tbllknocolband\tblindtype3\tblind108\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrs\brdrw30\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth2310\clpadfr3\clpadr108\clpadft3\clpadt108\cellx2580\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrnone\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth2245\clpadfr3\clpadr108\clpadft3\clpadt108\cellx5100\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrnone\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth6095\clpadfr3\clpadr108\clpadft3\clpadt108\cellx11475\pard\plain\qc\intbl{\lang1036\langfe1036\b\f2\fs20\cf3 Responsable de l\u8217\''92installation}\lang1036\langfe1036\b\f2\fs20\cf3\cell\pard\plain\qc\intbl{\lang1036\langfe1036\b\f2\fs20\cf3 Fr\u233\''e9quence}\lang1036\langfe1036\b\f2\fs20\cf3\cell\pard\plain\qc\intbl{\lang1036\langfe1036\b\f2\fs20\cf3 Actions \u224\''e0 prendre}\lang1036\langfe1036\b\f2\fs20\cf3\cell\trowd\irow0\irowband-1\trleft0\trrh249\trftsWidth3\trwWidth10650\trautofit1\tbllkhdrcols\tbllkhdrrows\tbllknocolband\tblindtype3\tblind108\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrs\brdrw30\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth2310\clpadfr3\clpadr108\clpadft3\clpadt108\cellx2580\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrnone\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth2245\clpadfr3\clpadr108\clpadft3\clpadt108\cellx5100\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrnone\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth6095\clpadfr3\clpadr108\clpadft3\clpadt108\cellx11475\row\pard\plain\qc\intbl\lang1036\langfe1036\f2\fs20\cf3\cell\pard\plain\qc\intbl\lang1036\langfe1036\f2\fs20\cf3\cell\pard\plain\qc\intbl\lang1036\langfe1036\f2\fs20\cf3\cell\trowd\irow1\irowband0\lastrow\trleft0\trrh365\trftsWidth3\trwWidth10650\trautofit1\tbllkhdrcols\tbllkhdrrows\tbllknocolband\tblindtype3\tblind108\clvertalt\clbrdrt\brdrnone\clbrdrl\brdrs\brdrw30\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clftsWidth3\clwWidth2310\clpadfr3\clpadr108\clpadft3\clpadt108\cellx2580\clvertalt\clbrdrt\brdrnone\clbrdrl\brdrnone\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clftsWidth3\clwWidth2245\clpadfr3\clpadr108\clpadft3\clpadt108\cellx5100\clvertalt\clbrdrt\brdrnone\clbrdrl\brdrnone\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clftsWidth3\clwWidth6095\clpadfr3\clpadr108\clpadft3\clpadt108\cellx11475\row\pard\plain\ql\lang1036\langfe1036\f2\cf3\par\trowd\irow0\irowband-1\trleft0\trftsWidth3\trwWidth10695\trautofit1\tbllkhdrcols\tbllkhdrrows\tbllknocolband\tblindtype3\tblind108\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrs\brdrw20\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth10695\clpadfr3\clpadr108\clpadft3\clpadt108\cellx10965\pard\plain\ql\intbl{\lang1036\langfe1036\b\f2\fs20\cf3 Commentaires additionnels:}\lang1036\langfe1036\b\f2\fs20\cf3\cell\trowd\irow0\irowband-1\trleft0\trftsWidth3\trwWidth10695\trautofit1\tbllkhdrcols\tbllkhdrrows\tbllknocolband\tblindtype3\tblind108\clvertalt\clcbpat2\clbrdrt\brdrs\brdrw20\clbrdrl\brdrs\brdrw20\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clhidemark\clftsWidth3\clwWidth10695\clpadfr3\clpadr108\clpadft3\clpadt108\cellx10965\row\pard\plain\ql\intbl\lang1036\langfe1036\f2\fs20\cf3\cell\trowd\irow1\irowband0\lastrow\trleft0\trftsWidth3\trwWidth10695\trautofit1\tbllkhdrcols\tbllkhdrrows\tbllknocolband\tblindtype3\tblind108\clvertalt\clbrdrt\brdrnone\clbrdrl\brdrs\brdrw20\clbrdrb\brdrs\brdrw20\clbrdrr\brdrs\brdrw20\cltxlrtb\clftsWidth3\clwWidth10695\clpadfr3\clpadr108\clpadft3\clpadt108\cellx10965\row\pard\plain\ql\f1\fs18\par}', 0, -1, CAST(0x0000A93B00000000 AS DateTime), NULL, NULL, 16)
End






GO
