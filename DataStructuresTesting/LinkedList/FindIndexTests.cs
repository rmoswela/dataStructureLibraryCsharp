using DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class FindIndexTests
  {
    private static readonly TestData TestData = new TestData();
    private static readonly IEnumerable<string> TestValues = TestData.EnumerableTestValues;

    [Test]
    [TestCase(null)]
    public void FindIndex_OfNullPredicate_ThrowsArgumentNullException(Predicate<string> predicate)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestValues);
      //Act and Assert
      Assert.Throws<ArgumentNullException>(() => myLinkedList.FindIndex(predicate));
    }
  }
}
