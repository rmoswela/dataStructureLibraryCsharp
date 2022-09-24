using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class PrependTests
  {
    private static readonly TestData TestData = new TestData();
    private static object[] _testValues = TestData.ValidValues;

    [Test]
    [TestCase(false)]
    public void Prepend_ElementToAnEmptyList_ReturnsTheAddedValue<T>(T value)
    {
      //Arrange
      MyLinkedList<T> myLinkedList = new MyLinkedList<T>();
      const int head = 0;
      //Act
      myLinkedList.Prepend(value);
      //Assert
      Assert.AreEqual(false, myLinkedList[head]);
    }

    [Test]
    [TestCaseSource(nameof(_testValues))]
    public void Prepend_ElementToAlreadyPopulatedList_ReturnsIncreasedNumberOfElementsByOne<T>(T value)
    {
      //Arrange
      MyLinkedList<T> myLinkedList = new MyLinkedList<T>(5);
      //Act
      myLinkedList.Prepend(value);
      //Assert
      Assert.AreEqual(6, myLinkedList.Count);
    }

    [Test]
    public void Prepend_NullValueToEmptyList_ReturnsIncreasedNumberOfElementsByOne()
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>();
      //Act
      myLinkedList.Prepend(null);
      //Assert
      Assert.AreEqual(1, myLinkedList.Count);
    }
  }
}
