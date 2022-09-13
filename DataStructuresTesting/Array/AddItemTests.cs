using NUnit.Framework;
using System;
using DataStructures;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class AddItemTests
  {
    private MyArray _myArray;

    [SetUp]
    public void Setup()
    {
      _myArray = new MyArray();
    }

    [Test]
    [TestCase(typeof(object))]
    [TestCase("Reuben")]//string
    [TestCase(1)] //int
    [TestCase(2.3)] //double
    [TestCase('a')] //char
    [TestCase(false)] //boolean
    public void AddItem_ValidValue_NumberOfItemsIncreaseByOne<T>(T value)
    {
      // Arrange
      Setup();
      // Act
      _myArray.AddItem(value);
      var length = _myArray.Length;
      // Assert
      Assert.AreEqual(_myArray.Length, 1);
    }
    [Test]
    public void AddItem_NullValue_NumberOfItemsIncreaseByOne()
    {
      // Arrange
      Setup();
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
      Setup();
      string value = string.Empty;
      //Act
      _myArray.AddItem(value);
      // Assert
      Assert.AreEqual(_myArray.Length, 1);
    }

    [Test]
    public void AddItem_MultipleValues_ReturnEqualNumberOfItemsAdded()
    {
      // Arrange
      Setup();
      string value1 = "Reuben", value2 = null, value3 = "Moswela", value4 = "Lame", value5 = ".";
      //Act
      _myArray.AddItem(value1);
      _myArray.AddItem(value2);
      _myArray.AddItem(value3);
      _myArray.AddItem(value4);
      _myArray.AddItem(value5);
      // Assert
      Assert.AreEqual(_myArray.Length, 5);
    }

    //[Test]
    public void AddItem_AddItemOfDifferentDataType_NumberOfItemsIncreaseByOne()
    {
      // Arrange
      Setup();
      string value = "Reuben";
      int wrongDataTypeValue = 1;
      //Act
      _myArray.AddItem(value);
      //_myArray.AddItem(wrongDataTypeValue);
      // Assert
      Assert.Throws<ArrayTypeMismatchException>(()=>_myArray.AddItem(wrongDataTypeValue));
    }
  }
}