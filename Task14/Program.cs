using System;

namespace Task14
{
    /// <summary>
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// https://leetcode.com/problems/longest-common-prefix/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt1(new [] {"flower", "flow", "flight"}));
            Console.WriteLine(Attempt1(new [] {"dog","racecar","car"}));
            Console.WriteLine(Attempt1(new string[0]));
            Console.WriteLine(Attempt1(new [] {"dlower", "d", "dlight"}));
            Console.WriteLine(Attempt1(new [] {"", "d"}));
        }
        
        private static string Attempt1(string[] strs)
        {
            string longest = "";
            if (strs.Length == 0)
                return longest;

            int i = 0;
            bool doWork = true;
            var firstWord = strs[0];
            
            while (true)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    var nextElement = strs[j];
                    if (nextElement.Length <= i || firstWord.Length <= i)
                    {
                        doWork = false;
                        break;
                    }

                    if (nextElement[i] != firstWord[i])
                    {
                        doWork = false;
                        break;
                    }
                }

                if (!doWork || firstWord.Length <= i)
                    break;

                longest += firstWord[i];
                i++;
            }

            return longest;
        }
    }
}