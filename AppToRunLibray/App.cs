using System;
using System.Collections.Generic;
using DataStructures;

namespace AppToRunLibrary
{
  internal class App
  {
    private static void Main(string[] args)
    {
      // MyArray - Creating Instances
      var arrList = new List<dynamic>() {"r", "e", "u", "b", "e", "n" };
      dynamic arrInitWithVal = new MyArray(arrList); //instantiate with values
      Console.WriteLine("InputWithVal: {0}\n InputArr Length: {1}\n Output: {2}", PrintItemsInArray(arrInitWithVal), arrInitWithVal.Length, PrintItemsInArray(arrInitWithVal));
      dynamic arrInitWithLen = new MyArray(5); //instantiate with length but no values
      IntializeTheArray(arrInitWithLen);
      Console.WriteLine("ArrLength: {0}\n Output: {1}", arrInitWithLen.Length, PrintItemsInArray(arrInitWithLen));
      dynamic arr = new MyArray();//instantiate empty
      Console.WriteLine("Array: {0}, Arr Length: {1}", arr, arr.Length);
      arr = AddItemsToArray(arr);
      dynamic arrCopy = new MyArray();
      arrCopy.Copy(arr, arr.Length);
      Console.WriteLine("Item: {0}, ArrayLength: {1}", arr[3], arr.Length);
      Console.WriteLine("arrCopyItem: {0}, arrCopyLength: {1}", arrCopy[3], arrCopy.Length);
      Console.WriteLine("arrCopyItems: {0}", PrintItemsInArray(arr));
      arrCopy.Reverse();
      Console.WriteLine("arrCopyReversedItems: {0}", PrintItemsInArray(arrCopy));
      arr.RemoveLastElement();
      Console.WriteLine("ArrayLength after deletion: {0}, LastItem: {1}", arr.Length,
        arr[arr.Length - 1]);
      arr.RemoveElement(1);
      Console.WriteLine("ArrayLength after deletion of specified index: {0}, LastItem: {1}", arr.Length,
        arr[1]);
      dynamic firstIndex = arr.FindIndexOfElementFirstOccurrence("Reuben");
      var lastIndex = arr.FindIndexOfElementLastOccurrence("Reuben");
      Console.WriteLine("ArrayLength: {0}, FirstOccuranceIndex: {1}, LastOccurenceIndex: {2}", arr.Length,
        firstIndex, lastIndex);

      var dsa = new CourseMasterDSAChallenges();
      Console.WriteLine("Array: {0}, Arr Length: {1}", arr, arr.Length);
      var str = dsa.Reverse("Reuben is fuckin good!");
      Console.WriteLine("Original str: Reuben \n Reversed str: {0}", str);
      int[] arr1 = new int[] {0, 2, 4, 31}, arr2 = new int[] {4, 6, 30};
      var results = dsa.MergeSortedArrays(arr1, arr2);
      Console.WriteLine("Results of the merge: {0}", string.Join(",", results));
      var intArr = new int[] {2, 7, 11, 15};
      var twosum = dsa.TwoSum(intArr, 9);
      Console.WriteLine("Values that make target: {0}", string.Join(",", twosum));
      var arrayInt = new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4};
      var subarray = dsa.MaxSubArray(arrayInt);
      Console.WriteLine("Largest sum value: {0}", subarray);
      var nums = new int[] {0, 1};
      var zeroArr = dsa.MoveZeroesOptimal(nums);
      Console.WriteLine("Input: {0} \n Output: {1}", string.Join(",", nums), string.Join(",", zeroArr));
      var numbers = new int[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2};
      var res = dsa.ContainsDuplicate(numbers);
      Console.WriteLine("Does the Array Have duplicates? {0}", res);
      var arrayVal = new int[] {1, 2, 3, 4, 5, 6, 7};
      var k = 3;
      var output = dsa.Rotate(arrayVal, k);
      Console.WriteLine("Input: {0}\n k: {1}\n Output: {2}", string.Join(",", arrayVal), k,
        string.Join(",", output));
      var stringsArr = new string[] { "cir", "car" };
      var longestPrefix = dsa.LongestCommonPrefix(stringsArr);
      Console.WriteLine("Input: {0}\n output: {1}", string.Join(" , ", stringsArr), longestPrefix);
      var array = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
      var sum = dsa.ThreeNumberSum(array, 0);
      Console.WriteLine("Input: {0} target = {1}\n output: {2}", string.Join(" , ", array), 0, PrintItemsFrom2dArray(sum));
      var arrayOne = new int[] { -1, 5, 10, 20, 28, 3 };
      var arrayTwo = new int[] { 26, 134, 135, 15, 17 };
      var diff = dsa.SmallestDifference(arrayOne, arrayTwo);
      Console.WriteLine("Input: arrayOne {0} arrayTwo {1}\n output: {2}", string.Join(" , ", arrayOne), string.Join(" , ", arrayTwo), string.Join(" , ", diff));



      //Linked Lists
      MyLinkedList<string> list = new MyLinkedList<string>();
      var list1 = new MyLinkedList<int>(3);
      list.AddEnd("Reuben1");
      list.AddEnd("Reuben2");
      Console.WriteLine("Element Count: {0}\n ElementData: {1}", list.Count, list.Find(x=>x.Contains("Reuben2")));
      list.Prepend("Reuben0");
      Console.WriteLine("Element Count: {0}\n ElementData: {1}", list.Count, list.Find(x => x.Contains("Reuben0")));
      list.Prepend("Reuben5");
      Console.WriteLine("MyLinkedList Items: {0}", PrintMyList(list));
    }

    private static string PrintItemsFrom2dArray(List<int[]> array)
    {
      string toPrint = "[";
      for (var index = 0; index < array.Count; index++)
      {
        toPrint = toPrint + "[ " + string.Join(" ", array[index]);
        toPrint += " ]";
        if (index == array.Count - 1)
          toPrint += "]";
      }
      return toPrint;
    }

    private static dynamic PrintItemsInArray(MyArray array)
    {
      string print = "[";
      int index = 0;
      while ( index < array.Length)
      {
        print += string.Join(",", array[index]) + " ";
        index++;
      }
      if (index == array.Length){
          print = print.TrimEnd() + "]";
      }
      return print;
    }

    private static void IntializeTheArray(MyArray arrayWithLen)
    {
      int[] primeNums = new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29};
      Random random = new Random();
      for (int index = 0; index < arrayWithLen.Length; index++)
      {
        arrayWithLen[index] = random.Next(0, primeNums.Length);
      }
    }

    private static MyArray AddItemsToArray(MyArray inputArray)
    {
      var names = new string[] {"Reuben", "Moswela", "Neo", "Khachana", "Meleko", "Reuben", "Gabrielle"};
      for (int loop = 0; loop < names.Length; loop++)
      {
        inputArray.AddElement(names[loop]);
      }

      return inputArray;
    }

    private static string PrintMyList<T>(MyLinkedList<T> list)
    {
      string print = "[";
      for (int index = 0; index < list.Count; index++)
      {
        print += " " + list[index];
        if (index == list.Count - 1)
          print += " ]";
      }
      return print;
    }
  }
}
