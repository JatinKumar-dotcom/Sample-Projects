using System;

public class User
{
    public string Name { get; } // The name of the user

    public User(string name)
    {
        Name = name;
    }

    public string GetUserName()
    {
        return Name; // Returns the name of the user
    }
}