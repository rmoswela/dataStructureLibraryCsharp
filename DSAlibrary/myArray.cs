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
      this._length = 0;
      this._data = new dynamic[]{};
    }

    //get data at a specified index
    //Access = O(1) on average and worst case
    public dynamic GetItem(int index)
    {
      return _data[index];
    }

    //add data at the end of the array
    //Insertion = O(n) on average and worst case
    public void AddItem<T>(T t)
    {
      var count = 0;
      var newArray = new dynamic[_length + 1];
      for (var loopIndex = 0; loopIndex < this._data.Length; loopIndex++) {
        newArray[count++] = this._data[loopIndex];
      }
      newArray[count] = t;
      this._data = newArray;
      this._length = _length + 1;
    }

    //length property
    public int Length
    {
      get => _length;
      set => _length = value;
    }
  }
}
