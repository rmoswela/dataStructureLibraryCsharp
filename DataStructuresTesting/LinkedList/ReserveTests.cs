using DataStructures;
using NUnit.Framework;

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
      var expected = new[] { 23, 19, 17, 7, 5, 3, 2 };
      //Act
      myLinkedList.Reverse();
      //Assert
      Assert.AreEqual(expected[0], myLinkedList[0]);
      Assert.AreEqual(expected[3], myLinkedList[3]);
      Assert.AreEqual(expected[6], myLinkedList[6]);

    }
  }
}
