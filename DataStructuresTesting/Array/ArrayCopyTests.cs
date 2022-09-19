using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class ArrayCopyTests
  {
    private static readonly TestData TestData = new TestData();
    private readonly List<dynamic> _list = TestData.InitializationValues;
    private MyArray _myArray;

    [SetUp]
    public void SetUp()
    {
      _myArray = new MyArray(_list);
    }

    [Test]
    public void ArrayCopy_FromSourceArrayWithValidElements_ReturnsTrueSourceAndDestinationArrayAreEqual()
    {
      //Arrange
      MyArray destinationArray = new MyArray();
      //Act
      destinationArray.Copy(_myArray, _myArray.Length);
      //Assert
      Assert.AreEqual(destinationArray, _myArray);
    }

    [Test]
    public void ArrayCopy_WhereSourceArrayIsNull_ThrowsArgumentNullException()
    {
      //Arrange
      int length = _myArray.Length;
      MyArray destinationArray = new MyArray();
      //Act and Assert
      Assert.Throws<ArgumentNullException>(() =>destinationArray.Copy(_myArray = null, length));
    }

    [Test]
    [TestCase(-1)]
    public void ArrayCopy_WhereLengthIsLessThanZero_ThrowsArgumentOutOfRangeException(int length)
    {
      //Arrange
      MyArray destinationArray = new MyArray();
      //Act and Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => destinationArray.Copy(_myArray, length));
    }

    [Test]
    [TestCase(100)]
    public void ArrayCopy_WhereLengthIsGreaterThanNumberOfElements_ThrowsArgumentOutOfRangeException(int length)
    {
      //Arrange
      List<dynamic> listOChars = new List<dynamic>() {'a', 'b', 'c', 'd', 'e'};
      _myArray = new MyArray(listOChars);
      MyArray destinationArray = new MyArray();
      //Act and Assert
      Assert.Throws<ArgumentException>(() => destinationArray.Copy(_myArray, length));
    }
  }
}
