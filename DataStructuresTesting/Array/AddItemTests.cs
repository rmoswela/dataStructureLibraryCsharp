using NUnit.Framework;
using DataStructures;

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
  }
}