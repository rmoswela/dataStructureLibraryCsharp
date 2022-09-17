using NUnit.Framework;
using DataStructures;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class AddItemTests
  {
    private MyArray _myArray;

    private static object[] _validValues =
    {
      new [] {"Reuben", "Moswela"},
      new [] {1, 2},
      new [] {2.5, 9.0},
      new [] {true, false},
      new [] {'a', 'b', 'c'},
      new [] {new Person("Reuben", Gender.Male, 100), new Person("Neo", Gender.Female, 5) }
    };

    private readonly List<dynamic> _list = new List<dynamic>() {"r", "e", "u", "b", "e"};

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
  }
}