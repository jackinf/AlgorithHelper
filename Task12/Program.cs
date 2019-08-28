using System;

namespace Task12
{
    /// <summary>
    /// https://leetcode.com/problems/integer-to-roman/
    /// Convert integer number to roman
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt1(10));
            Console.WriteLine(Attempt1(3));
            Console.WriteLine(Attempt1(4));
            Console.WriteLine(Attempt1(9));
            Console.WriteLine(Attempt1(58));
            Console.WriteLine(Attempt1(1994));
        }

        private static string Attempt1(int num)
        {
            var result = "";
            var digits = Math.Floor(Math.Log10(num) + 1);

            var thousands = num / 1000;
            var hundreds = num / 100 % 10;
            var tens = num / 10 % 10;
            var ones = num / 1 % 10;

            if (digits >= 4)
                result += ConvertNumberToRomanLetter(thousands, "M", "", "");
            if (digits >= 3)
                result += ConvertNumberToRomanLetter(hundreds, "C", "D", "M");
            if (digits >= 2)
                result += ConvertNumberToRomanLetter(tens, "X", "L", "C");
            result += ConvertNumberToRomanLetter(ones, "I", "V", "X");

            return result;
        }

        private static string ConvertNumberToRomanLetter(int number, string baseLetter, string nextFiveLetter, string nextTenLetter)
        {
            switch (number)
            {
                case 0: return "";
                case 1: return baseLetter;
                case 2: return $"{baseLetter}{baseLetter}";
                case 3: return $"{baseLetter}{baseLetter}{baseLetter}";
                case 4: return $"{baseLetter}{nextFiveLetter}";
                case 5: return nextFiveLetter;
                case 6: return $"{nextFiveLetter}{baseLetter}";
                case 7: return $"{nextFiveLetter}{baseLetter}{baseLetter}";
                case 8: return $"{nextFiveLetter}{baseLetter}{baseLetter}{baseLetter}";
                case 9: return $"{baseLetter}{nextTenLetter}";
                default: throw new Exception();
            }
        }
    }
}