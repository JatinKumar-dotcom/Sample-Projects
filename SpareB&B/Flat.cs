using System;
using System.Collections.Generic;

public class Flat : Accommodation
{
    public int Rooms { get; protected set; } // Number of rooms in the flat
    public int Bathrooms { get; protected set; } // Number of bathrooms in the flat
    public bool Kitchen { get; protected set; } // Whether the flat has a kitchen or not
    public bool Balcony { get; protected set; } // Whether the flat has a balcony or not

    public Flat(int id, int rooms, int bathrooms, bool kitchen, bool balcony, decimal pricePerNight, List<string> facilities)
        : base(id, "Flat", pricePerNight, facilities)
    {
        Rooms = rooms;
        Bathrooms = bathrooms;
        Kitchen = kitchen;
        Balcony = balcony;
    }

    public override void Print()
    {
        base.Print(); // Call the Print method of the base class (Accommodation) to print basic information

        // Print additional information specific to the Flat class
        Console.WriteLine($"Rooms: {Rooms}"); // Print the number of rooms
        Console.WriteLine($"Bathrooms: {Bathrooms}"); // Print the number of bathrooms
        Console.WriteLine($"Kitchen: {Kitchen}"); // Print whether the flat has a kitchen or not
        Console.WriteLine($"Balcony: {Balcony}"); // Print whether the flat has a balcony or not
    }

    public override string DisplayInfo
    {
        get { return base.DisplayInfo + $", Rooms: {Rooms}, Bedrooms: {Bathrooms}, Balcony: {Balcony}"; }
    }
}