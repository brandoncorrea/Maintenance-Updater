using System.Linq;

namespace Maintenance_Updater.MaintParser
{
    public class MaintTable
    {
        public MaintColumn[] Columns { get; private set; }
        public string Identifier { get; private set; }

        public MaintTable(IGrouping<string, string> group)
        {
            Columns = group
                .Select(g => new MaintColumn(g))
                .ToArray();
            
            int fillerNum = 1;
            foreach (var filler in Columns.Where(c => c.Name == "FILLER"))
                filler.SetName($"FILLER_{fillerNum++}");
        }

        internal void SetIdentifier(string identifier)
        {
            Identifier = identifier;
        }

        public MaintColumn GetColumn(string name)
        {
            return Columns
                .Where(c => c.Name == name)
                .FirstOrDefault();
        }
    }
}
