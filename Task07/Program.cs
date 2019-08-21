using System;
using System.Linq;

namespace Task07
{
    /// <summary>
    /// Reverse integer
    /// https://leetcode.com/problems/reverse-integer/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt2(123));
            Console.WriteLine(Attempt2(-123));
            Console.WriteLine(Attempt2(-120));
            Console.WriteLine(Attempt2(-2147483648));
        }
        
        /// <summary>
        /// My solution
        /// </summary>
        private static int Attempt1(int x)
        {
            if (x >= Int32.MaxValue || x <= Int32.MinValue)
            {
                return 0;
            }
            
            var absValue = Math.Abs(x);
            var sign = Math.Sign(x);
            if (CheckIfOverflow(absValue))
            {
                return 0;
            }

            var reversedStr = string.Concat($"{absValue}".Reverse());
            if (int.TryParse(reversedStr, out var reversed))
            {
                if (CheckIfOverflow(absValue))
                {
                    return 0;
                }

                return reversed * sign;
            }

            return 0;
        }
        
        /// <summary>
        /// Correct solution
        /// </summary>
        private static int Attempt2(int x) 
        {
            var rev = 0;
            while (x != 0) 
            {
                var pop = x % 10;
                x /= 10;
                if (rev > Int32.MaxValue/10 || (rev == Int32.MaxValue / 10 && pop > 7)) 
                    return 0;
                if (rev < Int32.MinValue/10 || (rev == Int32.MinValue / 10 && pop < -8)) 
                    return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }

        private static bool CheckIfOverflow(int absValue)
        {
            var maxValue = Math.Pow(2, 31);
            return absValue < -maxValue || absValue > maxValue - 1;
        }
    }
}