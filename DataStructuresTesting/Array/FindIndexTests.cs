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
     * First Occurrence Of Elements
     */

    [Test]
    [TestCase("e")]
    public void FindIndexElementFirstOccurrence_FromArrayWithValidElements_ReturnsIndexWhereElementFirstOccurred<T>(T element)
    {
      //Act
      int indexFirstOccurrenceOfElement = _myArray.FindIndexOfElementFirstOccurrence(element);
      //Assert
      Assert.AreEqual(indexFirstOccurrenceOfElement, 1);
    }

    [Test]
    [TestCase("x")]
    public void FindIndexElementFirstOccurrence_FromArrayWithoutElement_ReturnsNegativeOne<T>(T element)
    {
      //Act
      int returnTypeWhenNoElementFound = _myArray.FindIndexOfElementFirstOccurrence(element);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenNoElementFound);
    }

    [Test]
    [TestCase("r")]
    public void FindIndexElementFirstOccurrence_FromEmptyArray_ReturnsNegativeOne<T>(T element)
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act
      int returnTypeWhenArrayIsEmpty = _myArray.FindIndexOfElementLastOccurrence(element);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenArrayIsEmpty);
    }

    /*
     * Last Occurrence Of Elements
     */
    [Test]
    [TestCase("e")]
    public void FindIndexElementLastOccurrence_FromArrayWithValidElements_ReturnsIndexWhereElementLastOccurred<T>(T element)
    {
      //Act
      int indexLastOccurrenceOfElement = _myArray.FindIndexOfElementLastOccurrence(element);
      //Assert
      Assert.AreEqual(indexLastOccurrenceOfElement, 4);
    }

    [Test]
    [TestCase("z")]
    public void FindIndexElementLastOccurrence_FromArrayWithoutElement_ReturnsNegativeOne<T>(T element)
    {
      //Act
      int returnTypeWhenNoElementFound = _myArray.FindIndexOfElementLastOccurrence(element);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenNoElementFound);
    }

    [Test]
    [TestCase("u")]
    public void FindIndexElementLastOccurrence_FromEmptyArray_ReturnsNegativeOne<T>(T element)
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act
      int returnTypeWhenArrayIsEmpty = _myArray.FindIndexOfElementLastOccurrence(element);
      //Assert
      Assert.AreEqual(-1, returnTypeWhenArrayIsEmpty);
    }
  }
}
