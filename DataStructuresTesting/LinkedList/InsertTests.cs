using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class InsertTests
  {
    private static readonly TestData TestData = new TestData();
    private static readonly IEnumerable<string> TestValues = TestData.EnumerableTestValues;

    [Test]
    [TestCase(4, 11)]
    public void Insert_ValidIntValue_ReturnsIndexWhereTheElementIsAdded(int index, int value)
    {
      //Arrange
      IEnumerable<int> primeNumbers = new[] { 2, 3, 5, 7, 17, 19, 23 };
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(primeNumbers);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual(index, myLinkedList.FindIndex(x => x == value));
    }

    [Test]
    [TestCase(3, "Neoh")]
    public void Insert_ValidStringValue_ReturnsIndexWhereTheElementIsAdded(int index, string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual(index, myLinkedList.FindIndex(x => x == value));
    }

    [Test]
    [TestCase(-1, "failure")]
    [TestCase(100, "Another failure")]
    public void Insert_AddsValuesAtOutOfRangeIndexes_ThrowsArgumentOutOfRangeException(int index, string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act and Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => myLinkedList.Insert(index, value));
    }

    [Test]
    [TestCase(2, null)]
    public void Insert_NullValue_ReturnsIndexWhereTheElementIsAdded(int index, string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual(index, myLinkedList.FindIndex(x => x == value));
    }

    [Test]
    [TestCase(0, 'R')]
    public void Insert_ValidValueAtTheBeginningOfList_ReturnsTheFirstIndexOfList(int index, char value)
    {
      //Arrange
      IEnumerable<char> charList = new[] { 'e', 'u', 'b', 'e', 'n' };
      MyLinkedList<char> myLinkedList = new MyLinkedList<char>(charList);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual(index, myLinkedList.FindIndex(x => x == value));
    }

    [Test]
    [TestCase(5, 0.04)]
    public void Insert_ValidValueAtTheEndOfList_ReturnsTheLastIndexOfList(int index, double value)
    {
      //Arrange
      IEnumerable<double> squaredDoubles = new[] { 0.90, 0.81, 0.66, 0.44, 0.19 };
      MyLinkedList<double> myLinkedList = new MyLinkedList<double>(squaredDoubles);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual(myLinkedList.Count -1, myLinkedList.FindIndex(x => x == value));
    }
  }
}
