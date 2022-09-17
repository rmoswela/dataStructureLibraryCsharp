using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class RemoveItemTests
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
    public void RemoveItem_UsingAValidIndex_ItemsReducedByOne(int index)
    {
      //Arrange
      int beforeLength = _myArray.Length;
      //Act
      _myArray.RemoveItem(index);
      //Assert
      Assert.AreNotEqual(beforeLength, _myArray.Length);
    }

    [Test]
    [TestCase(-1)]
    public void RemoveItem_UsingIndexThatIsOutBounds_ThrowsIndexOutOfBoundsException(int index)
    {
      //Act and Assert
      Assert.Throws<IndexOutOfRangeException>(() => _myArray.RemoveItem(index));
    }

    [Test]
    [TestCase(3)]
    public void RemoveItem_FromAnEmptyArray_ThrowsIndexOutOfBoundsException(int index)
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act and Assert
      Assert.Throws<IndexOutOfRangeException>(() => _myArray.RemoveItem(index));
    }

    [Test]
    public void RemoveLastItem_FromAnArrayWithValidItems_ItemsReducedByOne()
    {
      //Arrange
      int beforeLength = _myArray.Length;
      //Act
      _myArray.RemoveLastItem();
      //Assert
      Assert.AreNotEqual(beforeLength, _myArray.Length);
    }

    [Test]
    public void RemoveLastItem_FromAnEmptyArray_ThrowsIndexOutOfBoundsException()
    {
      //Arrange
      _myArray = new MyArray(0);
      //Act and Assert
      Assert.Throws<IndexOutOfRangeException>(() => _myArray.RemoveLastItem());
    }
  }
}
