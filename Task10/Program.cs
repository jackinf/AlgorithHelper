using System;

namespace Task10
{
    /// <summary>
    /// https://leetcode.com/problems/container-with-most-water/
    /// Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
    /// n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0).
    /// Find two lines, which together with x-axis forms a container, such that the container contains the most water.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Attempt1(new int[] { 1,8,6,2,5,4,8,3,7 }));
            Console.WriteLine(Solution(new int[] { 1,8,6,2,5,4,8,3,7 }));
        }

        /// <summary>
        /// Brute force
        /// </summary>
        private static int Attempt1(int[] height)
        {
            int maxArea = 0;
            for (int i = 1; i < height.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i == j)
                        continue;

                    var smallerTop = Math.Min(height[i], height[j]);
                    var area = smallerTop * Math.Abs(i-j);
                    if (area > maxArea)
                        maxArea = area;
                }
            }

            return maxArea;
        }

        private static int Solution(int[] height)
        {
            int maxArea = 0, left = 0, right = height.Length - 1;
            while (left < right)
            {
                var smallerTop = Math.Min(height[left], height[right]);
                var width = right - left;
                var area = smallerTop * width;
                maxArea = Math.Max(maxArea, area);
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }
    }
}