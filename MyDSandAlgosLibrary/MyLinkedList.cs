using System;
using System.Collections.Generic;

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

    //initializes a new instance of list class with elements copied from the specified enumerable
    //This constructor is an (0)n operation for both time and space complexity
    public MyLinkedList(IEnumerable<T> enumerable)
    {
      InitializesListWithElements(enumerable);
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
    //time complexity is 0(1) and space complexity is 0(1)
    public void AddEnd(T value)
    {
      //new element to add at the end of list
      Node<T> newNode = new Node<T>() { Data = value, Pointer = default };
      //when tail is null, the assumption is the list is new
      //hence head and tail pointing to same reference
      if (_tail is null)
      {
        _tail = newNode;
        _head = _tail;
      }
      else
      {
        _tail.Pointer = newNode;
        _tail = newNode;
      }
      _length++;
    }

    //Adds object or values at the beginning of the list
    //time complexity is 0(1) and space complexity is 0(1)
    public void Prepend(T value)
    {
      //new element to add at the beginning of list
      Node<T> newNode = new Node<T>(){ Data = value, Pointer = default };
      newNode.Pointer = _head; //let it point to address of head
      _head = newNode; //then move head pointer to address of new node
      _length++;
    }

    //searches for an element that matches he condition specified by the predicate
    //returns the first occurrence of it
    //time complexity for search is linear that is 0(n) and space complexity is constant 0(1)
    //Predicate<T> is a delegate to a method that returns true if object passed matches conditions defined in the delegate
    //elements of the current List<T> are individually passed to the Predicate<T> delegate
    //Processing is stopped when a match is found
    public T Find(Predicate<T> predicate)
    {
      if (predicate is null)
        throw new ArgumentNullException();
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

    //Inserts an element into the list at the specified index
    //if index is equal 0 is added at the beginning
    //if index equals length of list, element is added at the end
    //Time complexity is 0(n) where n is equal to count
    public void Insert(int index, T value)
    {
      if (index < 0 || index > _length)
        throw new ArgumentOutOfRangeException();

      if (index == 0)
      {
        Prepend(value);
        return;
      }

      if (index == _length)
      {
        AddEnd(value);
        return;
      }

      int count = 1;
      Node<T> newNode = new Node<T> { Data = value, Pointer = default };
      Node<T> tempNode = _head;
      //iterate to the index you are looking to insert at
      while (count < index)
      {
        tempNode = tempNode.Pointer;
        count++;
      }
      //connect new node to where temp is pointing 
      //before pointing temp to new node
      newNode.Pointer = tempNode.Pointer;
      tempNode.Pointer = newNode;
      _length++;
    }

    //Determines whether the List contains elements that match the conditions
    //defined by the specified predicate
    //This is a linear search therefore Time Complexity is 0(n)
    //Space Complexity is 0(1) - Constant Operation
    public bool Exists(Predicate<T> predicate) 
    {
      if (predicate is null)
        throw new ArgumentNullException();

      Node<T> tempNode = _head;
      for (int count = 0; count < _length; count++)
      {
        if (predicate(tempNode.Data))
          return true;
        tempNode = tempNode.Pointer;
      }
      return false;
    }

    //create empty element of capacity provided
    private void CreateEmptyElements(int capacity)
    {
      Node<T> tempNode = null;
      for (int count = 0; count < capacity; count++)
      {
        Node<T> newNode = new Node<T>();
        //when temp node is null we know its the start of the new list
        //therefore point head to that reference
        if (tempNode is null)
        {
          _head = newNode;
          tempNode = newNode;
        }
        else
        {
          tempNode.Pointer = newNode;
          tempNode = newNode;
        }
      }
      //point tail to reference of last node added
      _tail = tempNode;
      _length = capacity;
    }

    //creates element from the provided enumerable data structure
    private void InitializesListWithElements(IEnumerable<T> enumerable)
    {
      if (enumerable is null)
        throw new ArgumentNullException();

      using IEnumerator<T> iterator = enumerable.GetEnumerator();
      int count = 0;
      Node<T> tempNode = null;
      while (iterator.MoveNext())
      {
        Node<T> node = new Node<T>(iterator.Current);
        //when temp node is null we know its the start of the new list
        //therefore point head to that reference
        if (tempNode is null)
        {
          _head = node;
          tempNode = node;
        }
        else
        {
          tempNode.Pointer = node;
          tempNode = node;
        }
        count++;
      }
      //point tail to reference of last node added
      _tail = tempNode;
      _length = count;
    }

    //searches for an element that the specified index - get property
    //time complexity is 0(n) and space complexity is 0(1)
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
