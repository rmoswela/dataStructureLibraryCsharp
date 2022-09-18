using DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class FindIndexTests
  {
    private MyArray _myArray;
    private static readonly TestData TestData = new TestData();
    private readonly List<dynamic> _list = TestData.InitializationValues;

    [SetUp]
    public void Setup()
    {
      _myArray = new MyArray(_list);
    }

    /*
     * First Occurrence Of Items
     */

    [Test]
    [TestCase("e")]
    public void FindIndexItemFirstOccurrence_FromArrayWithValidItems_ReturnsIndexWhereItemFirstOccurred<T>(T item)
    {
      //Act
      int indexFirstOccurrenceOfItem = _myArray.FindIndexItemFirstOccurrence(item);
      //Assert
      Assert.AreEqual(indexFirstOccurrenceOfItem, 1);
    }

    [Test]
    [TestCase("x")]
    public void FindIndexItemFirstOccurrence_FromArrayWithoutItem_ReturnsNegativeOne<T>(T item)
    {
      //Act
      int returnTypeWhenNoItemFound = _myArray.FindIndexItemFirstOccurrence(item);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenNoItemFound);
    }

    [Test]
    [TestCase("r")]
    public void FindIndexItemFirstOccurrence_FromEmptyArray_ReturnsNegativeOne<T>(T item)
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act
      int returnTypeWhenArrayIsEmpty = _myArray.FindIndexItemFirstOccurrence(item);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenArrayIsEmpty);
    }

    /*
     * Last Occurrence Of Items
     */
    [Test]
    [TestCase("e")]
    public void FindIndexItemLastOccurrence_FromArrayWithValidItems_ReturnsIndexWhereItemLastOccurred<T>(T item)
    {
      //Act
      int indexLastOccurrenceOfItem = _myArray.FindIndexItemLastOccurrence(item);
      //Assert
      Assert.AreEqual(indexLastOccurrenceOfItem, 4);
    }

    [Test]
    [TestCase("z")]
    public void FindIndexItemLastOccurrence_FromArrayWithoutItem_ReturnsNegativeOne<T>(T item)
    {
      //Act
      int returnTypeWhenNoItemFound = _myArray.FindIndexItemLastOccurrence(item);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenNoItemFound);
    }

    [Test]
    [TestCase("u")]
    public void FindIndexItemLastOccurrence_FromEmptyArray_ReturnsNegativeOne<T>(T item)
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act
      int returnTypeWhenArrayIsEmpty = _myArray.FindIndexItemLastOccurrence(item);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenArrayIsEmpty);
    }
  }
}
