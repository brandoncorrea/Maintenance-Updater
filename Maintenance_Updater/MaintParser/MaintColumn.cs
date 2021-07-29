using System.Linq;

namespace Maintenance_Updater.MaintParser
{
    public class MaintColumn
    {
        public int Length { get; private set; }
        public string Name { get; private set; }

        public MaintColumn(string line)
        {
            int spacesStart = line.IndexOf(
                line
                .First(c => string.IsNullOrWhiteSpace(c.ToString())));
            
            Length = int.Parse(
                line
                .Substring(spacesStart, line.Length - spacesStart)
                .Trim());
            
            // Get the name of the column
            int nameStart = line.IndexOf('.') + 1;
            int nameLength = spacesStart - nameStart;
            Name = line.Substring(nameStart, nameLength);
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
