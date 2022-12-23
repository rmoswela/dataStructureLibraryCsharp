using DataStructures;
using NUnit.Framework;
using System;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveAllTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    public void RemoveAll_NumbersLessThanFiveInPrimeNumberList_ReturnsThreeAsNumberOfElementRemoved()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      //Act
      var results = myLinkedList.RemoveAll(value => value <= 5);
      //Assert
      Assert.That(results, Is.EqualTo(3));
    }

    [Test]
    public void RemoveAll_WhenPredicateIsNull_ThrowsArgumentNullException()
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);

      //Act and Assert
      Assert.Throws<ArgumentNullException>(() => myLinkedList.RemoveAll(null));
    }

    [Test]
    public void RemoveAll_EvenNumbersInEmptyList_ReturnsZeroAsNumberOfElementRemoved()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
      //Act
      var results = myLinkedList.RemoveAll(value => (value % 2 == 0));
      //Assert
      Assert.That(results, Is.EqualTo(0));
    }
  }
}
