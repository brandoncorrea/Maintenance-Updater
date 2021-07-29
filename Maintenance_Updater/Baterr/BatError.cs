using System.Collections.Generic;

namespace Maintenance_Updater.Baterr
{
    public class BatError
    {
        public Dictionary<string, string> Fields { get; private set; } = new Dictionary<string, string>();
        public string ErrorDescription { get; private set; }
        public string Line { get; private set; }

        public BatError(string line)
        {
            Line = line;
            SetFields();
            SetErrorDescription();
        }

        private void SetErrorDescription()
        {
            try
            {
                int errCode = int.Parse(Fields["APPLY_ERROR"]);
                ErrorDescription = ApplyError.ErrorCode[errCode];
            }
            catch { ErrorDescription = ""; }
        }

        private void SetFields()
        {
            string id = Line.Substring(0, BaterrFormat.IdentifierLength);
            Fields.Add("Identifier", id);

            try
            {
                FormatLine fmt = BaterrFormat.LineFormats[id];
                int index = BaterrFormat.IdentifierLength;
                foreach (var field in fmt.Fields)
                {
                    string colName = field.Key;
                    byte length = field.Value;
                    Fields.Add(colName, Line.Substring(index, length));
                    index += length;
                }
            }
            catch { /* Do Nothing */ }
        }
    }
}
