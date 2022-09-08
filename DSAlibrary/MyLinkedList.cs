namespace DataStructures
{
  /*
   *
   *
   *
   */
  public class MyLinkedList<T>
  {
    private int _length;
    private Node<T> _node;

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of length zero
    public MyLinkedList()
    {
      _node = new Node<T>() { value = default, next = default };
      Node<T> head = _node;
      Node<T> tail = head;
      _length = 0;
    }

    //initializes a new instance of list that is empty (head and tail have no values)
    //and of specified length
    public MyLinkedList(int capacity)
    {
      _node = new Node<T>() {value = default, next = default};
      Node<T> head = _node;
      Node<T> tail = head;
      _length = capacity;
    }

    //returns the number of elements in the list
    public int Count
    {
      get => _length;
    }
  }
}
