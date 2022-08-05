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
      arr.AddItem("Reuben");
      arr.AddItem("Moswela");
      arr.AddItem("Neo");
      arr.AddItem("Khachana");
      arr.AddItem("Meleko");
      Console.WriteLine("Item: {0}, ArrayLength: {1}", arr.GetItem(3), arr.Length);
      arr.RemoveLastItem();
      Console.WriteLine("ArrayLength after deletion: {0}, LastItem: {1}", arr.Length, arr.GetItem(arr.Length - 1));
      arr.RemoveItem(1);
      Console.WriteLine("ArrayLength after deletion of specified index: {0}, LastItem: {1}", arr.Length, arr.GetItem(1));
    }
  }
}
