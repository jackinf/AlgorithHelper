import sys
from typing import List


class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        if nums is None or len(nums) == 0:
            return 0

        list.sort(nums)

        closest = sys.maxsize
        closest_diff = sys.maxsize
        for i in range(0, len(nums)):
            if closest == target:
                break

            left = i + 1
            right = len(nums) - 1
            while left < right:
                the_sum = nums[i] + nums[left] + nums[right]

                diff = abs(the_sum - target)
                if diff < closest_diff:
                    closest = the_sum
                    closest_diff = diff
                if diff == 0:
                    break  # best found

                if the_sum < target:
                    left += 1
                elif the_sum > target:
                    right -= 1
            i += 1

        return closest


def print_closest(i: int):
    print(f'final closest to the target: {i}')


solution = Solution()
print_closest(solution.threeSumClosest([-1, 2, 1, -4], 1))
