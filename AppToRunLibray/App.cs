using System;
using DataStructures;

namespace AppToRunLibrary
{
  internal class App
  {
    private static void Main(string[] args)
    {
      var arr = new myArray();
      Console.WriteLine("Array: {0}, Arr Length: {1}", arr, arr.Length);
      arr = AddItemsToArray(arr);
      Console.WriteLine("Item: {0}, ArrayLength: {1}", arr.GetItem(3), arr.Length);
      arr.RemoveLastItem();
      Console.WriteLine("ArrayLength after deletion: {0}, LastItem: {1}", arr.Length, arr.GetItem(arr.Length - 1));
      arr.RemoveItem(1);
      Console.WriteLine("ArrayLength after deletion of specified index: {0}, LastItem: {1}", arr.Length, arr.GetItem(1));
    }

    private static myArray AddItemsToArray(myArray inputArray)
    {
      var names = new string[] {"Reuben", "Moswela", "Neo", "Khachana", "Meleko", "Gabrielle" };
      for (int loop = 0; loop < names.Length; loop++) {
         inputArray.AddItem(names[loop]);
      }
      return inputArray;
    }
  }
}
