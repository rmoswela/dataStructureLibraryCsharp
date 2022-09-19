using System;
using System.Collections.Generic;

namespace DataStructures
{
  public class MyArray
  {
    private int _length;
    private dynamic[] _data;

    //initializes an instance of an empty array is empty and of length zero
    public MyArray()
    {
      _length = 0;
      _data = new dynamic[_length];
    }
    //initializes a new instance of empty array that has specified capacity
    public MyArray(int length)
    {
      _length = length;
      _data = new dynamic[_length];
    }

    //initializes a new instance of an array with initial values
    public MyArray(List<dynamic> data)
    {
      _length = data.Count;
      _data = data.ToArray();
    }

    //get and set data at a specified index
    //time complexity to Access = O(1) on average and worst case
    public dynamic this[int index]
    {
      get => _data[index];
      set => _data[index] = value;
    }

    //add data at the end of the array
    //time complexity for Insertion = O(n) on average and worst case
    public void AddItem<T>(T t)
    {
      var count = 0;
      var newArray = new dynamic[_length + 1];
      //iterates to end of array then increments by 1 to allow for new item
      for (var loopIndex = 0; loopIndex < _length; loopIndex++)
      {
        newArray[count++] = _data[loopIndex];
      }
      //assigns items to data and increments length
      newArray[count] = t;
      _data = newArray;
      _length++;
    }

    //removes item at the specified index
    //time complexity for this Deletion = 0(n) for both average and worst cases
    public void RemoveItem(int index)
    {
      if (_length < 1)
        throw new IndexOutOfRangeException();
      var newArray = new dynamic[_length - 1];
      for (int loopIndex = 0, count = 0; loopIndex < _length; loopIndex++)
      {
        if (loopIndex != index)
        {
          newArray[count++] = _data[loopIndex];
        }
      }
      _data = newArray;
      _length--;
    }

    //removes last item in the array
    //time complexity for Deletion of last item = 0(n) average and worst case
    public void RemoveLastItem()
    {
      if (_length < 1)
        throw new IndexOutOfRangeException();
      var newArray = new dynamic[_length - 1];
      for (int loopIndex = 0, count = 0; loopIndex < _length - 1; loopIndex++)
      {
        newArray[count++] = _data[loopIndex];
      }
      //assigns new items to data and decrements length
      _data = newArray;
      _length--;
    }


    //finds an index where the item first occurs
    //time complexity for Search = 0(n) average and worst case
    public int FindIndexItemFirstOccurrence<T>(T t)
    {
      for (var loop = 0; loop < _length; loop++)
      {
        if (t == _data[loop])
          return loop;
      }
      return -1;
    }

    //finds and returns index of items' last occurance
    //time complexity for Search = 0(n) average and worst case
    public int FindIndexItemLastOccurrence<T>(T t)
    {
      for (int loop = _length - 1; loop >= 0; loop--)
      {
        if (t == _data[loop])
          return loop;
      }
      return -1;
    }

    //Copy elements from source array
    //time complexity and space complexity is 0(n)
    public void Copy(MyArray sourceArray, int length)
    {
      if (sourceArray == null)
        throw new ArgumentNullException();
      if (length < 0)
        throw new ArgumentOutOfRangeException();

      var newArr = new dynamic[length];
      if (length > sourceArray.Length || length > newArr.Length)
        throw new ArgumentException();
      //iterates through and copies all items
      for (int index = 0; index < length; index++)
      {
        newArr[index] = sourceArray[index];
      }
      //assigns items to data and its appropriate length
      _data = newArr;
      _length = length;
    }

    //method that reverses the order of all items in the array
    //time complexity and space complexity is 0(n)
    public void Reverse()
    {
      var newArr = new dynamic[_length];
      //iterate through all items in reverse
      for (int index = _length - 1, count = 0; index >= 0; index--)
      {
        newArr[count++] = _data[index];
      }
      //assign items to array after reverse
      _data = newArr;
    }

    //length property
    public int Length => _length;

    /*
     * Override the Equals method in order to better compare instances of this class
     */
    public override bool Equals(object obj)
    {
      MyArray arrayObject = (MyArray)obj;

      if (arrayObject == null || _length != arrayObject.Length)
      {
        return false;
      }

      for (int index = 0; index < _length; index++)
      {
        if (arrayObject[index] != _data[index])
          return false;
      }
      return true;
    }

    /*
     * This is to generate the same hashcode for instantiations of this class
     * So that when you use instances of this class as keys in data structures that don't allow duplicate keys like dictionaries, hashset etc
     * to group them into buckets
     * https://learn.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.8#remarks
     * https://stackoverflow.com/q/371328/4782963
     */
    public override int GetHashCode()
    {
      return Length.GetHashCode();
    }
  }
}
