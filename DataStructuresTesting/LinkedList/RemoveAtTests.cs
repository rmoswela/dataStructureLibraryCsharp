using DataStructures;
using NUnit.Framework;
using System;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveAtTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase(0)]
    public void RemoveAt_FirstIndexOfValidList_ReturnsListCountReducedByOne(int value)
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      var listCountBefore = myLinkedList.Count;
      var valueToRemove = myLinkedList[value];
      //Act
      myLinkedList.RemoveAt(value);
      //Assert
      Assert.That(myLinkedList.Count, Is.LessThan(listCountBefore));
      Assert.AreNotEqual(valueToRemove, myLinkedList[value]);
    }

    [Test]
    public void RemoveAt_LastIndexOfValidList_ReturnsListCountReducedByOne()
    {
      //Arrange
      MyLinkedList<char> myLinkedList = new MyLinkedList<char>(TestData.charList);
      var listCountBefore = myLinkedList.Count;
      var valueToRemove = myLinkedList[myLinkedList.Count -1];
      //Act
      myLinkedList.RemoveAt(myLinkedList.Count - 1);
      //Assert
      Assert.That(myLinkedList.Count, Is.LessThan(listCountBefore));
      Assert.AreNotEqual(valueToRemove, myLinkedList[myLinkedList.Count -1]);
    }

    [Test]
    [TestCase(4)]
    public void RemoveAt_MiddleIndexOfValidList_ReturnsListCountReducedByOne(int value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);
      var listCountBefore = myLinkedList.Count;
      //Act
      myLinkedList.RemoveAt(value);
      //Assert
      Assert.That(myLinkedList.Count, Is.LessThan(listCountBefore));
    }

    [Test]
    [TestCase(100)]
    public void RemoveAt_IndexOutOfBounds_ThrowsArgumentOutOfRangeException(int value)
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
      //Act and Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => myLinkedList.RemoveAt(value));
    }
  }
}
