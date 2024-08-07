using System;
using System.Collections.Generic;

public class HotelRoom : Accommodation
{
    // The number of beds in the hotel room
    public int Beds { get; protected set; }

    // Constructor for the HotelRoom class
    public HotelRoom(int id, int beds, decimal pricePerNight, List<string> facilities)
        : base(id, "Hotel Room", pricePerNight, facilities)
    {
        Beds = beds;
    }

    // Method to print the information about the hotel room
    public override void Print()
    {
        base.Print(); // Call the base class's Print method
        Console.WriteLine($"Beds: {Beds}");
    }
    public override string DisplayInfo
    {
        get { return base.DisplayInfo + $", Beds: {Beds}"; }
    }
}