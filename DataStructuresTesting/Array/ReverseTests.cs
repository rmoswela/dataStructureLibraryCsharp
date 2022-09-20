using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.Array
{
  [TestFixture]
  public class ReverseTests
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
    public void Reverse_ArrayWithValidElements_AllElementsShouldBeReversed()
    {
      //Arrange
      MyArray myArrayBeforeReverse = new MyArray();
      myArrayBeforeReverse.Copy(_myArray, _myArray.Length);
      //Act
      _myArray.Reverse();
      //Assert
      Assert.AreNotEqual(_myArray, myArrayBeforeReverse);
    }

    [Test]
    public void Reverse_NullArray_ThrowsNullReferenceException()
    {
      //Arrange
      _myArray = null;
      //Act and Assert
      Assert.Throws<NullReferenceException>(() => _myArray.Reverse());
    }
  }
}
