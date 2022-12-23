using DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class ReserveTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    public void Reverse_ValidListOfInt_ReturnsReversedList()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      var actual = new[] { 23, 19, 17, 7, 5, 3, 2 };
      //Act
      myLinkedList.Reverse();
      //Assert
      //Assert.That(myLinkedList, Is.EquivalentTo(actual));
      Assert.AreEqual(actual[0], myLinkedList[0]);
      Assert.AreEqual(actual[3], myLinkedList[3]);
      Assert.AreEqual(actual[6], myLinkedList[6]);

    }

    [Test]
    public void Reverse_AnEmptyList_ReturnsEmptyList()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
      var listCountBefore = myLinkedList.Count;
      //Act
      myLinkedList.Reverse();
      //Assert
      Assert.That(listCountBefore, Is.EqualTo(myLinkedList.Count));
    }
  }
}
