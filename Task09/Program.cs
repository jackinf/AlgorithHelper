using System;
using System.Linq;

namespace Task09
{
    /// <summary>
    /// https://leetcode.com/problems/palindrome-number/
    /// Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt1(12321));
            Console.WriteLine(Attempt1(121));
            Console.WriteLine(Attempt1(-121));
            Console.WriteLine(Attempt1(12344321));
            Console.WriteLine(Attempt1(1252343));
            Console.WriteLine(Attempt1(534787435));
            Console.WriteLine(Attempt1(int.MaxValue));
            Console.WriteLine(Attempt1(int.MinValue));
            
            Console.WriteLine(Solution(12321));
            Console.WriteLine(Solution(121));
            Console.WriteLine(Solution(-121));
            Console.WriteLine(Solution(12344321));
            Console.WriteLine(Solution(1252343));
            Console.WriteLine(Solution(534787435));
            Console.WriteLine(Solution(int.MaxValue));
            Console.WriteLine(Solution(int.MinValue));
        }

        private static bool Attempt1(int x)
        {
            // Edge cases
            if (x < 0) return false;
            if (x == 0) return true;

            var digitCount = Math.Floor(Math.Log10(x) + 1);
            for (int i = 0; i < digitCount / 2; i++)
            {
                var divisor = digitCount - 1;
                var leftNr = x / (int)(Math.Pow(10, divisor - i));
                var rightNr = x % (int)(Math.Pow(10, i+1));

                var leftNrSingle = leftNr % 10;
                var rightNrSingle = rightNr / (int)Math.Pow(10, i);

                if (leftNrSingle != rightNrSingle)
                    return false;
            }

            return true;
        }

        private static bool Solution(int x)
        {
            if(x < 0 || (x % 10 == 0 && x != 0)) {
                return false;
            }
            
            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber /10;
        }
    }
}