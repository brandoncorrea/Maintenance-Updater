using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Maintenance_Updater.Baterr
{
    public class FormatLine
    {
        public Dictionary<string, byte> Fields { get; private set; }

        public FormatLine(XElement el)
        {
            Fields = new Dictionary<string, byte>();
            foreach (XElement field in el.Elements("Field"))
            {
                string name = field.Attribute("name").Value;
                byte b = byte.Parse(field.Attribute("length").Value);
                Fields.Add(name, b);
            }
        }
    }
}