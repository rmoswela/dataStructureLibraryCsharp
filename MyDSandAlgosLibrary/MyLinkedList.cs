using System;

namespace DataStructures
{
  public class MyLinkedList<T>
  {
    private Node<T> _head;
    private Node<T> _tail;
    private int _length;

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of length zero
    public MyLinkedList()
    {
      //Node<T> node = new Node<T>() { Data = default, Pointer = default };
      _head = null;
      _tail = _head;
      _length = 0;
    }

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of specified length
    public MyLinkedList(int capacity)
    {
      CreateEmptyElements(capacity);
      _length = capacity;
    }

    //returns the number of elements in the list
    public int Count => _length;

    //gets or sets elements at a specified index
    //accepts null as valid value for ref types and allows duplicates
    public T this[int index]
    {
      get => FindByIndex(index);
    }

    //Adds objects or values to end of list
    //nulls allowed for ref types
    public void AddEnd(T value)
    {
      //new element to add at the end of list
      Node<T> newNode = new Node<T>() { Data = value, Pointer = default };
      _tail = newNode;
      _tail.Pointer = null;
      if (_length == 0)
        _head = _tail;
      _length++;
    }

    //Adds object or values at the beginning of the list
    public void Prepend(T value)
    {
      //new element to add at the beginning of list
      Node<T> newNode = new Node<T>(){ Data = value, Pointer = default };
      newNode.Pointer = _head; //let it point to addr of head
      _head = newNode; //then point head to addr of new node
      _length++;
    }

    //searches for an element that matches he condition specified by the predicate
    //returns the first occurance of it
    public T Find(Predicate<T> predicate)
    {
      //temporary node to act as an iterator
      Node<T> tempNode = _head;
      for (int count = 0; count < _length; count++)
      {
        //check if the predicate matches, if not then move to next node
        if (predicate(tempNode.Data))
          return tempNode.Data;
        tempNode = tempNode.Pointer;
      }
      return default;
    }

    //create empty element of capacity provided
    private void CreateEmptyElements(int capacity)
    {
      for (int count = 0; count < capacity; count++)
      {
        Node<T> newNode = new Node<T>();
        if (count == 0)
        {
          _head = newNode;
          _head.Pointer = newNode;
        }
        newNode.Pointer = newNode;
        if (count == capacity - 1)
        {
          _tail = newNode;
          newNode.Pointer = null;
          _tail.Pointer = null;
        }
        _length++;
      }
    }

    //searches for an element that the specified index
    private T FindByIndex(int index)
    {
      //prevent accessing index out of range
      if (index < 0 || index >= _length)
        throw new IndexOutOfRangeException();

      //temporary node to act as an iterator
      Node<T> tempNode = _head;
      for (int count = 0; count < _length; count++)
      {
        //look for the node at the specified index
        if (count == index)
          break;
        tempNode = tempNode.Pointer;
      }
      return tempNode.Data;
    }
  }
}
