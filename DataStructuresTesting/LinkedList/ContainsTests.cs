using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class ContainsTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase(null)]
    public void Contains_NullValueInList_ReturnTrue(string value) 
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);
      //Act
      var result = myLinkedList.Contains(value);
      //Assert
      Assert.IsTrue(result);
    }
  }
}
