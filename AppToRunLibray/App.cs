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
      Console.WriteLine("Item: {0}, ArrayLength: {1}", arr.GetItem(3), arr.Length);
    }
  }
}
