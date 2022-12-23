using DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class ReserveTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    public void Reverse_ValidListOfInt_ReturnsReversedList()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      var actual = new[] { 2, 3, 5, 7, 17, 19, 23 };
      //Act
      myLinkedList.Reverse();
      //Assert
      //Assert.That(myLinkedList, Is.EquivalentTo(actual));
      Assert.AreNotEqual(actual[0], myLinkedList[0]);
      Assert.AreNotEqual(actual[1], myLinkedList[1]);
      Assert.AreNotEqual(actual[6], myLinkedList[6]);

    }

    [Test]
    public void Reverse_AnEmptyList_ReturnsEmptyList()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
      var listCountBefore = myLinkedList.Count;
      //Act
      myLinkedList.Reverse();
      //Assert
      Assert.That(listCountBefore, Is.EqualTo(myLinkedList.Count));
    }

    [Test]
    public void Reverse_ValidListOfStrings_ReturnsReversedList()
    {
      //Arrange
      var listOfStrings = new[] { "Reuben", "Neo", "Moswela" };
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(listOfStrings);
      //Act
      myLinkedList.Reverse();
      //Assert
      //Assert.That(myLinkedList, Is.EquivalentTo(listOfStrings));
      Assert.That(listOfStrings[0], Is.EqualTo(myLinkedList[2]));
      Assert.That(listOfStrings[1], Is.EqualTo(myLinkedList[1]));
      Assert.That(listOfStrings[2], Is.EqualTo(myLinkedList[0]));

    }
  }
}
