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
    public void Find_AnElementThatDoesNotMatchesConditionDefinedByPredicate_ReturnDefaultValue(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      string results = myLinkedList.Find(x => x.Contains(value));
      //Assert
      Assert.AreEqual(value, results);
    }
  }
}
