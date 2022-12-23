using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class RemoveTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase("Moswela")]
    public void Remove_ValidString_ReturnsTrue(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);
      //Act
      var results = myLinkedList.Remove(value);
      //Assert
      Assert.IsTrue(results);
    }
  }
}
