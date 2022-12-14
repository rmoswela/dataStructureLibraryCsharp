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
    //Time and Space complexity is constant = O(1)
    public T this[int index]
    {
      get 
      {
        if (index < 0 || index >= _length)
          throw new ArgumentOutOfRangeException("index");

        return FindByIndex(index); 
      }
      set 
      {
        if (index < 0 || index >= _length)
          throw new ArgumentOutOfRangeException("index");

        Insert(index, value);
        return;
      }
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
      while (tempNode != null)
      {
        //check if the predicate matches, if not then move to next node
        if (predicate(tempNode.Data))
          return tempNode.Data;
        tempNode = tempNode.Pointer;
      }
      return default;
    }

    //Searches for element that matches conditions defined by specified predicate
    //returns index of the first occurrence within the entire list or -1 if not found
    //Time complexity is linear = O(n) where n is Count
    //Space complexity is constant = O(1)
    public int FindIndex(Predicate<T> predicate)
    {
      if (predicate is null)
        throw new ArgumentNullException();

      int index = 0;
      Node<T> tempNode = _head;

      //iterate the entire list
      while(tempNode != null)
      {
        //where predicate condition is met return index
        if (predicate(tempNode.Data))
        {
          return index;
        }
        index++;
        tempNode = tempNode.Pointer;
      }

      return -1;
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
      while (tempNode != null)
      {
        if (predicate(tempNode.Data))
          return true;
        tempNode = tempNode.Pointer;
      }
      return false;
    }

    //Determines whether an element is in the List
    //The value can be null for ref types
    //This method determines equality by using the default equality comparer
    //Linear search operation, Time Complexity is 0(n) where n is Count
    public bool Contains(T value)
    {
      Node<T> tempNode = _head;
      while (tempNode != null)
      {
        if (value == null && tempNode.Data == null)
          return true;
        if (tempNode.Data.Equals(value))
          return true;
        tempNode = tempNode.Pointer;
      }
      return false;
    }

    //Reverses the order of the elements in the entire list
    //Time complexity is Linear operation O(n), where n is Count
    //Space complexity is constant O(1)
    public void Reverse()
    {
      _tail = _head;
      Node<T> currentNode = _head;
      Node<T> previousNode = null;
      Node<T> nextNode = null;
      //iterate while keeping track of curr, prev and next node
      while (currentNode != null)
      {
        //connect current node with previous before
        //updating previous node to current and current to next
        nextNode = currentNode.Pointer;
        currentNode.Pointer = previousNode;
        previousNode = currentNode;
        currentNode = nextNode;
      }
      _head = previousNode;
    }

    //Removes the first occurrence of a specific object from the list
    //Linear search operation, Time Complexity is 0(n) where n is Count
    public bool Remove(T value) 
    {
      //checks for value in the first node
      //since we don't have previous node
      if (_head != null && _head.Data.Equals(value))
      {
        _head = _head.Pointer;
        _length--;
        return true;
      }

      Node<T> currentNode = _head;
      Node<T> previousNode = null;
      //iterates through list keeping track of prev and curr
      while (currentNode != null)
      {
        if (currentNode.Data.Equals(value))
        {
          //where value is found in curr
          //point prev node to node after curr or null
          //decrement length of list
          previousNode.Pointer = currentNode.Pointer;
          currentNode = previousNode;
          _length--;
          return true;
        }
        previousNode = currentNode;
        currentNode = currentNode.Pointer;
      }
      return false;
    }

    //Removes element at the specified index of list
    //Time complexity is O(n) operation where n is (count - index)
    public void RemoveAt(int index)
    {
      if (index < 0 || index >= _length)
        throw new ArgumentOutOfRangeException("index");

      if (index == 0)
      {
        _head = _head.Pointer;
        _length--;
        return;
      }

      Node<T> currentNode = _head;
      Node<T> previousNode = null;

      for (int count = 0; count < _length; count++)
      {
        if (index == count)
        {
          previousNode.Pointer = currentNode.Pointer;
          currentNode = previousNode;
          _length--;
          return;
        }
        previousNode = currentNode;
        currentNode = currentNode.Pointer;
      }
      return;
    }

    //Removes all elements that matches conditions defined by specified predicate
    //returns the number of elements removed from list
    //Time Complexity is linear O(n) where is n is Count
    public int RemoveAll(Predicate<T> predicate)
    {
      if (predicate is null)
        throw new ArgumentNullException("match");

      Node<T> currentNode = _head;
      Node<T> previousNode = null;
      int count = 0;

      //iterate the list keeping track of curr an prev
      while(currentNode != null)
      {
        //check if condition matches and remove element
        if (predicate(currentNode.Data))
        {
          if (_head == currentNode)
          {
            _head = _head.Pointer;
          }
          else
          {
            previousNode.Pointer = currentNode.Pointer;
            currentNode = previousNode;
          }
          count++; //keep count of removed elements
        }
        //update linking of remaining elements after removal
        previousNode = currentNode;
        currentNode = currentNode.Pointer;
      }
      //update the length of remaining elements
      _length -= count;

      return count;
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
