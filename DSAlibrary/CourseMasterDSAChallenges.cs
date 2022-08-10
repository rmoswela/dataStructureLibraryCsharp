using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  public class CourseMasterDSAChallenges
  {
    public string Reverse(string str)
    {
      var newStr = new char[str.Length];
      for (int index = str.Length - 1, count = 0; index >= 0; index--)
      {
        newStr[count++] = str[index];
      }

      return new string(newStr);
    }

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

    public int MaxSubArray(int[] nums)
    {
      //int prev = nums[0], next = 0, max = 0;
      int start = 0, end = 0, max = 0;
      for (int count = 0, loop = nums.Length -1; count < nums.Length; count++)
      {
        //var curr = nums[count];
        //prev = prev + curr;
        //next = next + curr;
        start += nums[count];
        end += nums[loop--];
        //max = Math.Max(start, end);
        if (start > end) {
          max = Math.Max(start, max);
        }
        else
        {
          max = Math.Max(max, end);
        }
      }

      return max;
    }
  }
}
