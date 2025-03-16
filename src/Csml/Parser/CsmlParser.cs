using Csml.Parser.Nodes;
using System.Xml;
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
            errors.Add(new CsmlParseError("[UNKNOWN ELEMENT]", e.LineNumber));
        };

        serializer.UnknownAttribute += (s, e) =>
        {
            errors.Add(new CsmlParseError("[UNKNOWN ATTRIBUTE]", e.LineNumber));
        };

        serializer.UnknownNode += (s, e) =>
        {
            errors.Add(new CsmlParseError("[UNKNOWN NODE]", e.LineNumber));
        };

        serializer.UnreferencedObject += (s, e) =>
        {
            errors.Add(new CsmlParseError("[UNREFERENCED OBJECT]", null));
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

            XmlReader reader = xdoc.CreateReader();
            parsedResult = serializer.Deserialize(reader) as CsmlNode;
        }
        catch (XmlException xmlException)
        {
            errors.Add(new CsmlParseError(xmlException.Message, xmlException.LineNumber));
        }
        catch (Exception exception)
        {
            errors.Add(new CsmlParseError(exception.Message, null));
        }

        return new CsmlParseResult(parsedResult, errors);
    }
}
