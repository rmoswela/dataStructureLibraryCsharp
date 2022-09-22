namespace DataStructures
{
  /*
   * Class that represent an element of a linked list
   */
  internal class Node<T>
  {
    public Node()
    {
      Data = default;
      Pointer = default;
    }

    public Node(T data)
    {
      Data = data;
      Pointer = default;
    }
    //value of the node
    public T Data { get; set; }

    //pointer or reference to the next node
    public Node<T> Pointer { get; set; }
  }
}
