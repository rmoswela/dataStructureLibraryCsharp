﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DataStructures
{
  public class myArray
  {
    private int _length;
    private dynamic[] _data;

    //initializes an instance of an empty array is empty and of length zero
    public myArray()
    {
      _length = 0;
      _data = new dynamic[] { };
    }
    //initializes a new instance of empty array that has specified capacity
    public myArray(int length)
    {
      _length = length;
      _data = new dynamic[] { };
    }

    //get data at a specified index
    //time complexity to Access = O(1) on average and worst case
    public dynamic GetItem(int index)
    {
      return _data[index];
    }

    //add data at the end of the array
    //time complexity for Insertion = O(n) on average and worst case
    public void AddItem<T>(T t)
    {
      var count = 0;
      var newArray = new dynamic[_length + 1];
      for (var loopIndex = 0; loopIndex < _length; loopIndex++)
      {
        newArray[count++] = _data[loopIndex];
      }

      newArray[count] = t;
      _data = newArray;
      _length++;
    }

    //removes item at the specified index
    //time complexity for this Deletion = 0(n) for both average and worst cases
    public void RemoveItem(int index)
    {
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
      var newArray = new dynamic[_length - 1];
      for (int loopIndex = 0, count = 0; loopIndex < _length - 1; loopIndex++)
      {
        newArray[count++] = _data[loopIndex];
      }

      _data = newArray;
      _length--;
    }


    //finds an index where the item first occurs
    //time complexity for Search = 0(n) average and worst case
    public int FindIndexItemFirstOccurance<T>(T t)
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
    public int FindIndexItemLastOccurance<T>(T t)
    {
      for (int loop = _length - 1; loop >= 0; loop--)
      {
        if (t == _data[loop])
          return loop;
      }

      return -1;
    }

    //Copy elements from source array to this one
    public void Copy(myArray sourceArray, int length )
    {
      var newArr = new dynamic[length];
      for (int index = 0; index < length; index++)
      {
        newArr[index] = sourceArray.GetItem(index);
      }
      _data = newArr;
      _length = length;
    }

    //length property
    public int Length
    {
      get => _length;
    }
  }
}
