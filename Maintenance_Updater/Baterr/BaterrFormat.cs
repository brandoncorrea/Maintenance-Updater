using System.Collections.Generic;
using System.Xml.Linq;

namespace Maintenance_Updater.Baterr
{
    public static class BaterrFormat
    {
        public static Dictionary<string, FormatLine> LineFormats { get; private set; } = new Dictionary<string, FormatLine>();
        public static byte IdentifierLength { get; set; }

        public static void Initialize(string fileName)
        {
            XElement format = XDocument
                .Load(fileName)
                .Root
                .Element("Format");

            IdentifierLength = byte.Parse(format.Element("Identifier").Attribute("length").Value);

            foreach (XElement lineEl in format.Elements("Line"))
                LineFormats.Add(
                    lineEl.Attribute("id").Value.PadRight(IdentifierLength, ' '), 
                    new FormatLine(lineEl));
        }
    }
}
