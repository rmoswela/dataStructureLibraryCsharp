using DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase("Moswela")]
    public void Remove_FirstOccuranceOfValueInAList_ReturnsTrue(string value)
    {
      //Arrange
      var listOfStrings = new List<string>() { "Moswela", "Neo", "Moswela", "Reuben" };
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(listOfStrings);
      var listCountBefore = myLinkedList.Count;
      //Act
      var results = myLinkedList.Remove(value);
      //Assert
      Assert.IsTrue(results);
      Assert.That(myLinkedList[1], Is.EqualTo(value));
      Assert.That(myLinkedList.Count, Is.LessThan(listCountBefore));
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
    [TestCase('A')]
    public void Remove_ValueThatsDoesNotAppearInList_ReturnsFalse(char value)
    {
      //Arrange 
      MyLinkedList<char> myLinkedList = new MyLinkedList<char>(TestData.charList);
      //Act
      var results = myLinkedList.Remove(value);
      //Assert
      Assert.IsFalse(results);
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
