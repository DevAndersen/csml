﻿using System.Xml;
using System.Xml.Linq;

namespace Csml.Parser;

public static class CsmlParser
{
    public static CsmlParseResult Parse(string xml)
    {
        List<CsmlParseError> errors = [];

        Type baseNodeType = typeof(BaseNode);
        Type[] validNodes = baseNodeType.Assembly
            .GetTypes()
            .Where(x => !x.IsAbstract && x.IsSubclassOf(baseNodeType))
            .ToArray();

        XmlSerializer serializer = new XmlSerializer(typeof(CsmlNode), validNodes);
        serializer.UnknownElement += (s, e) =>
        {
            errors.Add(new CsmlParseError(CsmlDiagnostics.ParseError, e.LineNumber, "[UNKNOWN ELEMENT]"));
        };

        serializer.UnknownAttribute += (s, e) =>
        {
            errors.Add(new CsmlParseError(CsmlDiagnostics.ParseError, e.LineNumber, "[UNKNOWN ATTRIBUTE]"));
        };

        serializer.UnknownNode += (s, e) =>
        {
            errors.Add(new CsmlParseError(CsmlDiagnostics.ParseError, e.LineNumber, "[UNKNOWN NODE]"));
        };

        serializer.UnreferencedObject += (s, e) =>
        {
            errors.Add(new CsmlParseError(CsmlDiagnostics.ParseError, null, "[UNREFERENCED OBJECT]"));
        };

        CsmlNode? parsedResult = null;
        try
        {
            XDocument xdoc = XDocument.Parse(xml, LoadOptions.SetLineInfo);
            foreach (XElement? element in xdoc.Descendants())
            {
                IXmlLineInfo lineInfo = element;
                element.SetAttributeValue(CsmlConstants.LineNumberMetadataAttribute, lineInfo.LineNumber);
            }

            using XmlReader reader = xdoc.CreateReader();
            parsedResult = serializer.Deserialize(reader) as CsmlNode;

            if (parsedResult != null)
            {
                ObjectValidator.Validate(parsedResult, errors);
            }
        }
        catch (XmlException xmlException)
        {
            errors.Add(new CsmlParseError(CsmlDiagnostics.XmlParseException, xmlException.LineNumber, xmlException.Message));
        }
        catch (Exception exception)
        {
            errors.Add(new CsmlParseError(CsmlDiagnostics.UnexpectedParseException, null, exception.Message));
        }

        return new CsmlParseResult(parsedResult, errors);
    }
}
