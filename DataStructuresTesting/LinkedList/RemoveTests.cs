using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase("Moswela")]
    public void Remove_ValidStringInTheMiddleOfList_ReturnsTrue(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);
      //Act
      var results = myLinkedList.Remove(value);
      //Assert
      Assert.IsTrue(results);
    }

    [Test]
    [TestCase(2)]
    public void Remove_FirstNodeInTheList_ReturnsTrue(int value)
    {
      //Arrange 
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      //Act
      var results = myLinkedList.Remove(value);
      //Assert
      Assert.IsTrue(results);
    }

    [Test]
    public void Remove_LastNodeInTheList_ReturnsTrue()
    {
      //Arrange 
      MyLinkedList<double> myLinkedList = new MyLinkedList<double>(TestData.squaredDoubles);
      var lastNodeInList = myLinkedList[myLinkedList.Count - 1];
      //Act
      var results = myLinkedList.Remove(lastNodeInList);
      //Assert
      Assert.IsTrue(results);
    }

    [Test]
    [TestCase("Moswela")]
    public void Remove_ValueFromEmptyList_ReturnsFalse(string value)
    {
      //Arrange 
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>();
      //Act
      var results = myLinkedList.Remove(value);
      //Assert
      Assert.IsFalse(results);
    }
  }
}
