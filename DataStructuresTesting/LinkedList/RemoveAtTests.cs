using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveAtTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase(0)]
    public void RemoveAt_FirstIndexOfValidList_ReturnsListCountReducedByOne(int value)
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      var listCountBefore = myLinkedList.Count;
      var valueToRemove = myLinkedList[value];
      //Act
      myLinkedList.RemoveAt(value);
      //Assert
      Assert.That(myLinkedList.Count, Is.LessThan(listCountBefore));
      Assert.AreNotEqual(valueToRemove, myLinkedList[value]);
    }
  }
}
