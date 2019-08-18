using System;
using System.Text;

namespace Task06
{
    /// <summary>
    /// ZigZag Conversion
    /// https://leetcode.com/problems/zigzag-conversion/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt2("PAYPALISHIRING", 3));
//            Console.WriteLine(Attempt2("PAYPALISHIRING", 4));
//            Console.WriteLine(Attempt2("PAYPALISHIRING", 5));
        }
        
        /// <summary>
        /// Solution
        /// </summary>
        private static string Attempt2(string s, int numRows) 
        {
            if (numRows == 1) return s;

            var ret = new StringBuilder();
            var n = s.Length;
            var cycleLen = 2 * numRows - 2;

            for (var i = 0; i < numRows; i++) 
            {
                for (var j = 0; j + i < n; j += cycleLen)
                {
                    var letter1 = s[j + i];
                    ret.Append(letter1);
                    var condition1 = i == 0 || i == numRows - 1;
                    var weirdNr = j + cycleLen - i ; // wtf
                    if (condition1 || weirdNr >= n) continue;
                    
                    var letter = s[j + cycleLen - i];
                    ret.Append(letter);
                }
            }
            return ret.ToString();
        }

        private static string Attempt1(string s, int numRows)
        {
            var res = "";
            var sIndex = 0;
            
            var sizeOfCycle = numRows - 1;
            // 3 rows, 4 letters
            // 4 rows, 6 letters
            // 5 rows, 8 letters
            // 6 rows, 10 letters
            // n rows, n x 2 - 2 letters
            var lettersInCycle = numRows * 2 - 2;
            var numColumns = (s.Length +lettersInCycle) / lettersInCycle * sizeOfCycle;
            Console.WriteLine(numColumns);

            var colNr = -1;
            var arr = new char[numRows, numColumns];
            while (sIndex < s.Length)
            {
                colNr++;
                var delta = colNr % (numRows-1);
                if (delta == 0)
                {
                    for (var i = 0; i < numRows; i++)
                    {
                        if (sIndex < s.Length)
                            arr[i, colNr] = s[sIndex++];
                    }
                }
                else
                {
                    var rowIndex = numRows - delta - 1;
                    arr[rowIndex, colNr] = s[sIndex++];
                }
            }

            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j <= colNr; j++)
                {
                    var item = arr[i, j];
                    if (item == '\0')
                        continue;
                    res += item;
                }
            }

            return res;
        }
    }
}