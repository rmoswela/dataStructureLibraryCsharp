﻿using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class InsertTests
  {
    private static readonly TestData TestData = new TestData();
    private static readonly IEnumerable<string> TestValues = TestData.EnumerableTestValues;

    [Test]
    [TestCase(4, 11)]
    public void Insert_ValidIntValue_ReturnsTheAddedValue(int index, int value)
    {
      //Arrange
      IEnumerable<int> primeNumbers = new[] { 2, 3, 5, 7, 17, 19, 23 };
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(primeNumbers);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual(11, myLinkedList.Find(x => x == value));
    }

    [Test]
    [TestCase(3, "Neoh")]
    public void Insert_ValidStringValue_ReturnsTheAddedValue(int index, string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act
      myLinkedList.Insert(index, value);
      //Assert
      Assert.AreEqual("Neoh", myLinkedList.Find(x => x == value));
    }

    [Test]
    [TestCase(-1, "failure")]
    [TestCase(100, "Another failure")]
    public void Insert_AddsValuesAtOutOfRangeIndexes_ThrowsArgumentOutOfRangeException(int index, string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act and Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => myLinkedList.Insert(index, value));
    }
  }
}