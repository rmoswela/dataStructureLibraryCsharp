using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
  public class CourseMasterDSAChallenges
  {
    //Time and Space Complexity is O(n) - Linear time and space usage
    public string Reverse(string str)
    {
      var newStr = new char[str.Length];
      for (int index = str.Length - 1, count = 0; index >= 0; index--)
      {
        newStr[count++] = str[index];
      }

      return new string(newStr);
    }

    //Time and Space Complexity is 0(n) - Linear time and space usage
    public int[] MergeSortedArrays(int[] arr1, int[] arr2)
    {
      int i = 0, j = 0, loop = 0;
      var results = new int[arr1.Length + arr2.Length];
      while (loop < results.Length)
      {
        if (j >= arr2.Length || arr1.Length > 0 && arr1[i] < arr2[j])
        {
          results[loop++] = arr1[i++];
        }
        else
        {
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

    //Time and Space Complexity is 0(n) - Linear time and space utilized
    public int[] TwoSum(int[] nums, int target)
    {
      Hashtable hash = new Hashtable();
      for (int loop = 0; loop < nums.Length; loop++)
      {
        int comp = target - nums[loop];
        if (hash.ContainsKey(comp))
          return new[] { (int)hash[comp], loop };
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

    //Time Complexity is 0(n) and Space is 0(1) - Linear time and Constant use of space
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
    //Brute force solution
    //Time complexity is 0(n*n) and 0(1) space - Quadratic time constant space usage
    public int[] MoveZeroes(int[] nums)
    {
      for (int index = 0, count = 0; index < nums.Length; index++)
      {
        if (nums[count] == 0)
        {
          var countTemp = count;
          var inner = count + 1;
          if (inner < nums.Length && nums[count] == nums[inner])
            count--;
          while (inner < nums.Length)
          {
            SwapValues(nums, inner++, countTemp++);
          }
        }
        count++;
      }
      return nums;
    }

    //The most optimal solution
    //Time complexity 0(n) and 0(1) Space - Linear time and Constant space usage 
    public int[] MoveZeroesOptimal(int[] nums)
    {
      for (int lastNonZeroFoundAt = 0, current = 0; current < nums.Length; current++)
      {
        if (nums[current] != 0)
        {
          //swapping using a tuple - avail in c# 7.0 plus
          (nums[lastNonZeroFoundAt], nums[current]) = (nums[current], nums[lastNonZeroFoundAt++]);
        }
      }

      return nums;
    }

    //helper function to swap values
    private void SwapValues(int[] arr, int value1, int value2)
    {
      var temp = arr[value1];
      arr[value1] = arr[value2];
      arr[value2] = temp;
    }

    /*
     * Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
     * Example1: Input: nums = [1,2,3,1] Output: true
     * Example2: Input: nums = [1,2,3,4] Output: false
     * Example3: Input: nums = [1,1,1,3,3,4,3,2,4,2] Output: true
     * Constraints: 1 <= nums.length <= 105  -109 <= nums[i] <= 109
     */
    //Time and Space complexity is 0(n) - Linear time and space usage
    public bool ContainsDuplicate(int[] nums)
    {
      //hashset used as it doesn't allow duplicate elements
      HashSet<int> hash = new HashSet<int>();
      for (var index = 0; index < nums.Length; index++)
      {
        if (hash.Contains(nums[index]))
          return true;
        hash.Add(nums[index]);
      }
      return false;
    }

    /*
     * Given an array, rotate the array to the right by k steps, where k is non-negative.
     * Example1: Input: nums = [1,2,3,4,5,6,7], k = 3 Output: [5,6,7,1,2,3,4]
     * Explanation: rotate 1 steps to the right: [7,1,2,3,4,5,6] rotate 2 steps to the right: [6,7,1,2,3,4,5] rotate 3 steps to the right: [5,6,7,1,2,3,4]
     * Example2: Input: nums = [-1,-100,3,99], k = 2 Output: [3,99,-1,-100]
     * Explanation: rotate 1 steps to the right: [99,-1,-100,3] rotate 2 steps to the right: [3,99,-1,-100]
     * Constraints: 1 <= nums.length <= 105      -231 <= nums[i] <= 231 - 1    0 <= k <= 105
     * WildCard: Try to come up with as many solutions as you can. There are at least three different ways to solve this problem. Could you do it in-place with O(1) extra space?
     */
    public int[] Rotate(int[] nums, int k)
    {
      var arr = new int[nums.Length];
      for (var index = 0; index < nums.Length; index++)
      {
        var mod = (index + k) % nums.Length;
        arr[mod] = nums[index];
      }
      return arr;
    }

    /*
     * Write a function to find the longest common prefix string amongst an array of strings.
     * If there is no common prefix, return an empty string "". 
     * Example1: Input: strs = ["flower","flow","flight"]      Output: "fl"
     * Example2: Input: strs = ["dog","racecar","car"]         Output: ""
     * Explanation: There is no common prefix among the input strings.
     * Constraints: 1 <= strs.length <= 200       0 <= strs[i].length <= 200      strs[i] consists of only lowercase English letters.
     */
    // Brute force - Horizontal Scanning
    // Time Complexity (0)N*2 - Space complexity (0)1
    public string LongestCommonPrefixSol1(string[] strs)
    {
      if (strs.Length == 0)
        return "";

      var prefix = strs[0];
      for (var outer = 1; outer < strs.Length; outer++)
      {
        //first occurance of prefix in string outer
        while (strs[outer].IndexOf(prefix) != 0)
        {
          //no match remove? remove last character of prefix
          prefix = prefix.Substring(0, prefix.Length - 1);
          if (prefix.Length == 0)
            return "";
        }
      }

      return prefix;
    }

    // Brute force - Vertical Scanning
    // Time Complexity (0)N*2 - Space complexity (0)1
    public string LongestCommonPrefix(string[] strs)
    {
      if (strs.Length == 0)
        return "";

      for (var count = 0; count < strs[0].Length; count++)
      {
        char c = strs[0][count];
        for (var index = 1; index < strs.Length; index++)
        {
          //check if # of characters of first string is equal subsqent string or
          //character in first string is not equal to that from compared string
          if (count == strs[index].Length || strs[index][count] != c)
          {
            return strs[0].Substring(0, count);
          }
        }
      }

      return strs[0];
    }

    /*
     * Function that takes in non-empty array of distinct integers and and integer representing target sum.
     * Function should find all triplets in array that sum to target sum and return two dimensional array of all the triplets.
     * Numbers in each triplet should be ordered in asc and triplets themselves should be ordered in asc order with respect to number they hold
     * If no three numbers sum up to target sum, return empty array.
     * Example: Input: array = [12, 3, 1, 2, -6, 5, -8, 6] targetSum = 0; Output [[-8, 2, 6], [-8, 3, 5],  [-6, 1, 5]]
     */
    //Brute force solution
    //Time Complexity is 2(0)n^2
    public List<int[]> ThreeNumberSumSol1(int[] array, int targetSum)
    {
      //create hashset
      HashSet<int> hash = new HashSet<int>();
      for (var count = 0; count < array.Length; count++)
      {
        hash.Add(array[count]);
      }

      var listOfArr = new List<int[]>();
      for (int outer = 0; outer < array.Length; outer++)
      {
        var tempHash = new HashSet<int>(hash);
        for (int inner = outer + 1; inner < array.Length; inner++)
        {
          var thirdVal = targetSum - array[outer] - array[inner];
          if (tempHash.Contains(thirdVal) && thirdVal != array[outer] && thirdVal != array[inner])
          {
            var arr = new int[] { array[outer], array[inner], thirdVal };
            Array.Sort(arr);
            listOfArr.Add(arr);
          }
          tempHash.Remove(array[inner]);
        }
        hash.Remove(array[outer]);
      }
      for (int count = 0; count < listOfArr.Count; count++)
      {
        for (int inner = count + 1; inner < listOfArr.Count; inner++)
        {
          if (listOfArr[count][0] > listOfArr[inner][0])
          {
            Swap(listOfArr, count, inner);
          }
          if (listOfArr[count][0] == listOfArr[inner][0])
          {
            if (listOfArr[count][1] > listOfArr[inner][1])
            {
              Swap(listOfArr, count, inner);
            }
          }
        }
      }
      return listOfArr;
    }

    public void Swap(IList<int[]> list, int a, int b)
    {
      var temp = list[a];
      list[a] = list[b];
      list[b] = temp;
    }

    //more efficient algorithm
    /*
     * step1: sort the array and create a new list of arrays to add three sum numbers
     * step2: create a two loops with an index and two pointers in array, left(just after the index) and right (end)
     * step3: currentSum = currentNum(index) + left + right;
     * step4: check the currentSum and compare with targetSum the check which pointer to move
     * move left if currentSum is less than targetSum, right if currentSum is greater than target (this is where sorted becomes relevant)
     * step5: do this until you find target sum, when targeSum found the two pointers move at the same time
     * step6: when the left and right pointer cross each other, you move index to next and restart the pointers to left and right
     * step6: once index has passed a number never go back to check it again
     * 
     */
    //Time Complexity is (0)n^2 and Space Complexity is (0)n
    public List<int[]> ThreeNumberSum(int[] array, int targetSum)
    {
      //step 1
      Array.Sort(array);
      var threeSumArr = new List<int[]>();
      //step 2
      for (int index = 0; index < array.Length; index++)
      {
        var left = index + 1;
        var right = array.Length - 1;
        while (left < right)
        {
          //step 3
          var currentSum = array[index] + array[left] + array[right];
          //step 4, 5 ,6
          if (currentSum == targetSum)
          {
            threeSumArr.Add(new int[] { array[index], array[left], array[right] });
            left++;
            right--;
          }
          else if (currentSum < targetSum)
          {
            left++;
          }
          else
            right--;
        }
      }
      return threeSumArr;
    }

    /*
     * Write a function that takes in two non-empty arrays of integers, finds the pair of numbers (one from each array) whose absolute difference is closest to zero.
     * Then returns an array containing these two numbers, with the number from the first array in the first position
     * Note that the absolute difference of two integers is the distance between them on the real number line. 
     * For example, the absolute difference of -5 and 5 is 10, and the absolute difference of -5 and -4 is 1.
     * You can assume that there will only be one pair of numbers with the smallest difference
     * Example1: Input arrayOne = [-1, 5, 10, 20, 28, 3] arrayTwo = [26, 134, 135, 15, 17] output = [28, 26]
     */
    //brute force solution
    // Time complexity is (0)n^2 and Space Complexity is (0)n
    public int[] SmallestDifferenceSol1(int[] arrayOne, int[] arrayTwo)
    {
      int closestToZero = int.MaxValue;
      var arrVal = new int[2];
      for (int indexOne = 0; indexOne < arrayOne.Length; indexOne++)
      {
        for (int indexTwo = 0; indexTwo < arrayTwo.Length; indexTwo++)
        {
          var diff = AbsoluteDifference(arrayOne[indexOne], arrayTwo[indexTwo]);
          if (diff < closestToZero)
          {
            arrVal[0] = arrayOne[indexOne];
            arrVal[1] = arrayTwo[indexTwo];
            closestToZero = diff;
          }
        }
      }
      return arrVal;
    }

    //Effienct solution
    //Time Complexity is (0)n+m and space complexity is (0)2 which (0)1
    //sorting this makes the function have a time Complexity of O(n log n)
    //ref https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=net-6.0#system-array-sort(system-array)
    public int[] SmallestDifference (int[] arrayOne, int[] arrayTwo)
    {
      Array.Sort(arrayOne);
      Array.Sort(arrayTwo);
      var closestToZero = AbsoluteDifference(arrayOne[0], arrayTwo[0]);
      int indexOne = 0, indexTwo = 0;
      var result = new int[] { arrayOne[0], arrayTwo[0]};
      while (indexOne < arrayOne.Length && indexTwo < arrayTwo.Length)
      {
        var tempVal = AbsoluteDifference(arrayOne[indexOne], arrayTwo[indexTwo]);
        if (arrayOne[indexOne] > arrayTwo[indexTwo])
        {
          if (tempVal < closestToZero)
          {
            closestToZero = tempVal;
            result[0] = arrayOne[indexOne];
            result[1] = arrayTwo[indexTwo];
          }
          indexTwo++;
        }
        else if (arrayOne[indexOne] < arrayTwo[indexTwo])
        {
          if (tempVal < closestToZero)
          {
            closestToZero = tempVal;
            result[0] = arrayOne[indexOne];
            result[1] = arrayTwo[indexTwo];
          }
          indexOne++;
        }
        else
        {
          closestToZero = AbsoluteDifference(arrayOne[indexOne], arrayTwo[indexTwo]);
          result[0] = arrayOne[indexOne];
          result[1] = arrayTwo[indexTwo];
          return result;
        }
      }
      return result;
    }

    private int AbsoluteDifference(int numOne, int numTwo)
    {
      int diff;
      if (numOne < 0 && numTwo >= 0)
      {
        numOne = Math.Abs(numOne);
        diff = numOne + numTwo;
      }
      else if (numTwo < 0 && numOne >= 0)
      {
        numTwo = Math.Abs(numTwo);
        diff = numOne + numTwo;
      }
      else
        diff = Math.Abs(numOne - numTwo);
      return diff;
    }
      

    /*
     * Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
     * Return the array in the form [x1,y1,x2,y2,...,xn,yn].
     * Example1: Input: nums = [2,5,1,3,4,7], n = 3 Output: [2,3,5,4,1,7] 
     * Explanation: Since x1=2, x2=5, x3=1, y1=3, y2=4, y3=7 then the answer is [2,3,5,4,1,7].
     * Example2: Input: nums = [1,2,3,4,4,3,2,1], n = 4 Output: [1,4,2,3,3,2,4,1]
     * Example3: Input: nums = [1,1,2,2], n = 2 Output: [1,2,1,2]
     * Constraints: 1 <= n <= 500    nums.length == 2n    1 <= nums[i] <= 10^3
     */
    //Time Complexity and Space Complexity is (0)n
    public int[] Shuffle(int[] nums, int n)
    {
      var arr = new int[nums.Length];
      int index = 0, x = 0, y = n;
      while (index < nums.Length) {
        if (index % 2 == 0) {
          arr[index] = nums[x++];
        }
        else {
          arr[index] = nums[y++];
          index++;
        }
      }
      return arr;
    }

    /*
     * You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the i​​​​​​​​​​​th​​​​ customer has in the j​​​​​​​​​​​th​​​​ bank. Return the wealth that the richest customer has.
     * A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth
     * Example1: Input: accounts = [[1,2,3],[3,2,1]] Output: 6
     * Explanation: 1st customer has wealth = 1 + 2 + 3 = 6   2nd customer has wealth = 3 + 2 + 1 = 6
     * Both customers are considered the richest with a wealth of 6 each, so return 6.
     * Example2: Input: accounts = [[1,5],[7,3],[3,5]] Output: 10 
     * Explanation:  1st customer has wealth = 6   2nd customer has wealth = 10   3rd customer has wealth = 8
     * The 2nd customer is the richest with a wealth of 10.
     * Example3: Input: accounts = [[2,8,7],[7,1,3],[1,9,5]] Output: 17
     * Constraints: m == accounts.length   n == accounts[i].length   1 <= m, n <= 50 1 <= accounts[i][j] <= 100
     */
    //Brute force solution
    //Time Complexity is (0)n^2 and Space compelxity is (0)1
    public int MaximumWealth(int[][] accounts)
    {
      var max = 0;
      for (int cust = 0; cust < accounts.Length; cust++) {
        var sum = 0;
        for (int bank = 0; bank < accounts[cust].Length; bank++) {
          sum += accounts[cust][bank];
        }
        max = Math.Max(sum, max);
      }
     return max;
    }

    /*
     * There is a programming language with only four operations and one variable X:
     * ++X and X++ increments the value of the variable X by 1.
     * --X and X-- decrements the value of the variable X by 1.
     * Initially, the value of X is 0. Given an array of strings operations containing a list of operations, return the final value of X after performing all the operations.
     * Example1: Input: operations = ["--X","X++","X++"] Output: 1
     * Explanation: The operations are performed as follows: Initially, X = 0.
     * --X: X is decremented by 1, X =  0 - 1 = -1.
     * X++: X is incremented by 1, X = -1 + 1 =  0.
     * X++: X is incremented by 1, X =  0 + 1 =  1.
     * Example2: Input: operations = ["X++","++X","--X","X--"] Output: 0
     * Explanation: The operations are performed as follows: Initially, X = 0.
     * X++: X is incremented by 1, X = 0 + 1 = 1.
     * ++X: X is incremented by 1, X = 1 + 1 = 2.
     * --X: X is decremented by 1, X = 2 - 1 = 1.
     * X--: X is decremented by 1, X = 1 - 1 = 0.
     * Constraints: 1 <= operations.length <= 100  operations[i] will be either "++X", "X++", "--X", or "X--".
     */
    //Time Complexity is (0)n and Space Complexity is (0)1
    public int FinalValueAfterOperations(string[] operations) {
      var output = 0;
      for (int count = 0; count < operations.Length; count++){
         if (operations[count][0] == '-' || operations[count][1] == '-')
            output--;
         else
            output++;
      }
      return output;  
    }
  }
}
