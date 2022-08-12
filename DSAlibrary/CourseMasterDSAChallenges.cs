using System.Collections;
using System;

namespace DataStructures
{
  public class CourseMasterDSAChallenges
  {
    //Time and Space Complexity is O(n)
    public string Reverse(string str)
    {
      var newStr = new char[str.Length];
      for (int index = str.Length - 1, count = 0; index >= 0; index--)
      {
        newStr[count++] = str[index];
      }

      return new string(newStr);
    }

    //Time and Space Complexity is 0(n)
    public int[] MergeSortedArrays(int[] arr1, int[] arr2)
    {
      int i = 0, j = 0, loop = 0;
      var results = new int[arr1.Length + arr2.Length];
      while (loop < results.Length)
      {
        if (j >= arr2.Length || arr1.Length > 0 && arr1[i] < arr2[j]) {
          results[loop++] = arr1[i++];
        }
        else {
          results[loop++] = arr2[j++];
        }
      }
      return results;
    }

    /*
     * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
     * You may assume that each input would have exactly one solution, and you may not use the same element twice.
     * You can return the answer in any order.
     * Example1: Input: nums = [2,7,11,15], target = 9   Output: [0,1]   Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
     * Example2: Input: nums = [3,2,4], target = 6  Output: [1,2]
     * Example3: Input: nums = [3,3], target = 6  Output: [0,1]
     * Constraints: 2 <= nums.length <= 104  -109 <= nums[i] <= 109  -109 <= target <= 109  Only one valid answer exists.
     * Wildcard: Can you come up with an algorithm that is less than O(n2) time complexity
     */

    //Time and Space Complexity is 0(n)
    public int[] TwoSum(int[] nums, int target)
    {
      var hash = new Hashtable();
      for (var loop = 0; loop < nums.Length; loop++)
      {
        var comp = target - nums[loop];
        if (hash.ContainsKey(comp))
          return new int[] {(int) hash[comp], loop};
        hash.Add(nums[loop], loop);
      }
      return null;
    }

    /*
     * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
     * A subarray is a contiguous part of an array.
     * Example1: Input: nums = [-2,1,-3,4,-1,2,1,-5,4]    Output: 6   Explanation: [4,-1,2,1] has the largest sum = 6.
     * Example2: Input: nums = [1]  Output: 1
     * Example3: Input: nums = [5,4,-1,7,8] Output: 23
     * Constraints: 1 <= nums.length <= 105       -104 <= nums[i] <= 104
     * Wildcard: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
     */

    //Time Complexity is 0(n) and Space is 0(1)
    public int MaxSubArray(int[] nums)
    {
      int currentMaxEnding = 0, maxSoFar = int.MinValue;

      for (var count = 0; count < nums.Length; count++)
      {
        currentMaxEnding = currentMaxEnding + nums[count];
        if (maxSoFar < currentMaxEnding)
          maxSoFar = currentMaxEnding;

        if (currentMaxEnding < 0)
          currentMaxEnding = 0;
      }

      return maxSoFar;
    }

    /*
     * Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
     * Note that you must do this in-place without making a copy of the array.
     * Example1: Input: nums = [0,1,0,3,12] Output: [1,3,12,0,0]
     * Example2: Input: nums = [0] Output: [0]
     * Constraint: 1 <= nums.length <= 104    -231 <= nums[i] <= 231 - 1
     * Wildcard: minimize the total number of operations done
     */
    public int[] MoveZeroes(int[] nums)
    {
      for (var count = 0; count < nums.Length; count++)
      {
        Console.WriteLine("Element: {0} Index: {1}", nums[count], count);
        if (nums[count] == 0)
          Array.Copy(nums, count, nums, nums.Length - 1, 1);
      }

      return nums;
    }
  }
}
