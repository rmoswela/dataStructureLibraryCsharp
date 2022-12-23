using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveAllTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    public void RemoveAll_NumbersLessThanFiveInPrimeNumberList_ReturnsThreeAsNumberOfElementRemoved()
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);

      //Act
      var results = myLinkedList.RemoveAll(value => value <= 5);

      //Assert
      Assert.That(results, Is.EqualTo(3));
    }
  }
}
