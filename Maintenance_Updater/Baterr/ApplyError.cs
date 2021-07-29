using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Maintenance_Updater.Baterr
{
    public static class ApplyError
    {
        public static Dictionary<int, string> ErrorCode { get; private set; }

        public static void Initialize(string fileName)
        {
            ErrorCode = new Dictionary<int, string>();

            IEnumerable<XElement> codes = XDocument
                .Load(fileName)
                .Root
                .Element("ApplyError")
                .Elements("Code");
            
            foreach (XElement code in codes)
                ErrorCode.Add(
                    int.Parse(code.Attribute("id").Value),
                    code.Attribute("description").Value);
        }
    }
}
