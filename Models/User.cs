namespace FileManagerSample.Models;

internal class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public User(string name, string surname, int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }
}
