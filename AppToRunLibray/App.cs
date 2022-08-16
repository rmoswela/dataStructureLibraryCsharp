using System;
using DataStructures;

namespace AppToRunLibrary
{
  internal class App
  {
    private static void Main(string[] args)
    {
      var arr = new myArray();
      var dsa = new CourseMasterDSAChallenges();
      Console.WriteLine("Array: {0}, Arr Length: {1}", arr, arr.Length);
      var str = dsa.Reverse("Reuben is fuckin good!");
      Console.WriteLine("Original str: Reuben \n Reversed str: {0}", str);
      int[] arr1 = new int[] { 0, 2, 4, 31 }, arr2 = new int[] { 4, 6, 30 };
      var results = dsa.MergeSortedArrays(arr1, arr2);
      Console.WriteLine("Results of the merge: {0}", string.Join(",", results));
      var intArr = new int[] { 2, 7, 11, 15 };
      var twosum = dsa.TwoSum(intArr, 9);
      Console.WriteLine("Values that make target: {0}", string.Join(",", twosum));
      var arrayInt = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
      var subarray = dsa.MaxSubArray(arrayInt);
      Console.WriteLine("Largest sum value: {0}", subarray);
      var nums = new int[] { 0, 1};
      var zeroArr = dsa.MoveZeroesOptimal(nums);
      Console.WriteLine("Input: {0} \n Output: {1}", string.Join(",", nums), string.Join(",", zeroArr));
      var numbers = new int[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2};
      var res = dsa.ContainsDuplicate(numbers);
      Console.WriteLine("Does the Array Have duplicates? {0}", res);
      var arrayVal = new int[] { 1, 2, 3, 4, 5, 6, 7};
      var k = 3;
      var output = dsa.Rotate(arrayVal, k);
      Console.WriteLine("Input: {0}\n k: {1}\n Output: {2}", string.Join(",", arrayVal), k, string.Join(",", output));
      /*arr.AddItem("Reuben");
      arr.AddItem("Moswela");
      arr.AddItem("Neo");
      arr.AddItem("Khachana");
      arr.AddItem("Meleko");
      Console.WriteLine("Item: {0}, ArrayLength: {1}", arr.GetItem(3), arr.Length);
      arr.RemoveLastItem();
      Console.WriteLine("ArrayLength after deletion: {0}, LastItem: {1}", arr.Length, arr.GetItem(arr.Length - 1));
      arr.RemoveItem(1);
      Console.WriteLine("ArrayLength after deletion of specified index: {0}, LastItem: {1}", arr.Length, arr.GetItem(1));*/
    }
  }
}
