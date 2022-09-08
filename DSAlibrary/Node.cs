﻿namespace DataStructures
{
  /*
   * Class that represent an element of a linked list
   */
  internal class Node<T>
  {
    //value of the node
    public T value { get; set; }
    //pointer or reference to the next node
    public T next { get; set; }
  }
}
