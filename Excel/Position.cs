using System;
using System.Text.RegularExpressions;

namespace Excel
{
    public class Position
    {
        public int Row;
        public int Column;
        public string Name;

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
            Name = Utils.ConvertToColumnFromNumber(column) + row;
        }

        public Position(string name)
        {
            string columnPattern = @"[A-Z]+";
            string rowPattern = @"[0-9]+";
            try
            {
                var regex = new Regex(columnPattern, RegexOptions.IgnoreCase);
                var columnMatch = regex.Match(name).Value;

                regex = new Regex(rowPattern, RegexOptions.IgnoreCase);
                var rowMatch = regex.Match(name).Value;
                Row = Convert.ToInt32(rowMatch);
                Column = Utils.ConvertToNumberFromColumn(columnMatch);
            }
            catch { }
            Name = name;
        }
    }
}
