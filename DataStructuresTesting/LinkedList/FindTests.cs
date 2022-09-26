using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class FindTests
  {
    private static readonly TestData TestData = new TestData();
    private static readonly IEnumerable<string> TestValues = TestData.EnumerableTestValues;

    [Test]
    [TestCase("Lame")]
    public void Find_ValidElementThatMatchesConditionDefinedByPredicate_ReturnsFirstOccurrenceOfTheElement(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      string results = myLinkedList.Find(x => x.Contains(value));
      //Assert
      Assert.AreEqual(value,  results);
    }

    [Test]
    [TestCase("SeeSharp")]
    public void Find_AnElementThatDoesNotMatchesConditionDefinedByPredicate_ReturnDefaultValueForString(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      string results = myLinkedList.Find(x => x.Contains(value));
      //Assert
      Assert.AreEqual(null, results);
    }

    [Test]
    [TestCase(15)]
    public void Find_AnElementThatDoesNotMatchesConditionDefinedByPredicate_ReturnDefaultValueForInt(int value)
    {
      //Arrange
      IEnumerable<int> primeNumbers = new[] {2, 3, 5, 7, 11, 17, 19, 23};
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(primeNumbers);
      //Act
      int results = myLinkedList.Find(x => x.Equals(value));
      //Assert
      Assert.AreEqual(0, results);
    }

    [Test]
    [TestCase(null)]
    public void Find_ElementThatMatchesNullConditionDefinedByPredicate_ThrowsArgumentNullException(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act and Assert
      Assert.Throws<ArgumentNullException>(() => myLinkedList.Find(x => x.Contains(value)));
    }
  }
}
