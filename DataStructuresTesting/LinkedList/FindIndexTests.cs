using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class FindIndexTests
  {
    private static readonly TestData TestData = new TestData();
    private static readonly IEnumerable<string> TestValues = TestData.EnumerableTestValues;

    [Test]
    [TestCase(null)]
    public void FindIndex_OfNullPredicate_ThrowsArgumentNullException(Predicate<string> predicate)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act and Assert
      Assert.Throws<ArgumentNullException>(() => myLinkedList.FindIndex(predicate));
    }

    [Test]
    [TestCase("Neo")]
    public void FindIndex_OfValidPredicate_ReturnIndexOfElementThatMatchesPredicate(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      var index = myLinkedList.FindIndex(x => x == value);
      //Assert
      Assert.IsTrue(myLinkedList[index] == value);
    }

    [Test]
    [TestCase("Lame")]
    public void FindIndex_OfValidRecurringElement_ReturnIndexOfTheFirstOccurenceOfElement(string value)
    {
      //Arrange
      var secondIndex = 5;
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);

      //Act
      var firstIndex = myLinkedList.FindIndex(x => x == value);
      //Assert
      Assert.IsTrue(myLinkedList[firstIndex] == myLinkedList[secondIndex] && firstIndex != secondIndex);
    }

    [Test]
    [TestCase("nothing")]
    public void FindIndex_OfElementNotFoundOnList_ReturnsNegativeValueToMeanNotFound(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);

      //Act
      var index = myLinkedList.FindIndex(x => x == value);
      //Assert
      Assert.Negative(index);
    }
  }
}
