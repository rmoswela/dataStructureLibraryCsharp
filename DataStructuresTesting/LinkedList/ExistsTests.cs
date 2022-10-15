using DataStructures;
using NUnit.Framework;
using System;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class ExistsTests
  {
    private static readonly TestData TestData = new TestData();

    [Test]
    [TestCase(null)]
    public void Exists_ConditionOfANullPredicate_ThrowsArgumentNullException(Predicate<string> predicate)
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>(TestData.EnumerableTestValues);
      //Act and Assert
      Assert.Throws<ArgumentNullException>(() => myLinkedList.Exists(predicate));
    }

    [Test]
    public void Exists_ConditionThatDoesNotMatchAnyElement_ReturnFalse()
    {
      //Arrange
      Predicate<double> predicate = x => x % 3 == 0;
      MyLinkedList<double> myLinkedList = new MyLinkedList<double>(TestData.squaredDoubles);
      //Act
      var result = myLinkedList.Exists(predicate);
      //Assert
      Assert.IsFalse(result);
    }

    [Test]
    [TestCase('e')]
    public void Exists_ConditionThatMatchesOneOrMoreElements_ReturnTrue(char value)
    {
      //Arrange
      Predicate<char> predicate = x => x == value;
      MyLinkedList<char> myLinkedList = new MyLinkedList<char>(TestData.charList);
      //Act
      var result = myLinkedList.Exists(predicate);
      //Assert
      Assert.IsTrue(result);
    }
  }
}
