using System;
using System.Collections.Generic;

public class House : Accommodation
{
    // Properties
    public int Rooms { get; protected set; } // Number of rooms in the house
    public bool Garden { get; protected set; } // Indicates if the house has a garden
    public int Bathrooms { get; protected set; } // Number of bathrooms in the house

    // Constructor
    public House(int id, int rooms, bool garden, int bathrooms, decimal pricePerNight, List<string> facilities)
        : base(id, "House", pricePerNight, facilities)
    {
        Rooms = rooms;
        Garden = garden;
        Bathrooms = bathrooms;
    }

    // Method to print the details of the house
    public override void Print()
    {
        base.Print(); // Print the base accommodation details
        Console.WriteLine($"Rooms: {Rooms}"); // Print the number of rooms
        Console.WriteLine($"Garden: {Garden}"); // Print if the house has a garden
        Console.WriteLine($"Bathrooms: {Bathrooms}"); // Print the number of bathrooms
    }

    public override string DisplayInfo
    {
        get { return base.DisplayInfo + $", Floors: {Rooms}, Garden: {Garden}, Bathrooms: {Bathrooms}"; }
    }
}