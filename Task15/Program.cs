using System;
using System.Collections.Generic;
using System.Linq;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine(Attempt1_BruteForce(new int[] { -1, 0, 1, 2, -1, -4 }).AndPrint());
//            Console.WriteLine(Attempt1_BruteForce(new int[] { -1, 0, 1 }).AndPrint());
//            Console.WriteLine(Attempt1_BruteForce(new int[] { -1, 0, 1, 0 }).AndPrint());
//            Console.WriteLine(Attempt1_BruteForce(new int[] { 0, 0, 0, 0 }).AndPrint());
//            Console.WriteLine(Attempt1_BruteForce(new int[] { -2, 0, 1, 1, 2 }).AndPrint());
//            
//            Console.WriteLine("============");
//            
//            Console.WriteLine(Attempt2_TwoSum_ThenOne(new int[] { -1, 0, 1, 2, -1, -4 }).AndPrint());
//            Console.WriteLine(Attempt2_TwoSum_ThenOne(new int[] { -1, 0, 1 }).AndPrint());
//            Console.WriteLine(Attempt2_TwoSum_ThenOne(new int[] { -1, 0, 1, 0 }).AndPrint());
//            Console.WriteLine(Attempt2_TwoSum_ThenOne(new int[] { 0, 0, 0, 0 }).AndPrint());
//            Console.WriteLine(Attempt2_TwoSum_ThenOne(new int[] { -2, 0, 1, 1, 2 }).AndPrint());
//            
//            Console.WriteLine("============");
            
            Console.WriteLine(Attempt3_CorrectSolution(new int[] { -1, 0, 1, 2, -1, -4 }).AndPrint());
            Console.WriteLine(Attempt3_CorrectSolution(new int[] { -1, 0, 1 }).AndPrint());
            Console.WriteLine(Attempt3_CorrectSolution(new int[] { -1, 0, 1, 0 }).AndPrint());
            Console.WriteLine(Attempt3_CorrectSolution(new int[] { 0, 0, 0, 0 }).AndPrint());
            Console.WriteLine(Attempt3_CorrectSolution(new int[] { -2, 0, 1, 1, 2 }).AndPrint());
        }

        private static IList<IList<int>> Attempt3_CorrectSolution(int[] nums)
        {
            var list = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
                return list;
            
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; ++i)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        list.Add(new List<int>{ nums[i], nums[left], nums[right] });
                        
                        // Handle duplicates
                        var leftValue = nums[left];
                        while (left < right && nums[left] == leftValue) left++;
                        var rightValue = nums[right];
                        while (left < right && nums[right] == rightValue) right--;
                    } 
                    else if (sum < 0)
                        left++;
                    else
                        right--;
                }

                while (i + 1 < nums.Length && nums[i] == nums[i + 1]) i++;
            }
            
            return list;
        }

        private static IList<IList<int>> Attempt2_TwoSum_ThenOne(int[] nums)
        {
            List<List<int>> finalResult = new List<List<int>>();

            /*
             * Key is a sum of integers.
             * Value is a list, which has two indexes of those numbers, which sum equals to the key of the dictionary
             */
            Dictionary<int, List<(int, int)>> result1 = new Dictionary<int, List<(int, int)>>();
            List<int> foundIndexCombination = new List<int>();

            // step 1: calculate two sums
            for (int i = 0; i < nums.Length; i++)
            for (int j = i + 1; j < nums.Length; j++)
            {
                var sum = nums[i] + nums[j];
                if (result1.ContainsKey(sum))
                    result1[sum].Add((i, j));
                else
                    result1.Add(sum, new List<(int, int)>{(i, j)});
            }

            // step 2: find a pair where (0 - element) is the key in result1 dictionary. If found element's indexes are less than current elemnt's index then skip to avoid duplicates
            for (int i = 0; i < nums.Length; i++)
            {
                var searchingForElem = 0 - nums[i];
                if (!result1.ContainsKey(searchingForElem))
                    continue;
                
                var matchingList = result1[searchingForElem];
                foreach (var indexes in matchingList)
                {
                    var j = indexes.Item1;
                    var k = indexes.Item2;
                    bool unique = true;
                    foreach (var result in finalResult)
                    {
                        var combi1 = result[0] == nums[i]
                                     && result[1] == nums[j]
                                     && result[2] == nums[k];
                        var combi2 = result[0] == nums[j]
                                     && result[1] == nums[k]
                                     && result[2] == nums[i];
                        var combi3 = result[0] == nums[k]
                                     && result[1] == nums[i]
                                     && result[2] == nums[j];
                        var combi4 = result[0] == nums[i]
                                     && result[1] == nums[k]
                                     && result[2] == nums[j];
                        var combi5 = result[0] == nums[j]
                                     && result[1] == nums[i]
                                     && result[2] == nums[k];
                        var combi6 = result[0] == nums[k]
                                     && result[1] == nums[j]
                                     && result[2] == nums[i];
                        if (combi1 || combi2 || combi3 || combi4 || combi5 || combi6)
                        {
                            unique = false;
                            break;
                        }
                    }

                    if (!unique)
                    {
                        continue;
                    }
                    
                
                    var indexCombination = i + indexes.Item1 + indexes.Item2;
                    if (indexes.Item1 > i && indexes.Item2 > i)
                    {
                        finalResult.Add(new List<int> {nums[i], nums[indexes.Item1], nums[indexes.Item2]});
                        foundIndexCombination.Add(indexCombination);
                    }
                }

            }

            return DistinctBy(finalResult
                .Select(x => new AAA {A = x[0], B = x[1], C = x[2]}), x => new {x.A, x.B, x.C})
                .Select(x => (IList<int>) new List<int> {x.A, x.B, x.C})
                .ToList();
        }
        
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        class AAA
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
        }

        private static IList<IList<int>> Attempt1_BruteForce(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            List<int> foundIndexCombination = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        int indexCombination = i + j + k;
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            if (foundIndexCombination.Contains(indexCombination))
                                continue;

                            bool unique = true;
                            foreach (var result in results)
                            {
                                if (result[0] == nums[i] && result[1] == nums[j] && result[2] == nums[k])
                                {
                                    unique = false;
                                    break;
                                }
                            }

                            if (unique)
                            {
                                results.Add(new List<int>{ nums[i], nums[j], nums[k]});
                                foundIndexCombination.Add(indexCombination);
                            }
                        }
                    }
                }
                
            }

            return results;
        }
    }

    static class Helper
    {
        public static string AndPrint(this List<List<int>> lists)
        {
            return string.Join("||", lists.Select(item => string.Join(", ", item)));
        }
        public static string AndPrint(this IList<IList<int>> lists)
        {
            return string.Join("||", lists.Select(item => string.Join(", ", item)));
        }
    }
}