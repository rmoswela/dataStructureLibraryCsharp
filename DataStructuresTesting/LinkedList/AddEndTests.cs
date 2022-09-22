using DataStructures;
using NUnit.Framework;

namespace DataStructuresTesting.LinkedList
{
  [TestFixture]
  public class AddEndTests
  {
    private readonly Person _testPerson = new Person("Reu", Gender.Male, 10);

    [Test]
    [TestCase(2022)]
    public void AddEnd_AddsElementToAnEmptyList_ReturnsTheAddedValue<T>(T value)
    {
      //Arrange
      MyLinkedList<T> myLinkedList = new MyLinkedList<T>();
      //Act
      myLinkedList.AddEnd(value);
      int index = myLinkedList.Count - 1; // index of last value to be added
      //Assert
      Assert.AreEqual(2022, myLinkedList[index]);
    }

    [Test]
    [TestCase(2022)]
    [TestCase("Reu")]
    [TestCase(2.5)]
    [TestCase(nameof(_testPerson))]
    [TestCase(true)]
    public void AddEnd_AddsElementToAlreadyPopulatedList_ReturnsIncreasedNumberOfElementsByOne<T>(T value)
    {
      //Arrange
      MyLinkedList<T> myLinkedList = new MyLinkedList<T>(5);
      //Act
      myLinkedList.AddEnd(value);
      //Assert
      Assert.AreEqual(6, myLinkedList.Count);
    }

    [Test]
    public void AddEnd_AddsNullValueToEmptyList_ReturnsAnIncreasedNumberOfElementsInTheList()
    {
      //Arrange
      MyLinkedList<string> myLinkedList = new MyLinkedList<string>();
      //Act
      myLinkedList.AddEnd(null);
      //Assert
      Assert.AreEqual(1, myLinkedList.Count);
    }

    [Test]
    [TestCase(2023, 2023)]
    public void AddEnd_AddsDuplicateValuesToElements_ReturnsAnIncreasedNumberOfElementsAsDuplicatesAreAllowed<T>(T value1, T value2)
    {
      //Arrange
      MyLinkedList<T> myLinkedList = new MyLinkedList<T>();
      //Act
      myLinkedList.AddEnd(value1);
      myLinkedList.AddEnd(value2);//Bad practice, to be removed after i add insert method
      //Assert
      Assert.AreEqual(2, myLinkedList.Count);
    }
  }
}
