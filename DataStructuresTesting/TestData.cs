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

    public IEnumerable<string> EnumerableTestValues = new[] { "Reuben", "Neo", "Lame", "Moswela", "Lame", "Meleko" };
}
}
