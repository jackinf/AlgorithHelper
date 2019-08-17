using System;
using System.Linq;

namespace Task04
{
    class Program
    {
        /// <summary>
        /// There are two sorted arrays nums1 and nums2 of size m and n respectively.
        /// Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
        /// You may assume nums1 and nums2 cannot be both empty.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var arr1 = new[] {1, 3, 8, 9, 15};
            var arr2 = new[] {7, 11, 18, 19, 21, 25};
            var result = new Program().Attempt3(arr1, arr2);
            Console.WriteLine(result);
        }
        
        public double Attempt3(int[] nums1, int[] nums2)
        {
            var x = nums1.Length;
            var y = nums2.Length;

            if (x > y)
                return Attempt3(nums2, nums1);

            var low = 0;
            var high = x;
            while (low <= high)
            {
                var partitionX = (low + high) / 2;
                var partitionY = (x + y + 1) / 2 - partitionX;

                var maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
                var minRightX = partitionX == x ? int.MaxValue : nums1[partitionX];
                var maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
                var minRightY = partitionY == y ? int.MaxValue : nums2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    if (x + y % 2 == 0)
                    {
                        return (double)(Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    high = partitionX - 1;
                }
                else
                {
                    low = partitionX + 1;
                }
            }
            
            throw new ArgumentException();
        }
        
        private double Attempt2(int[] nums1, int[] nums2) 
        {
            var combined = GetCombined(nums1, nums2).ToList();
            combined.Sort();
            //Array.Sort(combined);
            return CalculateMedian(combined.ToArray());
        }
        
        private int[] GetCombined(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0) 
            {
                return new int[] {};
            }
            else if (nums1.Length != 0 && nums2.Length != 0)
            {
                return nums1.Concat(nums2).ToArray();
            }
            else if (nums1.Length != 0 && nums2.Length == 0)
            {
                return nums1;
            }
            else if (nums1.Length == 0 && nums2.Length != 0)
            {
                return nums2;
            }
        
            return new int[] {};
        }
    
        private double CalculateMedian(int[] combined) 
        {
            if (combined.Length % 2 == 0)
            {
                int middleIndex = combined.Length / 2;
                double sum = (double)(combined[middleIndex - 1] + combined[middleIndex]);
                double median = sum / 2;
                return median;
            } 
            else 
            {
                int lengthPlus1 = ((combined.Length + 1)/2)-1;
                double median = combined[lengthPlus1];
                return median;
            }
        }
    }
}