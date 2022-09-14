namespace DataStructuresTesting
{
  /*
   * An object helper class for when performing tests
   */

  internal enum Gender
  {
    Male,
    Female
  }
  internal class Person
  {
    private string _name;
    private int _age;
    private Gender _gender;

    public Person(string name, Gender gender, int age)
    {
      _name = name;
      _gender = gender;
      _age = age;
    }
  }
}
