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
      Node<T> node = new Node<T>() { data = default, pointer = default };
      _head = node;
      _tail = _head;
      _length = 0;
    }

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of specified length
    public MyLinkedList(int capacity)
    {
      Node<T> node = new Node<T>() { data = default, pointer = default };
      _head = node;
      _tail = _head;
      _length = capacity;
    }

    //Adds object or value at the beginning of the list
    public void Prepend(T value)
    {
      //new element to add at the beginning of list
      Node<T> newNode = new Node<T>(){ data = value, pointer = default };
      newNode.pointer = _head; //let it point to addr of head
      _head = newNode; //then point head to addr of new node
      _length++;
    }

    //Adds object or value to end of list
    public void AddEnd(T value)
    {
      //new element to add at the end of list
      Node<T> newNode = new Node<T>() { data = value, pointer = default };
      _tail.pointer = newNode;
      _tail = newNode;
      if (_length == 0)
        _head = _tail;
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
        if (predicate(tempNode.data))
          return tempNode.data;
        tempNode = tempNode.pointer;
      }
      return default;
    }

    //gets or sets elements at a specified index
    public T this[int index]
    {
      get => FindByIndex(index);
    }

    //returns the number of elements in the list
    public int Count => _length;

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
        tempNode = tempNode.pointer;
      }
      return tempNode.data;
    }
  }
}
