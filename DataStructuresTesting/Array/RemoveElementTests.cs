using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class RemoveElementTests
  {
    private MyArray _myArray;
    private static readonly TestData TestData = new TestData();
    private readonly List<dynamic> _list = TestData.InitializationValues;

    [SetUp]
    public void Setup()
    {
      _myArray = new MyArray(_list);
    }

    [Test]
    [TestCase(1)]
    public void RemoveElement_UsingAValidIndex_ElementsReducedByOne(int index)
    {
      //Arrange
      int beforeLength = _myArray.Length;
      //Act
      _myArray.RemoveElement(index);
      //Assert
      Assert.AreNotEqual(beforeLength, _myArray.Length);
    }

    [Test]
    [TestCase(-1)]
    public void RemoveElement_UsingIndexThatIsOutBounds_ThrowsIndexOutOfBoundsException(int index)
    {
      //Act and Assert
      Assert.Throws<IndexOutOfRangeException>(() => _myArray.RemoveElement(index));
    }

    [Test]
    [TestCase(3)]
    public void RemoveElement_FromAnEmptyArray_ThrowsIndexOutOfBoundsException(int index)
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act and Assert
      Assert.Throws<IndexOutOfRangeException>(() => _myArray.RemoveElement(index));
    }

    [Test]
    public void RemoveLastElement_FromAnArrayWithValidElements_ElementsReducedByOne()
    {
      //Arrange
      int beforeLength = _myArray.Length;
      //Act
      _myArray.RemoveLastElement();
      //Assert
      Assert.AreNotEqual(beforeLength, _myArray.Length);
    }

    [Test]
    public void RemoveLastElement_FromAnEmptyArray_ThrowsIndexOutOfBoundsException()
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act and Assert
      Assert.Throws<IndexOutOfRangeException>(() => _myArray.RemoveLastElement());
    }
  }
}
