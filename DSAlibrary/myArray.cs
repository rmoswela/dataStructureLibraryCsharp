using System;

namespace DataStructures
{
  public class myArray
  {
    private int _length;
    private dynamic[] _data;

    //array is empty and of length zero at instantiation
    public myArray()
    {
      _length = 0;
      _data = new dynamic[]{};
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
      for (var loopIndex = 0; loopIndex < _data.Length; loopIndex++) {
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
      for (int loopIndex = 0, count = 0; loopIndex < _length; loopIndex++) {
        if (loopIndex != index) {
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
      var newArray = new dynamic [_length - 1];
      for (int loopIndex = 0, count = 0; loopIndex < _length - 1; loopIndex++) {
        newArray[count++] = _data[loopIndex];
      }
      _data = newArray;
      _length--;
    }

    //length property
    public int Length
    {
      get => _length;
    }
  }
}
