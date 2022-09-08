namespace DataStructures
{
  /*
   *
   *
   *
   */
  public class MyLinkedList<T>
  {
    private Node<T> _head;
    private Node<T> _tail;
    private int _length;
    private Node<T> _node;

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of length zero
    public MyLinkedList()
    {
      _node = new Node<T>() { data = default, pointer = default };
      _head = _node;
      _tail = _head;
      _length = 0;
    }

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of specified length
    public MyLinkedList(int capacity)
    {
      _node = new Node<T>() { data = default, pointer = default };
      _head = _node;
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

    //Adds object to end of list
    public void AddEnd(T value)
    {
      //new element to add at the end of list
      Node<T> newNode = new Node<T>() { data = value, pointer = default };
      _tail.pointer = newNode;
      _tail = newNode;
      _length++;
    }

    //returns the number of elements in the list
    public int Count
    {
      get => _length;
    }
  }
}
