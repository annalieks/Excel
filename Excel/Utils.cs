using System;

namespace Excel
{
    public class Utils
    {
        const int baseNum = 26;
        public static string ConvertToColumnFromNumber(int value)
        {
            string columnString = "";
            value++;
            while (value > 0)
            {
                var currentLetterNumber = (value - 1) % baseNum;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                value = (value - (currentLetterNumber + 1)) / baseNum;
            }
            return columnString;
        }

        public static int ConvertToNumberFromColumn(string column)
        {
            int value = 0;
            for (int i = column.Length - 1; i >= 0; i--)
            {
                int colNum = column[i] - 65;
                value += colNum * (int)Math.Pow(baseNum, column.Length - (i + 1));
            }
            return value;
        }
    }
}
