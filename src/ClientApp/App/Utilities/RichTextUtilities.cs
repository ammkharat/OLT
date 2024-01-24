using System;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using CharacterProperties = DevExpress.XtraRichEdit.API.Native.CharacterProperties;
using UnderlineType = DevExpress.XtraRichEdit.API.Native.UnderlineType;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class RichTextUtilities
    {                              
        public static void FormatDocumentContents(
            Document document, float fontsize, bool bold, bool italics, bool underline)
        {
            document.SelectAll();
            DocumentRange documentRange = document.Selection;
            CharacterProperties properties = document.BeginUpdateCharacters(documentRange);
            properties.Bold = bold;
            properties.Italic = italics;
            properties.Underline = underline ? UnderlineType.Single : UnderlineType.None;
            properties.FontSize = fontsize;
            properties.FontName = UIConstants.CONTROL_FONT.Name;
            document.EndUpdateCharacters(properties);
        }

        public static string FormatDocumentSelection(string text, int start, int length, float fontsize, bool bold, bool italics, bool underline)
        {
            if (text == null || !text.IsRtf())
            {
                throw new ArgumentException("RTF Text is required", "text");
            }

            RichEditDocumentServer richEditDocumentServer = new RichEditDocumentServer();
            richEditDocumentServer.RtfText = text;

            Document document = richEditDocumentServer.Document; 
                      
            CharacterProperties properties = document.BeginUpdateCharacters(start, length);
            properties.Bold = bold;
            properties.Italic = italics;
            properties.Underline = underline ? UnderlineType.Single : UnderlineType.None;
            properties.FontSize = fontsize;
            properties.FontName = UIConstants.CONTROL_FONT.Name;
            document.EndUpdateCharacters(properties);
            return richEditDocumentServer.RtfText;
        }

        public static string ConvertTextToRTF(string text, float fontsize, bool bold, bool italics, bool underline)
        {
            if (text == null || text.IsRtf())
            {
                return text;
            }

            RichEditDocumentServer richEditDocumentServer = new RichEditDocumentServer();           
            richEditDocumentServer.Text = text;

            Document document = richEditDocumentServer.Document;            
            FormatDocumentContents(document, fontsize, bold, italics, underline);           
                                 
            return richEditDocumentServer.RtfText;
        }

        public static string ConvertTextToRTF(string text)
        {
            if (text == null || text.IsRtf())
            {
                return text;
            }

            RichEditDocumentServer richEditDocumentServer = new RichEditDocumentServer();           
            richEditDocumentServer.Text = text;

            Document document = richEditDocumentServer.Document;
            FormatDocumentContents(document, UIConstants.RichTextDefaultFontSize, false, false, false);           
                                 
            return richEditDocumentServer.RtfText;
        }

    }
}
