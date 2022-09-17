using NUnit.Framework;
using DataStructures;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class AddItemTests
  {
    private MyArray _myArray;
    private static readonly TestData TestData = new TestData();

    private static object[] _validValues = TestData.ValidValues;

    private readonly List<dynamic> _list = TestData.InitializationValues;

    [SetUp]
    public void Setup()
    {
      _myArray = new MyArray();
    }

    [Test]
    [TestCaseSource(nameof(_validValues))]
    public void AddItem_ValidValue_NumberOfItemsIncreaseByOne<T>(T value)
    {
      // Act
      _myArray.AddItem(value);
      // Assert
      Assert.AreEqual(_myArray.Length, 1);
    }

    [Test]
    public void AddItem_NullValue_NumberOfItemsIncreaseByOne()
    {
      // Arrange
      string value = null;
      //Act
      _myArray.AddItem(value);
      // Assert
      Assert.AreEqual(_myArray.Length, 1);
    }

    [Test]
    public void AddItem_EmptyItem_NumberOfItemsIncreaseByOne()
    {
      // Arrange
      string value = string.Empty;
      //Act
      _myArray.AddItem(value);
      // Assert
      Assert.AreEqual(_myArray.Length, 1);
    }

    [Test]
    [TestCase("n")]
    public void AddItem_AddToExistingItems_NumberOfItemsIncreaseByOne<T>(T value)
    {
      //Arrange
      _myArray = new MyArray(_list);
      //Act
      _myArray.AddItem(value);
      //Assert
      Assert.AreEqual(_myArray.Length, 6);
    }

    [Test]
    [TestCase('b')]
    public void AddItem_AddItemsToArrayOfFixedLength_ReturnsAddedItems<T>(T value)
    {
      //Arrange
      _myArray = new MyArray(2) {[0] = 'a', [1] = value};
      //Assert
      Assert.AreEqual('b', _myArray[1]);
    }

    [Test]
    [TestCase(65536)]
    public void AddItem_AddItemToArrayOfFixedLength_ThrowsIndexOutOfBondsException<T>(T value)
    {
      Assert.Throws<IndexOutOfRangeException>(() =>
      {
        _myArray = new MyArray(3) {[0] = 4, [1] = 16, [2] = 256, [3] = value};
      }, "Index was outside the bounds of the array.");
    }
  }
}