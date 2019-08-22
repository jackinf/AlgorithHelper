using System;

namespace Task08
{
    /// <summary>
    /// 8. String to Integer (atoi)
    /// https://leetcode.com/problems/string-to-integer-atoi/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt1("42"));
            Console.WriteLine(Attempt1("   -42"));
            Console.WriteLine(Attempt1("4193 with words"));
            Console.WriteLine(Attempt1("words and 987"));
            Console.WriteLine(Attempt1("-91283472332"));
            Console.WriteLine(Attempt1("+1"));
            Console.WriteLine(Attempt1("-2147483647"));
        }
        
        private static int Attempt1(string str)
        {
            var result = 0;
            var arr = str.ToCharArray();
            if (arr.Length == 0)
                return 0;

            var minusMultiplier = 1;
            var canBePlus = true;
            var canBeMinus = true;

            foreach (var item in arr)
            {
                if (item == ' ' && canBeMinus)
                    continue;
                
                if (item == '-' && canBeMinus)
                {
                    minusMultiplier = -1;
                    canBePlus = false;
                    canBeMinus = false;
                    continue;
                }

                if (item == '+' && canBePlus)
                {
                    canBePlus = false;
                    canBeMinus = false;
                    continue;
                }
                
                canBePlus = false;
                canBeMinus = false;

                if ('0' > item || '9' < item)
                {
                    return result * minusMultiplier;
                }
                
                var semi = (long)result * 10 + item - '0';
                if (semi * minusMultiplier <= int.MinValue)
                    return int.MinValue;
                if (minusMultiplier == 1 && semi >= int.MaxValue)
                    return int.MaxValue;
                
                result = result * 10 + item - '0';
            }

            return result * minusMultiplier;
        }
    }
}