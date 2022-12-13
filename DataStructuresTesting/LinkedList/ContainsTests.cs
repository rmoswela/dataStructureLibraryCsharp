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

    [Test]
    [TestCase("Lame")]
    public void Contains_ValidStringValue_ReturnTrue(string value)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);
      //Act
      var result = myLinkedList.Contains(value);
      //Assert
      Assert.IsTrue(result);
    }

    [Test]
    [TestCase(17)]
    public void Contains_ValidIntValue_ReturnTrue(int value)
    {
      //Arrange
      MyLinkedList<int> myLinkedList = new MyLinkedList<int>(TestData.primeNumbers);
      //Act
      var result = myLinkedList.Contains(value);
      //Assert
      Assert.IsTrue(result);
    }

    [Test]
    [TestCase(17)]
    public void Contains_DoubleValueThatIsNotOnList_ReturnFalse(int value)
    {
      //Arrange
      MyLinkedList<double> myLinkedList = new MyLinkedList<double>(TestData.squaredDoubles);
      //Act
      var result = myLinkedList.Contains(value);
      //Assert
      Assert.IsFalse(result);
    }
  }
}
