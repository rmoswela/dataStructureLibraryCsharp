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
  }
}
