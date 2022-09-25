using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class FindTests
  {
    private readonly TestData TestData = new TestData();

    [Test]
    public void Find_validValue_ReturnsTheValue()
    {
      //Arrange
      ICollection<string> names = new[] {"Reuben", "Neo", "Lame", "Moswela"};
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(names);
      //Act
      string results = myLinkedList.Find(x => x.Contains("Lame"));
      //Assert
      Assert.AreEqual("Lame",  results);
    }
  }
}
