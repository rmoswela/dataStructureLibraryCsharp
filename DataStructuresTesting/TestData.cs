using System;
using System.Collections.Generic;

namespace DataStructuresTesting
{
  internal class TestData
  {
    public object[] ValidValues { get; } =
    {
      new [] {"Reuben", "Moswela"},
      new [] {1, 2},
      new [] {2.5, 9.0},
      new [] {true, false},
      new [] {'a', 'b', 'c'},
      new [] {new Person("Reuben", Gender.Male, 100), new Person("Neo", Gender.Female, 5) }
    };

    public List<dynamic> InitializationValues { get; } = new List<dynamic>() { "r", "e", "u", "b", "e" };
    public IEnumerable<string> EnumerableTestValues = new[] { "Reuben", "Neo", "Lame", "Moswela", null, "Lame", "Meleko" };
    public IEnumerable<int> primeNumbers = new[] { 2, 3, 5, 7, 17, 19, 23 };
    public IEnumerable<char> charList = new[] { 'R', 'e', 'u', 'b', 'e', 'n' };
    public IEnumerable<double> squaredDoubles = new[] { 0.90, 0.81, 0.66, 0.44, 0.19 };
  }
}
