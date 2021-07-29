using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance_Updater.MaintParser
{
    public static class HOSTDN
    {
        public static Dictionary<string, MaintTable> Tables { get; private set; }

        public static void Initialize(string fileName)
        {
            Tables = new Dictionary<string, MaintTable>();

            // Group lines by the tables they reference
            IEnumerable<IGrouping<string, string>> tableGroups = File.ReadAllLines(fileName).Where(
                    i => i.Length > 1   // Has Data
                    && i[0] != '#'// Not a comment
                    && i.Contains('.')) // Is a table
                .GroupBy(
                    i => GetTableFromLine(i), i => i);

            // Add tables to Tables property
            foreach (IGrouping<string, string> group in tableGroups)
                Tables.Add(group.Key, new MaintTable(group));

            // Set identifier properties in Tables collection
            Dictionary<string, string> identifiers = GetIdentifiers(fileName);
            foreach (var item in identifiers)
                if (Tables.Keys.Contains(item.Key))
                    Tables[item.Key].SetIdentifier(item.Value);
        }

        private static Dictionary<string, string> GetIdentifiers(string fileName)
        {
            Dictionary<string, string> identifiers = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(fileName);
            
            for(int i = 0; i < lines.Length - 1; i++)
            {
                string line = lines[i];
                string table = GetTableFromLine(lines[i + 1]);
                string identifier = line.Length >= 14 ? line.Substring(0, 14) : null;
                if (identifier == "# Column 1 - 2"
                    && table != null)
                {
                    string id = line
                        .Substring(15, line.Length - 15)
                        .Trim('(', ')', ' ');
                    id = id.Length >= 2 ? 
                        id.Substring(id.Length - 2, 2) 
                        : null;

                    if (id != null)
                        identifiers.Add(table, id);
                }
            }

            return identifiers;
        }

        private static string GetTableFromLine(string line)
        {
            if (line.Contains('.') && line[0] != '#')
                return line.Substring(0, line.IndexOf('.'));
            return null;
        }

        public static string GetIdentifier(string tableName)
        {
            return Tables
                .Where(t => t.Key == tableName)
                .FirstOrDefault()
                .Value
                .Identifier;
        }

        public static MaintTable GetTable(string identifier)
        {
            return Tables
                .Where(t => t.Value.Identifier == identifier)
                .FirstOrDefault()
                .Value;
        }
    }
}
